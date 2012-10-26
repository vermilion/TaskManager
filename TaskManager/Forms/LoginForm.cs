using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Model;
using TaskManager.Properties;

namespace TaskManager.Forms
{
    public partial class LoginForm : Form
    {
        private readonly SqliteCommunicator _communicator = new SqliteCommunicator();

        public LoginForm()
        {
            InitializeComponent();
            checkBox1.Checked = bool.Parse(ConfigurationManager.AppSettings["save"]);
            LoginTextBox.Text = ConfigurationManager.AppSettings["login"];
            PasswordTextBox.Text = ConfigurationManager.AppSettings["pass"];

            _communicator.UpgradeDatabase();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var pass = Regex.IsMatch(PasswordTextBox.Text, "[0-9a-fA-F]{32}")
                           ? PasswordTextBox.Text
                           : ComputeMd5Checksum(PasswordTextBox.Text);

            User user = _communicator.GetList<User>("Users")
                .FirstOrDefault(x => x.Login == LoginTextBox.Text && x.Pass == pass);

            if (user == null)
                MessageBox.Show(Resources.Try_again, Resources.Wrong_login_pass);
            else
            {
                if (checkBox1.Checked)
                {
                    DataClass.SaveSettings("login", LoginTextBox.Text);
                    DataClass.SaveSettings("pass", pass);
                }

                MessageBox.Show(Resources.logged_in_as + user.ShowAs);
                UserData.UserName = user.ShowAs;
                DialogResult = DialogResult.OK;
            }
        }


        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LoginTextBox.Text == "" || PasswordTextBox.Text == "") return;

            var user = new User
                           {
                               Login = LoginTextBox.Text,
                               Pass = ComputeMd5Checksum(PasswordTextBox.Text),
                               ShowAs = LoginTextBox.Text
                           };

            try
            {
                _communicator.ModifyItem(user, "Login", user.Login, "Users");
                MessageBox.Show(string.Format("Login: {0}\r\nPass: {1}\r\nShown As: {2}",
                                              user.Login,
                                              PasswordTextBox.Text,
                                              user.ShowAs),
                                Resources.Registered_as);
            }
            catch
            {
                MessageBox.Show(Resources.Login_already_registered);
            }
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            DataClass.SaveSettings("save", checkBox1.Checked.ToString(CultureInfo.InvariantCulture));
        }

        private string ComputeMd5Checksum(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(input));
            return BitConverter.ToString(data).Replace("-", String.Empty);
        }
    }
}