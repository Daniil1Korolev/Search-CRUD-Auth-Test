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

namespace testUsers
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public testdemEntities db = new testdemEntities();
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UserLogin.Text;
            string password = UserPassword.Password;

            var user = db.User.FirstOrDefault(u => u.Login == username && u.Password == password);
            if (user != null)
            {
                switch (user.Role_ID)
                {
                    case 1:
                        new MainWindow().Show();
                        this.Close();
                        break;
                        
                    case 2:
                        new ForUser().Show();
                        this.Close();
                        break;

                   default:
                        MessageBox.Show("Роли нема такой");
                        break;
                      
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
