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
        // ù ��° ȣ���� ��ġ�� ���� ��� �����Դϴ�.
        GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, size);

        if (deviceCount == 0)
        {
            Debug.WriteLine("No devices found.");
            return;
        }

        // �޸𸮸� �Ҵ��մϴ�.
        IntPtr pRawInputDeviceList = Marshal.AllocHGlobal((int)(size * deviceCount));
        // �� ��° ȣ���� ��ġ ����� �������� �����Դϴ�.
        GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, size);

        for (int i = 0; i < deviceCount; ++i)
        {
            // �迭�� �� ��ҿ� �����մϴ�.
            IntPtr currentDevice = new IntPtr(pRawInputDeviceList.ToInt64() + (size * i));
            RAWINPUTDEVICELIST device 
                = (RAWINPUTDEVICELIST)Marshal.PtrToStructure(
                    currentDevice, typeof(RAWINPUTDEVICELIST));

            // ���⼭ �� Ű������ ���� ������ �� ���ϴ� Ű���带 �ĺ��� �� �ֽ��ϴ�.
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
