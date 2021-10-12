using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class NewScaner
    {
        public static string PATHTO { get; set; }

        public static void ScanRow()
        {
            List<double> arr = OpenFrom();

            int percent = 10;
            int step = 10;
            int half = step / 2;

            for (int i = step; i < arr.Count-step; i++)
            {
                if (arr[i] > arr[i-1] + (arr[i-1] / 100 * percent))
                {
                    var newList = arr.Skip(i - step).Take(step).ToList();
                    newList.Add(1.000);
                    string str = string.Join(",", newList);
                    SaveTo(str);
                }
                if (arr[i] < arr[i-1] - (arr[i-1] / 100 * percent))
                {
                    var newList = arr.Skip(i - step).Take(step).ToList();
                    newList.Add(2.000);
                    string str = string.Join(",", newList);
                    SaveTo(str);
                }
            }
        }

        public static List<double> OpenFrom()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.ShowDialog();
            PATHTO = saveDialog.FileName;
            List<double> arr = new List<double>();
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            string data = File.ReadAllText(openDialog.FileName);
            arr = JsonConvert.DeserializeObject<List<double>>(data);

            return arr;
        }
        public static void SaveTo(string str)
        {
            
            using (FileStream file = new FileStream(PATHTO, FileMode.Append))
            using (StreamWriter stream = new StreamWriter(file))
                stream.WriteLine(str);
        }
    }
}
