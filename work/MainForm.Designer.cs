namespace work
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SubjectTextBox = new MetroFramework.Controls.MetroTextBox();
            this.sendButton = new MetroFramework.Controls.MetroButton();
            this.ChooseFileButton = new MetroFramework.Controls.MetroButton();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.AttachFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChooseAnotherFileButton = new MetroFramework.Controls.MetroButton();
            this.AttachedFileLabel = new MetroFramework.Controls.MetroLabel();
            this.AttachedFileNamesLabel = new MetroFramework.Controls.MetroLabel();
            this.ProgressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.attachButton = new MetroFramework.Controls.MetroButton();
            this.attachedFilesListBox = new System.Windows.Forms.ListBox();
            this.AddAttachButton = new MetroFramework.Controls.MetroButton();
            this.DelAttachButton = new MetroFramework.Controls.MetroButton();
            this.filesLabel = new MetroFramework.Controls.MetroLabel();
            this.closeButton = new MetroFramework.Controls.MetroButton();
            this.SettingsButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // SubjectTextBox
            // 
            // 
            // 
            // 
            this.SubjectTextBox.CustomButton.Image = null;
            this.SubjectTextBox.CustomButton.Location = new System.Drawing.Point(631, 1);
            this.SubjectTextBox.CustomButton.Name = "";
            this.SubjectTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SubjectTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SubjectTextBox.CustomButton.TabIndex = 1;
            this.SubjectTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SubjectTextBox.CustomButton.UseSelectable = true;
            this.SubjectTextBox.CustomButton.Visible = false;
            this.SubjectTextBox.Lines = new string[0];
            this.SubjectTextBox.Location = new System.Drawing.Point(23, 82);
            this.SubjectTextBox.MaxLength = 32767;
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.PasswordChar = '\0';
            this.SubjectTextBox.PromptText = "Заголовок";
            this.SubjectTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SubjectTextBox.SelectedText = "";
            this.SubjectTextBox.SelectionLength = 0;
            this.SubjectTextBox.SelectionStart = 0;
            this.SubjectTextBox.ShortcutsEnabled = true;
            this.SubjectTextBox.Size = new System.Drawing.Size(653, 23);
            this.SubjectTextBox.Style = MetroFramework.MetroColorStyle.Brown;
            this.SubjectTextBox.TabIndex = 8;
            this.SubjectTextBox.UseSelectable = true;
            this.SubjectTextBox.WaterMark = "Заголовок";
            this.SubjectTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SubjectTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sendButton
            // 
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.Location = new System.Drawing.Point(373, 504);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(252, 37);
            this.sendButton.Style = MetroFramework.MetroColorStyle.Brown;
            this.sendButton.TabIndex = 9;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseSelectable = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ChooseFileButton
            // 
            this.ChooseFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChooseFileButton.Location = new System.Drawing.Point(88, 202);
            this.ChooseFileButton.Name = "ChooseFileButton";
            this.ChooseFileButton.Size = new System.Drawing.Size(497, 182);
            this.ChooseFileButton.Style = MetroFramework.MetroColorStyle.Brown;
            this.ChooseFileButton.TabIndex = 11;
            this.ChooseFileButton.Text = "Выбрать шаблон письма";
            this.ChooseFileButton.UseSelectable = true;
            this.ChooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "*.html|*.htm";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(23, 126);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(653, 372);
            this.webBrowser1.TabIndex = 12;
            // 
            // AttachFileDialog
            // 
            this.AttachFileDialog.Multiselect = true;
            // 
            // ChooseAnotherFileButton
            // 
            this.ChooseAnotherFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChooseAnotherFileButton.Location = new System.Drawing.Point(459, 31);
            this.ChooseAnotherFileButton.Name = "ChooseAnotherFileButton";
            this.ChooseAnotherFileButton.Size = new System.Drawing.Size(164, 37);
            this.ChooseAnotherFileButton.Style = MetroFramework.MetroColorStyle.Brown;
            this.ChooseAnotherFileButton.TabIndex = 14;
            this.ChooseAnotherFileButton.Text = "Сменить шаблон письма";
            this.ChooseAnotherFileButton.UseSelectable = true;
            this.ChooseAnotherFileButton.Visible = false;
            this.ChooseAnotherFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // AttachedFileLabel
            // 
            this.AttachedFileLabel.AutoSize = true;
            this.AttachedFileLabel.Location = new System.Drawing.Point(88, 504);
            this.AttachedFileLabel.Name = "AttachedFileLabel";
            this.AttachedFileLabel.Size = new System.Drawing.Size(182, 19);
            this.AttachedFileLabel.TabIndex = 15;
            this.AttachedFileLabel.Text = "Прикрепленных файлов нет";
            this.AttachedFileLabel.Visible = false;
            // 
            // AttachedFileNamesLabel
            // 
            this.AttachedFileNamesLabel.AutoSize = true;
            this.AttachedFileNamesLabel.Location = new System.Drawing.Point(88, 522);
            this.AttachedFileNamesLabel.Name = "AttachedFileNamesLabel";
            this.AttachedFileNamesLabel.Size = new System.Drawing.Size(0, 0);
            this.AttachedFileNamesLabel.TabIndex = 17;
            this.AttachedFileNamesLabel.Visible = false;
            // 
            // ProgressSpinner
            // 
            this.ProgressSpinner.Location = new System.Drawing.Point(635, 504);
            this.ProgressSpinner.Maximum = 100;
            this.ProgressSpinner.Name = "ProgressSpinner";
            this.ProgressSpinner.Size = new System.Drawing.Size(44, 44);
            this.ProgressSpinner.Style = MetroFramework.MetroColorStyle.Brown;
            this.ProgressSpinner.TabIndex = 18;
            this.ProgressSpinner.UseSelectable = true;
            this.ProgressSpinner.Visible = false;
            // 
            // attachButton
            // 
            this.attachButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.attachButton.BackgroundImage = global::MailSender.Properties.Resources.attach;
            this.attachButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.attachButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.attachButton.Location = new System.Drawing.Point(23, 508);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(50, 44);
            this.attachButton.TabIndex = 19;
            this.attachButton.UseSelectable = true;
            this.attachButton.Visible = false;
            this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
            // 
            // attachedFilesListBox
            // 
            this.attachedFilesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.attachedFilesListBox.FormattingEnabled = true;
            this.attachedFilesListBox.ItemHeight = 20;
            this.attachedFilesListBox.Location = new System.Drawing.Point(23, 82);
            this.attachedFilesListBox.Name = "attachedFilesListBox";
            this.attachedFilesListBox.Size = new System.Drawing.Size(421, 404);
            this.attachedFilesListBox.TabIndex = 20;
            this.attachedFilesListBox.Visible = false;
            // 
            // AddAttachButton
            // 
            this.AddAttachButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddAttachButton.Location = new System.Drawing.Point(459, 324);
            this.AddAttachButton.Name = "AddAttachButton";
            this.AddAttachButton.Size = new System.Drawing.Size(180, 50);
            this.AddAttachButton.TabIndex = 21;
            this.AddAttachButton.Text = "Добавить";
            this.AddAttachButton.UseSelectable = true;
            this.AddAttachButton.Visible = false;
            this.AddAttachButton.Click += new System.EventHandler(this.AddAttachButton_Click);
            // 
            // DelAttachButton
            // 
            this.DelAttachButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelAttachButton.Location = new System.Drawing.Point(459, 380);
            this.DelAttachButton.Name = "DelAttachButton";
            this.DelAttachButton.Size = new System.Drawing.Size(180, 50);
            this.DelAttachButton.TabIndex = 22;
            this.DelAttachButton.Text = "Удалить";
            this.DelAttachButton.UseSelectable = true;
            this.DelAttachButton.Visible = false;
            this.DelAttachButton.Click += new System.EventHandler(this.DelAttachButton_Click);
            // 
            // filesLabel
            // 
            this.filesLabel.AutoSize = true;
            this.filesLabel.Location = new System.Drawing.Point(23, 60);
            this.filesLabel.Name = "filesLabel";
            this.filesLabel.Size = new System.Drawing.Size(156, 19);
            this.filesLabel.TabIndex = 23;
            this.filesLabel.Text = "Прикрепленные файлы:";
            this.filesLabel.Visible = false;
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Location = new System.Drawing.Point(459, 436);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(180, 50);
            this.closeButton.TabIndex = 24;
            this.closeButton.Text = "Сохранить и закрыть";
            this.closeButton.UseSelectable = true;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackgroundImage = global::MailSender.Properties.Resources.settings_icon;
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SettingsButton.Location = new System.Drawing.Point(635, 31);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(32, 28);
            this.SettingsButton.Style = MetroFramework.MetroColorStyle.White;
            this.SettingsButton.TabIndex = 25;
            this.SettingsButton.UseCustomBackColor = true;
            this.SettingsButton.UseCustomForeColor = true;
            this.SettingsButton.UseSelectable = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 575);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.filesLabel);
            this.Controls.Add(this.DelAttachButton);
            this.Controls.Add(this.AddAttachButton);
            this.Controls.Add(this.attachedFilesListBox);
            this.Controls.Add(this.attachButton);
            this.Controls.Add(this.ProgressSpinner);
            this.Controls.Add(this.AttachedFileNamesLabel);
            this.Controls.Add(this.AttachedFileLabel);
            this.Controls.Add(this.ChooseAnotherFileButton);
            this.Controls.Add(this.ChooseFileButton);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.SubjectTextBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Brown;
            this.Text = "Автоматическая рассылка писем";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox SubjectTextBox;
        private MetroFramework.Controls.MetroButton sendButton;
        private MetroFramework.Controls.MetroButton ChooseFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.OpenFileDialog AttachFileDialog;
        private MetroFramework.Controls.MetroButton ChooseAnotherFileButton;
        private MetroFramework.Controls.MetroLabel AttachedFileLabel;
        private MetroFramework.Controls.MetroLabel AttachedFileNamesLabel;
        private MetroFramework.Controls.MetroProgressSpinner ProgressSpinner;
        private MetroFramework.Controls.MetroButton attachButton;
        private System.Windows.Forms.ListBox attachedFilesListBox;
        private MetroFramework.Controls.MetroButton AddAttachButton;
        private MetroFramework.Controls.MetroButton DelAttachButton;
        private MetroFramework.Controls.MetroLabel filesLabel;
        private MetroFramework.Controls.MetroButton closeButton;
        private MetroFramework.Controls.MetroButton SettingsButton;
    }
}

