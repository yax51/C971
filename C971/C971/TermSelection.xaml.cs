using C971.Model;
using SQLite;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace C971
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        public Page1()
        {
            InitializeComponent();


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Terms>();
                conn.CreateTable<Courses>();
                conn.CreateTable<Assessments>();

                var terms = conn.Table<Terms>().ToList();
                var courses = conn.Table<Courses>().ToList();
                var assessments = conn.Table<Assessments>().ToList();

                termPicker.ItemsSource = terms;


                var dateNow = DateTime.Now;
                if (!terms.Any())
                {
                    conn.Insert(new Terms
                    {
                        TermName = "Demo Term",
                        TermStatus = "In Progress",
                        TProjStart = dateNow,
                        TProjEnd = dateNow,
                        TActStart = dateNow,
                        TActEnd = dateNow,
                        
                    });
                }
                if (!courses.Any())
                {

                    conn.Insert(new Courses
                    {
                        CourseName = "Demo Course",
                        CourseStatus = "Completed",
                        CourseStart = dateNow,
                        CourseEnd = dateNow,
                        InstructName = "Patrick Davis",
                        InstructEmail = "pdavi80@wgu.edu",
                        InstructPhone = "509-608-7131",
                        Notes = "Some notes regarding this course",
                        CObjStart = dateNow,
                        CObjEnd = dateNow,
                        CPerStart = dateNow,
                        CPerEnd = dateNow,

                    });
                }
                if (!assessments.Any())
                {
                    conn.Insert(new Assessments
                    {
                        AssessCourse = "Demo Course",
                        AssessType = "Objective",
                        ObjAssessName = "Demo Objective",
                        ObjAssessStart = dateNow,
                        ObjAssessEnd = dateNow,
                        PerAssessName = "Performance",
                        PerAssessStart = dateNow,
                        PerAssessEnd = dateNow
                    });
                }

            }

        }

            //Displays actionsheet with the selected Term info
            void InfoClicked(Object sender, EventArgs e)

            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {

                var terms = conn.Table<Terms>().FirstOrDefault();

              var pickerItem = termPicker.Items[termPicker.SelectedIndex];

                

                    

                    DisplayActionSheet(pickerItem, "Ok", null, "Term Status: " + terms.TermStatus,
                    "Projected Start: " + terms.TProjStart.ToString(),
                    "Projected End: " + terms.TProjEnd.ToString(),
                    "Actual Start: " + terms.TActStart.ToString(),
                    "Actual End : " + terms.TActEnd.ToString());


                }

            }



            //Navigates to the TermEditor page to input Term information
            void AddClicked(object sender, EventArgs e)
            {
                Navigation.PushAsync(new AddTermPage());

            }

            //Popup to confirm deletion  
            async void RemoveClicked(object sender, EventArgs e)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    Terms _terms = new Terms();
                    bool answer = await DisplayAlert("Are you sure?", "Are you sure you want to remove this Term?", "Yes", "No");

                    if (answer == true)
                    {
                        //Need to delete only selected item
                        conn.Execute("DELETE FROM Terms");
                        //back up to clear all data
                        conn.Execute("DELETE FROM Courses");
                        var refresh = new Page1();
                        Navigation.InsertPageBefore(refresh, this);
                        await Navigation.PopAsync();

                    }
                    else
                    {
                        await Navigation.PopAsync();
                    }
                }

            }

            void TermGoClicked(object sender, EventArgs e)
            {

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {

                    var terms = conn.Table<Terms>().FirstOrDefault();
                    var courses = conn.Table<Courses>().FirstOrDefault();

                    //var pickerItem = termPicker.Items[termPicker.SelectedIndex];


                    //courses.PickerItem = pickerItem;
                    //terms.PickerItem = pickerItem;
                    conn.Update(courses);
                    conn.Update(terms);

                    Navigation.PushAsync(new TermPage());
                }

            }

            void EditClicked(object sender, EventArgs e)
            {
                Navigation.PushAsync(new TermEditor());
            }
          
    }
}










