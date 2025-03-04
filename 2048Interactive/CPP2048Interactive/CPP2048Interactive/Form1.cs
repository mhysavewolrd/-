using System;
using System.Windows.Forms;

namespace CPP2048Interactive
{
    public partial class Form1 : Form
    {
        private Game2048 game;
        private Label[][] labels = new Label[4][];

        public Form1()
        {
            InitializeComponent();
            game = new Game2048();
            InitializeLabels();
            UpdateUI();
        }

        private void InitializeLabels()
        {
            labels[0] = new[] { label00, label01, label02, label03 };
            labels[1] = new[] { label10, label11, label12, label13 };
            labels[2] = new[] { label20, label21, label22, label23 };
            labels[3] = new[] { label30, label31, label32, label33 };
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (game.MoveUp())
            {
                game.GenerateNewNumber();
            }
            UpdateUI();
            if (game.CheckWin())
            {
                MessageBox.Show("Congratulations! You've won!", "2048 Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (game.MoveDown())
            {
                game.GenerateNewNumber();
            }
            UpdateUI();
            if (game.CheckWin())
            {
                MessageBox.Show("Congratulations! You've won!", "2048 Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (game.MoveLeft())
            {
                game.GenerateNewNumber();
            }
            UpdateUI();
            if (game.CheckWin())
            {
                MessageBox.Show("Congratulations! You've won!", "2048 Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void btnRight_Click(object sender, EventArgs e)
        {
            if (game.MoveRight())
            {
                game.GenerateNewNumber();
            }
            UpdateUI();
            if (game.CheckWin())
            {
                MessageBox.Show("Congratulations! You've won!", "2048 Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void UpdateUI()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    labels[i][j].Text = game.board[i][j].ToString();
                    if (game.board[i][j] == 0) labels[i][j].Text = ""; // 如果值为0，就不显示
                }
            }
        }




        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        
        }
    }


    public class Game2048
    {
        public void GenerateNewNumber()
        {
            Random rand = new Random();
            int value = (rand.Next(0, 2) == 0) ? 2 : 4;  // 产生2或4
            int x, y;
            do
            {
                x = rand.Next(0, 4);
                y = rand.Next(0, 4);
            } while (board[x][y] != 0); //确保选择的位置是空的

            board[x][y] = value;
        }

        public int[][] board;

        public Game2048()
        {
            board = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                board[i] = new int[4];
            }
            // 启动时初始化一个随机位置的数字
            Random rand = new Random();
            board[rand.Next(0, 4)][rand.Next(0, 4)] = 2;
        }
        public bool CheckWin()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i][j] == 2048)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MoveUp()
        {
            bool hasMoved = false;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (board[i][j] == 0 && board[i + 1][j] != 0)
                    {
                        board[i][j] = board[i + 1][j];
                        board[i + 1][j] = 0;
                        hasMoved = true;
                    }
                    if (board[i][j] != 0 && board[i][j] == board[i + 1][j])
                    {
                        board[i][j] *= 2;
                        board[i + 1][j] = 0;
                        hasMoved = true;
                    }
                }
            }
            return hasMoved;
        }

        public bool MoveDown()
        {
            bool hasMoved = false;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i > 0; i--)
                {
                    if (board[i][j] == 0 && board[i - 1][j] != 0)
                    {
                        board[i][j] = board[i - 1][j];
                        board[i - 1][j] = 0;
                        hasMoved = true;
                    }
                    if (board[i][j] != 0 && board[i][j] == board[i - 1][j])
                    {
                        board[i][j] *= 2;
                        board[i - 1][j] = 0;
                        hasMoved = true;
                    }
                }
            }
            return hasMoved;
        }


        public bool MoveLeft()
        {
            bool hasMoved = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == 0 && board[i][j + 1] != 0)
                    {
                        board[i][j] = board[i][j + 1];
                        board[i][j + 1] = 0;
                        hasMoved = true;
                    }
                    if (board[i][j] != 0 && board[i][j] == board[i][j + 1])
                    {
                        board[i][j] *= 2;
                        board[i][j + 1] = 0;
                        hasMoved = true;
                    }
                }
            }
            return hasMoved;
        }


        public bool MoveRight()
        {
            bool hasMoved = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j > 0; j--)
                {
                    if (board[i][j] == 0 && board[i][j - 1] != 0)
                    {
                        board[i][j] = board[i][j - 1];
                        board[i][j - 1] = 0;
                        hasMoved = true;
                    }
                    if (board[i][j] != 0 && board[i][j] == board[i][j - 1])
                    {
                        board[i][j] *= 2;
                        board[i][j - 1] = 0;
                        hasMoved = true;
                    }
                }
            }
            return hasMoved;
        }


        // 实现 MoveDown(), MoveLeft(), MoveRight() 方法
    }

}
