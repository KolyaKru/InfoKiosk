using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoKiosk
{
    public partial class Form1 : Form
    {
        //Создание списка документов
        List<Docs> docs = new List<Docs>();

        public Form1()
        {
            InitializeComponent();

            //Добавление документов в список (объекты класса Docs)
            docs.Add(new Docs("Пинск помнит Бессмертный Полк", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Пинск помнит Бессмертный Полк.pdf")));
            docs.Add(new Docs("Захоронения героев советского союза г. Пинск", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Захоронения героев советского союза г. Пинск.pdf")));
            docs.Add(new Docs("Памятные места ДВФ в Пинске", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Памятные места ДВФ в Пинске.pdf")));
            docs.Add(new Docs("Моряки ДВФ города Пинска", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Моряки ДВФ города Пинска.pdf")));
            docs.Add(new Docs("Герои СССР связанные с Пинском", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Герои СССР связанные с Пинском.pdf")));
            //docs.Add(new Docs("Пинское ГЕТТО", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Пинское ГЕТТО.mp4")));
            docs.Add(new Docs("Пинчане бравшие Берлин", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Пинчане бравшие Берлин.pdf")));
            docs.Add(new Docs("Почётные граждане города Пинск - участники ВОВ", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Почётные граждане города Пинск - участники ВОВ.pdf")));
            docs.Add(new Docs("Призванные Жабчицким ВК павшие и пропавшие безвести", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Призванные Жабчицким ВК павшие и пропавшие безвести.pdf")));
            docs.Add(new Docs("Призванные Пинским ГВК павшие и пропавшие безвести", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Призванные Пинским ГВК павшие и пропавшие безвести.pdf")));
            //docs.Add(new Docs("Румак Г. А. - один из первых участников днепровской военной флотилии", (AppDomain.CurrentDomain.BaseDirectory + @"\Docs\Румак Г. А. - один из первых участников днепровской военной флотилии.mp4")));

            //Добавление в ListView имена созданных документов
            for (int i = 0; i < docs.Count(); i++)
            {
                listView1.Items.Add(docs[i].Name);
            }
        }

        //Кнопка - Закрыть
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                //Цикл - Поиск процессов Adobe Acrobat  
                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("AcroRd32"))
                {
                    //Закрытие найденных процессов
                    proc.Kill();
                }

                ////Цикл - Поиск процессов Windows Player  
                //foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("wmplayer"))
                //{
                //    //Закрытие найденных процессов
                //    proc.Kill();
                //}

                //Закрытие приложения
                Close();
            }
            catch { }         
        }

        //Кнопка - Посмотреть 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ////Цикл - Поиск процессов Windows Player  
                //foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("wmplayer"))
                //{
                //    //Закрытие найденных процессов
                //    proc.Kill();
                //}

                //Цикл - Поиск процессов Adobe Acrobat  
                foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("AcroRd32"))
                {
                    //Закрытие найденных процессов
                    proc.Kill();
                }

                //Открытие процесса - открыть выбранный документ 
                System.Diagnostics.Process.Start(docs[listView1.FocusedItem.Index].Address);

                //Сворачивание окна приложения
                this.WindowState = FormWindowState.Minimized;
            }
            catch { }
        }

        //Кнопка - Свернуть
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Сворачивание окна приложения
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
