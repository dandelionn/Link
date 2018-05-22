using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LinkScrollbar
{
    public partial class LinkScrollbar : UserControl
    {
        protected Image _imgUpArrow;
        protected Color _colorChannel;
        protected Color _colorChannelBorder;
        protected Color _colorThumb;
        protected Image _imgThumbTop;
        protected Image _imgThumbTopSpan;
        protected Image _imgThumbMiddle;
        protected Image _imgThumbBottomSpan;
        protected Image _imgThumbBottom;
        protected Image _imgDownArrow;

        private int _trackPosition;
        private int _thumbPosition;
        private int _pageSize;
        private int _minimum;
        private int _maximum;

        private bool _thumbDown;
        private bool _thumbDragging;
        private double _clickPoint;
        private double _distance;
        private int _clickDownDistance;
        private int _clickUpDistance;


        private double _channelHeight;
        private double _unit;
        private double _thumbHeight;
        private double _thumbTopPos;
        private bool _arrowClicked;

        List<IntPtr> _handle;
        Panel _panel;

        public LinkScrollbar()
        {
            _handle = new List<IntPtr>();

            InitializeComponent();


            MouseDown += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseDown);
            MouseMove += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseMove);
            MouseUp += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseUp);
            MouseWheel += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseWheel);
            MouseClick += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseClick);

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);


            UpArrow = ImageResource.uparrowblue;
            DownArrow = ImageResource.downarrowblue;


            //_clickUpDistance = (int)(point.Y - _thumbTopPos - UpArrow.Height);
            //_clickDownDistance = (int)(_thumbTopPos + _thumbHeight + UpArrow.Height - point.Y);
        }

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        public enum ScrollBarCommands
        {
            SB_LINEUP = 0,
            SB_LINELEFT = 0,
            SB_LINEDOWN = 1,
            SB_LINERIGHT = 1,
            SB_PAGEUP = 2,
            SB_PAGELEFT = 2,
            SB_PAGEDOWN = 3,
            SB_PAGERIGHT = 3,
            SB_THUMBPOSITION = 4,
            SB_THUMBTRACK = 5,
            SB_TOP = 6,
            SB_LEFT = 6,
            SB_BOTTOM = 7,
            SB_RIGHT = 7,
            SB_ENDSCROLL = 8
        }
        public enum Message : uint
        {
            WM_VSCROLL = 0x0115,
            WM_HSCROLL = 0x114
        }

        public void RegisterPanel(Panel panel)
        {
            _panel = panel;
        }

        private void UpdateRegisteredHandlesScroll()
        {
            if (_panel != null)
            {
                _panel.VerticalScroll.Value = ThumbPosition;
            }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                           DefaultValue(false), Category("Behaviour"),
                           Description("Minimum")]
        public int Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                            DefaultValue(false), Category("Behaviour"),
                            Description("Maximum")]
        public int Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                            DefaultValue(false), Category("Behaviour"),
                            Description("Thumb Position")]
        public int ThumbPosition
        {
            get { return _thumbPosition; }
            set { _thumbPosition = value; Invalidate(); }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                           DefaultValue(false), Category("Skin"),
                           Description("Channel Color")]
        public Color ChannelColor
        {
            get { return _colorChannel; }
            set { _colorChannel = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                           DefaultValue(false), Category("Skin"),
                           Description("Thumb Color")]
        public Color ThumbColor
        {
            get { return _colorThumb; }
            set { _colorThumb = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Channel Color")]
        public Color ChannelBorderColor
        {
            get { return _colorChannelBorder; }
            set { _colorChannelBorder = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                        DefaultValue(false), Category("Skin"),
                        Description("Up Arrow Image")]
        public Image UpArrow
        {
            get { return _imgUpArrow; }
            set { _imgUpArrow = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Down Arrow Image")]
        public Image DownArrow
        {
            get { return _imgDownArrow; }
            set { _imgDownArrow = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Thumb Top Image")]
        public Image ThumbTop
        {
            get { return _imgThumbTop; }
            set { _imgThumbTop = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                         DefaultValue(false), Category("Skin"),
                         Description("Thumb Top Span Image")]
        public Image ThumbTopSpan
        {
            get { return _imgThumbTopSpan; }
            set { _imgThumbTopSpan = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                  DefaultValue(false), Category("Skin"),
                  Description("Thumb Arrow Image")]
        public Image ThumbMiddle
        {
            get { return _imgThumbMiddle; }
            set { _imgThumbMiddle = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Thumb Bottom Span Image")]
        public Image ThumbBottomSpan
        {
            get { return _imgThumbBottomSpan; }
            set { _imgThumbBottomSpan = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                        DefaultValue(false), Category("Skin"),
                        Description("Thumb Bottom Image")]

        public Image ThumbBottom
        {
            get { return _imgThumbBottom; }
            set { _imgThumbBottom = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            ComputeDimensions();
            DrawUpDownArrows(e);
            DrawChannelBorders(e);
            DrawThumbControl(e);

            base.OnPaint(e);
        }
        private void DrawChannelBorders(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(ChannelBorderColor), 0, UpArrow.Height, 1, this.Height - DownArrow.Height - UpArrow.Height);
            e.Graphics.FillRectangle(new SolidBrush(ChannelBorderColor), this.Width - 1, UpArrow.Height, 1, this.Height - DownArrow.Height - UpArrow.Height);
            e.Graphics.FillRectangle(new SolidBrush(ChannelColor), 1, UpArrow.Height, this.Width - 2, this.Height - DownArrow.Height - UpArrow.Height);

        }
        private void DrawUpDownArrows(PaintEventArgs e)
        {
            if (UpArrow != null)
            {
                e.Graphics.DrawImage(UpArrow, 0, 0, this.Width, UpArrow.Height);
            }
            if (DownArrow != null)
            {
                e.Graphics.DrawImage(DownArrow, 0, this.Height - DownArrow.Height, this.Width, DownArrow.Height);
            }
        }
        private void AdvancedScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = this.PointToClient(Cursor.Position);
            ComputeDimensions();

            bool value = ThumbRectClicked(point);
            if (!value)
            {
                _arrowClicked = true;
                value = UpArrowRectClicked(point);

                if (!value)
                {
                    DownArrowRectClicked(point);
                }
            }
        }
        private bool ThumbRectClicked(Point point)
        {
            Rectangle thumbrect = new Rectangle(1, UpArrow.Height + (int)_thumbTopPos, this.Width - 2, (int)_thumbHeight);

            if (thumbrect.Contains(point))
            {
                _clickPoint = point.Y;
                _thumbDown = true;
                return true;
            }
            return false;
        }
        private bool UpArrowRectClicked(Point point)
        {
            Rectangle uparrowrect = new Rectangle(0, 0, this.Width, UpArrow.Height);
            if (uparrowrect.Contains(point))
            {
                if (ThumbPosition > Minimum)
                {
                    if (ThumbPosition - Minimum > 40)
                        ThumbPosition -= 40;
                    else
                        ThumbPosition = Minimum;

                    Invalidate();
                    UpdateRegisteredHandlesScroll();
                }

                return true;
            }

            return false;
        }
        private bool DownArrowRectClicked(Point point)
        {
            Rectangle downarrowrect = new Rectangle(0, UpArrow.Height + (int)_channelHeight, this.Width, DownArrow.Height);
            if (downarrowrect.Contains(point))
            {

                if (ThumbPosition < Maximum)
                {
                    if (Maximum - ThumbPosition > 40)
                        ThumbPosition += 40;
                    else
                        ThumbPosition = Maximum;

                    Invalidate();
                    UpdateRegisteredHandlesScroll();
                }
                return true;
            }
            return false;
        }
        private void AdvancedScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            _thumbDown = false;
            _thumbDragging = false;
            _arrowClicked = false;
        }

        private void FigureOutPosition()
        {
            ComputeUnit();

            double value = _distance / _unit;

            int steps = (int)value;
            if (Math.Abs(value - (int)value) > 0.5)
            {
                if (value > 0)
                {
                    steps += 1;
                }
                else
                {
                    steps -= 1;
                }
            }

            ThumbPosition += steps;
            if (ThumbPosition > Maximum)
            {
                steps -= Math.Abs(Math.Abs(ThumbPosition) - Math.Abs(Maximum));
                ThumbPosition = Maximum;
            }

            if (ThumbPosition < Minimum)
            {
                steps += Math.Abs(Math.Abs(ThumbPosition) - Math.Abs(Minimum));
                ThumbPosition = Minimum;
            }

            _clickPoint += (steps * _unit);
            _distance -= (steps * _unit);
        }

        private void AdvancedScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_thumbDown == true)
            {
                _thumbDragging = true;
            }

            if (_thumbDragging)
            {
                Point ptPoint = this.PointToClient(Cursor.Position);
                MoveThumb(ptPoint.Y);
            }
        }

        private void MoveThumb(int y)
        {
            ComputeDimensions();
            _distance = y - _clickPoint;

            if ((int)(_thumbTopPos + _distance) >= 0)
            {
                if (!((int)(_thumbTopPos + _distance + _thumbHeight) <= _channelHeight))
                {
                    _distance = _channelHeight - _thumbHeight - _thumbTopPos;
                }
            }
            else
            {
                _distance = -_thumbTopPos;
            }

            FigureOutPosition();
            Invalidate();
            UpdateRegisteredHandlesScroll();
        }
        private void DrawThumbControl(PaintEventArgs e)
        {
            if (_thumbDown == false)
            {
                e.Graphics.FillRectangle(new SolidBrush(_colorThumb), 1, UpArrow.Height + (int)_thumbTopPos, this.Width - 2, (int)_thumbHeight);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(_colorThumb), 1, UpArrow.Height + (int)(_thumbTopPos + _distance), this.Width - 2, (int)_thumbHeight);
            }
        }
        private void ComputeUnit()
        {
            _unit = _channelHeight / (Maximum + 100); // 20 units for thumb
        }
        private void ComputeDimensions()
        {
            _channelHeight = this.Height - UpArrow.Height - DownArrow.Height;
            _thumbHeight = 100 * _channelHeight / (Maximum + 100);

            if (Maximum == 0)
            {
                _thumbTopPos = 0;
            }
            else
            {
                _thumbTopPos = (int)(ThumbPosition * (_channelHeight - _thumbHeight) / Maximum);
            }
        }

        public void AdvancedScrollbar_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                ThumbPosition += 40;
                if (ThumbPosition > Maximum)
                {
                    ThumbPosition = Maximum;
                }
            }
            else
            {
                ThumbPosition -= 40;
                if (ThumbPosition < Minimum)
                {
                    ThumbPosition = Minimum;
                }
            }

            Invalidate();
            UpdateRegisteredHandlesScroll();
        }

        private void AdvancedScrollbar_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_thumbDown)
            {
                ComputeDimensions();
                Point point = this.PointToClient(Cursor.Position);
                Rectangle thumbrect = new Rectangle(1, UpArrow.Height, this.Width - 2, (int)_channelHeight);

                if (thumbrect.Contains(point))
                {
                    _clickPoint = point.Y;

                    if (UpArrow.Height + _channelHeight - _thumbHeight >= point.Y)
                    {
                        _distance = point.Y - UpArrow.Height - _thumbTopPos;
                    }
                    else
                    {
                        _distance = UpArrow.Height + _channelHeight - _thumbHeight;
                    }

                    FigureOutPosition();
                    Invalidate();
                    UpdateRegisteredHandlesScroll();
                }
            }
        }
    }
}
