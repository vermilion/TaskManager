using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common;
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
            saveCheckBox.Checked = bool.Parse(ConfigurationManager.AppSettings["save"]);
            LoginTextBox.Text = ConfigurationManager.AppSettings["login"];
            PasswordTextBox.Text = ConfigurationManager.AppSettings["pass"];

            _communicator.UpgradeDatabase();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            string pass = Regex.IsMatch(PasswordTextBox.Text, "[0-9a-fA-F]{32}")
                              ? PasswordTextBox.Text
                              : ConfigurationHelper.ComputeMd5Checksum(PasswordTextBox.Text);

            User user = _communicator.GetList<User>("Users")
                .FirstOrDefault(x => x.Login == LoginTextBox.Text && x.Pass == pass);

            if (user == null)
                MessageBox.Show(Resources.Try_again, Resources.Wrong_login_pass);
            else
            {
                if (saveCheckBox.Checked)
                {
                    ConfigurationHelper.SaveSettings("login", LoginTextBox.Text);
                    ConfigurationHelper.SaveSettings("pass", pass);
                }

                MessageBox.Show(Resources.logged_in_as + user.ShowAs);
                UserData.UserName = user.ShowAs;
                DialogResult = DialogResult.OK;
            }
        }


        private void RegisterLinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LoginTextBox.Text == "" || PasswordTextBox.Text == "") return;

            var user = new User
                           {
                               Login = LoginTextBox.Text,
                               Pass = ConfigurationHelper.ComputeMd5Checksum(PasswordTextBox.Text),
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

        private void SaveCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            ConfigurationHelper.SaveSettings("save", saveCheckBox.Checked.ToString(CultureInfo.InvariantCulture));
        }
    }
}