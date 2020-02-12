using C971.Model;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;


namespace C971
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermEditor : ContentPage
    {
               
        public TermEditor()
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

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var terms = conn.Table<Terms>().FirstOrDefault();

                termName.Text = terms.TermName;
                statusPicker.SelectedItem = terms.TermStatus;
                ProjectedStart.Date = terms.TProjStart;
                ProjectedEnd.Date = terms.TActEnd;
                termStart.Date = terms.TActStart;
                termEnd.Date = terms.TActEnd;

            }
        }
        private void updateTermButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {


                var terms = conn.Table<Terms>().FirstOrDefault();

                conn.Query<Terms>("UPDATE Terms SET TermName ='" + termName.Text + "'");
                conn.Query<Terms>("UPDATE Terms SET TermStatus='" + statusPicker.SelectedItem.ToString() + "'");
                conn.Query<Terms>("UPDATE Terms SET TProjStart ='" + ProjectedStart.Date + "'");
                conn.Query<Terms>("UPDATE Terms SET TProjEnd = '" + ProjectedEnd + "'");
                conn.Query<Terms>("UPDATE Terms SET TActSTart = '" + termStart + "'");
                conn.Query<Terms>("UPDATE Terms SET TActEnd = '" + termEnd + "'");

                if (terms.Id == terms.Id)
                {
                    DisplayAlert("Success", "Term Updated Successfully", "Ok");
                    var refresh = new Page1();
                    Navigation.InsertPageBefore(refresh, this);
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "Failed ot Update Term. Please try again", "Ok");
                    return;
                }
            }

        }


        async void CancelTerm(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

    }
}