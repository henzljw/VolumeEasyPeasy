//AINA WAHIDAH BT OSMAN (1171201426)
//LAW JUNWEI (1171201084)
//PUTERI NURHANIS SHAMIMI MAHZLAN (1171200172)
//DMP5018 Programming in Mobile Apps 
//Group Project
//VolumeEasyPeasy - Cube.cs [Content Page (C#)]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using VolumeEasyPeasy.Model;
using System.IO;
using Xamarin.Forms;

namespace VolumeEasyPeasy.View
{
    public class Cube : ContentPage
    {
        //View declaration
        private Label edgeTitle, resultTitle, Result, formulaTitle;
        private Entry Edge;
        private Button Equal, History;
        private Image sphereFormula;
        private Frame frame;
        private StackLayout stack1, stack2, stack3, sphereLayout;

        //Set DB path
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public Cube()
        {
            //Cube Page
            Title = "Cube";
            Padding = 20;
            this.BackgroundColor = Color.AntiqueWhite;

            edgeTitle = new Label()
            {
                Text = "Edge",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            Edge = new Entry()
            {
                Placeholder = "0.00",
                FontSize = 30,
                WidthRequest = 200,
                Keyboard = Keyboard.Numeric,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "BalooBhai-Regular.ttf#BalooBhai-Regular" : null // set only for Android
            };

            Equal = new Button();
            Equal.Text = "=";
            Equal.FontSize = 20;
            Equal.FontFamily = Device.RuntimePlatform == Device.Android ? "Product Sans Bold.ttf#Product Sans Bold" : null; // set only for Android

            Equal.Clicked += Equal_Clicked;

            stack1 = new StackLayout
            {
                Children =
                {
                    edgeTitle, Edge, Equal
                }
            };

            resultTitle = new Label()
            {
                Text = "Result",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            Result = new Label()
            {
                Text = "0.00",
                FontSize = 30,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                FontFamily = Device.RuntimePlatform == Device.Android ? "BalooBhai-Regular.ttf#BalooBhai-Regular" : null // set only for Android
            };

            stack2 = new StackLayout
            {
                Children =
                {
                    resultTitle, Result
                }
            };

            formulaTitle = new Label()
            {
                Text = "Formula",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            sphereFormula = new Image()
            {
                Source = "cube_formula.png",
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            stack3 = new StackLayout
            {
                Children =
                {
                    formulaTitle, sphereFormula
                }
            };

            History = new Button()
            {
                Text = "History",
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Product Sans Bold.ttf#Product Sans Bold" : null // set only for Android
            };
            History.Clicked += History_Clicked;

            //Sphere Layout
            Grid layout = new Grid
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(150, GridUnitType.Absolute) },
                    new RowDefinition{ Height = new GridLength(100, GridUnitType.Absolute) },
                    new RowDefinition{ Height = new GridLength(150, GridUnitType.Absolute) },
                },
            };

            layout.Children.Add(stack1, 0, 0);
            layout.Children.Add(stack2, 0, 1);
            layout.Children.Add(stack3, 0, 2);

            sphereLayout = new StackLayout
            {
                Children = {
                    layout, History
                }
            };

            Content = sphereLayout;

            frame = new Frame
            {
                BackgroundColor = Color.LightPink,
                Content = sphereLayout,
            };

            Content = frame;
        }

        //Equal clicked
        private void Equal_Clicked(object sender, EventArgs e)
        {
            double x = Double.Parse(Edge.Text);
            Result.Text = (x * x * x).ToString("00.00");
            //Store data into database
            var db = new SQLiteConnection(dbPath);

            db.CreateTable<CubeModel>();

            CubeModel obj = new CubeModel();
            obj.Edge = Convert.ToDouble(Edge.Text);
            obj.Total = Convert.ToDouble(Result.Text);

            db.Insert(obj);
        }

        //History clicked 
        private void History_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CubeHistory());
        }
    }
}