using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomWindow
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        struct POINT
        {
            public int X;
            public int Y;
        }

        CustomWindowEventsHandler _customWindowEventsHandler;
        LocationManager _locationManager;
        DataManager _dataManager;

        public void InitializeEventHandler()
        {
            _customWindowEventsHandler = CustomWindowEventsHandler.CreateCustomWindowEventsHandler();
            _customWindowEventsHandler.SetBorders(panelTop, panelBottom, panelRight, panelLeft);
            _customWindowEventsHandler.SetTitleBar(panelTitleBar);
            _customWindowEventsHandler.SetOwner(this);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            _dataManager = new DataManager();

            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, panelMain, new object[] { true });
        }

        //eliminates the flickering problem
        protected override CreateParams CreateParams
        {
           get
           {
               CreateParams cp = base.CreateParams;
               cp.ExStyle |= 0x02000000;
               return cp;
           }
        }

        public MainForm()
        {
            //AllocConsole();
            InitializeComponent();
            ManageLocation();
            InitializeEventHandler();

            this.ShowInTaskbar = false;
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Text = String.Empty;
            ControlBox = false;


            linkList.OnDisableUndo = DisableUndo;
            linkList.OnEnableUndo = EnableUndo;
            linkList.OnEnableRedo = EnableRedo;
            linkList.OnDisableRedo = DisableRedo;
        }

        public void EnableUndo()
        {
            buttonUndo.Enabled = true;
        }

        public void DisableUndo()
        {
            buttonUndo.Enabled = false;
        }

        public void EnableRedo()
        {
            buttonRedo.Enabled = true;
        }

        public void DisableRedo()
        {
            buttonRedo.Enabled = false;
        }

        public void ManageLocation()
        { 
            _locationManager = LocationManager.CreateLocationManager();
            _locationManager.SetForm(this);
            _locationManager.InitializeFormData();
        }

        private void buttonAddNewItem_Click(object sender, System.EventArgs e)
        {
            linkList.Add(new LinkItem());
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {
            linkList.Remove(linkList.LastSelectedLinkItem);
        }

        private void buttonMoveUp_Click(object sender, System.EventArgs e)
        {
            linkList.MoveUp(linkList.LastSelectedLinkItem);
        }

        private void buttonMoveDown_Click(object sender, System.EventArgs e)
        {
            linkList.MoveDown(linkList.LastSelectedLinkItem);
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            _dataManager.Serialize(linkList.GetLinkData());
        }

        private void linkList_Load(object sender, System.EventArgs e)
        {
            List<LinkData> linkData = _dataManager.Deserialize();
            if (linkData != null)
            {
                linkList.Populate(linkData);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dataManager.Serialize(linkList.GetLinkData());
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            _dataManager.Serialize(linkList.GetLinkData());
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    buttonMin_Click(null, null);
                    break;
                case Keys.Delete:
                    linkList.Remove(linkList.LastSelectedLinkItem);
                    break;
                case Keys.N:
                    if (e.Modifiers == Keys.Control)
                    {
                        linkList.Add(new LinkItem());
                    }
                    break;
            }
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            linkList.Undo();
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            linkList.Redo();
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
             //_locationManager.HideTitleBar();   
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //_locationManager.HideTitleBar();
        }

        const int WM_SIZING = 0x0214;
        const int WMSZ_LEFT = 1;
        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;
        const int HTCLIENT = 1;
        const int WM_NCPAINT = 0x0085;

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case WM_NCPAINT:
                    {
                        IntPtr hdc = GetWindowDC(message.HWnd);
                        if ((int)hdc != 0)
                        {
                            Graphics g = Graphics.FromHdc(hdc);
                            g.FillRectangle(Brushes.Blue, new Rectangle(0, 0, 4800, 23));
                            g.Flush();
                            ReleaseDC(message.HWnd, hdc);
                        }
                    }
                    break;

                case WM_NCHITTEST:
                    {
                        POINT p;
                        if (GetCursorPos(out p))
                        {
                            if (p.X - this.Location.X < 7)
                            {
                                message.Result = (IntPtr)HTLEFT;
                            }
                            else
                            {
                                message.Result = (IntPtr)1;
                            }
                        }
                        else
                        {
                            message.Result = (IntPtr)1;
                        }

                    }
                    break;

                default:
                    {
                        base.WndProc(ref message);
                    }
                    break;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            linkList.ResizeItems();
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            linkList.ResizeItems();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            linkList.ResizeItems();
        }

        private void closeToolStripMenuItemRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void closeToolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        //https://stackoverflow.com/questions/5089601/how-to-run-a-c-sharp-application-at-windows-startup
        /*/////run at startup
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public frmStartup()
        {
            InitializeComponent();
            // Check to see the current state (running at startup or not)
            if (rkApp.GetValue("MyApp") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                chkRun.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                chkRun.Checked = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkRun.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("MyApp", Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("MyApp", false);
            }
        }*/
    }
}
