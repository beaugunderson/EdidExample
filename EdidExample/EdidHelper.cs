using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EdidExample
{
    static class EdidHelper
    {
        public static Tuple<int,int> ScreenSize()
        {
            var displayDevice = new NativeMethods.DisplayDevice();

            displayDevice.cb = Marshal.SizeOf(displayDevice);

            try
            {
                for (uint id = 0; NativeMethods.EnumDisplayDevices(null, id, ref displayDevice, 0); id++)
                {
                    if (displayDevice.StateFlags.HasFlag(NativeMethods.DisplayDeviceStateFlags.AttachedToDesktop) &&
                        displayDevice.StateFlags.HasFlag(NativeMethods.DisplayDeviceStateFlags.PrimaryDevice))
                    {
                        break;
                    }

                    displayDevice.cb = Marshal.SizeOf(displayDevice);
                }

                if (string.IsNullOrEmpty(displayDevice.DeviceID))
                {
                    return null;
                }

                Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                    displayDevice.DeviceName,
                    displayDevice.DeviceString,
                    displayDevice.StateFlags,
                    displayDevice.DeviceID,
                    displayDevice.DeviceKey);

                var devInfo = NativeMethods.SetupDiGetClassDevs(
                    ref NativeMethods.GUID_CLASS_MONITOR,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    NativeMethods.DiGetClassFlags.DIGCF_PRESENT);

                if (devInfo == IntPtr.Zero)
                {
                    Console.WriteLine("Couldn't get devInfo.");

                    return null;
                }

                int error = 0;

                for (uint i = 0; error != NativeMethods.ERROR_NO_MORE_ITEMS; i++)
                {
                    var devInfoData = new NativeMethods.SP_DEVINFO_DATA();

                    devInfoData.cbSize = (uint)Marshal.SizeOf(devInfoData);

                    if (!NativeMethods.SetupDiEnumDeviceInfo(devInfo, i, ref devInfoData))
                    {
                        break;
                    }

                    error = Marshal.GetLastWin32Error();

                    // TODO: Check for correct monitor here

                    var registryKeyPointer = NativeMethods.SetupDiOpenDevRegKey(devInfo, ref devInfoData,
                        NativeMethods.DICS_FLAG_GLOBAL, 0, NativeMethods.DIREG_DEV, NativeMethods.KEY_READ);

                    //if (!registryKeyPointer || (registryKeyPointer == INVALID_HANDLE_VALUE))
                    //    continue;

                    //RegCloseKey(registryKeyPointer);

                    uint size = 0;

                    // Use NtQueryKey to get the path of the registry key handle by getting the size first
                    NativeMethods.NtQueryKey(registryKeyPointer, 3, IntPtr.Zero, 0, ref size);

                    var registryKeyCharArray = new char[size];
                    var pointerToRegistryKeyCharArray = Marshal.AllocHGlobal(registryKeyCharArray.Length);

                    // And then getting the string itself (in a weird format)
                    NativeMethods.NtQueryKey(registryKeyPointer, 3, pointerToRegistryKeyCharArray, size, ref size);

                    Marshal.Copy(pointerToRegistryKeyCharArray, registryKeyCharArray, 0, (int)size);
                    Marshal.FreeHGlobal(pointerToRegistryKeyCharArray);

                    var registryKeyName = new string(registryKeyCharArray);

                    // This is a ridiculous workaround for NtQueryKey's limitations
                    registryKeyName = registryKeyName.Substring(2);
                    registryKeyName = registryKeyName.Substring(0, registryKeyName.IndexOf("Parameters", StringComparison.Ordinal) + "Parameters".Length);
                    registryKeyName = registryKeyName.Replace(@"\REGISTRY\MACHINE", "HKEY_LOCAL_MACHINE");

                    // Open the key using the managed Registry API since it's a thousand times easier than P/Invoke
                    var edid = (byte[])Registry.GetValue(registryKeyName, "EDID", null);

                    if (edid == null)
                    {
                        Console.WriteLine("Couldn't get data from {0}", registryKeyName);

                        return null;
                    }

                    return GetMonitorSizeFromEdid(edid);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex);
            }

            return null;
        }

        public static Tuple<int, int> ScreenResolution()
        {
            return new Tuple<int, int>(Screen.PrimaryScreen.Bounds.Width,
                                       Screen.PrimaryScreen.Bounds.Height);
        }

        // Assumes registryKeyPointer is valid
        static Tuple<int, int> GetMonitorSizeFromEdid(byte[] edid)
        {
            int width = ((edid[68] & 0xF0) << 4) + edid[66];
            int height = ((edid[68] & 0x0F) << 8) + edid[67];

            return new Tuple<int, int>(width, height);
        }
    }
}