using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomWindow
{
    public partial class LinkList : UserControl {

        public delegate void EnableUndo();
        public delegate void EnableRedo();
        public delegate void DisableUndo();
        public delegate void DisableRedo();

        public EnableUndo OnEnableUndo;
        public EnableRedo OnEnableRedo;
        public DisableUndo OnDisableUndo;
        public DisableRedo OnDisableRedo;

        List<Tuple<string, int, LinkItem>> _undoHistory;  //position, item
        List<Tuple<string, int, LinkItem>> _redoHistory;  //position, item

        List<LinkItem> _items;

        public LinkItem LastSelectedLinkItem;

        public LinkList()
        {
            InitializeComponent();

            MakePanelLinkSettings();
            scrollbarList.RegisterPanel(panelList);
            _items = new List<LinkItem>();
            _undoHistory = new List<Tuple<string, int, LinkItem>>();
            _redoHistory = new List<Tuple<string, int, LinkItem>>();

            UpdateScrollBar();
        }

        public void ResizeItems()
        {
            foreach (LinkItem linkItem in _items)
            {
                linkItem.Width = this.Width - SystemInformation.VerticalScrollBarWidth;
                linkItem.Controls[0].Width = this.Width - SystemInformation.VerticalScrollBarWidth;
                linkItem.Controls[1].Width = this.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }

        public void MakePanelLinkSettings()
        {
            panelList.MouseWheel += scrollbarList.AdvancedScrollbar_MouseWheel;
            panelList.AutoScroll = false;
            panelList.HorizontalScroll.Maximum = 0;
            panelList.VerticalScroll.Visible = true;
            panelList.VerticalScroll.Enabled = true;
            
            panelList.AutoScroll = true;
        }

        public void SetLinkItemInfo(LinkItem linkItem, System.Drawing.Point location)
        {
            linkItem.Location = location;
            linkItem.Width = this.Width - SystemInformation.VerticalScrollBarWidth;
            linkItem.MouseWheel += scrollbarList.AdvancedScrollbar_MouseWheel;
            linkItem.Controls[0].MouseWheel += scrollbarList.AdvancedScrollbar_MouseWheel;
            linkItem.Controls[1].MouseWheel += scrollbarList.AdvancedScrollbar_MouseWheel;
            linkItem.OnLinkItemResizedVertically += RepositionItems;
            linkItem.OnLinkItemSelected += SetLastSelectedLinkItem;
            linkItem.OnTabPressed += FocusNextItem;
            linkItem.OnDeleteKeyDown += Remove;
        }

        private void FocusNextItem(LinkItem linkItem, bool upNotDown)
        {
            if (upNotDown == false)
            {
                int index = _items.IndexOf(linkItem);
                if (index < _items.Count - 1)
                {
                    _items[index + 1].Controls[1].Focus();
                }
                else
                {
                    _items[0].Controls[1].Focus();
                }
            }
            else
            {
                int index = _items.IndexOf(linkItem);
                if (index > 0)
                {
                    _items[index - 1].Controls[0].Focus();
                }
                else
                {
                    _items[_items.Count - 1].Controls[0].Focus();
                }
            }

            scrollbarList.ThumbPosition = panelList.VerticalScroll.Value;
        }

        private void SetLastSelectedLinkItem(LinkItem linkItem)
        {
            LastSelectedLinkItem = linkItem;
        }

        internal void Populate(List<LinkData> list)
        {
            LinkItem linkItem;
            for(int i = list.Count-1; i >= 0; i--)
            {
                linkItem = new LinkItem();
                linkItem.Controls[0].Text = list[i].Description;
                linkItem.Controls[1].Text = list[i].Address;
                Add(linkItem);
            }
        }

        public void Add(LinkItem linkItem)
        {
            scrollbarList.ThumbPosition = 0;

            if (_items.Count == 0)
            {
                SetLinkItemInfo(linkItem, new System.Drawing.Point(0, 0));
            }
            else
            {
                SetLinkItemInfo(linkItem, new System.Drawing.Point(0, _items[0].Location.Y));
            }

            foreach (LinkItem item in _items)
            {
                item.Location = new System.Drawing.Point(item.Location.X, item.Location.Y + linkItem.Height);
            }

            _items.Insert(0, linkItem);
            if (_undo == false)
            {
                _undoHistory.Insert(0, new Tuple<string, int, LinkItem>("insert", 0, linkItem));
                if (_redo == false)
                {
                    if (_redoHistory.Count != 0)
                    {
                        _redoHistory.Clear();
                        OnDisableRedo?.Invoke();
                    }
                }
            }

            panelList.Controls.Add(_items[0]);

            if (_items.Count == 0)
            {
                OnDisableUndo?.Invoke();
            }
            else
            {
                OnEnableUndo?.Invoke();
            }

            UpdateScrollBar();
        }

        private void SwapWithNextFromIndex(int index)
        {
            LinkItem item = _items[index];
            panelList.Controls.Remove(item);
            _items.RemoveAt(index);

            _items[index].Location = new System.Drawing.Point(_items[index].Location.X, item.Location.Y);
            item.Location = new System.Drawing.Point(item.Location.X, item.Location.Y + _items[index].Height);

            _items.Insert(index + 1, item);
            panelList.Controls.Add(item);
        }

        public void MoveDown(LinkItem linkItem)
        {
            if (linkItem != null)
            {
                int index = _items.IndexOf(linkItem);
                if (index < _items.Count - 1)
                {
                    SwapWithNextFromIndex(index);
                    if (_undo == false)
                    {
                        _undoHistory.Add(new Tuple<string, int, LinkItem>("moveDown", index, linkItem));
                        if (_redo == false)
                        {
                            if (_redoHistory.Count != 0)
                            {
                                _redoHistory.Clear();
                                OnDisableRedo?.Invoke();
                            }
                        }
                    }
                }
                linkItem.Controls[0].Focus();
            }
        }

        public void MoveUp(LinkItem linkItem)
        {
            if (linkItem != null)
            {
                int index = _items.IndexOf(linkItem);
                if (index > 0)
                {
                    SwapWithNextFromIndex(index - 1);
                    if (_undo == false)
                    {
                        _undoHistory.Add(new Tuple<string, int, LinkItem>("moveUp", index, linkItem));
                        if (_redo == false)
                        {
                            if (_redoHistory.Count != 0)
                            {
                                _redoHistory.Clear();
                                OnDisableRedo?.Invoke();
                            }
                        }
                    }
                }
                linkItem.Controls[0].Focus();
            }
        }

        public void UpdateScrollBar()
        {
            int maximum = 0;
            foreach (LinkItem linkItem in _items)
            {
                maximum += linkItem.Height;
            }

            scrollbarList.Minimum = 0;
            if (maximum > panelList.Height)
            {
                scrollbarList.Maximum = maximum - panelList.Height;
            }

            scrollbarList.Refresh();

           // Console.WriteLine(panelList.VerticalScroll.Maximum);
        }

        public void Insert(int index, LinkItem linkItem)
        {
            scrollbarList.ThumbPosition = 0;
            if (_items.Count == 0)
            {
                SetLinkItemInfo(linkItem, new System.Drawing.Point(0, 0));
            }
            else
            {
                if (_items.Count == index)
                {
                    SetLinkItemInfo(linkItem, new System.Drawing.Point(0, _items[index-1].Location.Y + _items[index - 1].Height));
                }
                else
                {
                    SetLinkItemInfo(linkItem, new System.Drawing.Point(0, _items[index].Location.Y));
                }
            }

            for (int i = index; i < _items.Count; i++)
            {
                _items[i].Location = new System.Drawing.Point(_items[i].Location.X, _items[i].Location.Y + linkItem.Height);
            }

            panelList.Controls.Add(linkItem);
            if (_items.Count == 0)
            {
                _items.Add(linkItem);
            }
            else
            {
                if(_items.Count == index)
                {
                    _items.Add(linkItem);
                }
                else
                {
                    _items.Insert(index, linkItem);
                }
            }

            if (_undo == false)
            {
                _undoHistory.Add(new Tuple<string, int, LinkItem>("insert", index, linkItem));
                if (_redo == false)
                {
                    if (_redoHistory.Count != 0)
                    {
                        _redoHistory.Clear();
                        OnDisableRedo?.Invoke();
                    }
                }
            }

            if (_items.Count == 0)
            {
                OnDisableUndo?.Invoke();
            }
            else
            {
                OnEnableUndo?.Invoke();
            }

            UpdateScrollBar();
        }

        private void RepositionItems(LinkItem linkItem, int difference)
        {
            int index = _items.IndexOf(linkItem);
            for (int i = index + 1; i < _items.Count; i++)
            {
                _items[i].Location = new System.Drawing.Point(_items[i].Location.X, _items[i].Location.Y + difference);
            }

            UpdateScrollBar();
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                for (int i = index + 1; i < _items.Count; i++)
                {
                    _items[i].Location = new System.Drawing.Point(0, _items[i].Location.Y - _items[index].Height);
                }

                if (_undo == false)
                {
                    _undoHistory.Add(new Tuple<string, int, LinkItem>("remove", index, _items[index]));
                    if(_redo == false)
                    {
                        if (_redoHistory.Count != 0)
                        {
                            _redoHistory.Clear();
                            OnDisableRedo?.Invoke();
                        }
                    }
                }
               
                panelList.Controls.Remove(_items[index]);
                _items.RemoveAt(index);
               
                UpdateScrollBar();
            }
        }

        public void Remove(LinkItem linkItem)
        {
            LastSelectedLinkItem = null;

            if (linkItem != null)
            {
                int index = -1;
                for (int i = 0; i < _items.Count; i++)
                {
                    if (_items[i] == linkItem)
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    RemoveAt(index);
                }
            }
        }

        public List<LinkData> GetLinkData()
        {
            List<LinkData> linkData = new List<LinkData>();
            foreach (LinkItem item in _items)
            {
                linkData.Add(new LinkData(item.Controls[0].Text, item.Controls[1].Text));
            }

            return linkData;
        }

        bool _undo = false;
        public void Undo()
        {
            _undo = true;
            int peek = _undoHistory.Count - 1;
            switch(_undoHistory[peek].Item1)
            {
                case "moveDown":
                    MoveUp(_undoHistory[peek].Item3);
                    break;

                case "moveUp":
                    MoveDown(_undoHistory[peek].Item3);
                    break;

                case "remove":
                    Insert(_undoHistory[peek].Item2, _undoHistory[peek].Item3);
                    break;

                case "insert":
                    RemoveAt(_undoHistory[peek].Item2);
                    break;
            }
       
            _redoHistory.Add(_undoHistory[peek]);

            _undoHistory.RemoveAt(peek);

            if (_undoHistory.Count == 0)
            {
                OnDisableUndo?.Invoke();
            }

            OnEnableRedo?.Invoke();

            _undo = false;
        }

        bool _redo;
        public void Redo()
        { 
            _redo = true;
            int peek = _redoHistory.Count - 1;
            switch (_redoHistory[peek].Item1)
            {
                case "moveDown":
                    MoveDown(_redoHistory[peek].Item3);
                    break;

                case "moveUp":
                    MoveUp(_redoHistory[peek].Item3);
                    break;

                case "remove":
                    RemoveAt(_redoHistory[peek].Item2);
                    break;

                case "insert":
                    Insert(_redoHistory[peek].Item2, _redoHistory[peek].Item3);
                    break;
            }

            _redoHistory.RemoveAt(peek);

            if(_redoHistory.Count == 0)
            {
                OnDisableRedo?.Invoke();
            }
            _redo = false;
        }
    }
}
