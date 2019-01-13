using MailSender.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailSender.Resources
{
    public partial class SettingsForm : MetroFramework.Forms.MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            EmailTextBox.Text = Settings.Default.Email;
            PasswordTextBox.Text = Settings.Default.Password;
            NameTextBox.Text = Settings.Default.Name;
            foreach (var foo in HostComboBox.Items)
            {
                if (foo.ToString().Contains(Settings.Default.Host))
                {
                    HostComboBox.SelectedItem = foo;
                    break;
                }
            }
            ServerTextBox.Text = Settings.Default.Server;
            PortTextBox.Text = Settings.Default.Port.ToString();
            HtmlCheckBox.Checked = Settings.Default.IsHtml;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.Email = EmailTextBox.Text;
                Settings.Default.Password = PasswordTextBox.Text;
                Settings.Default.Name = NameTextBox.Text;
                Settings.Default.Server = ServerTextBox.Text;
                Settings.Default.Port = int.Parse(PortTextBox.Text);
                Settings.Default.IsHtml = HtmlCheckBox.Checked;
                Settings.Default.Host = HostComboBox.Text;
                Settings.Default.Save();
                MessageBox.Show("Настройки успешно сохранены!");
            }
            catch
            {
                MessageBox.Show("Ошибка! Проверьте введенные данные!");
            }   
        }

        private void HostComboBox_TextChanged(object sender, EventArgs e)
        {
            string host = HostComboBox.Text;
            string serv = ServerTextBox.Text;
            string port = PortTextBox.Text;
            if (host == "Яндекс")
            {
                serv = "smtp.yandex.ru";
                port = "465";
            }
            else if (host == "Mail.ru")
            {
                serv = "smtp.mail.ru";
                port = "465";
            }
            else if (host == "Google")
            {
                serv = "smtp.gmail.com";
                port = "465";
            }
            else if (host == "Рамблер")
            {
                serv = "smtp.rambler.ru";
                port = "465";
                MessageBox.Show("Внимание! Для работы с рамблером необходимо в настройках почты включить доступ к почте с помощью почтовых клиентов!");
            }
            else if (host == "Outlook")
            {
                serv = "smtp-mail.outlook.com";
                port = "587";
            }
            else if (host == "Yahoo")
            {
                serv = "smtp.mail.yahoo.com";
                port = "465";
            }
            ServerTextBox.Text = serv;
            PortTextBox.Text = port;
        }
    }
}
