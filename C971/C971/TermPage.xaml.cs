﻿using System;
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
            
            Console.WriteLine(PickerPersist.PickerSelectedItem);
           

        }



    }
}