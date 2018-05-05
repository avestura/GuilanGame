using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GuilanGame.Configurations;
using GuilanGame.DataAccessLayer;
using GuilanGame.Models;
using GuilanGame.Views.Pages;

namespace GuilanGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Returnes current app as an <see cref="App"/> instead of an <see cref="Application"/>
        /// </summary>
        public static App CurrentApp => (App)Current;

        public static MainWindow CastedMainWindow => CurrentApp.MainWindow as MainWindow;

        public static MainMenu MainMenu { get; set; } = new MainMenu();

        /// <summary>
        /// Returens current <see cref="Configuration"/> of application
        /// </summary>
        public Configuration Configuration { get; set; } = new Configuration();

        public RecordData RecordData { get; set; } = new RecordData();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Configuration.InitializeLocalFolder();
            Configuration.LoadSettingsFromFile();

            var faCultureInfo = new CultureInfo("fa-IR");

            CultureInfo.DefaultThreadCurrentCulture = faCultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = faCultureInfo;

            Unosquare.FFME.MediaElement.FFmpegDirectory = $"{AppDomain.CurrentDomain.BaseDirectory}/Assets/Binary/FFMPEG.3.4_win32";

        }
    }
}
