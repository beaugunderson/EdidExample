using System;
using System.Runtime.InteropServices;

namespace EdidExample
{
    static class NativeMethods
    {
        [Flags]
        public enum DisplayDeviceStateFlags
        {
            AttachedToDesktop = 0x1,
            PrimaryDevice = 0x4,
        }

        [Flags]
        public enum DiGetClassFlags : uint
        {
            DIGCF_PRESENT = 0x00000002,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SP_DEVINFO_DATA
        {
            public UInt32 cbSize;
            public Guid ClassGuid;
            public uint DevInst;
            public IntPtr Reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DisplayDevice
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceString;
            [MarshalAs(UnmanagedType.U4)]
            public DisplayDeviceStateFlags StateFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceKey;
        }

        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetupDiGetClassDevs(
            ref Guid ClassGuid,
            IntPtr Enumerator,
            IntPtr hwndParent,
            DiGetClassFlags Flags);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, BestFitMapping = false)]
        public static extern bool EnumDisplayDevices(
            [MarshalAs(UnmanagedType.LPStr)]
            string lpDevice,
            uint iDevNum,
            ref DisplayDevice lpDisplayDevice,
            uint dwFlags);

        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiEnumDeviceInfo(
            IntPtr DeviceInfoSet,
            uint MemberIndex,
            ref SP_DEVINFO_DATA DeviceInfoData);

        [DllImport("Setupapi", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetupDiOpenDevRegKey(
            IntPtr hDeviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            int scope,
            int hwProfile,
            int parameterRegistryValueKind,
            int samDesired);

        [DllImport("ntdll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int NtQueryKey(
            IntPtr KeyHandle,
            int KeyInformationClass,
            IntPtr KeyInformation,
            uint Length,
            ref uint ResultLength);

        public const int ERROR_NO_MORE_ITEMS = 259;
        public const int DIREG_DEV = 0x00000001;
        public const int DICS_FLAG_GLOBAL = 0x00000001;
        public const int KEY_READ = 0x20019;

        public static Guid GUID_CLASS_MONITOR = 
            new Guid(0x4d36e96e, 0xe325, 0x11ce, 0xbf, 0xc1, 0x08, 0x00, 0x2b, 0xe1, 0x03, 0x18);
    }
}
