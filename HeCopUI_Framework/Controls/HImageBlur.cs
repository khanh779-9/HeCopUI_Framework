using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using HeCopUI_Framework.Helper;

namespace HeCopUI_Framework.Controls
{
    public class HImageBlur : Control
    {
        private Image _image = null;
        private int _blurRadius = 20;

        public HImageBlur()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        [Category("Appearance")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Invalidate(); 
            }
        }

        [Category("Appearance")]
        public int BlurRadius
        {
            get => _blurRadius;
            set
            {
                _blurRadius = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_image != null)
            {
                using (Bitmap bmp = new Bitmap(_image))
                {
                    // Using the optimized blur from HBlurs helper
                    Bitmap blurred = HBlurs.StackBlur(bmp, _blurRadius);
                    e.Graphics.DrawImage(blurred, ClientRectangle);
                    blurred.Dispose();
                }
            }
        }
    }
}
