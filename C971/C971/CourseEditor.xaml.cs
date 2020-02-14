using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using C971.Model;
using System.Collections;
using System.Collections.ObjectModel;

namespace C971
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseEditor : ContentPage
    {
        public CourseEditor()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var statusItems = new ObservableCollection<String>();
            statusItems.Add("In Progress");
            statusItems.Add("Completed");
            statusItems.Add("Not Started");
            statusItems.Add("On Hold");
            statusPicker.ItemsSource = statusItems;
        }

        public void SaveCourse(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var courses = conn.Table<Courses>().FirstOrDefault();
                var assessment = conn.Table<Assessments>().FirstOrDefault();
                           
                    conn.Insert(new Courses
                    {
                        CourseName = CourseName.Text,
                        CourseStatus = statusPicker.SelectedItem.ToString(),
                        CourseStart = courseStart.Date,
                        CourseEnd = courseEnd.Date,
                        InstructName = InstructorName.Text,
                        InstructPhone = InstructorPhone.Text,
                        InstructEmail = InstructorEmail.Text,
                        Notes = notes.Text,
                        
                    });

                conn.Insert(new Assessments
                {
                    ObjAssessName = ObjectiveName.Text,
                    CObjStart = ObjectiveStart.Date,
                    CObjEnd = ObjectiveEnd.Date,
                    PerAssessName = PerformanceName.Text,
                    CPerStart = PerformanceStart.Date,
                    CPerEnd = PerformanceEnd.Date
                });

                    if (courses.Id > 0)
                    {
                        DisplayAlert("Success", "Courses Saved. Click NEXT to add another course. Click DONE to finish adding courses", "Ok");
                        NextButton.IsVisible = true;
                        doneButton.IsVisible = true;
                        saveButton.IsVisible = false;
                        CancelButton.IsVisible = false;

                    }
                    if (assessment.Id > 0)
                    {
                    DisplayAlert("Success", "Courses Saved. Click NEXT to add another course. Click DONE to finish adding courses", "Ok");
                    NextButton.IsVisible = true;
                    doneButton.IsVisible = true;
                    saveButton.IsVisible = false;
                    CancelButton.IsVisible = false;

                    }
                    else
                    {
                        DisplayAlert("Error", "Course not save. Please try again", "Ok");
                        return;
                    }
            }
        }

        
        private void CancelCourse(object sender, EventArgs e)
        {
            DisplayAlert("Canceled", "Canceled", "Ok");
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            var refresh = new CourseEditor();
            Navigation.InsertPageBefore(refresh, this);
            Navigation.PopAsync();
        }

        private void doneButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }
    }
}