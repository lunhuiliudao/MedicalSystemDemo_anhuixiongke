//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      System_API.cs
//功能描述(Description)：    键盘事件WinApi
//数据表(Tables)：		    无 
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MedicalSystem.UsbKeyBoard
{
    public class System_API
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateEvent(IntPtr eventAttributes, bool manualReset, bool initialState, String name);

        [DllImport("kernel32.dll")]
        public static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetEvent(IntPtr hEvent);


        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "GetKeyboardState")]
        public static extern int GetKeyboardState(byte[] pbKeyState);


    }

    class POC_API
    {
        public const string DLLName = @"poc-basic.dll";

        public const UInt32 POC_ERR_NO_ERROR = 0x00000000;
        public const UInt32 POC_ERR_INVALID_ARGUMENT = 0x00000002;
        public const UInt32 POC_ERR_USBHID_IS_BUSY = 0x01000004;

        public const UInt32 POC_KEYBOARD_PID = 0x576E;
        public const UInt32 POC_KEYBOARD_PID_SECOND = 0x576F;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void keycode_event_callback(UInt32 keys, UInt32 Fnkeys);

        public static UInt32 HIT_MAX_LIB_VER_STR_LENGTH = 24;
        public static UInt32 HIT_MAX_FW_VER_STR_LENGTH = 16;
        public static UInt32 HIT_MAX_BOARD_NAME_STR_LENGTH = 12;

        public enum led_enum
        {
            POC_LED_PIN1 = 0,
            POC_LED_PIN2,
            POC_LED_PIN3,
            POC_LED_PIN4,
            POC_LED_PIN5,
            POC_LED_PIN6
        };

        [DllImport(DLLName, EntryPoint = "poc_init")]
        public static extern UInt32 poc_init(UInt32 pid);

        [DllImport(DLLName, EntryPoint = "poc_deinit")]
        public static extern UInt32 poc_deinit(UInt32 pid);

        [DllImport(DLLName, EntryPoint = "poc_get_version")]
        public unsafe static extern UInt32 poc_get_version(UInt32 pid, byte[] version);

        [DllImport(DLLName, EntryPoint = "poc_get_firmware_version")]
        public unsafe static extern UInt32 poc_get_firmware_version(UInt32 pid, byte[] version);

        [DllImport(DLLName, EntryPoint = "poc_get_board_name")]
        public unsafe static extern UInt32 poc_get_board_name(UInt32 pid, byte[] name);

        [DllImport(DLLName, EntryPoint = "poc_led_on")]
        public static extern UInt32 poc_led_on(UInt32 pid, led_enum led_id);

        [DllImport(DLLName, EntryPoint = "poc_led_off")]
        public static extern UInt32 poc_led_off(UInt32 pid, led_enum led_id);

        [DllImport(DLLName, EntryPoint = "poc_get_led_status")]
        public static extern UInt32 poc_get_led_status(UInt32 pid, led_enum led_id, out byte status);

        [DllImport(DLLName, EntryPoint = "poc_set_all_led_status")]
        public static extern UInt32 poc_set_all_led_status(UInt32 pid, UInt32 led_num, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] bool[] led_id);

        [DllImport(DLLName, EntryPoint = "poc_get_all_led_status")]
        public static extern UInt32 poc_get_all_led_status(UInt32 pid, UInt32 led_num, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] bool[] led_id);

        [DllImport(DLLName, EntryPoint = "poc_set_keyboard_delay")]
        public static extern UInt32 poc_set_keyboard_delay(UInt32 pid, byte delay);

        [DllImport(DLLName, EntryPoint = "poc_get_keyboard_delay")]
        public static extern UInt32 poc_get_keyboard_delay(UInt32 pid, out byte delay);

        [DllImport(DLLName, EntryPoint = "poc_set_keycode_callback")]
        public static extern UInt32 poc_set_keycode_callback(UInt32 pid, keycode_event_callback fn);
    }
}
