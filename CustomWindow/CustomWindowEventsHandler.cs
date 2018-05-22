using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomWindow
{
    public class CustomWindowEventsHandler
    {
        public delegate void ResizeItems(int delta);
        public ResizeItems OnResizeItems { get; set; }

        bool _isLeftPanelDragged = false;
        Point _normalWindowLocation = Point.Empty;

        Panel _panelTop;
        Panel _panelBottom;
        Panel _panelRight;
        Panel _panelLeft;
        Panel _panelTitleBar;
        Form _owner;

        static bool isInstanceCreated = false;

        public static CustomWindowEventsHandler CreateCustomWindowEventsHandler()
        {
            if(isInstanceCreated == false)
            {
                isInstanceCreated = true;
                return new CustomWindowEventsHandler();
            }
            else
            {
                return null;
            }
        }

        public void SetOwner(Form o)
        {
            _owner = o;
        }

        public void SetBorders(Panel borderTop, Panel borderBottom, Panel borderRight, Panel borderLeft)
        {
            _panelTop = borderTop;
            _panelBottom = borderBottom;
            _panelRight = borderRight;
            _panelLeft = borderLeft;
        }

        public void SetTitleBar(Panel topPanel)
        {
            _panelTitleBar = topPanel;
        }
    }
}
