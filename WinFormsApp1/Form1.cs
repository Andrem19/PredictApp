using MyAppTabControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1ML.Model;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pair = textBox1.Text;
            string dateForm = DateTimeToUnix((DateTime)dateTimePicker1.Value).ToString();
            string period = comboBox1.Text;
            SaveFileDialog path = new SaveFileDialog();
            path.ShowDialog();
            string pathTo = path.FileName;
            using(WebClient wc = new WebClient())
                wc.DownloadFile($"https://api.cryptowat.ch/markets/kraken/{pair}/ohlc?after={dateForm}&periods={period}&apikey=EU7A6MJPFOW2AKKQTZCZ", pathTo);
        }
        public long DateTimeToUnix(DateTime MyDateTime)
        {
            TimeSpan timeSpan = MyDateTime - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)timeSpan.TotalSeconds;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectCandelClose.Convert();
        }


        private async void button4_Click(object sender, EventArgs e)
        {
            string data = textBox2.Text;
            int zeroes = Int32.Parse(comboBox2.Text);
            string z = "0000000000000000000000";
            for (int i = 0; i < 1000000000; i++)
            {
                string hashdata = ComputeSha256Hash(data + i);
                label5.Text = hashdata;
                await Task.Delay(1);
                if (hashdata.Substring(0, zeroes) == z.Substring(0, zeroes))
                {
                    label5.Text = hashdata + "\n" + "Number: " + i;
                    break;
                }
            }
        }
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private  void button7_Click(object sender, EventArgs e)
        {
            NewScaner.ScanRow();
        }
         private void button2_Click(object sender, EventArgs e)
        {
            string pair = textBox3.Text;
            string dateForm = ((int)DateTimeToUnix(DateTime.Now) - 777600).ToString();
            string period = comboBox3.Text;
            string data;
            using (WebClient wc = new WebClient())
            data = wc.DownloadString($"https://api.cryptowat.ch/markets/kraken/{pair}/ohlc?after={dateForm}&periods={period}&apikey=EU7A6MJPFOW2AKKQTZCZ");
            string dataTrim = data.Substring(data.IndexOf("["));
            string dataTrim2 = dataTrim.Remove(dataTrim.IndexOf("}"));
            List<List<double>> arr = new List<List<double>>();
            arr = JsonConvert.DeserializeObject<List<List<double>>>(dataTrim2);
            List<double> newArr = new List<double>();

            for (int i = 0; i < arr.Count; i++)
            {
                
                newArr.Add(Math.Round(arr[i][4] / 100, 3));
            }
            string output = JsonConvert.SerializeObject(newArr);
            label6.Text = output;

            var input = new ModelInput();
            input.Col0 = (float)newArr[0];
            input.Col1 = (float)newArr[1];
            input.Col2 = (float)newArr[2];
            input.Col3 = (float)newArr[3];
            input.Col4 = (float)newArr[4];
            input.Col5 = (float)newArr[5];
            input.Col6 = (float)newArr[6];
            input.Col7 = (float)newArr[7];
            input.Col8 = (float)newArr[8];
            input.Col9 = (float)newArr[9];

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            label8.Text = result.Prediction.ToString();
        }


    }
}
