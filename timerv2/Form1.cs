using System;
using System.Drawing;
using System.Windows.Forms;

namespace timerv2
{
    public partial class Form1 : Form
    {
        private int clickCount;
        private int maxClickCount;
        private Color[] colors = { Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Cyan, Color.Blue, Color.Pink, Color.White };
        private int currentColorIndex = 0;
        private int a = 0;

        DateTime bdayTimeLeft = new DateTime(2023, 6, 29, 0, 0, 0);
        DateTime NewYearLeft = new DateTime(2024, 1, 1, 0, 0, 0);
        DateTime TheEnd = new DateTime(2023, 6, 13, 19, 35, 0);

        string myBday = "My bday in ";
        string NewYear = "Happy new year in ";
        string WF = "WF will be removed from my PC in ";

  

        public Form1()
        {
            InitializeComponent();
            clickCount = 0;
            maxClickCount = 0;

            timer1 = new System.Windows.Forms.Timer();
            timer2 = new System.Windows.Forms.Timer();
            timer3 = new System.Windows.Forms.Timer();

            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();

            timer2.Tick += timer2_Tick;
            timer2.Interval = 1000;
            timer2.Enabled = true;
            timer2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clickCount++;
            button1.Name= clickCount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            clickCount = 0;

            // Отключаем кнопку старта, чтобы предотвратить повторные запуски
            button2.Enabled = false;

            // Включаем кнопку клика, чтобы пользователь мог совершать клики
            button1.Enabled = true;

            // Запускаем таймер на 5 секунд
            timer3.Interval = 5000; // 5 секунд
            timer3.Tick += new EventHandler(timer_Tick);
            timer3.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Останавливаем таймер
            timer3.Stop();

            // Выводим результаты
            MessageBox.Show("Количество кликов: " + clickCount.ToString() + "\nМаксимальный рекорд: " + maxClickCount.ToString());

            // Обновляем максимальный рекорд
            if (clickCount > maxClickCount)
            {
                maxClickCount = clickCount;
            }

            // Сбрасываем количество кликов
            clickCount = 0;

            // Включаем кнопку старта
            button2.Enabled = true;

            // Отключаем кнопку клика
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a = a + 10;
            this.Text = a.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan TimeRemaining = bdayTimeLeft - DateTime.Now;
            TimeSpan TimeRemaining1 = NewYearLeft - DateTime.Now;
            TimeSpan TimeRemaining2 = TheEnd - DateTime.Now;

            label2.Text = myBday + TimeRemaining.Days + " : " + TimeRemaining.Hours + " : " + TimeRemaining.Minutes + " : " + TimeRemaining.Seconds;
            label3.Text = NewYear + TimeRemaining1.Days + " : " + TimeRemaining1.Hours + " : " + TimeRemaining1.Minutes + " : " + TimeRemaining1.Seconds;
            label1.Text = WF + TimeRemaining2.Days + " : " + TimeRemaining2.Hours + " : " + TimeRemaining2.Minutes + " : " + TimeRemaining2.Seconds;

            Color currentColor = colors[currentColorIndex];
            this.BackColor = currentColor;
            this.Refresh();

            currentColorIndex = (currentColorIndex + 1) % colors.Length;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}