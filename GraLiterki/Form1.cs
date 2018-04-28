using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraLiterki
{
    public partial class Form1 : Form
    {

        Random random = new Random();
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65,90));
            if (listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Koniec Gry");
                timer1.Stop();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode))
            {

                listBox1.Items.Remove(e.KeyCode);
                if(timer1.Interval >400) { timer1.Interval -= 10; }
                if (timer1.Interval > 250) { timer1.Interval -= 7; }
                if (timer1.Interval > 100) { timer1.Interval -= 2; }

                difficultyProgressBar.Value = 800 - timer1.Interval;
                stats.update(true);
            }
            else
            {

                stats.update(false);
            }

            correctLabel.Text = "Prawidłowych: "+ stats.Correct;
            missedLabel.Text = "Błędnych: " + stats.Missed;
            totalLabel.Text = "Wszystkich: " + stats.Total;
            accuracyLabel.Text = "Dokładność: " + stats.Accuracy + "%";





        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }

    public class Stats
    {
        public int Total;
        public int Missed;
        public int Correct;
        public int Accuracy;

        public void update(bool correctKey)
        {
            Total++;

            if (!correctKey)
            {
                Missed++;
            }
            else
            {
                Correct++;
            }

            Accuracy = 100 * Correct / Total;

        }

    }
}
