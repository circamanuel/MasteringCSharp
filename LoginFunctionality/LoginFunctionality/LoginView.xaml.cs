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

namespace LoginFunctionality
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public void OnLoginBtnClicked(object sender, RoutedEventArgs e)
        {
            string passwordEntered = PasswordBox.Password;

            String envPW = Environment.GetEnvironmentVariable("InvoiceManagement");

            if (envPW != null)
            {
                if (passwordEntered == envPW)
                {
                    MessageBox.Show("Entered correct Password");
                    Window window = Window.GetWindow(this);
                    window.Content = new PersonData();
                }
                else
                {
                    MessageBox.Show("Entered wrong Password");
                }
            }
            else
            {
                MessageBox.Show("Envoironment variable not found");
            }
        }

        public void OnPasswordChanged(object sender, EventArgs e)
        {
            LoginButton.IsEnabled = !string.IsNullOrEmpty(PasswordBox.Password);
        }
    }
}
