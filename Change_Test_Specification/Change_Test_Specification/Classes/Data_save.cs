using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Change_Test_Specification;
using Change_Test_Specification.Forms;


namespace Change_Test_Specification.Class
{
    public class TestCaseModel
    {
        int resultt;

        

        public string id { get; set; }
        public string testname { get; set; }
        private string Min;
        private string Max;
        private string Voltage;
        private string MeasuredValue { get; set; }
        private string Result { get; set; }
        public string file_path { get; set; }



        public string min
        {
            get 
            {
                return Min;
            }

            set
            {
                if (int.TryParse(value, out resultt))
                {
                    Min = value;
                }
            }
        }

        public string max
        {
            get
            {
                return Max;
            }

            set
            {
                if (int.TryParse(value, out resultt))
                {
                    Max = value;
                }
            }
        }

        public string voltage
        {
            get
            {
                return Voltage;
            }

            set
            {
                if (int.TryParse(value, out resultt))
                {
                    Voltage = value;
                }
            }
        }

        public string measuredvalue
        {
            get
            {
                return MeasuredValue;
            }

            set
            {
                if (int.TryParse(value, out resultt))
                {
                    MeasuredValue = value;
                }
            }
        }

        public string result
        {
            get
            {
                return Result;
            }

            set
            {
                if (int.TryParse(value, out resultt))
                {
                    Result = value;
                }
            }
        }


        List<string> datasave = new List<string>();

        public void datalist()
        {
            datasave.Clear();

            datasave.Add(testname); //datasave[0]
            datasave.Add(Min); // 1
            datasave.Add(Max); // 2
            datasave.Add(Voltage); // 3
            datasave.Add(measuredvalue);
            datasave.Add(result);
        }

        public void datacontrol(int c, string Data)
        {
            datasave[c] = Data;
        }

        public string dataout(int c)
        {
            string data = datasave[c];
            return data;
        }
    }
}