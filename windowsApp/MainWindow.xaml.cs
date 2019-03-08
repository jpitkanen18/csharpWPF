using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace windowsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "testWPF";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        public string PlaceholderText { get; set; }
        public static DependencyProperty PlaceholderTextProperty { get; }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();

        }
        private void FirstButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The App will close");
            this.Close();
        }
        private void SecondButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDiag = new OpenFileDialog();
            openDiag.ShowDialog();
        }
        private void ThirdButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDiag = new SaveFileDialog();
            saveDiag.ShowDialog();
        }
        private void SignupClick(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            this.Close();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            String email = emailBox.Text.ToString();
            int ticker = 1;
            String passwd = passwordBox.Password.ToString();
            String creds = (email + "\r\n" + (passwd));
            PlaceHolderMemme.Text = "Your email is " + email.ToString();
            if (File.Exists("C:/Users/JP/Desktop/creds.txt"))
            {
                File.WriteAllText("C:/Users/JP/Desktop/creds" + ticker + ".txt", creds.ToString());
            }
            else
            {
                File.WriteAllText("C:/Users/JP/Desktop/creds.txt", (creds.ToString()));
            }
            if(!(string.IsNullOrWhiteSpace(emailBox.Text) || string.IsNullOrWhiteSpace(passwordBox.Password)))
            {
                if (emailBox.Text.Contains("@") && emailBox.Text.Contains("."))
                {
                    MailAddress loginMail = new MailAddress(emailBox.Text, "blank");
                    if (File.Exists("C:/Users/JP/Desktop/credsFolder/creds" + loginMail.User + ".txt"))
                    {
                        var file = File.ReadAllText("C:/Users/JP/Desktop/credsFolder/creds" + loginMail.User + ".txt");
                        if (file.Contains("Password: " + passwordBox.Password.ToString()))
                        {
                            new Window2(file).Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login credintentials");
                        }
                        Console.WriteLine(loginMail.User);
                        Console.WriteLine(file.ToString());
                    }
                    else
                    {
                        MessageBox.Show("You have to sign up first!");
                    }
                } else
                {
                }

            }
        }
    }
}
