using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XpuctAPP
{

    delegate int DelegatSumInt(int x, int y);
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


            //Чтение файла с помощью стрима

            //Работа с делегатом и лямба функциями.
            // StartLambaMetoht();
            // chenueFailaStream(); // выводим 
            //запись в файл.
            // ZapisFaila();

            //Работаем с регуляркой 
            // RabRegex(); // значения по умолчанию.
          //  RabRegexInZnach(); 


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

        string pathZoobr = @"C:\Users\Dim\Desktop\зубр.txt";
        string path = @"C:\Users\Dim\Desktop\1233.txt";
        string path12 = @"C:\Users\Dim\Desktop\reges.txt";
        string path1 = @"C:\Users\Dim\Desktop\29599998716.pdf";
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
            catch (Exception ex)
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

            catch (Exception ex)
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
            catch (Exception ex)
            {
                textBox1.Text = $"ОШИБКА  При создании категории \t\n {ex}";

            }


            return otvet;
        }

        public void readFile(string path)
        {
            string textt = File.ReadAllText(path);

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
            catch (Exception ex)
            {
                textBox1.Text = $"ОШИБКА  При записи файла \t\n {ex}";
            }
        }


        #endregion

        /// <summary>
        /// Получение даты и времени.
        /// </summary>
        /// <returns></returns>
        public string PoluchenieDataTime()
        {
            //  DateTime dateTime = new DateTime();

            string dateTime = DateTime.Now.ToString();

            return dateTime;
        }

        /// <summary>
        /// Чтение из текстового файла. С помощью StreamReader
        /// </summary>
        public string chenueFailaStream
            ()
        {
            string line;
        using (StreamReader reader = new StreamReader(path12, Encoding.Default) )
        {

                line = reader.ReadToEnd(); ;
                //while ((line = sr.ReadLine()) != null)
                //{
                //    Console.WriteLine(line);
                //}

                 textBox1.Text = line;
            }
            return line;
        }
      
        /// <summary>
        /// Чтение из текстового файла  С передачей параметра нахождения файла.
        /// </summary>
        /// <param name="str">Путь к файлу</param>
        /// <returns></returns>
        public string chenueFailaStreamParams(string str)  
        {
            string line;
            using (StreamReader reader = new StreamReader(str, Encoding.Default))
            {
                line = reader.ReadToEnd(); ;
            }
            return line;
        }

        /// <summary>
        /// Запись файла в файл(Stream)
        /// </summary>
        public void ZapisFaila()
        {
            //указываем куда записываем, перезапись, кодировку
            using(StreamWriter sw = new StreamWriter(pathЬщмуу,true,Encoding.UTF8))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(textBox1.Text);
            }
        }

        public void ZapisFailaParams(string pah_, string textContent)
        {
            //указываем куда записываем, перезапись, кодировку
            using (StreamWriter sw = new StreamWriter(pah_, true, Encoding.UTF8))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(textContent);
            }
        }

        /// <summary>
        ///Регулярный метод №1 поиск по маске
        /// </summary>
        public void RabRegex()
        {

            //string line = "Какой-то текст, который от другого текста не отличается от другого текст.";
            string line = chenueFailaStream();

            Regex regex = new Regex("030000000231");

            MatchCollection match = regex.Matches(line);

            textBox1.Text = "\n";
            string tempZ = $"Количество совпадения: {match.Count.ToString()}";
            textBox1.Text += tempZ;

            
        }

        /// <summary>
        /// Поиск с помощью регулярного выражения
        /// </summary>
        public void RabRegexInZnach()
        {
            //где ищем
            string line = chenueFailaStream();

            //Что ищем
            string tempZnach = textBox2.Text;

            //маска поиска
            Regex regex = new Regex(tempZnach);

           // сохраняем результат поиска
            MatchCollection match = regex.Matches(line);

            //сохранение и вывод полученных  значений
            textBox1.Text = "\n";
            string tempZ = $"Искомое {tempZnach}\nКоличество совпадения: {match.Count.ToString()}";
            textBox1.Text += tempZ;

            //поиск пробелов > 1
           // string pattern = @"\s+"; //ищем пробелы которые больше 1.
            string pattern = @"\s+"; //ищем пробелы которые больше 1.
            //string zamenProbel = " "; //на что заменяем
            string zamenProbel = " *"; //на что заменяем
            Regex regex1 = new Regex(pattern);
            string znach1 = regex1.Replace(line,zamenProbel); //где ищим, на что меняем
            string tempZ123 = $"Ищем в {tempZnach}\nКоличество замененных побелов: {znach1}";

            ZapisFailaParams(path, tempZ);
            //ZapisFailaParams(path, tempZ123); // записть в лог

        }

        public void RabRegexInZnach2()
        {
           string tempSorse = chenueFailaStreamParams(pathZoobr);

            string tempZnach = new Regex(@"\s+").Replace(tempSorse,","); //Ищем все пробелы которые больше 1-го и заменяем их на 1 пробел " " 

            textBox1.Text = tempZnach;
        }


        public void ParseCorsDolarsRegex()
        {
            string line;
            string datee = DateTime.Now.ToLongTimeString().ToString();
            string nameFile = "XML_daily_" + "datee" + ".xml";
            using (WebClient wc = new WebClient() )
            {
                line = wc.DownloadString("http://www.cbr.ru/scripts/XML_daily.asp");
                wc.DownloadFile("http://www.cbr.ru/scripts/XML_daily.asp", nameFile);
            }
            label1.Text = line;
        }

        //лямба методы
        public void StartLambaMetoht()
        {
            textBox1.Text += "Метод делегата. \nСуммируем2 числа ";
           DelegatSumInt SumaXY = (x, y) => x + y;

            textBox1.Text += $"Результаты сложения:{SumaXY(10,25).ToString()}";

        //список параметров,
        }

        //Кнопка выход

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Кнопка найти
        private void Button4_Click(object sender, EventArgs e)
        {
            //RabRegexInZnach(); // п
            //RabRegexInZnach2();

            ParseCorsDolarsRegex(); // Спасрить данные по api 
        }
    }
}
