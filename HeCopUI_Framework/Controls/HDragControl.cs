using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HDragControl : Component, IComponent
    {
        public HDragControl()
        {

        }

        private Control _targetControl;
        public Control TargetControl
        {
            get { return _targetControl; }
            set
            {
                _targetControl = value;
                _targetControl.Invalidate();
            }
        }

        private Control _dragControl;
        public Control GetControl
        {
            get { return _dragControl; }
            set
            {
                _dragControl = value;
                try
                {
                    _dragControl.MouseDown += OnDragControlMouseDown;
                    _dragControl.MouseUp += OnDragControlMouseUp;
                    _dragControl.MouseMove += OnDragControlMouseMove;
                }
                catch { }
                _dragControl.Invalidate();
            }
        }

        private bool _isMouseDown;
        private int _xLast;
        private int _yLast;

        private void OnDragControlMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                int newY = _targetControl.Top + (e.Y - _yLast);
                int newX = _targetControl.Left + (e.X - _xLast);

                _targetControl.Location = new Point(newX, newY);
            }
        }

        private void OnDragControlMouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void OnDragControlMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                _xLast = e.X;
                _yLast = e.Y;
            }
        }
    }
}
