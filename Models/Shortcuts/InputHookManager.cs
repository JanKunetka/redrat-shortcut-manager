using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RedRatShortcuts.Models.Shortcuts
{
    /// <summary>
    /// Reads input from the keyboard.
    /// </summary>
    public static class InputHookManager
    {
        private const int WH_KEYBOARD_LL = 13;
            
        private delegate IntPtr LowLevelKeyboardProcess(int nCode, IntPtr wParam, IntPtr lParam);
        public static event Action? OnKeyboardInput;

        private static IntPtr HookID = IntPtr.Zero;
        private static readonly LowLevelKeyboardProcess lowLevelProcess = HookCallback;

        private static bool IsHookSetup { get; set; }

        /// <summary>
        /// Enable the Windows Keyboard Hook.
        /// </summary>
        public static void SetupSystemHook()
        {
            if (IsHookSetup) return;
            HookID = SetHook(lowLevelProcess);
            IsHookSetup = true;
        }

        /// <summary>
        /// Disable the Windows Keyboard Hook.
        /// </summary>
        public static void ShutdownSystemHook()
        {
            if (!IsHookSetup) return;
            UnhookWindowsHookEx(HookID);
            IsHookSetup = false;
        }

        /// <summary>
        /// Sets up a Windows Hook.
        /// </summary>
        /// <param name="process">The process to set the hook for.</param>
        /// <returns></returns>
        private static IntPtr SetHook(LowLevelKeyboardProcess process)
        {
            using Process currentProcess = Process.GetCurrentProcess();
            using ProcessModule? currentModule = currentProcess.MainModule;
            return SetWindowsHookEx(WH_KEYBOARD_LL, process, GetModuleHandle(currentModule.ModuleName), 0);
        }
        
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0) OnKeyboardInput?.Invoke();
            return CallNextHookEx(HookID, nCode, wParam, lParam);
        }
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProcess lpfn, IntPtr hMod, uint dwThreadId);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr UnhookWindowsHookEx(IntPtr hhk);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}