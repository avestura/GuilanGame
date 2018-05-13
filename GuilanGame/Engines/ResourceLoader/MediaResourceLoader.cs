using GuilanGame.Extensions;
using GuilanGame.Views.Pages.Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Media;
using System.Windows.Navigation;
using Unosquare.FFME;
using System.Windows.Media;
using System.Diagnostics;
using GuilanGame.Views.Pages.Extension;
using GuilanGame.Views.Pages;
using System.Windows.Controls;
using GuilanGame.Views.Pages.Questions;

namespace GuilanGame.Engines.ResourceLoader
{
    public class MediaResourceLoader : IResourceLoader
    {
        public void Preload()
        {
            LoadPages();
        }

        private void LoadPages()
        {
            var loadWin = new NavigationWindow();

            Uri[] pagesToLoad = {
                //nameof(MainMenu).PageLocalUri(),
                //nameof(Intro).PageLocalUri(),
                nameof(About).PageLocalUri("Main/"),
                nameof(MasterPage).PageLocalUri("Main/"),
                nameof(Scoreboard).PageLocalUri("Main/"),
                nameof(Settings).PageLocalUri("Main/"),
                nameof(University).PageLocalUri("Main/"),
                nameof(QuestionLoader).PageLocalUri("Main/"),
                nameof(LoadingPage).PageLocalUri("Extension/"),
                nameof(Question1).PageLocalUri("Questions/"),
                nameof(Question2).PageLocalUri("Questions/"),
                nameof(Question3).PageLocalUri("Questions/"),
                nameof(Question4).PageLocalUri("Questions/"),
                nameof(Question5).PageLocalUri("Questions/"),
                nameof(Question6).PageLocalUri("Questions/"),
                nameof(Question7).PageLocalUri("Questions/"),
                nameof(Question8).PageLocalUri("Questions/"),
                nameof(Question9).PageLocalUri("Questions/"),
            };

            foreach (var page in pagesToLoad)
            {

                Application.LoadComponent(page);

#if DEBUG
                Console.WriteLine($"loaded {page.OriginalString}");
#endif
            }

            LoadMedia();

        }

        private void LoadMedia()
        {

            var loadMediaElement = new MediaPlayer
            {
                Volume = 0,
                IsMuted = true,

            };

            var media1 = new TaggedUri($"{Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)}\\Assets\\Media\\Video\\GameIntro 1920x1080.mp4");
            var media2 = new TaggedUri($"{Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)}\\Assets\\Media\\Video\\Guilan Trailer.mp4");
            var media3 = new TaggedUri($"{Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)}\\Assets\\Media\\Sound\\Music.mp3");

            TaggedUri[] mediasToLoad = { media3, media2, media1 };

            foreach (var media in mediasToLoad)
            {
                loadMediaElement.Open(media);
                while (loadMediaElement.IsBuffering) { }
                loadMediaElement.Close();
            }

        }

    }
}
