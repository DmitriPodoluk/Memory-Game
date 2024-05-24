using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05_logic
{
    // $G$ DSN-001 (-10) You should have create a separate form to represent the game settings.
    // $G$ DSN-001 (-7) This class should be under the UI project, as it comunicates with the user.
    // $G$ CSS-999 (-5) Bad class name, every class that extends the Form class should include 'Form' as prefix/suffix.
    public partial class FormMemoryGame : Form
    {
        // $G$ CSS-999 (-5) Those members must have an access modifier.
        // $G$ CSS-999 (-5) Members names should be meaningful, what exactly is "form"/"form2"/"label1" ???
        Button start;
        Button opponent;
        Button size;
        Button[,] buttonArray;
        Button[,] buttonArrayEmpty;

        Form form;
        Form form2;

        TextBox textBox;
        TextBox textBox1;

        Label label;
        Label label1;
        Label label2;
        Label label3;
        Label label4;
        Label label5;

        Input Input;

        Player player = null;
        Player p1 = new Player("", 0, 0);
        Player p2 = new Player("", 0, 0);
        Player[] pArray = new Player[2];




        Board board = new Board(0, 0);

        string name = "";
        string name1 = "";
        string str = " ";
        string temp = " ";
        string indexPre1 = "";
        string indexCurr1 = "";


        bool flag = true;
        bool flag1 = true;
        bool flag3 = true;



        int rows = 4;
        int coloumns = 4;

        int h = 0;
        int r = 0;

        int preI = 0;
        int preJ = 0;
        int currI = 0;
        int currJ = 0;



        Color c = Color.LightGreen;
        Color c1 = Color.LightGreen;
        Color c2 = Color.LightBlue;

        public FormMemoryGame()
        {
            InitializeComponent();
        }

        // $G$ DSN-003 (-5) This method is too long, you should have split it into several methods.
        public void Create()
        {
            start = new Button();
            opponent = new Button();
            size = new Button();
            opponent.Click += new EventHandler(opponent_Click);
            start.Click += new EventHandler(start_Click);
            size.Click += new EventHandler(size_Click);
            form = new Form();
            form.Height = 200;
            form.Width = 350;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);


            textBox = new TextBox();
            textBox1 = new TextBox();

            label = new Label();
            textBox1.Enabled = false;
            textBox1.Text = "computer";
            label.Text = "first player name:";
            textBox.Left = 80;
            label.Width = 80;
            label.Top = 5;

            label1 = new Label();
            label1.Text = "second player name:";
            label1.Width = 80;
            label1.Top = 35;
            label1.Left = 0;

            textBox1.Left = 100;
            textBox1.Top = 35;

            textBox.Left = 100;
            textBox.Top = 5;

            label5 = new Label();
            label5.Text = "board size:";
            label5.Top = 75;
            label5.Left = 20;


            opponent.Width = 100;
            opponent.Top = 35;
            opponent.Left = 230;
            opponent.Text = "agianst friend";



            start.Top = 100;
            start.Left = 200;
            start.Text = "start";
            start.BackColor = Color.Green;

            size.Height = 50;
            size.Width = 100;
            size.Top = 100;
            size.Left = 50;
            size.BackColor = Color.Purple;
            size.Text = rows + "x" + coloumns;


            form.Controls.Add(size);
            form.Controls.Add(start);
            form.Controls.Add(opponent);
            form.Controls.Add(label1);
            form.Controls.Add(label5);
            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(textBox1);
            form.ShowDialog();

        }

        // $G$ DSN-003 (-3) ? Redundant and not in use method, you should have remove it.
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Button btn = (Button)sender;

            if (!string.Equals((sender as Button).Name, @"CloseButton"))
            {
                // $G$ CSS-027 (-2) Unnecessary blank lines.

                form.Close();
                e.Cancel = false;
                form2.ShowDialog();

            }

        }


        // $G$ CSS-027 (-2) Unnecessary blank lines.

        private void opponent_Click(object sender, System.EventArgs e)
        {
            if (!textBox1.Enabled)
            {
                textBox1.Enabled = true;
                opponent.Text = "against computer";
            }
            else
            {
                textBox1.Enabled = false;
                opponent.Text = " friend";
            }
        }

        private void start_Click(object sender, System.EventArgs e)
        {
            int x = 1;
            int y = 1;
            int z = 0;
            form2 = new Form();
            buttonArray = new System.Windows.Forms.Button[this.rows, this.coloumns];
            buttonArrayEmpty = new System.Windows.Forms.Button[this.rows, this.coloumns];

            for (int h = 0; h < this.rows; h++)
            {
                for (int r = 0; r < this.coloumns; r++)
                {
                    buttonArray[h, r] = new System.Windows.Forms.Button();
                    buttonArrayEmpty[h, r] = new System.Windows.Forms.Button();
                }
            }

            form2.Width = 70 * this.coloumns;
            form2.Height = 80 * this.rows;

            for (int h = 0; h < this.rows; h++)
            {
                for (int r = 0; r < this.coloumns; r++)
                {
                    buttonArrayEmpty[h, r].Name = z.ToString();
                    buttonArrayEmpty[h, r].Left = x;
                    buttonArrayEmpty[h, r].Top = y * 15;
                    buttonArrayEmpty[h, r].Width = 40;
                    buttonArrayEmpty[h, r].Height = 30;
                    buttonArrayEmpty[h, r].Left = x * 20;
                    form2.Controls.Add(buttonArrayEmpty[h, r]);
                    buttonArray[h, r].Name = z.ToString();
                    buttonArray[h, r].Left = x;
                    buttonArray[h, r].Top = y * 15;
                    buttonArray[h, r].Width = 40;
                    buttonArray[h, r].Height = 30;
                    buttonArray[h, r].Left = x * 20;
                    form2.Controls.Add(buttonArray[h, r]);

                    x += 3;
                    z++;
                }

                x = 1;
                y += 3;
            }

            name1 = textBox.Text;
            name = textBox1.Text;

            this.board = new Board(this.rows, this.coloumns);

            for (int h = 0; h < this.rows; h++)
            {
                for (int r = 0; r < this.coloumns; r++)
                {
                    buttonArrayEmpty[h, r].Text = " ";

                    buttonArray[h, r].Text = board.CharArrayForTheBord[h, r].ToString();


                    buttonArray[h, r].Click += new System.EventHandler(user_Click);

                    buttonArrayEmpty[h, r].Click += new System.EventHandler(user_Click);


                }

            }

            Input = new Input(board, name, name1, this.rows, this.coloumns);
            p1 = new Player(name, 0, 0);
            p2 = new Player(name1, 0, 0);

            pArray[0] = p2;
            pArray[1] = p1;

            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label4.Text = "current player:" + pArray[0].PlayerName;
            label2.Text = " " + p1.PlayerName + " " + p1.CurrentPoints + " pairs";
            label3.Text = " " + p2.PlayerName + " " + p2.CurrentPoints + " pairs";

            label2.Top = 60 * this.rows;
            label3.Top = 54 * this.rows;
            label4.Top = 47 * this.rows;

            label4.BackColor = Color.LightBlue;
            label3.BackColor = Color.LightBlue;
            label2.BackColor = Color.LightGreen;

            form2.Controls.Add(label4);
            form2.Controls.Add(label2);
            form2.Controls.Add(label3);

            form.Visible = false;
            form2.ShowDialog();
        }


        // $G$ DSN-003 (-7) This method is way too long!
        private void user_Click(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;

            if ((btn.Text.Equals(" ")))
            {
                for (int h = 0; h < this.rows; h++)
                {
                    for (int z = 0; z < this.coloumns; z++)
                    {
                        if (btn.Name.Equals(buttonArray[h, z].Name))
                        {
                            if (buttonArray[h, z].Enabled)
                            {
                                if (!flag)
                                {
                                    buttonArrayEmpty[h, z].Hide();

                                    buttonArray[h, z].Enabled = false;
                                    buttonArray[h, z].BackColor = label4.BackColor;
                                    indexPre1 = indexCurr1;
                                    indexCurr1 = buttonArray[h, z].Name;
                                    temp = str;
                                    str = buttonArray[h, z].Text;
                                    user_Click(buttonArray[h, z], null);

                                }
                                else
                                {
                                    buttonArrayEmpty[h, z].Hide();
                                    buttonArray[h, z].BackColor = label4.BackColor;
                                    buttonArray[h, z].Enabled = false;
                                    indexPre1 = indexCurr1;
                                    indexCurr1 = buttonArray[h, z].Name;
                                    temp = str;
                                    str = buttonArray[h, z].Text;
                                    flag = false;
                                }
                            }
                        }
                    }
                }
            }

            player = pArray[0];

            if (str != " " && temp != " ")
            {
                pArray[0] = Input.InputPlayer(pArray[0], temp, str);

                if (pArray[0].CurrentPoints == pArray[0].PreviousPoints)
                {
                    for (int h = 0; h < this.rows; h++)
                    {
                        for (int r = 0; r < this.coloumns; r++)
                        {
                            if (buttonArray[h, r].Name.Equals(indexCurr1))
                            {
                                currI = h;
                                currJ = r;
                            }
                            if (buttonArray[h, r].Name.Equals(indexPre1))
                            {
                                preI = h;
                                preJ = r;
                            }
                        }
                    }

                    MessageBox.Show(" not match");

                    buttonArrayEmpty[preI, preJ].Show();
                    buttonArrayEmpty[currI, currJ].Show();
                    buttonArray[preI, preJ].Enabled = true;
                    buttonArray[currI, currJ].Enabled = true;

                    player = pArray[0];
                    pArray[0] = pArray[1];
                    pArray[1] = player;

                    // $G$ NTT-999 (-10) You should have use string.Format instead of strings concatenation.
                    label4.Text = "current player:" + pArray[0].PlayerName;
                    label3.Text = " " + pArray[0].PlayerName + " " + pArray[0].CurrentPoints + " pairs";
                    label2.Text = " " + pArray[1].PlayerName + " " + pArray[1].CurrentPoints + " pairs";

                    c = c1;
                    c1 = c2;
                    c2 = c;

                    label4.BackColor = c;
                    label2.BackColor = c1;
                    label3.BackColor = c2;
                    flag = true;

                }
                else
                {
                    if (pArray[0].CurrentPoints > pArray[0].PreviousPoints)
                    {
                        MessageBox.Show("match");

                        for (int h = 0; h < this.rows; h++)
                        {
                            for (int r = 0; r < this.coloumns; r++)
                            {
                                if (buttonArray[h, r].Name.Equals(indexCurr1))
                                {
                                    buttonArrayEmpty[h, r].Enabled = false;
                                    buttonArray[h, r].BackColor = label4.BackColor;

                                }

                                if (buttonArray[h, r].Name.Equals(indexPre1))
                                {
                                    buttonArrayEmpty[h, r].Enabled = false;
                                    buttonArray[h, r].BackColor = label4.BackColor;

                                }

                            }
                        }



                        label4.Text = "current player:" + pArray[0].PlayerName;
                        label3.Text = " " + pArray[0].PlayerName + ": " + pArray[0].CurrentPoints + " pairs";
                        label2.Text = " " + pArray[1].PlayerName + ": " + pArray[1].CurrentPoints + " pairs";

                    }

                }
                indexCurr1 = "";
                indexPre1 = "";
                temp = " ";
                str = " ";
            }

            if (pArray[0].PlayerName.Equals("computer") && Input.GameManeger.Pairs > 0)
            {
                System.Threading.Thread.Sleep(1000);
                Random random = new Random();
                h = random.Next(0, this.rows);
                r = random.Next(0, this.coloumns);
                user_Click(buttonArrayEmpty[h, r], null);
            }


            if (Input.GameManeger.Pairs == 0 && flag3)
            {
                player = Input.GameManeger.Winner(pArray[0], pArray[1]);
                flag3 = false;
                MessageBox.Show(player.PlayerName + "win the game");
                form2.Visible = false;
            }
        }
        // $G$ CSS-018 (-5) You should have use enum for the board size options check.
        // $G$ CSS-999 (-2) Missing blank line between the methods.
        private void size_Click(object sender, System.EventArgs e)
        {
            if (this.rows == 6 & this.coloumns <= 6)
            {
                if (this.coloumns == 6)
                {
                    flag1 = false;
                    this.rows = 4;
                    this.coloumns = 4;
                    size.Text = this.rows + "x" + this.coloumns;
                }
                if (this.coloumns < 6 && this.rows == 6)
                {
                    this.coloumns++;
                    size.Text = this.rows + "x" + this.coloumns;

                }
            }

            if (this.rows == 5 && this.coloumns <= 6)
            {
                if (this.coloumns == 6)
                {
                    this.coloumns = 4;
                    this.rows++;
                    size.Text = this.rows + "x" + this.coloumns;
                }
                if (this.coloumns < 6 && this.rows == 5)
                {
                    this.coloumns += 2;
                    size.Text = this.rows + "x" + this.coloumns;
                }
            }

            if (this.rows == 4 && this.coloumns <= 6 && flag1)
            {
                if (this.coloumns == 6)
                {
                    this.coloumns = 4;
                    this.rows++;
                    size.Text = this.rows + "x" + this.coloumns;
                }
                if (this.coloumns < 6 && this.rows == 4)
                {

                    this.coloumns++;
                    size.Text = this.rows + "x" + this.coloumns;

                }
            }

            flag1 = true;

        }

    }
}
