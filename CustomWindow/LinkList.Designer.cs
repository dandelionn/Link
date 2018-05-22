namespace CustomWindow
{
    partial class LinkList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkList));
            this.panelList = new System.Windows.Forms.Panel();
            this.scrollbarList = new LinkScrollbar.LinkScrollbar();
            this.SuspendLayout();
            // 
            // panelList
            // 
            this.panelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelList.BackColor = System.Drawing.Color.LightCyan;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(316, 375);
            this.panelList.TabIndex = 0;
            // 
            // scrollbarList
            // 
            this.scrollbarList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollbarList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.scrollbarList.ChannelBorderColor = System.Drawing.Color.Empty;
            this.scrollbarList.ChannelColor = System.Drawing.Color.Empty;
            this.scrollbarList.DownArrow = ((System.Drawing.Image)(resources.GetObject("scrollbarList.DownArrow")));
            this.scrollbarList.Location = new System.Drawing.Point(300, 0);
            this.scrollbarList.Maximum = 0;
            this.scrollbarList.Minimum = 0;
            this.scrollbarList.Name = "scrollbarList";
            this.scrollbarList.Size = new System.Drawing.Size(16, 375);
            this.scrollbarList.TabIndex = 2;
            this.scrollbarList.ThumbBottom = null;
            this.scrollbarList.ThumbBottomSpan = null;
            this.scrollbarList.ThumbColor = System.Drawing.Color.DeepSkyBlue;
            this.scrollbarList.ThumbMiddle = null;
            this.scrollbarList.ThumbPosition = 0;
            this.scrollbarList.ThumbTop = null;
            this.scrollbarList.ThumbTopSpan = null;
            this.scrollbarList.UpArrow = ((System.Drawing.Image)(resources.GetObject("scrollbarList.UpArrow")));
            // 
            // LinkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scrollbarList);
            this.Controls.Add(this.panelList);
            this.Name = "LinkList";
            this.Size = new System.Drawing.Size(316, 375);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelList;
        private LinkScrollbar.LinkScrollbar scrollbarList;
    }
}
