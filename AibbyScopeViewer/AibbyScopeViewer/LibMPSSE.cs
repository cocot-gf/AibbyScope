using System;
using System.Runtime.InteropServices;

namespace LibMPSSE {
  /// <summary>
  /// Defined in ftd2xx.h
  /// </summary>
  public enum FT_STATUS : uint {
    OK,
    InvalidHandle,
    DeviceNotFound,
    DeviceNotOpened,
    IoError,
    InsufficientResources,
    InvalidParameter,
    InvalidBaudRate,
    DeviceNotOpenedForErase,
    DeviceNotOpenedForWrite,
    FailedToWriteDevice,
    EepromReadFailed,
    EepromWriteFailed,
    EepromEraseFailed,
    EepromNotPresent,
    EepromNotProgrammed,
    InvalidArgs,
    NotSupported,
    OtherError,
    DeviceListNotReady,
  }

  /// <summary>
  /// FT_DEVICE_LIST_INFO_NODE "Type" field, defined in ftd2xx.h
  /// </summary>
  public enum FT_DEVICE : uint {
    FT_BM,
    FT_AM,
    FT8U100AX,
    Unknown,
    FT2232,
    FT232R,
    FT2232H,
    FT4232H,
    FT232H,
    FT_X_SERIES,
    FT4222H_0,
    FT4222H_1_2,
    FT4222H_3,
    FT4222_PROG,
    FT900,
    FT930,
    UMFTPD3A,
    FT2233HP,
    FT4233HP,
    FT2232HP,
    FT4232HP,
    FT233HP,
    FT232HP,
    FT2232HA,
    FT4232HA,
  }

  /// <summary>
  /// FT_DEVICE_LIST_INFO_NODE "Flags" field, defined in ftd2xx.h
  /// </summary>
  [Flags]
  public enum FT_FLAGS : uint {
    None = 0,
    Opened = 1,
    HiSpeed = 2,
    SuperSpeed = 4,
  }

  /// <summary>
  /// Defined in ftd2xx.h
  /// </summary>
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
  public struct FT_DEVICE_LIST_INFO_NODE {
    public FT_FLAGS Flags;
    public FT_DEVICE DevType;
    public uint DevId;
    public uint LocId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string SerialNumber;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string Description;
    public IntPtr handle;
  }

  public class MPSSE {
    /// <summary>
    /// Defined in AN_135_MPSSE_Basics
    /// </summary>
    public const uint BufferSizeMax = 65536;

    [DllImport("libmpsse.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS Ver_libMPSSE(out uint verMPSSE, out uint verD2XX);
  }
}
