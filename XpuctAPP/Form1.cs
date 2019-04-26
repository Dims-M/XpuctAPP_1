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
           

           // if(Test())
           // {
                // DeleteFail(path); // удаление
                // CoppyFail(path, pathSavee); //копирование с зпменной файла
                // PeremeshenieFail(path, pathSavee); // перенос файла с заменной
                //CreateFile(@"C:\Users\Dim\Desktop\temp");
                // readFile(path); // прочитать из файла
              //  ZapisWraitFile();



          //  }


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
        string pathЬщмуу = @"C:\Users\Dim\Desktop\1233\temp.txt";

        #region Старые методы

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

        /// <summary>
        /// Коппирование с заменной файла
        /// </summary>
        /// <param name="SorcePath_">Какой файл копируем</param>
        /// <param name="SavePath">Куда файл копируем</param>
       public void CoppyFail(string SorcePath_, string SavePath)
        {
            try
            {
                File.Copy(SorcePath_, SavePath, true); // с перезаписью файла
                textBox1.Text = $"Копировали  из {SorcePath_} в {SavePath}";

            }
            catch(Exception ex)
            {
                textBox1.Text = $"ОШИБКА  При копировании файла \t\n {ex}";
            }
            
        }

        /// <summary>
        /// Перемещение файла с заменнной
        /// </summary>
        /// <param name="SorcePath_"></param>
        /// <param name="SavePath"></param>
        public void PeremeshenieFail(string SorcePath_, string SavePath)
        {
            try
            {
                File.Copy(SorcePath_, SavePath, true); // с перезаписью файла
                textBox1.Text = $"Переместили фал  из {SorcePath_} в {SavePath}";

            }
            catch (Exception ex)
            {
                textBox1.Text = $"ОШИБКА  При перемещении файла \t\n {ex}";
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

        /// <summary>
        /// Создание папки категории
        /// </summary>
        /// <param name="path">Путьдля создания нужной папки</param>
        /// <returns></returns>
       public bool CreateFile(string path)
        {
            bool otvet = false;
            try
            {
                Directory.CreateDirectory(path);
                otvet = true;
                textBox1.Text = $"Созданна котегория {path}";

            }
            catch(Exception ex)
            {
                textBox1.Text = $"ОШИБКА  При создании категории \t\n {ex}";

            }
           

            return otvet;
        }

       public void readFile(string path)
        {
           string textt= File.ReadAllText(path);

            textBox1.Text = textt;

        }

        /// <summary>
        /// Запис в файл. С указанием места создания и записи
        /// </summary>
        public void ZapisWraitFile()
        {
            List<string> ts = new List<string>();
            var a = $"{ textBox1.Text } \n";

            ts.Add(a);

          //  var ff = new string[] {a};

            try
            {
                File.WriteAllLines(pathЬщмуу, ts);
                
            }
            catch(Exception ex)
            {
                textBox1.Text = $"ОШИБКА  При записи файла \t\n {ex}";
            }
        }


      public  string PoluchenieDataTime()
        {
          //  DateTime dateTime = new DateTime();

           string dateTime = DateTime.Now.ToString();

            return dateTime;
        }

        #endregion 
       
        //Кнопка выход
        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
