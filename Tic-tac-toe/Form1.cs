using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {

        private int state = 0;
        private bool winner;
        private SoundPlayer player;
        private int status = 1;
        public PictureBox[] ImageLocProp
        {
            get { return new PictureBox[] {A1,A2,A3,
                B1,B2,B3,
                C1,C2,C3};}
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void picture_box(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (status==0)
            {
                MessageBox.Show("Введите данные и нажмите на кнопку \"Начать\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (pictureBox.ImageLocation == null)
                {
                    player.SoundLocation = @"../jg-032316-sfx-elevator-button.wav";
                    player.Play();
                    if (state == 0) pictureBox.ImageLocation = @"../img/circle.png";
                    else pictureBox.ImageLocation = @"../img/x.png";
                }
            }

            state = state == 0 ? 1 : 0;
            winner = Check_For_Winner();

            if (winner)
            {
                MessageBox.Show(state == 0 ? $"{player1Name.Text}: ПОЗДРАВЛЯЮ! Ты Победил" : $"{player2Name.Text}: ПОЗДРАВЛЯЮ! Ты Победил");
                Clear_Items();
                winner = false;
                UnbLockInput();
                status = 0;
                state = default;
            }
            else if (CheckForDraw())
            {
                MessageBox.Show("Ничья!");
                Clear_Items();
                UnbLockInput();
                status = 0;
                state = default;
            }
            
        }
        private void Clear_Items()
        {
            for (int i = 0; i < ImageLocProp.Length; i++)
            {
                ImageLocProp[i].ImageLocation = null;
            }
        }

        private bool CheckForDraw()
        {
            bool isDraw = false;
            int nullNum = 0;
            foreach (var item in ImageLocProp) if (item.ImageLocation!=null)nullNum++;

            if (nullNum==9) isDraw = true;

            return isDraw;
        }
        private bool Check_For_Winner()
        {
            //horizontal 
            if (A3.ImageLocation != null)
            {
                if (A1.ImageLocation == A2.ImageLocation && A2.ImageLocation == A3.ImageLocation) return true;
            }
            if (B3.ImageLocation!=null)
            {
                if (B1.ImageLocation == B2.ImageLocation && B2.ImageLocation == B3.ImageLocation) return true;
            }
            if (C3.ImageLocation!=null)
            {
                if (C1.ImageLocation == C2.ImageLocation && C2.ImageLocation == C3.ImageLocation) return true;
            }
            //vertical 
            if (A1.ImageLocation!=null&&C1.ImageLocation!=null)
            {
                if (A1.ImageLocation == B1.ImageLocation && B1.ImageLocation == C1.ImageLocation) return true;
            }
            if (A2.ImageLocation!=null&&C2.ImageLocation!=null)
            {
                if (A2.ImageLocation == B2.ImageLocation && B2.ImageLocation == C2.ImageLocation) return true;
            }
            if (A3.ImageLocation!=null&&C3.ImageLocation!=null)
            {
                if (A3.ImageLocation == B3.ImageLocation && B3.ImageLocation == C3.ImageLocation) return true;
            }
            //diagonal
            if (A1.ImageLocation!=null&&C3.ImageLocation!=null)
            {
                if(A1.ImageLocation == B2.ImageLocation && B2.ImageLocation == C3.ImageLocation) return true;   
            }
            if (A3.ImageLocation!=null&&C1.ImageLocation!=null)
            {
                if (A3.ImageLocation == B2.ImageLocation && B2.ImageLocation == C1.ImageLocation) return true;
            }
            return false;
        }

        private void BLockInput()
        {
            player1Name.Enabled = false;
            player2Name.Enabled = false;
            players.Enabled = false;
            bunifuButton2.Text = "Завершить";
        }
        private void UnbLockInput()
        {
            player1Name.Enabled = true;
            player2Name.Enabled = true;
            players.Enabled = true;
            bunifuButton2.Text = "Начать";
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuButton2.Text== "Начать")
                {
                    if (player1Name.Text.Length > 0 && player2Name.Text.Length > 0 && players.SelectedItem.ToString().Length > 0)
                    {
                        Clear_Items();
                        player.SoundLocation = "../zvuk41.wav";
                        player.Play();
                        BLockInput();
                        status = 1;
                        if (players.SelectedItem.ToString() == "Игрко №1: X") state = 1;
                        else state = 0;
                    }
                    else
                    {
                        player.SoundLocation = "../zvuk41.wav";
                        player.Play();
                        MessageBox.Show("Введите данные и нажмите на кнопку \"Начать\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    Clear_Items();
                    UnbLockInput();
                }


            }
            catch (Exception)
            {
                player.SoundLocation = "../zvuk41.wav";
                player.Play();
                MessageBox.Show("Введите данные и нажмите на кнопку \"Начать\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear_Items();
        }

        private void players_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
