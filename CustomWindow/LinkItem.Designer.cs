namespace CustomWindow
{
    partial class LinkItem
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
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLink = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.AcceptsTab = true;
            this.richTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDescription.BackColor = System.Drawing.Color.PowderBlue;
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDescription.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxDescription.Size = new System.Drawing.Size(215, 10);
            this.richTextBoxDescription.TabIndex = 0;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBoxDescription_ContentsResized);
            this.richTextBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxDescription_KeyDown);
            // 
            // richTextBoxLink
            // 
            this.richTextBoxLink.AcceptsTab = true;
            this.richTextBoxLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLink.BackColor = System.Drawing.Color.MediumAquamarine;
            this.richTextBoxLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLink.Location = new System.Drawing.Point(0, 10);
            this.richTextBoxLink.Name = "richTextBoxLink";
            this.richTextBoxLink.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxLink.Size = new System.Drawing.Size(215, 10);
            this.richTextBoxLink.TabIndex = 1;
            this.richTextBoxLink.Text = "";
            this.richTextBoxLink.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBoxLink_ContentsResized);
            this.richTextBoxLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxLink_KeyDown);
            // 
            // LinkItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.Controls.Add(this.richTextBoxLink);
            this.Controls.Add(this.richTextBoxDescription);
            this.Name = "LinkItem";
            this.Size = new System.Drawing.Size(215, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.RichTextBox richTextBoxLink;
    }
}
