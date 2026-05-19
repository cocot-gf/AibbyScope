using System;
using System.Runtime.InteropServices;

namespace LibMPSSE {
  /// <summary>
  /// GPIO library for FTDI MPSSE.
  /// </summary>
  class GPIO {
    [DllImport("libmpsse.dll", EntryPoint = "FT_WriteGPIO", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS WriteGPIO(IntPtr handle, byte direction, byte writeValue);

    [DllImport("libmpsse.dll", EntryPoint = "FT_ReadGPIO", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS ReadGPIO(IntPtr handle, out byte readValue);
  }
}
