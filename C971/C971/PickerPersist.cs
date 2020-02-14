using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C971.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using C971;

namespace C971
{
    public static class PickerPersist
    {
        public static string PickerSelectedItem = Page1.termPicker.SelectedItem;

    }
}
