using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClicker_V1
{
    public partial class Form1 : Form
    {
        AutoClicker autoClicker = new AutoClicker();


        public Form1()
        {
            InitializeComponent();
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {               
                autoClicker.Repeats = Convert.ToInt32(textBox1.Text);
                autoClicker.Clicks = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception) { Console.WriteLine("Fehler!"); }
            autoClicker.Start();
            autoClicker.ClickBot();

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.Text == "0")
            { autoClicker.sleep = 0; }
            if (listBox1.Text == "1")
            { autoClicker.sleep = 1000; }
            if (listBox1.Text == "2")
            { autoClicker.sleep = 2000; }
            if (listBox1.Text == "3")
            { autoClicker.sleep = 3000; }
            if (listBox1.Text == "4")
            { autoClicker.sleep = 4000; }
            if (listBox1.Text == "5")
            { autoClicker.sleep = 5000; }
            if (listBox1.Text == "6")
            { autoClicker.sleep = 6000; }
            if (listBox1.Text == "7")
            { autoClicker.sleep = 7000; }
            if (listBox1.Text == "8")
            { autoClicker.sleep = 8000; }
            if (listBox1.Text == "9")
            { autoClicker.sleep = 9000; }
            if (listBox1.Text == "10")
            { autoClicker.sleep = 10000; }
        }

        private void infoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.C)
            {
                this.Close();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
            {
                this.Close();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "1. Zahl eintragen bei 'Anzahl der  Wiederholungen' um die Anzahl der Durchläufe zu definieren.\n2. Zahl eintragen bei 'Anzahl der Klicks' um festzulegen wieviel Klicks je durchlauf gemacht werden sollen\n3.Wenn benötigt kann bei 'Zeit in S zwischen Klicks' eingestellt werden wieviel Sekunden der Bot warten soll je Durchlauf\n4. Start Drücken\n6.Gewünschte Position anklicken\n7.Alt+Tab drücken und damit Programm wieder aufrufen damit mit Tastatur Enter die Position bestätigt werden kann\n8.Weitere gewünschte Positionen anklicken und bestätigen - sooft wiederholen wie bei Anzahl Klicks eingetragen wurde.\n9.Der Algorithmus merkt sich die Reihenfolge der Klicks. Ab jetzt Abwarten und Zuschauen\n10. Stop beendet das Programm";
            string caption = "Anleitung";
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
