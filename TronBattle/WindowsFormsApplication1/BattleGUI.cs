using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TronBattle.Helpers;


namespace WindowsFormsApplication1
{
    public partial class BattleGui : Form
    {
        private int index = 0;
        private List<Color> _allowerColors = new List<Color> {Color.Blue, Color.Red, Color.Yellow, Color.Green, Color.Chocolate, Color.Gold, Color.BlueViolet, Color.DeepPink, Color.LawnGreen, Color.Orange, Color.PeachPuff, Color.Olive, Color.SteelBlue, Color.RosyBrown};
        private readonly List<string> CompetitorFiles = new List<string>();
        private Dictionary<string,char> AIs = new Dictionary<string, char>();
        private Dictionary<char, Color> PlayerColors = new Dictionary<char, Color>();
        readonly Random _randomGen = new Random();
        private string _map;
        private bool initialized = false;
        private TronBattle.TronBattle _battle;
        public BattleGui()
        {
            InitializeComponent();
        }

        private void btnCompetitor1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "dll|*.dll";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filenames = dialog.FileNames;
                CompetitorFiles.AddRange(filenames);
                ChooseColours();
                var g = pCompetitors.CreateGraphics();
                var font = new Font("Arial", 14);
                var starty = 0;
                foreach (var aI in AIs)
                {
                    var temp = aI.Key.Split('\\').Last();
                    var name = temp.Substring(0, temp.Length - 4);
                    var brush =  new SolidBrush(PlayerColors[aI.Value]);
                    g.DrawString(name, font, brush, 0, starty);
                    starty += 20;
                }
                
            }
        }

        private void ChooseColours()
        {
            foreach (var competitorFile in CompetitorFiles)
            {
                var colour = GetRandomColor();
                while (PlayerColors.ContainsValue(colour))
                {
                    colour = GetRandomColor();
                }
                var letter = Helpers.GetLetter(_randomGen);
                while (AIs.ContainsValue(letter) || letter == 'c' || letter == 'x')
                {
                    letter = Helpers.GetLetter(_randomGen);
                }
                AIs.Add(competitorFile, letter);
                PlayerColors.Add(letter, colour);
            }

        }

        private Color GetRandomColor()
        {
            return _allowerColors[index++];
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!initialized)
            {
                return;
            }
            while (true)
            {
                Thread.Sleep(250);
                var state = _battle.MakeNextMove();
               
                DrawMap(state);
                
                if (!string.IsNullOrEmpty(state.LogEntry))
                {
                    txtEvents.AppendText(state.LogEntry);
                    txtEvents.AppendText(Environment.NewLine);
                }
                
                if (state.IsOver)
                {
                    LblWinner.Text += " " + state.Winner;
                    lblGameOver.Visible = true;
                    LblWinner.Visible = true;

                    break;
                }
            }

        }

        private void DrawMap(TronBattle.GameState state)
        {
            var g = pictureBox1.CreateGraphics();
            var whitepen = new Pen(Color.White);
            for (var x = 0; x < 50; x++)
            {
                for (var y = 0; y < 50; y++)
                {
                    var blackBrush = new SolidBrush(Color.Black);
                    var color = state.Map[x][y];
                    if (color == '-')
                    {
                        continue;
                    }
                    if (color == 'C')
                    {
                        
                        g.FillRectangle(new SolidBrush(Color.Black), x*16, y* 16, 16, 16);
                        g.DrawLine(whitepen, x* 16, y* 16, x* 16 + 17, y* 16 + 17);
                        g.DrawLine(whitepen, x* 16, y* 16 + 17, x* 16 + 17, y* 16);
                    } else if (color == 'X')
                    {
                        g.FillRectangle(blackBrush, x * 16, y * 16, 16, 16);
                    }
                    else
                    {
                        var realchar = char.ToLower(color);
                        var brush = new SolidBrush(PlayerColors[realchar]);

                        if (char.IsUpper(color))
                        {
                            var blackPen = new Pen(Color.Black);
                            var goodPen = new Pen(PlayerColors[realchar]);
                            var greyPen = new Pen(Color.DimGray);
                            var maxX = x*16;
                            var maxY = y*16;
                            g.DrawLine(whitepen, maxX, maxY, maxX + 16, maxY);

                            g.DrawLine(whitepen, maxX, maxY+1, maxX + 3, maxY+1);
                            g.DrawLine(blackPen, maxX+4, maxY+1, maxX + 12, maxY+1);
                            g.DrawLine(whitepen, maxX+13, maxY+1, maxX + 16, maxY+1);

                            g.DrawLine(whitepen, maxX, maxY + 2, maxX + 3, maxY + 2);
                            g.DrawLine(blackPen, maxX + 4, maxY + 2, maxX + 5, maxY + 2);
                            g.DrawLine(goodPen, maxX + 6, maxY + 2, maxX + 10, maxY + 2);
                            g.DrawLine(blackPen, maxX + 11, maxY + 2, maxX + 12, maxY + 2);
                            g.DrawLine(whitepen, maxX + 13, maxY + 2, maxX + 16, maxY + 2);

                            g.DrawLine(whitepen, maxX, maxY + 3, maxX + 3, maxY + 3);
                            g.DrawLine(blackPen, maxX + 4, maxY + 3, maxX + 5, maxY + 3);
                            g.DrawLine(goodPen, maxX + 6, maxY + 3, maxX + 10, maxY + 3);
                            g.DrawLine(blackPen, maxX + 11, maxY + 3, maxX + 12, maxY + 3);
                            g.DrawLine(whitepen, maxX + 13, maxY + 3, maxX + 16, maxY + 3);

                            g.DrawLine(whitepen, maxX, maxY + 4, maxX + 3, maxY + 4);
                            g.DrawLine(blackPen, maxX + 4, maxY + 4, maxX + 5, maxY + 4);
                            g.DrawLine(goodPen, maxX + 6, maxY + 4, maxX + 10, maxY + 4);
                            g.DrawLine(blackPen, maxX + 11, maxY + 4, maxX + 12, maxY + 4);
                            g.DrawLine(whitepen, maxX + 13, maxY + 4, maxX + 16, maxY + 4);

                            g.DrawLine(whitepen, maxX, maxY + 5, maxX + 3, maxY + 5);
                            g.DrawLine(blackPen, maxX + 4, maxY + 5, maxX + 5, maxY + 5);
                            g.DrawLine(goodPen, maxX + 6, maxY + 5, maxX + 10, maxY + 5);
                            g.DrawLine(blackPen, maxX + 11, maxY + 5, maxX + 12, maxY + 5);
                            g.DrawLine(whitepen, maxX + 13, maxY + 5, maxX + 16, maxY + 5);


                            g.DrawLine(whitepen, maxX, maxY + 6, maxX + 5, maxY + 6);
                            g.DrawLine(goodPen, maxX + 6, maxY + 6, maxX + 10, maxY + 6);
                            g.DrawLine(whitepen, maxX + 11, maxY + 6, maxX + 16, maxY + 6);

                            g.DrawLine(whitepen, maxX, maxY + 7, maxX + 5, maxY + 7);
                            g.DrawLine(goodPen, maxX + 6, maxY + 7, maxX + 6, maxY + 7);
                            g.DrawLine(blackPen, maxX + 7, maxY + 7, maxX + 9, maxY + 7);
                            g.DrawLine(goodPen, maxX + 10, maxY + 7, maxX + 10, maxY + 7);
                            g.DrawLine(whitepen, maxX + 11, maxY + 7, maxX + 16, maxY + 7);

                            g.DrawLine(whitepen, maxX, maxY + 8, maxX + 5, maxY + 8);
                            g.DrawLine(goodPen, maxX + 6, maxY + 8, maxX + 6, maxY + 8);
                            g.DrawLine(blackPen, maxX + 7, maxY + 8, maxX + 9, maxY + 8);
                            g.DrawLine(goodPen, maxX + 10, maxY + 8, maxX + 10, maxY + 8);
                            g.DrawLine(whitepen, maxX + 11, maxY + 8, maxX + 16, maxY + 8);

                            g.DrawLine(whitepen, maxX, maxY + 9, maxX + 3, maxY + 9);
                            g.DrawLine(blackPen, maxX+4, maxY + 9, maxX + 5, maxY + 9);
                            g.DrawLine(goodPen, maxX + 6, maxY + 9, maxX + 6, maxY + 9);
                            g.DrawLine(blackPen, maxX + 7, maxY + 9, maxX + 9, maxY + 9);
                            g.DrawLine(goodPen, maxX + 10, maxY + 9, maxX + 10, maxY + 9);
                            g.DrawLine(blackPen, maxX + 11, maxY + 9, maxX + 12, maxY + 9);
                            g.DrawLine(whitepen, maxX + 13, maxY + 9, maxX + 16, maxY + 9);


                            g.DrawLine(whitepen, maxX, maxY + 10, maxX + 3, maxY + 10);
                            g.DrawLine(blackPen, maxX + 4, maxY + 10, maxX + 5, maxY + 10);
                            g.DrawLine(goodPen, maxX + 6, maxY + 10, maxX + 6, maxY + 10);
                            g.DrawLine(blackPen, maxX + 7, maxY + 10, maxX + 9, maxY + 10);
                            g.DrawLine(goodPen, maxX + 10, maxY + 10, maxX + 10, maxY + 10);
                            g.DrawLine(blackPen, maxX + 11, maxY + 10, maxX + 12, maxY + 10);
                            g.DrawLine(whitepen, maxX + 13, maxY + 10, maxX + 16, maxY + 10);

                            g.DrawLine(whitepen, maxX, maxY + 11, maxX + 3, maxY + 11);
                            g.DrawLine(blackPen, maxX + 4, maxY + 11, maxX + 5, maxY + 11);
                            g.DrawLine(goodPen, maxX + 6, maxY + 11, maxX + 6, maxY + 11);
                            g.DrawLine(blackPen, maxX + 7, maxY + 11, maxX + 9, maxY + 11);
                            g.DrawLine(goodPen, maxX + 10, maxY + 11, maxX + 10, maxY + 11);
                            g.DrawLine(blackPen, maxX + 11, maxY + 11, maxX + 12, maxY + 11);
                            g.DrawLine(whitepen, maxX + 13, maxY + 11, maxX + 16, maxY + 11);


                            g.DrawLine(whitepen, maxX, maxY + 12, maxX + 3, maxY + 12);
                            g.DrawLine(blackPen, maxX + 4, maxY + 12, maxX + 5, maxY + 12);
                            g.DrawLine(goodPen, maxX + 6, maxY + 12, maxX + 10, maxY + 12);
                            g.DrawLine(blackPen, maxX + 11, maxY + 12, maxX + 12, maxY + 12);
                            g.DrawLine(whitepen, maxX + 13, maxY + 12, maxX + 16, maxY + 12);



                            g.DrawLine(whitepen, maxX, maxY + 13, maxX + 3, maxY + 13);
                            g.DrawLine(blackPen, maxX + 4, maxY + 13, maxX + 5, maxY + 13);
                            g.DrawLine(goodPen, maxX + 6, maxY + 13, maxX + 10, maxY + 13);
                            g.DrawLine(blackPen, maxX + 11, maxY + 13, maxX + 12, maxY + 13);
                            g.DrawLine(whitepen, maxX + 13, maxY + 13, maxX + 16, maxY + 13);

                            g.DrawLine(whitepen, maxX, maxY + 14, maxX + 3, maxY + 14);
                            g.DrawLine(blackPen, maxX + 4, maxY + 14, maxX + 12, maxY + 14);
                            g.DrawLine(whitepen, maxX + 13, maxY + 14, maxX + 16, maxY + 14);

                            g.DrawLine(whitepen, maxX, maxY + 15, maxX + 3, maxY + 15);
                            g.DrawLine(blackPen, maxX + 4, maxY + 15, maxX + 12, maxY + 15);
                            g.DrawLine(whitepen, maxX + 13, maxY + 15, maxX + 16, maxY + 15);

                            g.DrawLine(whitepen, maxX, maxY + 16, maxX + 16, maxY + 16);
                        }
                        else
                        {
                            g.FillRectangle(brush, x * 16, y * 16, 16, 16);
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            initialized = false;
            txtEvents.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblGameOver.Visible = false;
            LblWinner.Visible = false;
            lblWinReason.Text = "";
            LblWinner.Text = "The winner is:";

            if (CompetitorFiles.Count == 1)
            {
                MessageBox.Show("Please select more than one competitor");
                return;
            }
            _battle = new TronBattle.TronBattle(AIs, _map);
            var initialState = _battle.GetInitialGameState();
            DrawMap(initialState);
            initialized = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "txt|*.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _map = dialog.FileName;
            }
        }
    }
}
