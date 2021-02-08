using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamThemes
{
   public partial class App : Application
   {
      public App()
      {
         InitializeComponent();

         var theme = Preferences.Get("OSAppTheme", Enum.GetName(typeof(OSAppTheme), OSAppTheme.Unspecified));
         App.Current.UserAppTheme = (OSAppTheme)Enum.Parse(typeof(OSAppTheme), theme);

         MainPage = new MainPage();
      }
   }
}
