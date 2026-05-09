using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HShowFormLocation : Component
    {
        public HShowFormLocation()
        {
        }

        private int _locationX = 0;
        private int _locationY = 0;
        private Form _targetForm;
        public Form TargetForm
        {
            get { return _targetForm; }
            set
            {
                _targetForm = value;
                _targetForm.Load += (sender, e) =>
                  {
                      if (UseAnimation)
                      {
                          _timer.Interval = Interval;
                          _timer.Tick += OnTimerTick;
                          _timer.Start();
                      }
                      switch (ShowFormLocation)
                      {
                          case ShowLocation.MiddleCenter:
                              _locationX = Screen.PrimaryScreen.WorkingArea.Width / 2 - _targetForm.Width / 2;
                              _locationY = Screen.PrimaryScreen.WorkingArea.Height / 2 - _targetForm.Height / 2;
                              _targetForm.Location = new Point(_locationX, _locationY);
                              break;
                          case ShowLocation.TopLeft:
                              _locationX = _locationY = 0;
                              _targetForm.Location = new Point(_locationX, _locationY);
                              break;
                          case ShowLocation.BottomRight:
                              _locationX = Screen.PrimaryScreen.WorkingArea.Width - _targetForm.Width;
                              _locationY = Screen.PrimaryScreen.WorkingArea.Height - _targetForm.Height;
                              _targetForm.Location = new Point(_locationX, _locationY);
                              break;
                      }

                  };
            }
        }

        private Timer _timer = new Timer();
        public int Interval { get; set; } = 10;
        public bool UseAnimation { get; set; } = false;
        public enum AnimateStyle
        {
            FadeIn, FadeOut, ZoomIn, None
        }

        private double _opacity = 0;
        private void OnTimerTick(object sender, EventArgs e)
        {
            _targetForm.Opacity = _opacity;
            switch (ShowAnimationStyle)
            {
                case AnimateStyle.FadeIn:
                    if (_opacity < 1)
                    {
                        _opacity += 0.1;
                        _targetForm.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    break;

            }
        }

        public AnimateStyle ShowAnimationStyle { get; set; } = HShowFormLocation.AnimateStyle.None;

        public enum ShowLocation { TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, MiddleRight, BottomLeft, BottomCenter, BottomRight }

        public ShowLocation ShowFormLocation { get; set; } = ShowLocation.MiddleCenter;
    }
}
