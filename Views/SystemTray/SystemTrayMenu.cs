using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace RedRatShortcuts.Views.SystemTray
{
    /// <summary>
    /// Controls the System Tray Menu.
    /// </summary>
    public class SystemTrayMenu
    {
        public event Action OnShow;
        public event Action OnExit;
        
        private readonly NotifyIcon notifyIcon;
        private readonly Window window;

        public SystemTrayMenu(Window mainWindow)
        {
            window = mainWindow;
            
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon(@"..\..\..\..\Views\Resource\img\icon_App.ico");
            notifyIcon.Text = "RedRat Shortcut Manager";
            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Open", null, (_,__) => OnShow?.Invoke());
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, (_,__) => OnExit?.Invoke());

            notifyIcon.DoubleClick += WhenDoubleClick;
        }

        public void Exit() => notifyIcon.Dispose();
        
        private void WhenDoubleClick(object? sender, EventArgs e)
        {
            window.Show();
            window.WindowState = WindowState.Normal;
            window.Activate();
        }
        

    }
}