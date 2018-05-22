namespace CustomWindow
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.buttonRedo = new CustomWindow.ButtonZ();
            this.buttonUndo = new CustomWindow.ButtonZ();
            this.buttonSave = new CustomWindow.ButtonZ();
            this.buttonMoveDown = new CustomWindow.ButtonZ();
            this.buttonMoveUp = new CustomWindow.ButtonZ();
            this.buttonDelete = new CustomWindow.ButtonZ();
            this.buttonNewItem = new CustomWindow.ButtonZ();
            this.buttonMin = new CustomWindow.ButtonZ();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelMain = new System.Windows.Forms.Panel();
            this.linkList = new CustomWindow.LinkList();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItemRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTitleBar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelTop.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(318, 2);
            this.panelTop.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelTitleBar.Controls.Add(this.buttonRedo);
            this.panelTitleBar.Controls.Add(this.buttonUndo);
            this.panelTitleBar.Controls.Add(this.buttonSave);
            this.panelTitleBar.Controls.Add(this.buttonMoveDown);
            this.panelTitleBar.Controls.Add(this.buttonMoveUp);
            this.panelTitleBar.Controls.Add(this.buttonDelete);
            this.panelTitleBar.Controls.Add(this.buttonNewItem);
            this.panelTitleBar.Controls.Add(this.buttonMin);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(318, 27);
            this.panelTitleBar.TabIndex = 2;
            // 
            // buttonRedo
            // 
            this.buttonRedo.BackColor = System.Drawing.Color.Transparent;
            this.buttonRedo.BackgroundImage = global::Link.Properties.Resources.redosq_blue_transparent;
            this.buttonRedo.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonRedo.DisplayText = "";
            this.buttonRedo.Enabled = false;
            this.buttonRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRedo.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedo.ForeColor = System.Drawing.Color.White;
            this.buttonRedo.Location = new System.Drawing.Point(198, 1);
            this.buttonRedo.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonRedo.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(29, 24);
            this.buttonRedo.TabIndex = 1;
            this.buttonRedo.TextLocation_X = 6;
            this.buttonRedo.TextLocation_Y = -20;
            this.toolTip.SetToolTip(this.buttonRedo, "Redo");
            this.buttonRedo.UseVisualStyleBackColor = false;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.BackColor = System.Drawing.Color.Transparent;
            this.buttonUndo.BackgroundImage = global::Link.Properties.Resources.undosq_blue_transparent;
            this.buttonUndo.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonUndo.DisplayText = "";
            this.buttonUndo.Enabled = false;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUndo.ForeColor = System.Drawing.Color.White;
            this.buttonUndo.Location = new System.Drawing.Point(165, 1);
            this.buttonUndo.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonUndo.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(29, 24);
            this.buttonUndo.TabIndex = 1;
            this.buttonUndo.TextLocation_X = 6;
            this.buttonUndo.TextLocation_Y = -20;
            this.toolTip.SetToolTip(this.buttonUndo, "Undo");
            this.buttonUndo.UseVisualStyleBackColor = false;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Transparent;
            this.buttonSave.BackgroundImage = global::Link.Properties.Resources.save_transparent;
            this.buttonSave.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonSave.DisplayText = "";
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(132, 1);
            this.buttonSave.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonSave.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(29, 24);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.TextLocation_X = 6;
            this.buttonSave.TextLocation_Y = -20;
            this.toolTip.SetToolTip(this.buttonSave, "Save");
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.BackColor = System.Drawing.Color.Transparent;
            this.buttonMoveDown.BackgroundImage = global::Link.Properties.Resources.down_transparent_2;
            this.buttonMoveDown.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonMoveDown.DisplayText = "";
            this.buttonMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveDown.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveDown.ForeColor = System.Drawing.Color.Yellow;
            this.buttonMoveDown.Location = new System.Drawing.Point(99, 1);
            this.buttonMoveDown.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonMoveDown.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(29, 24);
            this.buttonMoveDown.TabIndex = 1;
            this.buttonMoveDown.TextLocation_X = 6;
            this.buttonMoveDown.TextLocation_Y = -20;
            this.toolTip.SetToolTip(this.buttonMoveDown, "Move Down");
            this.buttonMoveDown.UseVisualStyleBackColor = false;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.BackColor = System.Drawing.Color.Transparent;
            this.buttonMoveUp.BackgroundImage = global::Link.Properties.Resources.up_transparent;
            this.buttonMoveUp.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonMoveUp.DisplayText = "";
            this.buttonMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveUp.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveUp.ForeColor = System.Drawing.Color.Yellow;
            this.buttonMoveUp.Location = new System.Drawing.Point(66, 1);
            this.buttonMoveUp.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonMoveUp.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(29, 24);
            this.buttonMoveUp.TabIndex = 1;
            this.buttonMoveUp.TextLocation_X = 6;
            this.buttonMoveUp.TextLocation_Y = -20;
            this.toolTip.SetToolTip(this.buttonMoveUp, "Move Up");
            this.buttonMoveUp.UseVisualStyleBackColor = false;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.BackgroundImage = global::Link.Properties.Resources.transparent_background_fit_green;
            this.buttonDelete.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.DisplayText = "";
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.Green;
            this.buttonDelete.Location = new System.Drawing.Point(33, 1);
            this.buttonDelete.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonDelete.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(29, 24);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.TextLocation_X = 6;
            this.buttonDelete.TextLocation_Y = -20;
            this.toolTip.SetToolTip(this.buttonDelete, "Delete");
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonNewItem
            // 
            this.buttonNewItem.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewItem.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonNewItem.DisplayText = "+";
            this.buttonNewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewItem.ForeColor = System.Drawing.Color.Yellow;
            this.buttonNewItem.Location = new System.Drawing.Point(3, 1);
            this.buttonNewItem.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonNewItem.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonNewItem.Name = "buttonNewItem";
            this.buttonNewItem.Size = new System.Drawing.Size(27, 24);
            this.buttonNewItem.TabIndex = 4;
            this.buttonNewItem.Text = "+";
            this.buttonNewItem.TextLocation_X = -1;
            this.buttonNewItem.TextLocation_Y = -8;
            this.toolTip.SetToolTip(this.buttonNewItem, "New");
            this.buttonNewItem.UseVisualStyleBackColor = false;
            this.buttonNewItem.Click += new System.EventHandler(this.buttonAddNewItem_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMin.BackColor = System.Drawing.Color.Transparent;
            this.buttonMin.BZBackColor = System.Drawing.Color.Transparent;
            this.buttonMin.DisplayText = ">";
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.Font = new System.Drawing.Font("Sitka Small", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMin.ForeColor = System.Drawing.Color.White;
            this.buttonMin.Location = new System.Drawing.Point(286, 1);
            this.buttonMin.MouseClickColor1 = System.Drawing.Color.Transparent;
            this.buttonMin.MouseHoverColor = System.Drawing.Color.Transparent;
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(29, 24);
            this.buttonMin.TabIndex = 1;
            this.buttonMin.Text = ">";
            this.buttonMin.TextLocation_X = 1;
            this.buttonMin.TextLocation_Y = 0;
            this.toolTip.SetToolTip(this.buttonMin, "Minimize");
            this.buttonMin.UseVisualStyleBackColor = false;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 29);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(2, 432);
            this.panelLeft.TabIndex = 3;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(315, 29);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(3, 432);
            this.panelRight.TabIndex = 4;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(2, 459);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(313, 2);
            this.panelBottom.TabIndex = 5;
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.linkList);
            this.panelMain.Location = new System.Drawing.Point(3, 30);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(313, 428);
            this.panelMain.TabIndex = 6;
            // 
            // linkList
            // 
            this.linkList.BackColor = System.Drawing.Color.White;
            this.linkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkList.Location = new System.Drawing.Point(0, 0);
            this.linkList.Name = "linkList";
            this.linkList.Size = new System.Drawing.Size(313, 428);
            this.linkList.TabIndex = 0;
            this.linkList.Load += new System.EventHandler(this.linkList_Load);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Link";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItemRestore,
            this.closeToolStripMenuItemClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // closeToolStripMenuItemRestore
            // 
            this.closeToolStripMenuItemRestore.Name = "closeToolStripMenuItemRestore";
            this.closeToolStripMenuItemRestore.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItemRestore.Text = "Restore";
            this.closeToolStripMenuItemRestore.Click += new System.EventHandler(this.closeToolStripMenuItemRestore_Click);
            // 
            // closeToolStripMenuItemClose
            // 
            this.closeToolStripMenuItemClose.Name = "closeToolStripMenuItemClose";
            this.closeToolStripMenuItemClose.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItemClose.Text = "Close";
            this.closeToolStripMenuItemClose.Click += new System.EventHandler(this.closeToolStripMenuItemClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 461);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelTitleBar.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelTitleBar;
        private ButtonZ buttonMin;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMain;
        private ButtonZ buttonNewItem;
        private LinkList linkList;
        private ButtonZ buttonDelete;
        private ButtonZ buttonMoveDown;
        private ButtonZ buttonMoveUp;
        private ButtonZ buttonSave;
        private ButtonZ buttonUndo;
        private ButtonZ buttonRedo;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItemRestore;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItemClose;
    }
}

