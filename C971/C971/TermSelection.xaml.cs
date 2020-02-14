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
using C971.Properties;

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
                var courses = conn.Table<Courses>().ToList().FirstOrDefault();
                var assessments = conn.Table<Assessments>().ToList().FirstOrDefault();

                termPicker.ItemsSource = terms;


                if (!terms.Any())
                {
                    conn.Insert(new Terms
                    {
                        TermName = "Demo Term",
                        TermStatus = "In Progress",
                        TProjStart = new DateTime(2020, 1, 1),
                        TProjEnd = new DateTime(2020, 5, 28),
                        TActStart = new DateTime(2020, 1, 1),
                        TActEnd = new DateTime(2020, 5, 15)
                    });
                    if (courses.Id == 0)
                    {
                        conn.Insert(new Courses
                        {
                            CourseName = "Demo Course",
                            CourseStatus = "Completed",
                            CourseStart = new DateTime(2020, 1, 1),
                            CourseEnd = new DateTime(2020, 1, 31),
                            InstructName = "Patrick Davis",
                            InstructEmail = "pdavi80@wgu.edu",
                            InstructPhone = "509-608-7131",
                            Notes = "Some notes regarding this course",

                        });
                    }
                    if (assessments.Id == 0)
                    {
                        conn.Insert(new Assessments
                        {
                            AssessCourse = courses.CourseName,
                            AssessType = "Objective",
                            ObjAssessName = "Demo Objective",
                            PerAssessName = "Performance",
                            CObjStart = new DateTime(2020, 1, 29),
                            CObjEnd = new DateTime(2020, 1, 29),
                            CPerStart = new DateTime(2020, 1, 30),
                            CPerEnd = new DateTime(2020, 1, 31),
                        });
                    }

                }

            }
        }

        //Displays actionsheet with the selected Term info
        void InfoClicked(Object sender, EventArgs e)
        {
            var terms = (Terms)termPicker.SelectedItem;
            string pattern = "MM/dd/yyyy";
            if (terms == null)
            {
                DisplayAlert("Error", "Please Select a term", "Ok");
            }
            else
            {
                DisplayActionSheet(terms.TermName, "Ok", null, "Term Status: " + terms.TermStatus,
                "Projected Start: " + terms.TProjStart.ToString(pattern),
                "Projected End: " + terms.TProjEnd.ToString(pattern),
                "Actual Start: " + terms.TActStart.ToString(pattern),
                "Actual End : " + terms.TActEnd.ToString(pattern));


            }



        }




        void AddClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTermPage());

        }

        //Popup to confirm deletion  
        async void RemoveClicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var selectedTerm = (Terms)termPicker.SelectedItem;
                var courses = conn.Table<Courses>().FirstOrDefault();

                courses.TermId = selectedTerm.Id;

                bool answer = await DisplayAlert("Are you sure?", "Are you sure you want to remove this Term?", "Yes", "No");

                if (answer == true)
                {

                    conn.Execute($"DELETE FROM Terms WHERE '{selectedTerm.Id}' = Id ");

                    conn.Execute($"DELETE FROM Courses WHERE '{selectedTerm.Id}' = '{courses.TermId}'");
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
            var selectedTerm = (Terms)termPicker.SelectedItem;
            if (selectedTerm == null)
            {
                DisplayAlert("Error", "Please Select a term", "Ok");
            }
            else
            {


                Navigation.PushAsync(new TermPage());
            }



        }



        void EditClicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var selectedTerm = (Terms)termPicker.SelectedItem;
                if (selectedTerm == null)
                {
                    DisplayAlert("Error", "Please Select a term", "Ok");
                }
                else
                {
                    Navigation.PushAsync(new TermEditor());
                }
            }


        }
    }
}










