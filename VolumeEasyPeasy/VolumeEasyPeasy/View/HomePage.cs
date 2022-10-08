//AINA WAHIDAH BT OSMAN (1171201426)
//LAW JUNWEI (1171201084)
//PUTERI NURHANIS SHAMIMI MAHZLAN (1171200172)
//DMP5018 Programming in Mobile Apps 
//Group Project
//VolumeEasyPeasy - HomePage.cs [Content Page (C#)]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using VolumeEasyPeasy.View;
using Xamarin.Forms;

namespace VolumeEasyPeasy.View
{
    public class HomePage : ContentPage
    {
        //View declaration
        private Label sphereTitle, cubeTitle, cuboidTitle, pyramidTitle, coneTitle, cylinderTitle;
        private ImageButton Sphere, Cube, Cuboid, Pyramid, Cone, Cylinder;
        public HomePage()
        {
            //Home Page
            Title = "Volume Easy Peasy";
            Padding = 20;
            this.BackgroundColor = Color.AntiqueWhite;

            //Sphere
            Sphere = new ImageButton
            {
                Source = "sphere.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Sphere.Clicked += Sphere_Clicked;

            sphereTitle = new Label
            {
                Text = "Sphere",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            StackLayout stack1 = new StackLayout
            {
                Children =
                {
                    Sphere, sphereTitle
                }
            };

            //Cube
            Cube = new ImageButton
            {
                Source = "cube.jpg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Cube.Clicked += Cube_Clicked;

            cubeTitle = new Label
            {
                Text = "Cube",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            StackLayout stack2 = new StackLayout
            {
                Children =
                {
                    Cube, cubeTitle
                }
            };
                                                                                             
            //Cuboid
            Cuboid = new ImageButton
            {
                Source = "cuboid.jpeg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Cuboid.Clicked += Cuboid_Clicked;

            cuboidTitle = new Label
            {
                Text = "Cuboid",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            StackLayout stack3 = new StackLayout
            {
                Children =
                {
                    Cuboid, cuboidTitle
                }
            };

            //Pyramid
            Pyramid = new ImageButton
            {
                Source = "pyramid.jpg",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Pyramid.Clicked += Pyramid_Clicked;

            pyramidTitle = new Label
            {
                Text = "Pyramid",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            StackLayout stack4 = new StackLayout
            {
                Children =
                {
                    Pyramid, pyramidTitle
                }
            };

            //Cone
            Cone = new ImageButton
            {
                Source = "cone.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Cone.Clicked += Cone_Clicked;

            coneTitle = new Label
            {
                Text = "Cone",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            StackLayout stack5 = new StackLayout
            {
                Children =
                {
                    Cone, coneTitle
                }
            };

            //Cylinder
            Cylinder = new ImageButton
            {
                Source = "cylinder.jpg",
                WidthRequest = 300,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Cylinder.Clicked += Cylinder_Clicked;

            cylinderTitle = new Label
            {
                Text = "Cylinder",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Acme-Regular.ttf#Acme-Regular" : null // set only for Android
            };

            StackLayout stack6 = new StackLayout
            {
                Children =
                {
                    Cylinder, cylinderTitle
                }
            };

            //Home Page Layout
            Grid layout = new Grid
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(300, GridUnitType.Absolute) },
                    new RowDefinition{ Height = new GridLength(300, GridUnitType.Absolute) },
                    new RowDefinition{ Height = new GridLength(300, GridUnitType.Absolute) },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                }
            };

            layout.Children.Add(stack1, 0, 0);
            layout.Children.Add(stack2, 1, 0);
            layout.Children.Add(stack3, 0, 1);
            layout.Children.Add(stack4, 1, 1);
            layout.Children.Add(stack5, 0, 2);
            layout.Children.Add(stack6, 1, 2);

            StackLayout stackLayout = new StackLayout
            {
                Children = 
                {
                    layout
                }
            };
            this.Content = stackLayout;

            ScrollView scrollView = new ScrollView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = stackLayout
            };
            this.Content = scrollView;
        }
        //ImageButton Clicked
        private void Sphere_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sphere());
        }

        private void Cube_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cube());
        }

        private void Cuboid_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cuboid());
        }

        private void Pyramid_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pyramid());
        }

        private void Cone_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cone());
        }

        private void Cylinder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cylinder());
        }
    }
}