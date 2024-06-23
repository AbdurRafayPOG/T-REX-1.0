using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_REX_10._5
{
    public partial class Form4 : Form
    {
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public Form4()
        {
            InitializeComponent();
        }
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
        SoundPlayer scoreSound;
        SoundPlayer deathSound;
        SoundPlayer jumpSound;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Abdur Rafay\\source\\repos\\T-REX 10.5\\Database1.mdf\";Integrated Security=True";
        private string playerName;
        public Form4(string playerName)
        {
            InitializeComponent();
            GameReset();
            this.playerName = playerName;
            scoreSound = new SoundPlayer(soundLocation: @"D:\OOP PROJECT\audio\score sound.wav");
            deathSound = new SoundPlayer(soundLocation: @"D:\OOP PROJECT\audio\death sound.wav");
            jumpSound = new SoundPlayer(soundLocation: @"D:\OOP PROJECT\audio\jump sound.wav");

        }
        private void SaveScoreToDatabase(int score)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO [Scores] (PlayerName, Score) VALUES (@PlayerName, @Score)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlayerName", playerName);
                command.Parameters.AddWithValue("@Score", score);
                command.ExecuteNonQuery();
            }
        }
        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            trex.Top += jumpSpeed;

            txtScore.Text = "Score: " + score;

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            if (jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }


            if (trex.Top > 366 && jumping == false)
            {
                force = 12;
                trex.Top = 367;
                jumpSpeed = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                        score++;
                    }

                    if (trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        trex.Image = Properties.Resources.dead;
                        txtScore.Text += " Press R to restart the game!";
                        isGameOver = true;
                    }
                }
            }
            if (score > 5)
            {
                obstacleSpeed = 15;
            }
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                GameReset();
            }
        }
        private void GameReset()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            txtScore.Text = "Score: " + score;
            trex.Image = Properties.Resources.running;
            isGameOver = false;
            trex.Top = 367;
            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    position = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);

                    x.Left = position;
                }
            }
            gameTimer.Start();
        }
        private void PlayJumpSound()
        {
            jumpSound.Play();
        }
        private void PlayScoreSound()
        {
            scoreSound.Play();
        }
        private void PlayDeathSound()
        {
            deathSound.Play();
        }
    }
}
