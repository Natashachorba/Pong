using System;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        int playerScore;
        int botScore;
        readonly int MAXSCORE = 5;

        bool gamePaused = true;
        int secondsElapsed = 0;

        readonly int playerSpeed = 8;
        bool playerUp;
        bool playerDown;

        readonly int botSpeed = 3;
        
        int ballXSpeed = 5;
        int ballYSpeed = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void ResetBall()
        {
            ball.Top = 488;
            ball.Left = 288;
            ballXSpeed = 5;
            ballYSpeed = 3;
            var random = new Random();
            var ballGoingLeft = ballXSpeed > 0; //just scored on bot, default served to be player
            if (random.Next(10) >= 3) //70% chance that ball X goes faster than default
            {
                ballXSpeed += random.Next(3);
            }
            else
            {
                ballXSpeed -= random.Next(2);
            }
            if (ballGoingLeft) { ballXSpeed = -ballXSpeed; }
            if (random.Next(10) >= 2) //20% chance it goes toward the player that just lost a point
            {
                ballXSpeed = -ballXSpeed;
            }

            if (random.Next(10) >= 3) //70% chance ball y speed is higher than default
            {
                ballYSpeed += random.Next(4);
            }
            if (random.Next(10) >= 5) //50% chance of switching direction from default
            {
                ballYSpeed = -ballYSpeed;
            }

        }

#region Collisions
        bool CheckFloorCollision(PictureBox obj)
        {
            if(obj.Location.Y + obj.Height >= WorldFrame.Height)
            {
                return true;
            }
            return false;
        }

        bool CheckCeilingCollision(PictureBox obj)
        {
            if (obj.Location.Y <= 0)
            {
                return true;
            }
            return false;
        }

        bool CheckLeftCollision(PictureBox obj)
        {
            if (obj.Location.X <= 0)
            {
                return true;
            }
            return false;
        }

        bool CheckRightCollision(PictureBox obj)
        {
            if (obj.Location.X + obj.Width >= WorldFrame.Width)
            {
                return true;
            }
            return false;
        }

        bool CollideWithPaddle(PictureBox paddle)
        {
            if (ball.Bounds.IntersectsWith(paddle.Bounds))
            {
                return true;
            }
            return false;
        }
#endregion Collisions

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    playerUp = true;
                    playerDown = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    playerDown = true;
                    playerUp = false;
                    break;
                case Keys.Space:
                    gamePaused = !gamePaused;
                    break;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    playerUp = false;
                    break;
                case Keys.S:
                case Keys.Down:
                    playerDown = false;
                    break;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (!gamePaused)
            {
                secondsElapsed++;
                TimeSpan time = TimeSpan.FromSeconds(secondsElapsed);
                var timeString = time.ToString(@"mm\:ss");
                timerBox.Text = $"Time: {timeString}";
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            if (!gamePaused)
            {
                UpdatePlayer();
                UpdateBot();
                UpdateBall();
                CheckGameOver();
            }
        }

        private void UpdateBall()
        {
            ball.Left -= ballXSpeed;
            ball.Top -= ballYSpeed;

            if (CheckCeilingCollision(ball) || CheckFloorCollision(ball))
            {
                ballYSpeed = -ballYSpeed;
            }

            if (CheckLeftCollision(ball))
            {
                botScore++;
                botScoreBox.Text = $"{botScore}";
                ResetBall();
            }
            else if (CheckRightCollision(ball))
            {
                playerScore++;
                playerScoreBox.Text = $"{playerScore}";
                ResetBall();
            }

            if (CollideWithPaddle(player))
            {
                UpdateCollidingBall(player);
            }
            else if (CollideWithPaddle(bot))
            {
                UpdateCollidingBall(bot);
            }
        }

        private void UpdateCollidingBall(PictureBox paddle)
        {
            var locDifference = ball.Location.Y - paddle.Location.Y;
            var ballHasHigherGround = ballYSpeed <= 0; //keep track of whether or not the ball is coming from below or above

            int locRepresentation = (locDifference + 37) / 30; //math time! the differences we care about are at -8,22,52,82,112. Adding 38 to each, they become multiples of 30 and ASSURED greated than 0 difference

            if (!ballHasHigherGround)
            {
                locRepresentation = 6 - locRepresentation;
            }

            switch (locRepresentation)
            {
                case 0:
                    ballXSpeed = (int)(-ballXSpeed*1.3);
                    ballYSpeed = (int)(-ballYSpeed*1.3);
                    if (ballYSpeed == 0) ballYSpeed = 2;
                    break;
                case 1:
                    ballXSpeed = -ballXSpeed;
                    ballYSpeed = (int)(-ballYSpeed * 0.9);
                    if (ballYSpeed == 0) ballYSpeed = 1;
                    break;
                case 3:
                    ballXSpeed = -ballXSpeed;
                    ballYSpeed = (int)(ballYSpeed * 1.1);
                    if (ballYSpeed == 0) ballYSpeed = -1;
                    break;
                case 4:
                    ballXSpeed = (int)(-ballXSpeed * 1.2);
                    ballYSpeed = (int)(ballYSpeed * 1.5);
                    if (ballYSpeed == 0) ballYSpeed = -2;
                    break;
                default: //for middle hits or wonky shit that I failed to account for...
                    ballXSpeed = -ballXSpeed;
                    break;
            }

            ball.Left -= ballXSpeed;
            ball.Top -= ballYSpeed;
        }

        private void UpdateBot()
        {
            if (bot.Location.Y < ball.Location.Y)
            {
                if (!CheckFloorCollision(bot))
                {
                    bot.Top += botSpeed;
                }
            }
            else if (bot.Location.Y + 80 > ball.Location.Y)
            {
                if (!CheckCeilingCollision(bot))
                {
                    bot.Top -= botSpeed;
                }
            }
        }

        private void UpdatePlayer()
        {
            if (playerUp && !CheckCeilingCollision(player))
            {
                player.Top -= playerSpeed;
            }
            else if (playerDown && !CheckFloorCollision(player))
            {
                player.Top += playerSpeed;
            }
        }

        private void CheckGameOver()
        {
            if (playerScore >= MAXSCORE || botScore >= MAXSCORE)
            {
                gameTimer.Stop();
                ballTimer.Stop();
                var winnerText = playerScore > botScore ? "You won! I'm pretty impressed!!" : "The bot won! How's it feel being a loser?";
                MessageBox.Show($"{winnerText}");
            }
        }
    }
}
