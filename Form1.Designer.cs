namespace Pong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WorldFrame = new System.Windows.Forms.Panel();
            this.player = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.bot = new System.Windows.Forms.PictureBox();
            this.playerScoreBox = new System.Windows.Forms.Label();
            this.botScoreBox = new System.Windows.Forms.Label();
            this.timerBox = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.ballTimer = new System.Windows.Forms.Timer(this.components);
            this.WorldFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bot)).BeginInit();
            this.SuspendLayout();
            // 
            // WorldFrame
            // 
            this.WorldFrame.BackColor = System.Drawing.Color.MidnightBlue;
            this.WorldFrame.Controls.Add(this.player);
            this.WorldFrame.Controls.Add(this.ball);
            this.WorldFrame.Controls.Add(this.bot);
            this.WorldFrame.Location = new System.Drawing.Point(1, 1);
            this.WorldFrame.Name = "WorldFrame";
            this.WorldFrame.Size = new System.Drawing.Size(1000, 600);
            this.WorldFrame.TabIndex = 0;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Cyan;
            this.player.Location = new System.Drawing.Point(10, 200);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(25, 100);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.GhostWhite;
            this.ball.Location = new System.Drawing.Point(488, 288);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(24, 24);
            this.ball.TabIndex = 0;
            this.ball.TabStop = false;
            // 
            // bot
            // 
            this.bot.BackColor = System.Drawing.Color.DarkViolet;
            this.bot.Location = new System.Drawing.Point(965, 200);
            this.bot.Name = "bot";
            this.bot.Size = new System.Drawing.Size(25, 100);
            this.bot.TabIndex = 0;
            this.bot.TabStop = false;
            // 
            // playerScoreBox
            // 
            this.playerScoreBox.AutoSize = true;
            this.playerScoreBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playerScoreBox.ForeColor = System.Drawing.Color.Cyan;
            this.playerScoreBox.Location = new System.Drawing.Point(177, 610);
            this.playerScoreBox.Name = "playerScoreBox";
            this.playerScoreBox.Size = new System.Drawing.Size(56, 45);
            this.playerScoreBox.TabIndex = 1;
            this.playerScoreBox.Text = "00";
            // 
            // botScoreBox
            // 
            this.botScoreBox.AutoSize = true;
            this.botScoreBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botScoreBox.ForeColor = System.Drawing.Color.DarkViolet;
            this.botScoreBox.Location = new System.Drawing.Point(792, 610);
            this.botScoreBox.Name = "botScoreBox";
            this.botScoreBox.Size = new System.Drawing.Size(56, 45);
            this.botScoreBox.TabIndex = 1;
            this.botScoreBox.Text = "00";
            // 
            // timerBox
            // 
            this.timerBox.AutoSize = true;
            this.timerBox.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timerBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.timerBox.Location = new System.Drawing.Point(412, 610);
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new System.Drawing.Size(196, 47);
            this.timerBox.TabIndex = 2;
            this.timerBox.Text = "Time: 00:00";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // ballTimer
            // 
            this.ballTimer.Enabled = true;
            this.ballTimer.Interval = 10;
            this.ballTimer.Tick += new System.EventHandler(this.GameTick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1004, 701);
            this.Controls.Add(this.timerBox);
            this.Controls.Add(this.botScoreBox);
            this.Controls.Add(this.playerScoreBox);
            this.Controls.Add(this.WorldFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Pong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.WorldFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel WorldFrame;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox bot;
        private System.Windows.Forms.Label playerScoreBox;
        private System.Windows.Forms.Label botScoreBox;
        private System.Windows.Forms.Label timerBox;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer ballTimer;
    }
}

