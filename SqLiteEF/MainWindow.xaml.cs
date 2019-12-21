﻿using Data.SqLiteEF;
using SqLiteEF.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqLiteEF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Data(object sender, RoutedEventArgs e)
        {
            RefreshDatas();
        }

        public void RefreshDatas()
        {
            DG.ItemsSource = BookManager.GetAllBooks();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AgregateWindow win = new AgregateWindow();
            win.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

           Books book = (Books)DG.SelectedItem;

       
                if (MessageBox.Show("¿Desea eliminar este libro?", "Eliminar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    BookManager.DeleteBook(book);
                }
       
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Books book = (Books)DG.SelectedItem;
            AgregateWindow win = new AgregateWindow(book);
            win.ShowDialog();
        }
        private void Edit_Delete(object sender, SelectedCellsChangedEventArgs e)
        {
            Books book = (Books)DG.SelectedItem;

            if (book != null)
            {
                BtnEdit.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
            }
            else
            {
                BtnEdit.Visibility = Visibility.Hidden;
                BtnDelete.Visibility = Visibility.Hidden;
            }

        }
    }
}
