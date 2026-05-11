using HeCopUI_Framework.Win32.Enums;
using HeCopUI_Framework.Win32.Struct;
using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{
    public static class CompositionHelper
    {
        public static bool SetAccentPolicy(IntPtr hWnd, ACCENT_STATE state, int accentFlags = 0, int gradientColor = 0)
        {
            var policy = new ACCENT_POLICY
            {
                AccentState = state,
                AccentFlags = unchecked((uint)accentFlags),
                GradientColor = unchecked((uint)gradientColor),
                AnimationId = 0
            };

            int size = Marshal.SizeOf(policy);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(policy, ptr, false);
                var data = new WINCOMPATTRDATA
                {
                    Attribute = WINCOMPATTR.WCA_ACCENT_POLICY,
                    Data = ptr,
                    SizeOfData = size
                };
                int res = User32.SetWindowCompositionAttribute(hWnd, ref data);
                return res == 1 || res == 0; // Some implementations return 1 on success
            }
            catch
            {
                return false;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static void EnableMica(IntPtr hWnd)
        {
            try
            {
                int val = (int)Dwmapi.DWM_SYSTEMBACKDROP_TYPE.DWMSBT_MAINWINDOW;
                Dwmapi.DwmSetWindowAttribute(hWnd, Dwmapi.DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE, ref val, sizeof(int));
            }
            catch
            {
            }
        }

        public static void SetWindowCornerPreference(IntPtr hWnd, Dwmapi.DWM_WINDOW_CORNER_PREFERENCE pref)
        {
            try
            {
                int val = (int)pref;
                Dwmapi.DwmSetWindowAttribute(hWnd, Dwmapi.DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE, ref val, sizeof(int));
            }
            catch
            {
            }
        }
    }
}
