using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class SudokuForm : Form
    {
        public SudokuPolje[,] polja = new SudokuPolje[9, 9];
        int[,] startMat;
        int tezina = 21;

        public SudokuForm()
        {
            InitializeComponent();

            trackBar1.Value = 3;


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var polje = new SudokuPolje(i, j, this);
                    polje.Location = new System.Drawing.Point(i * 500 / 9, j * 500 / 9);
                    polje.Size = new Size(40, 40);
                    polje.MaxLength = 1;
                    polje.TextAlign = HorizontalAlignment.Center;
                    polje.Font = new Font("Arial", 24, FontStyle.Bold);
                    polje.Enabled = false;
                    panel1.Controls.Add(polje);
                    polja[i, j] = polje;
                   

                }
            }

            pixelArt();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Brush color = Brushes.DarkGray;

            Rectangle r1 = new Rectangle(500 / 3 - 10, 0, 5, 500);
            Rectangle r2 = new Rectangle(500 * 2 / 3 - 10, 0, 5, 500);
            Rectangle r3 = new Rectangle(0, 500 / 3 - 8, 500, 5);
            Rectangle r4 = new Rectangle(0, 500 * 2 / 3 - 8, 500, 5);

            e.Graphics.FillRectangle(color, r1);
            e.Graphics.FillRectangle(color, r2);
            e.Graphics.FillRectangle(color, r3);
            e.Graphics.FillRectangle(color, r4);
        }
        private void generisiSudokuBtn_Click(object sender, EventArgs e)
        {
            SudokuGenerator gen = new SudokuGenerator(9, tezina);
            gen.fillValues();
            startMat = gen.getSudoku();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    polja[i, j].Text = "";
                    polja[i, j].ForeColor = Color.Black;
                    polja[i, j].BackColor = Color.White;
                    polja[i, j].Enabled = true;
                    if (startMat[i, j] != 0)
                    {
                        polja[i, j].ForeColor = Color.Blue;
                        polja[i, j].Text = startMat[i, j].ToString();
                        polja[i, j].Enabled = false;
                    }
                }
            }
        }
        private void pixelArt()
        {
            int[,] map = {{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0, 0, 0, 0, 0},
                           {0, 0, 1, 1, 0, 1, 1, 0, 0 },
                           {0, 1, 1, 1, 1, 1, 1, 1, 0 },
                           {0, 1, 1, 1, 1, 1, 1, 1, 0 },
                           {0, 0, 1, 1, 1, 1, 1, 0, 0},
                           {0, 0, 0, 1, 1, 1, 0, 0, 0},
                           {0, 0, 0, 0, 1, 0, 0, 0, 0},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0}
                           };
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (map[i, j] == 1)
                        polja[j, i].BackColor = Color.Red;
                    else polja[j, i].BackColor = Color.White;
                }
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            tezina = trackBar1.Value*6+4;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pravila su sledeća: Cilj je popuniti sva prazna polja, tako da se u istoj koloni, istom redi i u istom kvadratu(3x3) ne ponovi nijedan broj.");
        }
    }
}
