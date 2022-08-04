﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {

        private int state = 1;
        private bool winner;
        private SoundPlayer player;
        private int status = 0;
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
            B1.BackColor = Color.Black;


        }

        private void picture_box(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (status==0)
            {
                MessageBox.Show("Введите данные, чтобы начать игру", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(state == 0 ? "X: ПОЗДРАВЛЯЮ! Ты Победил" : "Y: ПОЗДРАВЛЯЮ! Ты Победил");

                Clear_Items();
                winner = false;
            }
        }
        private void Clear_Items()
        {
            PictureBox[] img_locations =
{
                A1,A2,A3,
                B1,B2,B3,
                C1,C2,C3
                };

            for (int i = 0; i < img_locations.Length; i++)
            {
                img_locations[i].ImageLocation = null;
            }
        }
        private bool Check_For_Winner()
        {

            //string[] img_locations =
            //{
            //    A1.ImageLocation,A2.ImageLocation,A3.ImageLocation,
            //    B1.ImageLocation,B2.ImageLocation,B3.ImageLocation,
            //    C1.ImageLocation,C2.ImageLocation,C3.ImageLocation
            //};

            if (!(A3.ImageLocation == null))
            {
                if (A1.ImageLocation == A2.ImageLocation && A2.ImageLocation == A3.ImageLocation) return true;
                if (!(C1.ImageLocation==null)&&!(B2.ImageLocation==null))
                {
                    if (A1.ImageLocation == B1.ImageLocation && B1.ImageLocation == C1.ImageLocation) return true;
                    else if (A3.ImageLocation == B2.ImageLocation && B2.ImageLocation == C1.ImageLocation||A1.ImageLocation == B2.ImageLocation && B2.ImageLocation == C3.ImageLocation ) return true;
                }
            }
            if (!(B3.ImageLocation == null))
            {
                if (B1.ImageLocation == B2.ImageLocation && B2.ImageLocation == B3.ImageLocation) return true;
                if (!(C2.ImageLocation==null))
                {
                    if (A2.ImageLocation == B2.ImageLocation && B2.ImageLocation == C2.ImageLocation) return true;
                    else if (A3.ImageLocation == B2.ImageLocation && B2.ImageLocation == C3.ImageLocation || A1.ImageLocation == B2.ImageLocation && B2.ImageLocation == C3.ImageLocation) return true;
                }
            }
            if (!(C3.ImageLocation == null))
            {
                if (C1.ImageLocation == C2.ImageLocation && C2.ImageLocation == C3.ImageLocation) return true;
                if (!(A3.ImageLocation==null)||!(B2.ImageLocation==null))
                {
                    if (A3.ImageLocation == B3.ImageLocation && B3.ImageLocation == C3.ImageLocation) return true;
                    else if (C1.ImageLocation == B2.ImageLocation && B2.ImageLocation == A3.ImageLocation || A1.ImageLocation == B2.ImageLocation && B2.ImageLocation == C3.ImageLocation) return true;

                }
            }
            //if (!(A1.ImageLocation == null))
            //{
            //    if (A1.ImageLocation == B1.ImageLocation && B1.ImageLocation == C1.ImageLocation) return true;
            //}
            //if (!(B2.ImageLocation == null))
            //{
            //    if (A2.ImageLocation == B2.ImageLocation && B2.ImageLocation == C2.ImageLocation) return true;
            //}
            //if (!(C3.ImageLocation == null))
            //{
            //    if (A3.ImageLocation == B3.ImageLocation && B3.ImageLocation == C3.ImageLocation) return true;
            //}




            return false;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            
            if (player1Name.Text.Length>0&&player2Name.Text.Length>0&&players.SelectedItem.ToString().Length>0)
            {
                status = 1;
            }
            else
            {
                MessageBox.Show("Введите данные, чтобы начать игру", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}