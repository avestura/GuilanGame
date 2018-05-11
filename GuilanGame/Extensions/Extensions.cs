using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;

namespace GuilanGame.Extensions
{
    public static class Extensions
    {

        public static Uri PageLocalUri(this string name, string locator = "") => new Uri($"/Views/Pages/{locator}{name}.xaml", UriKind.Relative);

    }
}
