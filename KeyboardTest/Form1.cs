using System;
using System.Runtime.InteropServices;

using System.Diagnostics;

namespace KeyboardTest;


public partial class Form1 : Form
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWINPUTDEVICELIST
    {
        public IntPtr hDevice;
        public uint dwType;
    }

    [DllImport("user32.dll")]
    static extern uint GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint uiNumDevices, uint cbSize);

    [DllImport("user32.dll")]
    static extern uint GetRawInputDeviceInfo(IntPtr hDevice, uint uiCommand, IntPtr pData, ref uint pcbSize);




    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWINPUTDEVICE
    {
        public ushort usUsagePage;
        public ushort usUsage;
        public uint dwFlags;
        public IntPtr hwndTarget;
    }

    [DllImport("user32.dll")]
    static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices, uint uiNumDevices, uint cbSize);

    public Form1()
    {
        InitializeComponent();

        uint deviceCount = 0;
        uint size = (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICELIST));
        // 첫 번째 호출은 장치의 수를 얻기 위함입니다.
        GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, size);

        if (deviceCount == 0)
        {
            Debug.WriteLine("No devices found.");
            return;
        }

        // 메모리를 할당합니다.
        IntPtr pRawInputDeviceList = Marshal.AllocHGlobal((int)(size * deviceCount));
        // 두 번째 호출은 장치 목록을 가져오기 위함입니다.
        GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, size);

        for (int i = 0; i < deviceCount; ++i)
        {
            // 배열의 각 요소에 접근합니다.
            IntPtr currentDevice = new IntPtr(pRawInputDeviceList.ToInt64() + (size * i));
            RAWINPUTDEVICELIST device 
                = (RAWINPUTDEVICELIST)Marshal.PtrToStructure(
                    currentDevice, typeof(RAWINPUTDEVICELIST));

            // 여기서 각 키보드의 세부 정보를 얻어서 원하는 키보드를 식별할 수 있습니다.
            Debug.WriteLine($"{i} num : {device.hDevice}");
        }
        




        RAWINPUTDEVICE[] rid0 = new RAWINPUTDEVICE[1];

        rid0[0].usUsagePage = 0x01;
        rid0[0].usUsage = 0x06; // Keyboard
        rid0[0].dwFlags = 0x00; // Default
        rid0[0].hwndTarget = IntPtr.Zero;

        if (!RegisterRawInputDevices(rid0, (uint)rid0.Length, (uint)Marshal.SizeOf(rid0[0])))
        {
            Debug.WriteLine("Failed to register raw input device(s).");
        }




        RAWINPUTDEVICE[] rid2 = new RAWINPUTDEVICE[1];

        rid2[0].usUsagePage = 0x01;
        rid2[0].usUsage = 0x06; // Keyboard
        rid2[0].dwFlags = 0x00; // Default
        rid2[0].hwndTarget = IntPtr.Zero;

        if (!RegisterRawInputDevices(rid2, (uint)rid2.Length, (uint)Marshal.SizeOf(rid2[0])))
        {
            Debug.WriteLine("Failed to register raw input device(s).");
        }

    }

}
