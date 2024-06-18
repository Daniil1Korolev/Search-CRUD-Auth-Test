using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testUsers
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public testdemEntities db = new testdemEntities();
        public MainWindow()
        {
            InitializeComponent();
            Data_Reload();
        }

        public void Data_Reload()
        {
            var UserList = db.User.ToList();
            dgUsers.SelectedValuePath = "ID";
            dgUsers.ItemsSource = UserList;
            dgUsers.SelectionMode = DataGridSelectionMode.Single;

            var OfficeList = db.Office.ToList();
            Office.SelectedValuePath = "ID";
            Office.ItemsSource = OfficeList;
            Office.SelectedIndex = 0;
            Office.DisplayMemberPath = "NameOffice";

            Function function = new Function();

            CountUser.Text = function.CountUsers().ToString();

        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                User selectedItem = (User)dgUsers.SelectedItem; 
                Login.Text = selectedItem.Login;
                Password.Text = selectedItem.Password;
                Office.SelectedItem = selectedItem.Role;
                if(selectedItem.Role_ID == 1)
                {
                    Role.IsChecked = true;
                }
                else
                {
                    Role.IsChecked = false;
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItem != null)
            {
                User selectedItem = (User)dgUsers.SelectedItem;
                selectedItem.Login = Login.Text;
                selectedItem.Password = Password.Text;
                selectedItem.Office = (Office)Office.SelectedItem;
               

                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Запись обновлена");
                    Data_Reload();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка");
                }

            }
            else
            {
                MessageBox.Show("Выберите запись для удаления");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(dgUsers.SelectedItems != null)
            {
                User selectedItem = (User)dgUsers.SelectedItem;
                db.User.Remove(selectedItem);
                db.SaveChanges();
                Data_Reload();

            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var UserList = db.User.Where(a => a.Login.Contains(Search.Text)).ToList();
            dgUsers.SelectedValuePath = "ID";
            dgUsers.ItemsSource = UserList;
            dgUsers.SelectionMode = DataGridSelectionMode.Single;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Login = Login.Text,
                Password = Password.Text,
                Office_ID = (int)Office.SelectedValue,
                Role_ID = (bool)Role.IsChecked ? 1 : 2,

            };
            db.User.Add(user);
            try
            {
                db.SaveChanges();
            }
            catch
            {

            }
            Data_Reload();

        }
        
        }
    }

