using MvvmHelpers;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamThemes.ViewModel
{
   public class MainViewModel : BaseViewModel
   {
      public MainViewModel()
      {
         var theme = Preferences.Get("OSAppTheme", Enum.GetName(typeof(OSAppTheme), Xamarin.Forms.OSAppTheme.Unspecified));
         OSAppTheme = (int)Enum.Parse(typeof(OSAppTheme), theme);
      }

      public ObservableCollection<string> Themes => new ObservableCollection<string> { "System Default", "Light", "Dark" };

      int osAppTheme;
      public int OSAppTheme
      {
         get => osAppTheme;
         set
         {
            if (osAppTheme == value)
            {
               return;
            }

            Preferences.Set("OSAppTheme", Enum.GetName(typeof(OSAppTheme), value));
            App.Current.UserAppTheme = (OSAppTheme)value;
            SetProperty(ref osAppTheme, value);
         }

      }
   }
}
