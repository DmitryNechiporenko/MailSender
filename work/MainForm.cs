using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

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
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        ProgressSpinner.Value = i + 1;
                        ProgressSpinner.Update();


                        MailMessage message = new MailMessage("karazeeva_ye@civssm.ru", dt.Rows[i]["Email"].ToString()); //Создаем новое письмо
                        message.IsBodyHtml = true;
                        message.Subject = SubjectTextBox.Text; //Добавляем заголовок


                        string HTMLtext; //Тело письма
                        string[] imagesList = new string[0]; //Список изображений (в теле)
                        string dirname = ""; //Директория с изображениями


                        string imagePath = Path.Combine(Path.GetDirectoryName(openFileDialog2.FileName), Path.GetFileNameWithoutExtension(openFileDialog2.FileName) + ".files"); //Определяем директорию с картинками письма
                        if (Directory.Exists(imagePath)) //Если она существует, то добавляем в список картинок все файлы папки
                        {
                            imagesList = Directory.GetFiles(imagePath);
                            dirname = new DirectoryInfo(Path.GetDirectoryName(imagesList[0])).Name;

                            for (int z = 0; z < imagesList.Length; z++)
                            {
                                imagesList[z] = Path.GetFileName(imagesList[z]);
                            }
                        }


                        Encoding enc = Encoding.GetEncoding("windows-1251"); //Задаем кодировку нашего письма
                        Stream stream = webBrowser1.DocumentStream; //Читаем html текст письма
                        StreamReader sr = new StreamReader(stream, enc);
                        HTMLtext = sr.ReadToEnd();
                        stream.Close();


                        HTMLtext = HTMLtext.Replace("</body>", "<img src='https://www.google-analytics.com/collect?v=1&tid=UA-126839954-1&t=event&cid=POLUCHATEL1&ea=WHOISIT&ec=PIXELHIDE' width=1 height=1></body>");
                        HTMLtext = HTMLtext.Replace("WHOISIT", dt.Rows[i][0].ToString()); //Добавляем в письмо скрытый пиксель для отслеживания прочтения
                        HTMLtext = HTMLtext.Replace("PIXELHIDE", SubjectTextBox.Text);


                        List<LinkedResource> imgResourceList = new List<LinkedResource>();

                        if (Directory.Exists(imagePath))
                        {
                            foreach (var img in imagesList) //Добавляем все изображения в письмо
                            {
                                string imgPath = Path.Combine(imagePath, img);
                                var image = new LinkedResource(imgPath, "image/" + img.Split('.')[1]);
                                image.ContentId = Guid.NewGuid().ToString();
                                HTMLtext = HTMLtext.Replace(dirname + "/" + img, "cid:" + image.ContentId);
                                image.ContentType.Name = img;
                                image.TransferEncoding = TransferEncoding.Base64;
                                imgResourceList.Add(image);
                            }
                        }

                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(HTMLtext, null, "text/html"); //Делаем тело типа html

                        foreach (var imgResource in imgResourceList)
                        {
                            htmlView.LinkedResources.Add(imgResource);
                        }
                        message.AlternateViews.Add(htmlView); //Добавляем тело к письму


                        if (attachedFilesListBox.Items.Count > 0) //Проверяем, нужно ли прикреплять файлы к письму
                        {
                            try
                            {
                                foreach (string itm in attachedFilesListBox.Items)
                                {
                                    Attachment at = new Attachment(itm, MediaTypeNames.Application.Octet);
                                    message.Attachments.Add(at);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Невозможно прикрепить файлы к письму для " + dt.Rows[i]["Email"].ToString() + ". СЛЕДУЮЩИЕ ПИСЬМА НЕ БУДУТ ОТПРАВЛЕНЫ! Текст ошибки: \n \n" + ex.ToString());
                                break;
                            }

                        }

                        try
                        {
                            SmtpClient client = new SmtpClient("smtp.yandex.ru", 25);
                            client.EnableSsl = true;
                            client.Credentials = new NetworkCredential("karazeeva_ye@civssm.ru", "060981kye");
                            client.Send(message);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при отправке сообщения для " + dt.Rows[i]["Email"].ToString() + ". СЛЕДУЮЩИЕ ПИСЬМА НЕ БУДУТ ОТПРАВЛЕНЫ! Текст ошибки: \n \n" + ex.ToString());
                            break;
                        }
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
                    {
                        webBrowser1.Document.Write(string.Empty);
                    }
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
    }
}
