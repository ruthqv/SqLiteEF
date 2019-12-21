using Data.SqLiteEF;
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
using System.Windows.Shapes;

namespace SqLiteEF
{
    /// <summary>
    /// Lógica de interacción para AgregateWindow.xaml
    /// </summary>
    public partial class AgregateWindow : Window
    {
        private Books book;
        public AgregateWindow(Books book = null)
        {
            InitializeComponent();

            if(book != null)
            {
                this.book = book;
                FillForm();
            }
        }

        private void FillForm()
        {
            txtTitle.Text = book.title;
            txtAuthor.Text = book.author;
            txtPrice.Text = book.price.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtAuthor.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Todos los datos son obligatorios", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTitle.Focus();
                return;
            }

            if (book != null)
            {
                book.title = txtTitle.Text;
                book.author = txtAuthor.Text;
                book.price = float.Parse(txtPrice.Text);

                BookManager.UpdateBook(book);
            }
            else
            {
                var bookNew = new Books()
                {
                    title = txtTitle.Text,
                    author = txtAuthor.Text,
                    price = float.Parse(txtPrice.Text)
                };
                BookManager.InsertBook(bookNew);
            }

            this.Close();
             MainWindow main = new MainWindow();
            main.RefreshDatas();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
