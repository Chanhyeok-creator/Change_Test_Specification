using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Change_Test_Specification;
using Change_Test_Specification.Forms;
using System.IO;
using System.Xml;
using Change_Test_Specification.Classes;

namespace Change_Test_Specification.Forms.Controls
{
    public partial class DataGridView_Setting : UserControl
    {
        XmlDocument doc = new XmlDocument();
        //private static string file_path = Path.Combine(Application.StartupPath, @"..\..\res\xml\testcase.xml");
        Make_New_XML make_xml = new Make_New_XML();
        private string real_path;
        XmlDocument doc2 = new XmlDocument();
        public DataGridView_Setting()
        {
            InitializeComponent();

            //LoadMeasuredSpecList();
        }

        public string path_setting()
        {
            try
            {
                doc2.Load(make_xml.new_file_path);

                XmlNode path_node = doc2.SelectSingleNode("/Path_List/path");

                if (path_node == null)
                {
                    make_xml.make_new_path_xml();

                    doc2.Load(make_xml.new_file_path);
                    path_node = doc2.SelectSingleNode("/Path_List/path");
                }

                real_path = path_node.InnerText;

                return real_path;
            }
            catch (FileNotFoundException)
            {
                make_xml.make_new_path_xml();

                doc2.Load(make_xml.new_file_path);

                XmlNode path_node = doc2.SelectSingleNode("/Path_List/path");

                real_path = path_node.InnerText;

                return real_path;
            }
        }

        public int DataGrid_Column(bool set, out string message) //int 값이랑 string 값 두 개를 내보낸다.
        {

            Table1.ReadOnly = set;

            Table1.Rows.Clear();


            path_setting();

            

            try
            {
                doc.Load(real_path);
                



                XmlNodeList data_node = doc.SelectNodes("/Test/Data");
                foreach (XmlNode node in data_node) // node는 data1, data2... 을 의미한다.
                {
                    string name_data = node.SelectSingleNode("Test_name").InnerText;
                    string min_data = node.SelectSingleNode("Min").InnerText;
                    string max_data = node.SelectSingleNode("Max").InnerText;
                    string volt_data = node.SelectSingleNode("Voltage").InnerText;
                    string measured_data = node.SelectSingleNode("Measured_value").InnerText;
                    string result_data = node.SelectSingleNode("Result").InnerText;
                    Table1.Rows.Add(name_data, min_data, max_data, volt_data, measured_data, result_data);
                }
            }
            catch (FileNotFoundException)
            {


                //make_xml.make_new_xml();
                message = "";
                return 1;
                
            }
            catch (Exception ex)
            {
                //ex.Message
                message = ex.ToString();
                return 2;
            }
            message = "";
            return 0;

        }

        private void Table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Clear_Table1()
        {
            Table1.Rows.Clear();
        }

        public int Count_Table1_Row() //datagrid view의 row를 카운트 하는 메서드
        {
            int row_count = Table1.RowCount;
            return row_count;
        }

        public string Read_Table_data(int i,int j)
        {
            string data = Convert.ToString(Table1.Rows[i].Cells[j].Value);
            return data;
        }

        public void Add_row()
        {
            Table1.Rows.Add();
        }

        public void Delete_row()
        {
            if (Table1.SelectedRows.Count >= 1)
            {
                int index = Table1.SelectedRows[0].Index;
                Table1.Rows.RemoveAt(index);
            }
        }

        public string Return_filename()
        {
            string file_name = Path.GetFileName(real_path);
            return file_name;
        }
    }
}
