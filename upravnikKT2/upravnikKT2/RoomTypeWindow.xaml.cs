﻿using bolnica.Controller;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace upravnikKT2
{
    /// <summary>
    /// Interaction logic for RoomTypeWindow.xaml
    /// </summary>
    public partial class RoomTypeWindow : Window
    {
        private readonly IRoomTypeController _roomTypeController;

        public RoomTypeWindow()
        {
            InitializeComponent();

            var app = Application.Current as App;
            _roomTypeController = app.RoomTypeController;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<String> tipovi = new List<String>();
            //tipovi.Add("magazin");
            //tipovi.Add("operaciona");
            //tipovi.Add("rehabilitaciona");

            //this.lista.ItemsSource = tipovi;

            List<RoomType> roomTypes = new List<RoomType>();
            roomTypes = _roomTypeController.GetAll().ToList();

            ObservableCollection<RoomType> temp = new ObservableCollection<RoomType>(roomTypes);

            listViewRoomTypes.ItemsSource = temp;
            listViewRoomTypes.DisplayMemberPath = "Name";
            listViewRoomTypes.SelectedValuePath = "Id";
            listViewRoomTypes.SelectedValue = "2";


        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AddRoomType dialog = new AddRoomType(listViewRoomTypes);
            dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dialog.ShowDialog();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (listViewRoomTypes.SelectedItem != null)
            {
                AddRoomType dialog = new AddRoomType(listViewRoomTypes, (RoomType)listViewRoomTypes.SelectedItem);
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                dialog.ShowDialog();
            }
            else
            {
                string messageBoxText = "Morate selektovati tip prostorije da biste ga izmenili!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (listViewRoomTypes.SelectedItem != null)
            {
                _roomTypeController.Delete((RoomType)listViewRoomTypes.SelectedItem);


                listViewRoomTypes.ItemsSource = null;

                List<RoomType> roomTypes = new List<RoomType>();
                roomTypes = _roomTypeController.GetAll().ToList();

                ObservableCollection<RoomType> temp = new ObservableCollection<RoomType>(roomTypes);

                listViewRoomTypes.ItemsSource = temp;
                listViewRoomTypes.DisplayMemberPath = "Name";
                listViewRoomTypes.SelectedValuePath = "Id";
                listViewRoomTypes.SelectedValue = "2";
            }
            else
            {
                string messageBoxText = "Morate selektovati tip prostorije da biste ga izbrisali!";
                string caption = "Greska";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                this.Close();
            }
        }
    }
}
