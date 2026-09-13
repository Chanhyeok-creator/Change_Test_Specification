using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Change_Test_Specification.Forms;
using System.IO;
using System.Xml;
using Change_Test_Specification.Class;
using Change_Test_Specification.Forms.Controls;
using Change_Test_Specification.Classes;


namespace Change_Test_Specification
{
    public partial class Form1 : Form
    {
        DataGridView_Setting datagridview_setting = new DataGridView_Setting();


        public Form1()
        {
            InitializeComponent();

            LoadMeasuredSpecList();
            
        }


        private void LoadMeasuredSpecList()
        {

            panel1.Controls.Clear();
            panel1.Controls.Add(datagridview_setting);

            string ex;
            int i = datagridview_setting.DataGrid_Column(true, out ex); //readonly를 true 하였다.

            if (i == 1)
            {
                MessageBox.Show(
                    "파일을 찾을 수 없습니다.",
                    "파일 오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else if (i == 2)
            {
                MessageBox.Show(
                    "검사 결과를 불러오는 중 오류가 발생했습니다.\n\n" + ex,
                    "오류",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
            else if (i == 0)
            {
                // 현재 DataGridView에 연결된 파일 이름 표시
                label2.Text = datagridview_setting.Return_filename();
            }
        }

        private void editor_button_Click(object sender, EventArgs e)
        {
            Editor_form2 editor_form2 = new Editor_form2();
            if (editor_form2.ShowDialog() == DialogResult.Cancel)
            {
                datagridview_setting.Clear_Table1();
                LoadMeasuredSpecList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}