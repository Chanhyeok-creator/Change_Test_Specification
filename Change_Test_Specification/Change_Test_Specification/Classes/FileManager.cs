using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Change_Test_Specification.Forms;
using Change_Test_Specification.Forms.Controls;
using Change_Test_Specification;
using System.Windows.Forms;
using Change_Test_Specification.Class;



namespace Change_Test_Specification.Classes
{
    class FileManager
    {

        //private static string file_path = Path.Combine(Application.StartupPath, @"..\..\res\xml\testcase.xml");
        private static string new_path;
        XmlDocument doc = new XmlDocument();
        XmlDocument doc2 = new XmlDocument();
        Make_New_XML make_xml = new Make_New_XML();
        TestCaseModel data_save = new TestCaseModel();
        SaveFileDialog savefiledialog = new SaveFileDialog();
        OpenFileDialog openfiledialog1 = new OpenFileDialog();

        public bool create_file_button()
        {
            

            savefiledialog.Filter = "XML file (*.xml)|*.xml";

            if (savefiledialog.ShowDialog() != DialogResult.OK) // 저장 창에서 사용자가 '확인/저장'을 누르지 않았다면 이 메서드를 종료하고 false를 반환한다.
            {
                return false;
            }

            string selectedFilePath = savefiledialog.FileName;
            MessageBox.Show(
                "파일을 생성합니다.",
                "생성",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            make_xml.make_real_new_xml(selectedFilePath);


            return true;
        }


        public bool delete_file_button()
        {
            openfiledialog1.Filter = "XML file (*.xml)|*.xml";

            if (openfiledialog1.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            string selectedFilePath = openfiledialog1.FileName;

            if (File.Exists(selectedFilePath))
            {
                File.Delete(selectedFilePath);

                MessageBox.Show(
                    "파일을 삭제하였습니다.",
                    "삭제",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "파일이 존재하지 않습니다.",
                    "오류",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return true;
        }



        public bool open_file_button()
        {
            openfiledialog1.Filter = "XML file (*.xml)|*.xml";

            if (openfiledialog1.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            string selectedFilePath = openfiledialog1.FileName;

            doc2.Load(make_xml.new_file_path);

            XmlNode need_fix = doc2.SelectSingleNode("/Path_List/path");

            if (need_fix == null)
            {
                return false;
            }

            need_fix.InnerText = selectedFilePath;

            doc2.Save(make_xml.new_file_path);

            MessageBox.Show(
                "파일을 엽니다.",
                "로드",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            return true;
        }




        public void Save_button(bool ON_OFF, bool messagebox_check, DataGridView_Setting datagridview_setting)
        {

            
            if (ON_OFF) // Load가 되어 있는 상태라면?
            {

                new_path = datagridview_setting.path_setting();

                doc.Load(new_path);

                //기존의 xml 파일 중 root 를 제외한 나머지 데이터들을 삭제하는 과정
                XmlNode root = doc.SelectSingleNode("/Test");
                root.RemoveAll();
                
                int k = datagridview_setting.Count_Table1_Row(); //행의 개수
                data_save.datalist(); // 데이터 저장 공간들을 모아둔 리스트 미리 선언.
                for (int j = 0; j < k; j++)
                {
                    if (messagebox_check == false)
                    {
                        break;
                    }
                    //root에 data라는 새로운 자식 노드를 만드는 과정
                    XmlElement Data = doc.CreateElement("Data");
                    data_save.id = j.ToString();
                    string id = data_save.id;
                    Data.SetAttribute("id", id); // Data의 attribute를 만드는 곳
                    root.AppendChild(Data);


                    for (int c = 0; c < 6; c++) // DataGridView의 6개 열을 순서대로 처리
                    {
                        string data = datagridview_setting.Read_Table_data(j, c); //datagridview에 있는 모든 데이터들을 순환
                        
                        
                        if (c == 1 || c == 2 || c == 3) //min,max,volt 값인 경우 오류가 있는지 없는지 판단한다.
                        {
                            int check;
                            bool check_int = int.TryParse(data, out check); //해당 값이 숫자인지 판단한다.

                            if (!check_int && data != "") //숫자가 아니고 빈칸이 아닌 경우 해당 메시지 박스 소환
                            {
                                MessageBox.Show(
                                    "Min,Max,Voltage에는 숫자가 들어가야 합니다.\n\n",
                                    "오류",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                messagebox_check = false;
                                break;
                            }

                            else //min,max,volt가 숫자인 경우
                            {
                                if (c == 2)
                                {
                                    string min = datagridview_setting.Read_Table_data(j, 1);
                                    string max = datagridview_setting.Read_Table_data(j, 2);

                                    if (min != "" && max != "")
                                    {
                                        if (int.Parse(min) >= int.Parse(max))
                                        {
                                            MessageBox.Show(
                                                "Min과 Max를 확인해주세요.\n\n",
                                                "오류",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error
                                            );

                                            messagebox_check = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (messagebox_check)
                        {
                            data_save.datacontrol(c, data);
                        }

                        if (c == 5) // 현재 Data 노드에 자식 노드들을 생성 및 연결시키기
                        {
                            XmlElement test_name = doc.CreateElement("Test_name");
                            XmlElement test_min = doc.CreateElement("Min");
                            XmlElement test_max = doc.CreateElement("Max");
                            XmlElement test_volt = doc.CreateElement("Voltage");
                            XmlElement test_value = doc.CreateElement("Measured_value");
                            XmlElement test_result = doc.CreateElement("Result");

                            test_name.InnerText = data_save.dataout(0);
                            test_min.InnerText = data_save.dataout(1);
                            test_max.InnerText = data_save.dataout(2);
                            test_volt.InnerText = data_save.dataout(3);
                            

                            Data.AppendChild(test_name);
                            Data.AppendChild(test_min);
                            Data.AppendChild(test_max);
                            Data.AppendChild(test_volt);
                            Data.AppendChild(test_value);
                            Data.AppendChild(test_result);
                        }
                    }
                }



                if (messagebox_check)
                {
                    //연결된 현 상태를 저장하기.
                    doc.Save(new_path);
                    MessageBox.Show(
                        "저장 성공.\n\n",
                        "Saved!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None
                    );
                }
            } // ⭐⭐⭐⭐⭐  ꧁༺★༻꧂ ☾⋆⁺₊✧ 𓆩♡𓆪【⚡】꧁༺⚡༻꧂ ༺═────────═༻⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡⚡
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
    }
}