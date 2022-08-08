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
using System.Diagnostics;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {

        private int state = 0;
        private SoundPlayer player;
        private int status = 0;
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
                if (pictureBox.Image == null)
                {
                    player = new SoundPlayer(Properties.Resources.jg_032316_sfx_elevator_button);
                    player.Play();                  
                    if (state == 0)
                    {
                        pictureBox.Image = Properties.Resources.circle;
                        pictureBox.Tag = nameof(Properties.Resources.circle);
                    }
                    else
                    {
                        pictureBox.Image = Properties.Resources.x;
                        pictureBox.Tag = nameof(Properties.Resources.x);
                    }
                }
            }

            state = state == 0 ? 1 : 0;
            if (Check_For_Winner())
            {
                MessageBox.Show(state == 0 ? $"{player1Name.Text}: ПОЗДРАВЛЯЮ! Ты Победил" : $"{player2Name.Text}: ПОЗДРАВЛЯЮ! Ты Победил");
                Clear_Items();
                UnbLockInput();
                status = 0;
                state = default;
            }
            else if (CheckForDraw())
            {
                MessageBox.Show("Ничья!","Конец",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                ImageLocProp[i].Image = null;
                ImageLocProp[i].Tag = default;
            }
        }

        private bool CheckForDraw()
        {
            bool isDraw = false;
            int nullNum = 0;
            foreach (var item in ImageLocProp) if (item.Image!=null)nullNum++;

            if (nullNum==9) isDraw = true;

            return isDraw;
        }
        private bool Check_For_Winner()
        {
            //horizontal 
            if (A3.Image != null)
            {
                if (A1.Tag == A2.Tag && A2.Tag == A3.Tag) return true;
            }
            if (B3.Image!=null)
            {
                if (B1.Tag == B2.Tag && B2.Tag == B3.Tag) return true;
            }
            if (C3.Image!=null)
            {
                if (C1.Tag == C2.Tag && C2.Tag == C3.Tag) return true;
            }
            //vertical 
            if (A1.Image!=null&&C1.Image!=null)
            {
                if (A1.Tag == B1.Tag && B1.Tag == C1.Tag) return true;
            }
            if (A2.Image!=null&&C2.Image!=null)
            {
                if (A2.Tag == B2.Tag && B2.Tag == C2.Tag) return true;
            }
            if (A3.Image!=null&&C3.Image!=null)
            {
                if (A3.Tag == B3.Tag && B3.Tag == C3.Tag) return true;
            }
            //diagonal
            if (A1.Image!=null&&C3.Image!=null)
            {
                if(A1.Tag == B2.Tag && B2.Tag == C3.Tag) return true;   
            }
            if (A3.Image!=null&&C1.Image!=null)
            {
                if (A3.Tag == B2.Tag && B2.Tag == C1.Tag) return true;
            }
            return false;
        }

        private void BLockInput()
        {
            player1Name.Enabled = false;
            player2Name.Enabled = false;
            players.Enabled = false;
            bunifuButton2.Text = "Завершить";
            status = 0;
        }
        private void UnbLockInput()
        {
            player1Name.Enabled = true;
            player2Name.Enabled = true;
            players.Enabled = true;
            bunifuButton2.Text = "Начать";
            status = 0;
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            player = new SoundPlayer(Properties.Resources.zvuk41);
            try
            {
                if (bunifuButton2.Text== "Начать")
                {

                    if (player1Name.Text.Length > 0 && player2Name.Text.Length > 0 && players.SelectedItem.ToString().Length > 0)
                    {
                        Clear_Items();
                        player.Play();
                        BLockInput();
                        status = 1;
                        if (players.SelectedItem.ToString() == "Игрок №1: X") state = 1;
                        else state = 0;
                    }
                    else
                    {
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
                player.Play();
                MessageBox.Show("Введите данные и нажмите на кнопку \"Начать\"", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clear_Items();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/o101xd");
        }
    }
}
