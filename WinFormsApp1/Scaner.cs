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
    class Scaner
    {

        public static string PATHTO { get; set; }
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

        public static void Scan()
        {
            List<double> arr = OpenFrom();
            int percent = 10;
            int step = 10;
            int collect = 0;
            int half = step / 2;
            for (int i = 0; i < arr.Count - step; i += step)
            {
                double per = arr[i] / 100 * percent;
                for (int j = i; j < i + step; j++)
                {

                    if (arr[j + half] > arr[j + half - 1] + per)
                    {
                        if (arr[j + half + 1] < arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 1] < arr[j + half - 1] + per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 2] < arr[j + half - 1] + per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 2] < arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 2] < arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] < arr[j + half - 1] + per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] < arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] < arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] < arr[j + half + 2])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] < arr[j + half - 1] + per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] < arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] < arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] < arr[j + half + 2])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] < arr[j + half + 3])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] < arr[j + half - 1] + per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] < arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] < arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] < arr[j + half + 2])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] < arr[j + half + 3])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] < arr[j + half + 4])
                            collect += 0;
                        else
                            collect++;
                    }

                    else
                        collect += 0;
                    if (collect > 6)
                    {
                        collect = 0;
                        var newList = arr.Skip(j).Take(step).ToList();
                        newList.Add(1);
                        SaveTo(newList);


                    }
                }
            }
        }
        public static void ScanFallPoints()
        {
            List<double> arr = OpenFrom();
            int percent = 10;
            int step = 10;
            int collect = 0;
            int half = step / 2;
            for (int i = 0; i < arr.Count - step; i += step)
            {
                double per = arr[i] / 100 * percent;
                for (int j = i; j < i + step; j++)
                {

                    if (arr[j + half] < arr[j + half - 1] - per)
                    {
                        if (arr[j + half + 1] > arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 1] > arr[j + half - 1] - per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 2] > arr[j + half - 1] - per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 2] > arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 2] > arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] > arr[j + half - 1] - per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] > arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] > arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 3] > arr[j + half + 2])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] > arr[j + half - 1] - per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] > arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] > arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] > arr[j + half + 2])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 4] > arr[j + half + 3])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] > arr[j + half - 1] - per)
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] > arr[j + half])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] > arr[j + half + 1])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] > arr[j + half + 2])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] > arr[j + half + 3])
                            collect += 0;
                        else
                            collect++;
                        if (arr[j + half + 5] > arr[j + half + 4])
                            collect += 0;
                        else
                            collect++;
                    }

                    else
                        collect += 0;
                    if (collect > 6)
                    {
                        collect = 0;
                        var newList = arr.Skip(j).Take(step).ToList();
                        newList.Add(0);
                        SaveTo(newList);


                    }
                }
            }
        }
        public static void SaveTo(List<double> arr)
        {
            string output = JsonConvert.SerializeObject(arr);
            using (FileStream file = new FileStream(PATHTO, FileMode.Append))
            using (StreamWriter stream = new StreamWriter(file))
                stream.Write(output);
        }

    }
}
