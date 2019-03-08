using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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

namespace windowsApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            buttonSignUp.IsEnabled = false;
            invalidEmail.Visibility = Visibility.Hidden;
        }
        private void SignUpButton(object sender, RoutedEventArgs e)
        {
            String names = ("Name: " + firstName.Text.ToString() + " " + lastName.Text.ToString());
            String email = ("\r\nEmail: " + emailAddress.Text.ToString());
            String passwd = ("\r\nPassword: " + passwordFirst.Password.ToString());
            String creds = (names + email + passwd);
            MailAddress emailParse = new MailAddress(email, names);
            String fileName = emailParse.User;
            int sameNameTicker = 1;
            if(File.Exists("C:/Users/JP/Desktop/credsFolder/creds" + fileName + ".txt"))
            {
                File.WriteAllText("C:/Users/JP/Desktop/credsFolder/creds" + fileName + sameNameTicker + ".txt", creds);
            } else
            {
                File.WriteAllText("C:/Users/JP/Desktop/credsFolder/creds" + fileName + ".txt", creds);
            }
            new MainWindow().Show();
            this.Close();
        
        }

        private void PasswordSecond_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if(!(passwordFirst.Password == passwordSecond.Password))
            {
                MessageBox.Show("Passwords do not match!");
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if((string.IsNullOrWhiteSpace(firstName.Text) || string.IsNullOrWhiteSpace(lastName.Text) || string.IsNullOrWhiteSpace(emailAddress.Text) || 
                string.IsNullOrWhiteSpace(passwordFirst.Password) || string.IsNullOrWhiteSpace(passwordSecond.Password)))
            {
                alertBlock(StopIt, "Add missing info!");
                StopIt.TextAlignment = TextAlignment.Center;
            } else
            {
                StopIt.Visibility = Visibility.Hidden;
                buttonSignUp.IsEnabled = true;
            }
        }

        private void EmailAddress_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(emailAddress.Text.Contains("@")))
            {
                alertBlock(invalidEmail, "Invalid email address!");
                invalidEmail.TextAlignment = TextAlignment.Left;
            }
        }
        private void alertBlock(TextBlock textBlock, String contentForBlock)
        {
            TextBlock textBlockVoid = textBlock;
            String contentBlock = contentForBlock;
            textBlockVoid.Foreground = Brushes.Red;
            textBlockVoid.Text = contentBlock;
            textBlockVoid.Visibility = Visibility.Visible;
        }
    }
}
