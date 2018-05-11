using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Media;
using GuilanGame.Configurations;
using GuilanGame.DataAccessLayer;
using GuilanGame.Engines.ResourceLoader;
using GuilanGame.Models;
using GuilanGame.Views.Pages;
using Unosquare.FFME;

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

        public RecordData RecordData { get; set; }

        public RecordItem CurrentRecord { get; set; }

        public ManualResetEvent MediaResourceLoaderEvent { get; set; } = new ManualResetEvent(false);

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Configuration.InitializeLocalFolder();
            Configuration.LoadSettingsFromFile();

            RecordData = new RecordData();

            var faCultureInfo = new CultureInfo("fa-IR");

            CultureInfo.DefaultThreadCurrentCulture = faCultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = faCultureInfo;

            Unosquare.FFME.MediaElement.FFmpegDirectory = $"{Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)}\\Assets\\Binary\\FFMPEG.3.4.2_win32";

        }

        private bool loadOnce = false;
        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (!loadOnce)
            {
                new MediaResourceLoader().Preload();
                loadOnce = true;
            }

        }
    }

}
