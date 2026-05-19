using System;
using System.Runtime.InteropServices;

namespace LibMPSSE {
  /// <summary>
  /// SPI interface library for FTDI MPSSE.
  /// </summary>
  class SPI {
    [Flags]
    public enum TransferOptions : uint {
      None = 0,
      SizeInBits = 1,
      AssertCs = 2,  // Before Transfer
      NegateCs = 4,  // After Transfer
      LsbFirst = 8,
    }

    public enum ClockRates : uint {
      Minimum = 92,
      FT2232Max = 6000000,
      Maximum = 30000000
    }

    public enum SPIModes : uint {
      Mode0, // ClkIdle=Low,  In=Rise, Out=Fall
      Mode1, // ClkIdle=Low,  In=Fall, Out=Rise
      Mode2, // ClkIdle=High, In=Fall, Out=Rise
      Mode3  // ClkIdle=High, In=Rise, Out=Fall
    }

    public enum CSPins : uint {
      DBUS3,
      DBUS4,
      DBUS5,
      DBUS6,
      DBUS7
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ChannelConfigOptions {
      public uint data;

      public SPIModes SpiMode {
        get { return (SPIModes)(data & 3); }
        set { data = (data & ~(uint)3) | (uint)value; }
      }

      public CSPins CsPin {
        get { return (CSPins)((data >> 2) & 7); }
        set { data = (data & ~(uint)0x1c) | (uint)value << 2; }
      }

      public bool CsActiveLow {
        get { return ((data >> 5) & 1) == 1; }
        set { data = value ? data | 0x20 : data & ~(uint)0x20; }
      }
    }

    /// <summary>
    /// GPIOL pin state configuration, defined in libmpsse_spi.h
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PinStates {
      public byte InitialDirection;
      public byte InitialValue;
      public byte FinalDirection;
      public byte FinalValue;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ChannelConfig {
      public uint ClockRate;
      public byte LatencyTimer;
      public ChannelConfigOptions Options;
      public PinStates PinState;
      public ushort _reserved;

      public ChannelConfig(uint clockRate, byte latencyTimer, uint options) {
        ClockRate = clockRate;
        LatencyTimer = latencyTimer;
        Options.data = options;

        PinState.InitialDirection = 0;
        PinState.InitialValue = 0;
        PinState.FinalDirection = 0;
        PinState.FinalValue = 0;
        _reserved = 0;
      }
    }

    [DllImport("libmpsse.dll", EntryPoint = "SPI_GetNumChannels", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS GetNumChannels(out uint numChannels);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_GetChannelInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS GetChannelInfo(uint index, out FT_DEVICE_LIST_INFO_NODE chanInfo);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_OpenChannel", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS OpenChannel(uint index, out IntPtr handle);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_InitChannel", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS InitChannel(IntPtr handle, ref ChannelConfig config);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_CloseChannel", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS CloseChannel(IntPtr handle);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_Read", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS Read(IntPtr handle, byte[] buffer, uint sizeToTransfer, out uint sizeTransfered, TransferOptions transferOptions);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_Write", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS Write(IntPtr handle, byte[] buffer, uint sizeToTransfer, out uint sizeTransfered, TransferOptions transferOptions);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_ReadWrite", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS ReadWrite(IntPtr handle, byte[] inBuffer, byte[] outBuffer, uint sizeToTransfer, out uint sizeTransferred, TransferOptions transferOptions);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_IsBusy", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS IsBusy(IntPtr handle, out bool state);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_ChangeCS", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS ChangeCS(IntPtr handle, ChannelConfigOptions channelConfigOptions);

    [DllImport("libmpsse.dll", EntryPoint = "SPI_ToggleCS", CallingConvention = CallingConvention.Cdecl)]
    public static extern FT_STATUS ToggleCS(IntPtr handle, bool state);
  }
}
