using System.Windows;
using RedRatShortcuts.ViewModels;
using RedRatShortcuts.Views.SystemTray;

namespace RedRatShortcuts.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainVM mainDataContext;
        private SystemTrayMenu systemTray;

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            
            systemTray = new SystemTrayMenu(MainWindow);
            systemTray.OnExit += Current.Shutdown;
            systemTray.OnShow += ShowWindow;
            
            mainDataContext = new MainVM();
            MainWindow.DataContext = mainDataContext;
            MainWindow.Show();
            
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            mainDataContext.Exit();
            systemTray.Exit();
            base.OnExit(e);
        }

        /// <summary>
        /// Show the Main Window.
        /// </summary>
        private void ShowWindow()
        {
            MainWindow.Show();
            MainWindow.WindowState = WindowState.Normal;
        }
    }
}