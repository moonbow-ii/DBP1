using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace test_1007
{
    public partial class TestCSV : Form
    {
        public TestCSV()
        {
            InitializeComponent();
        }
        //버튼을 통해서 csv파일 불러오기
        private List<List<string>> MakeColumnarDataStructure()
        {
            StreamReader sr = new StreamReader(new FileStream("market.csv", FileMode.Open)
           , Encoding.Default);



            var line = sr.ReadLine();
            var headers = line.Split(',');

            List<List<string>> wholeData = new List<List<string>>();

            foreach (String header in headers)
            {
                List<string> list = new List<string>();
                list.Add(header);
                wholeData.Add(list);
            }


            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                var value = line.Split(',');
                value = parseCSVLine(value);
                for (int i = 0; i < value.Length; i++)
                    wholeData[i].Add(value[i]);
            }
            sr.Close();
            return wholeData;
        }
        private void printColumnData_C(List<List<string>> data, int coIdx)
        {
            string str = "";
            CSV_text.Text = "";
            foreach (string values in data[coIdx]) {
                str += values + "\r\n";
            }
            CSV_text.Text = str;//ui업데이트는 한번에 모아서 하는게 좋음.(오래걸림)
        }
        private void printRowData_C(List<List<string>> data) {
            string str = "";
            CSV_text.Text = "";
            for (int i = 0; i < data[0].Count; i++) {
                foreach (List<string> values in data) {
                    str += values[i] + "\t";
                }
                str += "\r\n";
            }
            CSV_text.Text = str;
        }
            
        private List<List<string>> MakeRowbaseDataStructure()
        {
            StreamReader sr = new StreamReader(new FileStream("market.csv", FileMode.Open)
           , Encoding.Default);

            List<List<string>> wholeData = new List<List<string>>();

            var line = sr.ReadLine();

            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine(); 
                var value = line.Split(',');
                value = parseCSVLine(value);
                wholeData.Add(value.ToList());//string 배열을 리스트 형태로 넣음
            }

            sr.Close();
            return wholeData;
        }
        private void printRowData_R(List<List<string>> data) {
            string str = "";
            CSV_text.Text = "";
            foreach(List<string> values in data){
                foreach (string value in values)
                    str += value + '\t';
                str += '\n';
            }
            CSV_text.Text = str;
        }
        private void printColumnData_R(List<List<string>> data, int colIdx) {
            string str = "";
            CSV_text.Text = "";
            foreach(List<string>values in data){
                str += values[colIdx] + "\r\n";
            }
            CSV_text.Text = str;
        }//coInx에 숫자 넣으면 그 부분만 나오는

        private string[] parseCSVLine(string[] line) {        
             for(int j=0; j<line.Length; j++) {
                if (line[j][0] == '\"'){
                    line[j] = line[j] + ',' + line[j+1];
                    for (int i = j+1; i < line.Length - 1; i++)
                        line[i] = line[i + 1];
                    Array.Resize(ref line, line.Length - 1);
                }
            }                       
            return line;
        }// (구, 우리시장) 같은거 잘되도록.
        private void buttonOpenCSV_Click(object sender, EventArgs e){
            List<List<string>> data_C = MakeColumnarDataStructure();
            //List<List<string>> data_R = MakeRowbaseDataStructure();
            //int selectIndex=1;
            //printColumnData_C(data_C, selectIndex);
            printRowData_C(data_C);
            //printColumnData_R(data_R, selectIndex);
            //printRowData_R(data_R);

        }
    }
}
