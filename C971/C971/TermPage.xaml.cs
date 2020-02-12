using C971.Model;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Runtime;


namespace C971
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermPage : ContentPage
    {
       
        public TermPage()
        {
            InitializeComponent();
           
        }

     
        protected override void OnAppearing()
        {
            base.OnAppearing();

                          

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                var terms = conn.Table<Terms>().ToList();
                var courses = conn.Table<Courses>().ToList();

                termTitle.ItemsSource = terms;

                termTitle.HeightRequest = (40 * terms.Count) + (1 * terms.Count);

                pageListing.ItemsSource = courses;
                
                
                termButton.ItemsSource = courses;
                termButton.HeightRequest = (40 * courses.Count) + (6 * courses.Count);




            }
        }

        

        // tapped and clicked events. Need to change alert to action sheet for item tapped
        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");

        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }

        //Context menu items. Need to add more functionality to item selection.

        async void OnEditCourse(Object sender, EventArgs e)
        {

            await Navigation.PushAsync(new CourseEditor());
        }

        private void OnEditStatus(object sender, EventArgs e)
        {

        }

        private void OnCourseNotes(object sender, EventArgs e)
        {


        }

        
       
        private void Button_Clicked(object sender, EventArgs e)
        {
          pageListing.IsVisible = !pageListing.IsVisible;

        }
    }
}

