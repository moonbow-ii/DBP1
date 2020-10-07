using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_1007
{
    public partial class TestCSV : Form
    {
        public TestCSV()
        {
            InitializeComponent();
        }

        private void buttonOpenCSV_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(new FileStream("market.csv", FileMode.Open)
                , Encoding.Default);
            var str = "";
            var line = sr.ReadLine();
   
            while (sr.EndOfStream == false)
            {
                var values = line.Split(',');
                foreach (String string_value in values)
                {
                    line = sr.ReadLine();
                    str = string_value;
                    CSV_text.Text += str.PadRight(30-string_value.Length);
                }
                CSV_text.Text += "\r\n";
            }
            sr.Close();
        }
    }
}
