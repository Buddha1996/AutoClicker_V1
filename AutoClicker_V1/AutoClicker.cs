using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoClicker_V1
{
    class AutoClicker
    {
        /// <summary>
        /// Diese Klasse stellt den Algorithmus zur Erfassung, Speicherung und der Programmseitigen Benutzung der Maus Positionen bereit und lässt diese sooft "Anklicken" wie im+
        /// Startfenster bei Wiederholung eingetragen wurde. Ausserdem wird hier auch die zeitliche Dauer je Intervall in den Algorithmus eingearbeitet.
        /// </summary>
        public int Clicks = 0;
        public int Repeats = 0;
        public int sleep = 0;

        public static System.Drawing.Point Position { get; set; }

        public uint[] CursorPositionsX = new uint[0];
        public uint[] CursorPositionsY = new uint[0];

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(uint X1, uint Y1);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Thread.Sleep(5000);
            }
        }

        public void Start()
        {
            //Erfassung der Positionen
            for (int i = 1; i <= Clicks; i++)
            {
                var result = System.Windows.Forms.MessageBox.Show("Linksklick auf gewünschte Position! Danach mit 'Enter' OK bestätigen, Abbruch um zum Menü zurückzukehren!", "Erfasse Ziel", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if (result == DialogResult.Cancel)
                {
                    break; //Abbruch
                }

                if (result == DialogResult.OK)
                {

                    uint X = Convert.ToUInt32(Cursor.Position.X);
                    uint Y = Convert.ToUInt32(Cursor.Position.Y);

                    System.Windows.Forms.MessageBox.Show("Bestätige Pos: " + X + " " + Y, "Ziel Erfasst", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Array.Resize(ref CursorPositionsX, CursorPositionsX.Length + 1);
                    CursorPositionsX[CursorPositionsX.Length - 1] = X;

                    Array.Resize(ref CursorPositionsY, CursorPositionsY.Length + 1);
                    CursorPositionsY[CursorPositionsY.Length - 1] = Y;

                    Console.WriteLine("Position X " + X + "Position Y " + Y);

                    Console.WriteLine("Written Cursor Positions to Array..");
                }
            }
        }

        public void ClickBot()
        {

            try
            {

                for (int j = 1; j <= Repeats; j++)
                {
                    //Initialisierung der Positionen
                    int index = 0;
                    for (int k = 1; k <= Clicks; k++)
                    {

                        int PosX = (int)CursorPositionsX[index];
                        int PosY = (int)CursorPositionsY[index];

                        //Einbau der im Startfenster eingegbenen Wartezeit in Sekunden je Intervall
                        Thread.Sleep(sleep);
                        System.Windows.Forms.Cursor.Position = new Point(PosX, PosY);

                        //Klick
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                        //Erhöhung des Index
                        index += 1;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}