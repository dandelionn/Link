using System.Drawing;
using System.Windows.Forms;

namespace CustomWindow
{
    public class LocationManager
    {
        static bool isInstanceCreated = false;
        private Form _form;

        public static LocationManager CreateLocationManager()
        {
            if (isInstanceCreated == false)
            {
                isInstanceCreated = true;
                return new LocationManager();
            }
            else
            {
                return null;
            }
        }

        public void SetForm(MainForm mainForm)
        {
            _form = mainForm;
        }

        public int GetTitleBarHeight()
        {
            Rectangle screenRectangle = _form.RectangleToScreen(_form.ClientRectangle);

            int titleHeight = screenRectangle.Top - _form.Top;

            return titleHeight;
        }

        private double factor = 4.9;
        public void InitializeFormData()
        {
            _form.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - (int)(Screen.PrimaryScreen.Bounds.Width / factor) -8 , -GetTitleBarHeight()); //-8 because it is not the good location, not sure why yet
            _form.Size = new System.Drawing.Size((int)(Screen.PrimaryScreen.Bounds.Width / factor), Screen.PrimaryScreen.WorkingArea.Height - 8); 
            _form.MinimumSize = new System.Drawing.Size((int)(Screen.PrimaryScreen.Bounds.Width / factor), Screen.PrimaryScreen.WorkingArea.Height - 8);
        }

        public void HideTitleBar()
        {
            _form.Location = new System.Drawing.Point(_form.Location.X, -GetTitleBarHeight());
        }
    }
}
