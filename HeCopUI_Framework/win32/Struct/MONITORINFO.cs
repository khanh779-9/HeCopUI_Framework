using System;

namespace HeCopUI_Framework.Win32.Struct
{
    [Serializable]
    [CLSCompliant(false)]
    public struct MONITORINFO
    {
        public int cbSize;
        public RECT rcMonitor;
        public RECT rcWork;
        public int dwFlags;
    }
}
