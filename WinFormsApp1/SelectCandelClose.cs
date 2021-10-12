using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAppTabControl
{
    class SelectCandelClose
    {
        public static void Convert()
        {
            List<List<double>> arr = new List<List<double>>();
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
            
                string data = File.ReadAllText(openDialog.FileName);
                string dataTrim = data.Substring(data.IndexOf("["));
                string dataTrim2 = dataTrim.Remove(dataTrim.IndexOf("}"));

                arr = JsonConvert.DeserializeObject<List<List<double>>>(dataTrim2);

                List<double> NewArr = new List<double>();
                for (int i = 0; i < arr.Count; i++)
                {
                    NewArr.Add(Math.Round(arr[i][4] / 100, 3));
                }
                string output = JsonConvert.SerializeObject(NewArr);
                using (FileStream file = new FileStream(@"C:\Users\72555\Desktop\Data2.json", FileMode.Append))
                using (StreamWriter stream = new StreamWriter(file))
                    stream.Write(output);
            
        }
    }
}

