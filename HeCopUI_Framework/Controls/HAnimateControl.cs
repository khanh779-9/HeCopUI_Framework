using System.ComponentModel;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HAnimateControl : Component
    {
        public HAnimateControl()
        {

        }

        private Control _targetControl;
        /// <summary>
        /// Gets or sets control to show animation.
        /// </summary>
        public Control TargetControl
        {
            get { return _targetControl; }
            set
            {
                _targetControl = value;
                if (DesignMode == false)
                    HeCopUI_Framework.Win32.User32.AnimateWindow(_targetControl.Handle, Interval, AnimateMode);
                _targetControl.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets animate mode to show animate effect of control.
        /// </summary>

        //[SettingsBindable(true)]
        public HeCopUI_Framework.Win32.Enums.AnimateWindowFlags AnimateMode { get; set; } = HeCopUI_Framework.Win32.Enums.AnimateWindowFlags.AW_BLEND;

        public int Interval { get; set; } = 100;
    }
}
