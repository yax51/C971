using C971.Model;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace C971
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTermPage : ContentPage
    {
        public AddTermPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var statusItems = new ObservableCollection<String>();
            statusItems.Add("In Progress");
            statusItems.Add("Completed");
            statusItems.Add("Not Started");
            statusItems.Add("On Hold");
            statusPicker.ItemsSource = statusItems;

        }

        private void SaveTerm(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var terms = conn.Table<Terms>().FirstOrDefault();

                conn.Insert(new Terms

                {
                    TermName = termName.Text,
                    TermStatus = statusPicker.SelectedItem.ToString(),
                    TProjStart = ProjectedStart.Date,
                    TProjEnd = ProjectedEnd.Date,
                    TActStart = termStart.Date,
                    TActEnd = termEnd.Date
                });
                if (terms.Id > 0)
                {

                    DisplayAlert("Success", "Term Added Successfully. Press NEXT to add Courses, or click DONE to be finished.", "Ok");
                    next.IsVisible = true;
                    SaveTermButton.IsVisible = false;
                    CancelTermButton.IsVisible = false;
                    done.IsVisible = true;


                }
                else
                {
                    DisplayAlert("Error", "Term failed to be added", "Ok");
                    return;
                }

            }
        }

        private void CancelTerm(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }

        private void next_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseEditor());
        }

        private void done_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}