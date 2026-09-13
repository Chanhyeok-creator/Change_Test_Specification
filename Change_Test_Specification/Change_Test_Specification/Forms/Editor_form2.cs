using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Change_Test_Specification;
using Change_Test_Specification.Class;
using Change_Test_Specification.Forms.Controls;
using Change_Test_Specification.Classes;


namespace Change_Test_Specification.Forms
{
    public partial class Editor_form2 : Form
    {
        //static string new_file_path;

        FileManager button_click = new FileManager();



        /*static */ bool ON_OFF = false; // Load 전 다른 버튼들을 누를 수 있는지 여부를 체크함.

        DataGridView_Setting datagridview_setting = new DataGridView_Setting();

        public Editor_form2()
        {

            InitializeComponent();
            ON_OFF = false;
        }



        private void button5_Click(object sender, EventArgs e)
        {
            ON_OFF = true;

            panel1.Controls.Clear();
            panel1.Controls.Add(datagridview_setting);


            string ex;
            int i = datagridview_setting.DataGrid_Column(false, out ex); // readonly를 false 하였다.

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
                datagridview_name.Text = datagridview_setting.Return_filename();
                
            }
        }

        private void save_file_button_Click(object sender, EventArgs e)
        {
            //Button_click button_click = new Button_click(); 이미 만들었음
            bool messagebox_check = true;

            button_click.Save_button(ON_OFF, messagebox_check,datagridview_setting);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (ON_OFF)
            {
                datagridview_setting.Add_row();
            }
            else 
            {
                MessageBox.Show(
                    "먼저 파일을 로드 하세요.\n\n",
                    "오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ON_OFF)
            {
                datagridview_setting.Delete_row();
            }
            else
            {
                MessageBox.Show(
                    "먼저 파일을 로드 하세요.\n\n",
                    "오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            bool result = button_click.open_file_button();

            if (!result)
            {
                return;
            }

            ON_OFF = true;

            panel1.Controls.Clear();
            panel1.Controls.Add(datagridview_setting);


            string ex;
            int i = datagridview_setting.DataGrid_Column(false, out ex); // readonly를 false 하였다.

            if (i == 1)
            {
                MessageBox.Show(
                    "testcase.xml 파일을 찾을 수 없습니다.\n\n testcase.xml 파일을 생성합니다.",
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
                datagridview_name.Text = datagridview_setting.Return_filename();

            }
        }

        private void datagridview_name_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            bool check = button_click.create_file_button();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool check = button_click.delete_file_button();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}