using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
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
                var value = parseCSVLine(line);
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

        Dictionary<string, int> headerIndexDic = new Dictionary<string, int>();

        private void setHeaderList(string header)
        {
            var values = parseCSVLine(header);

            listBoxHeaders.Items.Clear();

            for(int i=0; i < values.Length; i++){
                string column = values[i];
                listBoxHeaders.Items.Add(column);
                headerIndexDic[column] = i;
            }            
        }
        List<List<string>> wholeData;
        private List<List<string>> MakeRowbaseDataStructure(string filename)
        {
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open)
           , Encoding.Default);

            var line = sr.ReadLine();
            setHeaderList(line);


            wholeData = new List<List<string>>();

            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine(); 
                var value = parseCSVLine(line);
                wholeData.Add(value.ToList());//string 배열을 리스트 형태로 넣음
            }

            sr.Close();
            return wholeData;
        }
        private void printRowData_R(List<List<string>> data, TextBox textBox) {
            string str = "";
            textBox.Text = "";
            foreach(List<string> values in data){
                foreach (string value in values)
                    str += value + '\t';
                str += "\r\n";
            }
            textBox.Text = str;
        }
        private void printColumnData_R(List<List<string>> data, int colIdx) {
            string str = "";
            CSV_text.Text = "";
            foreach(List<string>values in data){
                str += values[colIdx] + "\r\n";
            }
            CSV_text.Text = str;
        }//coInx에 숫자 넣으면 그 부분만 나오는

        private string[] parseCSVLine(string value) {
            var list =  value.Split(',');
            for (int j=0; j<list.Length; j++) {
                if (list[j][0] == '\"'){
                    list[j] = list[j] + ',' + list[j+1];
                    for (int i = j+1; i < list.Length - 1; i++)
                        list[i] = list[i + 1];
                    Array.Resize(ref list, list.Length - 1);
                }
            }                       
            return list;
        }// (구, 우리시장) 같은거 잘되도록.
        private void buttonOpenCSV_Click(object sender, EventArgs e){
            var FD = new OpenFileDialog();
            DialogResult dresult = FD.ShowDialog();

            if (dresult == DialogResult.OK){
                string filename = FD.FileName;
                List<List<string>> data_R = MakeRowbaseDataStructure(filename);
                printRowData_R(data_R,CSV_text);
            }

            //List<List<string>> data_C = MakeColumnarDataStructure();

            //int selectIndex=1;
            //printColumnData_C(data_C, selectIndex);
            //printRowData_C(data_C);
            //printColumnData_R(data_R, selectIndex);


        }
        private void doSearch(string key, string col)
        {
            //대상컬럼 확인
            //int targetcolumnIndex = listBoxheaders.selectedIndex;
            //dictionary활용
            if (headerIndexDic.ContainsKey(col) == false)
            {
                MessageBox.Show("검색 컬럼을 선택하세요.", "확인");
                return;
            }
            int targetcolumnIndex=headerIndexDic[col];

            //대상 컬럼에서 키워드 확인
            List<List<string>> search = new List<List<string>>(); ;
            foreach (List<string> row in wholeData)
            {
                var result = row[targetcolumnIndex];
                if (result.Contains(key))
                    search.Add(row);
            }
            printRowData_R(search, textBoxSearchResult);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBoxSearchKeyword.Text;

            if (keyword == "")
            {
                MessageBox.Show("검색 키워드를 입력하세요.", "확인");
                return;
            }
            if(listBoxHeaders.SelectedItem == null)
            {
                MessageBox.Show("검색 컬럼을 선택하세요.", "확인");
                return;
            }

            string column = listBoxHeaders.SelectedItem.ToString();
            doSearch(keyword, column);
        }
    }
}
