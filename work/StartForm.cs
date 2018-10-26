using System;
using System.Data;
using System.Windows.Forms;
using ExcelObj = Microsoft.Office.Interop.Excel;

namespace work
{
    public partial class StartForm : MetroFramework.Forms.MetroForm
    {
        public StartForm()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            if (OpenClientsDialog.ShowDialog() == DialogResult.OK)
            {
                dt = new DataTable();

                ExcelObj.Application app = new ExcelObj.Application();
                ExcelObj.Workbook workbook;
                ExcelObj.Worksheet NwSheet;
                ExcelObj.Range ShtRange;


                workbook = app.Workbooks.Open(OpenClientsDialog.FileName);

                NwSheet = (ExcelObj.Worksheet)workbook.Sheets.get_Item(1);
                ShtRange = NwSheet.UsedRange;

                dt.Columns.Add(new DataColumn("Email"));
                dt.Columns.Add(new DataColumn("Организация"));
                dt.Columns.Add(new DataColumn("ФИО"));

                try
                {
                    for (int Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
                    {
                        try
                        {
                            if ((ShtRange.Cells[Rnum, 1] as ExcelObj.Range).Value2 != null)
                            {
                                DataRow dr = dt.NewRow();
                                try
                                {
                                    for (int Cnum = 1; Cnum <= 3; Cnum++)
                                    {
                                        if ((ShtRange.Cells[Rnum, 6] as ExcelObj.Range).Value2.ToString().Length > 0)
                                        {
                                            dr[0] = (ShtRange.Cells[Rnum, 6] as ExcelObj.Range).Value2.ToString().Trim();
                                            dr[1] = (ShtRange.Cells[Rnum, 1] as ExcelObj.Range).Value2.ToString().Trim();
                                            dr[2] = (ShtRange.Cells[Rnum, 3] as ExcelObj.Range).Value2.ToString().Trim();
                                        }

                                    }
                                    dt.Rows.Add(dr);
                                    dt.AcceptChanges();
                                }
                                catch
                                {
                                    MessageBox.Show("Ошибка! Столбцы №1, №3, №6 должны быть заполнены для ВСЕХ строчек!!");
                                    break;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Не удалось добавить строчку №" + Rnum + ". Текст ошибки: \n \n" + ex.ToString());
                            break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Не удалось добавить адреса. Текст ошибки: \n \n" + ex.ToString());
                }

            
                metroGrid1.DataSource = dt;

                app.Quit();

                metroGrid1.Columns[0].Width = 145;

                OpenNextFormButton.Enabled = true;
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            OpenClientsDialog.Filter = "Файлы Excel (*.xls; *.xlsx) | *.xls; *.xlsx";
        }

        private void OpenNextFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainform = new MainForm(dt);
            mainform.Closed += (s, args) => this.Close();
            mainform.Show();

        }
    }
}
