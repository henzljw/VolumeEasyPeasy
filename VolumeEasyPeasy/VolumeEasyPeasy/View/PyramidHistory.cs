//AINA WAHIDAH BT OSMAN (1171201426)
//LAW JUNWEI (1171201084)
//PUTERI NURHANIS SHAMIMI MAHZLAN (1171200172)
//DMP5018 Programming in Mobile Apps 
//Group Project
//VolumeEasyPeasy - PyramidHistory.cs [Content Page (C#)]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolumeEasyPeasy.Model;
using SQLite;
using Xamarin.Forms;
using System.IO;

namespace VolumeEasyPeasy.View
{
    public class PyramidHistory : ContentPage
    {
        private ListView historyList;
        private Button Delete;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        PyramidModel obj = new PyramidModel();
        public PyramidHistory()
        {
            //History Page
            Title = "History";
            Padding = 20;
            this.BackgroundColor = Color.AntiqueWhite;
            var db = new SQLiteConnection(dbPath);

            historyList = new ListView();
            historyList.ItemsSource = db.Table<PyramidModel>().ToList();
            historyList.ItemTapped += historyList_ItemTapped;

            Delete = new Button();
            Delete.Text = "Delete";
            Delete.Clicked += Delete_Clicked;
            Delete.FontFamily = Device.RuntimePlatform == Device.Android ? "Product Sans Bold.ttf#Product Sans Bold" : null; // set only for Android

            Content = new StackLayout
            {
                Children =
                {
                    historyList, Delete
                }
            };
        }

        private void historyList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            obj = (PyramidModel)e.Item;
        }

        //Delete Clicked function
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            if (obj.Id != 0)
            {
                if (await DisplayAlert("Delete History", "Confirm delete ID: " + obj.Id + "?", "Yes", "No"))
                {
                    db.Table<PyramidModel>().Delete(x => x.Id == obj.Id);
                    await DisplayAlert("Delete History", "ID: " + obj.Id + " deleted", "Ok");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Nothing Selected", "Please select one of the history to delete", "Ok");
            }
        }
    }
}