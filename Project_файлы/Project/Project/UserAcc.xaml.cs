using Project.Control;
using Project.Data;
using Project.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace Project
{

    public partial class UserAcc : UserControl
    {
        public SqlConnection sqlConnection = null;



        ControlAcc control;

        public UserAcc()
        {
            InitializeComponent();
            control = new ControlAcc();

           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAccounts();

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);

            sqlConnection.Open();


        }

        private void LoadAccounts()
        {
            var accounts = control.GetAccountList();

            if (accounts.Count > 0)
            {
                ListViewAcc.ItemsSource = accounts;
                TextBlockAccountsEmpty.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlockAccountsEmpty.Visibility = Visibility.Visible;
            }

            TextBlockTotal.Text = accounts.Sum(a => a.Account.Amount).ToString("C");
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Acc] (Name, Amount) VALUES (@Name, @Amount)", sqlConnection);

            command.Parameters.AddWithValue("Name", TextBoxName.Text);
            command.Parameters.AddWithValue("Amount", TextBoxInitialAmount.Text);




            MessageBox.Show(command.ExecuteNonQuery().ToString("Успешно"));

             





      





            var messageQueue = SnackbarThree.MessageQueue;
            if (TextBoxName.Text == string.Empty)
            {
                TextBoxName.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("введите корректное имя"));
                return;
            }

            if (TextBoxInitialAmount.Text == string.Empty)
            {
                TextBoxInitialAmount.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("введите корректное число"));
                return;
            }

            string name = TextBoxName.Text;
            Double initialValue = Double.Parse(TextBoxInitialAmount.Text, NumberStyles.Currency);

            control.SaveAccount(name, initialValue);
            LoadAccounts();

            TextBoxName.Text = string.Empty;
            TextBoxInitialAmount.Text = string.Empty;
        }

        private void TextBoxInitialValue_LostFocus(object sender, RoutedEventArgs e)
        {
            Double.TryParse(TextBoxInitialAmount.Text, out double result);

            if (!(new Regex(@"\d+(,\d{1,2})?")).Match(result.ToString()).Success)
            {
                TextBoxInitialAmount.Text = string.Empty;
            }
            else
            {
                TextBoxInitialAmount.Text = result.ToString("C");
            }
        }

        private void TextBoxInitialValue_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxInitialAmount.Text = string.Empty;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                control.Delete(((Button)sender).DataContext);
                LoadAccounts();
            }
            catch (Exep)
            {
                var messageQueue = SnackbarThree.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Ошибка"));
            }
        }
    }
}
