using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using MailSender.Properties;
using MailSender.Resources;
using System.ComponentModel;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Utils;

namespace work
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        DataTable dt = new DataTable();
        string[] AttachedFilenames = new string[0];

        public MainForm(DataTable clients)
        {
            InitializeComponent();
            dt = clients;
        }

        private void sendButton_Click(object sender, EventArgs e) //Кнопка отправить
        {
            ProgressSpinner.Visible = true;
            ProgressSpinner.Maximum = dt.Rows.Count;
            ProgressSpinner.Update();

            if (dt.Rows.Count > 0)
            {
                try
                {
                    MimeMessage message = new MimeMessage(); //создаем письмо
                    message.From.Add(new MailboxAddress(Settings.Default.Name, Settings.Default.Email));
                    message.Subject = SubjectTextBox.Text;

                    string dirname = ""; //Директория с изображениями
                    string imagePath = Path.Combine(Path.GetDirectoryName(openFileDialog2.FileName), Path.GetFileNameWithoutExtension(openFileDialog2.FileName) + ".files"); //Определяем директорию с картинками письма
                    Stream stream = webBrowser1.DocumentStream; //Читаем html текст письма
                    StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("windows-1251"));
                    string HTMLtext = sr.ReadToEnd(); //Тело письма
                    stream.Close();

                    BodyBuilder builder = new BodyBuilder();

                    if (Directory.Exists(imagePath)) //Если картинки существуют, то добавляем их в тело письма
                    {
                        string[] imagesList = Directory.GetFiles(imagePath);
                        MimeEntity[] imgs = new MimeEntity[imagesList.Length];
                        dirname = new DirectoryInfo(Path.GetDirectoryName(imagesList[0])).Name;

                        for (int z = 0; z < imagesList.Length; z++)
                        {
                            var image = builder.LinkedResources.Add(imagesList[z]);
                            image.ContentId = MimeUtils.GenerateMessageId();
                            HTMLtext = HTMLtext.Replace(dirname + "/" + Path.GetFileName(imagesList[z]), "cid:" + image.ContentId);
                        }
                    }

                    foreach (string itm in attachedFilesListBox.Items)
                        builder.Attachments.Add(itm);

                    builder.TextBody = webBrowser1.Document.Body.InnerText;
                    if (Settings.Default.IsHtml)
                        builder.HtmlBody = HTMLtext;

                    message.Body = builder.ToMessageBody();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        ProgressSpinner.Value = i + 1;
                        ProgressSpinner.Update();

                        message.To.Clear();
                        message.To.Add(new MailboxAddress(dt.Rows[i]["Email"].ToString(), dt.Rows[i]["Email"].ToString()));

                        var client = new SmtpClient();
                        client.Connect(Settings.Default.Server, Settings.Default.Port, MailKit.Security.SecureSocketOptions.Auto);
                        client.Authenticate(Settings.Default.Email, Settings.Default.Password);
                        client.Send(message);
                        client.Disconnect(true);
                    }

                    ProgressSpinner.Visible = false;
                    MessageBox.Show("Успешно!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ошибка при отправке. Текст ошибки: \n \n" + ex.ToString());
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Файлы HTML (*.html; *.htm) | *.html; *.htm" ; ;
            SubjectTextBox.Visible = false;
            webBrowser1.Visible = false;
            sendButton.Visible = false;
        }

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("ВНИМАНИЕ! Для правильного отображения картинок у получателя, название письма НЕ ДОЛЖНО содержать пробелов!!");
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    webBrowser1.Navigate("about:blank");
                    if (webBrowser1.Document != null)
                        webBrowser1.Document.Write(string.Empty);
                    webBrowser1.Navigate(openFileDialog2.FileName);
                }

                ChooseFileButton.Visible = false;
                SubjectTextBox.Visible = true;
                webBrowser1.Visible = true;
                sendButton.Visible = true;
                ChooseAnotherFileButton.Visible = true;
                attachButton.Visible = true;
                AttachedFileLabel.Visible = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при откытии письма. Текст ошибки: \n \n" + ex.ToString());
            }
        }




        private void attachButton_Click(object sender, EventArgs e)
        {
            if (attachedFilesListBox.Visible == false)
            {
                attachedFilesListBox.Visible = true;
                AddAttachButton.Visible = true;
                DelAttachButton.Visible = true;
                filesLabel.Visible = true;
                closeButton.Visible = true;
                SubjectTextBox.Visible = false;
                webBrowser1.Visible = false;
                sendButton.Visible = false;
                ChooseAnotherFileButton.Visible = false;
            }
            else
            {
                attachedFilesListBox.Visible = false;
                AddAttachButton.Visible = false;
                DelAttachButton.Visible = false;
                filesLabel.Visible = false;
                closeButton.Visible = false;
                SubjectTextBox.Visible = true;
                webBrowser1.Visible = true;
                sendButton.Visible = true;
                ChooseAnotherFileButton.Visible = true;
            }
        }

        private void AddAttachButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AttachFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in AttachFileDialog.FileNames)
                    {
                        attachedFilesListBox.Items.Add(file);
                        attachedFilesListBox.SelectedIndex = int.Parse(attachedFilesListBox.Items.Count.ToString()) - 1;
                    }
                    AttachedFileLabel.Text = "Прикрепленных файлов: " + attachedFilesListBox.Items.Count.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении файла. Текст ошибки: \n \n" + ex.ToString());
            }
        }

        private void DelAttachButton_Click(object sender, EventArgs e)
        {
            try
            {
                attachedFilesListBox.Items.RemoveAt(attachedFilesListBox.SelectedIndex);
                attachedFilesListBox.SelectedIndex = int.Parse(attachedFilesListBox.Items.Count.ToString()) - 1;
                AttachedFileLabel.Text = "Прикрепленных файлов: " + attachedFilesListBox.Items.Count.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при удалении файла. Текст ошибки: \n \n" + ex.ToString());
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            attachedFilesListBox.Visible = false;
            AddAttachButton.Visible = false;
            DelAttachButton.Visible = false;
            filesLabel.Visible = false;
            closeButton.Visible = false;
            SubjectTextBox.Visible = true;
            webBrowser1.Visible = true;
            sendButton.Visible = true;
            ChooseAnotherFileButton.Visible = true;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settForm = new SettingsForm();
            settForm.Show();
        }
    }
}
