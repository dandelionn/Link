using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomWindow
{
    public partial class LinkItem : UserControl
    {
        public delegate void LinkItemResizedVertically(LinkItem linkItem, int difference);
        public delegate void LinkItemSelected(LinkItem linkItem);
        public delegate void TabPressed(LinkItem linkItem, bool upFocus);
        public delegate void DeleteKeyDown(LinkItem linkItem);

        public LinkItemResizedVertically OnLinkItemResizedVertically { get; set; }
        public LinkItemSelected OnLinkItemSelected { get; set; }
        public TabPressed OnTabPressed { get; set; }
        public DeleteKeyDown OnDeleteKeyDown { get; set; }

        public LinkItem()
        {
            InitializeComponent();

            richTextBoxDescription.GotFocus += RichTextBoxDescription_GotFocus;
            richTextBoxDescription.LostFocus += RichTextBoxDescription_LostFocus;
            richTextBoxLink.LostFocus += RichTextBoxLink_LostFocus;
            richTextBoxLink.GotFocus += RichTextBoxLink_GotFocus;
        }

        public void SetLostFocusBackColor()
        {
            richTextBoxDescription.BackColor = Color.PowderBlue;
            richTextBoxLink.BackColor = Color.MediumAquamarine;
        }

        public void SetGotFocusBackColor()
        {
            richTextBoxDescription.BackColor = Color.Yellow;
            richTextBoxLink.BackColor = Color.YellowGreen;
        }

        private void RichTextBoxLink_GotFocus(object sender, EventArgs e)
        {
            SetGotFocusBackColor();
            OnLinkItemSelected(this);
        }

        private void RichTextBoxDescription_LostFocus(object sender, EventArgs e)
        {
            SetLostFocusBackColor();
            OnLinkItemSelected(this);
        }

        private void RichTextBoxLink_LostFocus(object sender, EventArgs e)
        {
            SetLostFocusBackColor();
            OnLinkItemSelected(this);
        }

        private void RichTextBoxDescription_GotFocus(object sender, EventArgs e)
        {
            SetGotFocusBackColor();
            OnLinkItemSelected(this);
        }

        private void richTextBoxDescription_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
             ((RichTextBox)sender).Height = e.NewRectangle.Height;
             richTextBoxLink.Location = new Point(richTextBoxLink.Location.X, richTextBoxDescription.Height);
             int difference = (richTextBoxDescription.Height + richTextBoxLink.Height) - this.Height;
             this.Height = this.Height + difference;

             OnLinkItemResizedVertically?.Invoke(this, difference);
        }

        private void richTextBoxLink_ContentsResized(object sender, ContentsResizedEventArgs e)
        { 
            ((RichTextBox)sender).Height = e.NewRectangle.Height;

            int difference = (richTextBoxDescription.Height + richTextBoxLink.Height) - this.Height;
            this.Height = this.Height + difference;

            OnLinkItemResizedVertically?.Invoke(this, difference);
        }

        private void richTextBoxDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                if (e.Modifiers == Keys.Shift)
                {
                    OnTabPressed?.Invoke(this, true);
                }
                else
                {
                    richTextBoxLink.Focus();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (richTextBoxDescription.SelectedText == String.Empty)
                    {
                        OnDeleteKeyDown?.Invoke(this);
                    }
                }
            }
        }

        private void richTextBoxLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;

                if (e.Modifiers == Keys.Shift)
                {
                    richTextBoxDescription.Focus();
                }
                else
                {
                    OnTabPressed?.Invoke(this, false);
                }
            }
            else
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (richTextBoxDescription.SelectedText == String.Empty)
                    {
                        OnDeleteKeyDown?.Invoke(this);
                    }
                }
            }
        }
    }
}
