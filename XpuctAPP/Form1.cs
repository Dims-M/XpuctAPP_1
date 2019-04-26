using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XpuctAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if(Test())
            {
                // DeleteFail(path); // удаление
                CoppyFail(path, pathSavee);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Получение даты с помощью командной строки
        /// </summary>
        public void PoluchenieDaty()
        {
            Process process = Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                // Arguments = "/c time /t", // получение текущего времени
                // Arguments = "/c chcp 65001 &  ipconfig", // англ кодировка 65001 рус 1251 
                Arguments = "/c chcp 65001 & dism /online /cleanup-image /startcomponentcleanup",
                UseShellExecute = false, // не использовать текущию видемую оболочку 
                CreateNoWindow = true, // команда на Несоздание окна
                RedirectStandardOutput = true, // переопределение потока 
                                               // WindowStyle = ProcessWindowStyle.Hidden


            });
            label1.Text = process.StandardOutput.ReadToEnd();
            //в лэйбл записываем полученные данные из консоли.
        }

        string path = @"C:\Users\Dim\Desktop\1233.txt";
        string pathSavee = @"C:\Users\Dim\Desktop\1233\saveFile.txt";

        public bool Test()
        {
            bool marker = false;

           // string path = @"C:\Users\Dim\Desktop\1233.txt";

            string path1 = textBox1.Text;

            if (File.Exists(path))
            {
                textBox1.Text = "Данный файл существует!";
                label1.Text = PoluchenieDataTime();
                marker = true;
            }
            
            else
            {
                textBox1.Text = "Данный файл не существует!";
                 label1.Text = PoluchenieDataTime();
            }

            return marker;
        }

        //Кнопка очистки окон
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            label1.Text = " ";
        }


       public void CoppyFail(string SorcePath_, string SavePath)
        {
            try
            {
                File.Copy(SorcePath_, SavePath);
                textBox1.Text = $"Копировали  из {SorcePath_} в {SavePath}";
            }
            catch(Exception ex)
            {
                textBox1.Text = $"ОШИБКА  При копировании файла \t\n {ex}";
            }
            
        }


        /// <summary>
        /// Удаляем файл
        /// </summary>
        /// <param name="path_">Путь к файлу</param>
        public void DeleteFail(string path_)
        {
            try
            {
                File.Delete(path_);
                textBox1.Text = $"Произошло Удаление файла \t\n {path_}";
            }

            catch(Exception ex)
            {
                textBox1.Text = $"ОШИБКА \t\n {ex}";
            }
        }

      public  string PoluchenieDataTime()
        {
          //  DateTime dateTime = new DateTime();

           string dateTime = DateTime.Now.ToString();

            return dateTime;
        }

        //Кнопка выход
        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
