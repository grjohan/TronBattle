namespace WindowsFormsApplication1
{
    partial class BattleGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCompetitor1 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblCompetitor1 = new System.Windows.Forms.Label();
            this.lblCompetitor2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.LblWinner = new System.Windows.Forms.Label();
            this.lblWinReason = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCompetitors = new System.Windows.Forms.Label();
            this.txtEvents = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pCompetitors = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCompetitors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCompetitor1
            // 
            this.btnCompetitor1.Location = new System.Drawing.Point(1079, 12);
            this.btnCompetitor1.Name = "btnCompetitor1";
            this.btnCompetitor1.Size = new System.Drawing.Size(125, 29);
            this.btnCompetitor1.TabIndex = 0;
            this.btnCompetitor1.Text = "Choose competitors";
            this.btnCompetitor1.UseVisualStyleBackColor = true;
            this.btnCompetitor1.Click += new System.EventHandler(this.btnCompetitor1_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1085, 669);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(125, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start battle";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblCompetitor1
            // 
            this.lblCompetitor1.AutoSize = true;
            this.lblCompetitor1.Location = new System.Drawing.Point(1082, 677);
            this.lblCompetitor1.Name = "lblCompetitor1";
            this.lblCompetitor1.Size = new System.Drawing.Size(0, 13);
            this.lblCompetitor1.TabIndex = 3;
            // 
            // lblCompetitor2
            // 
            this.lblCompetitor2.AutoSize = true;
            this.lblCompetitor2.Location = new System.Drawing.Point(1427, 677);
            this.lblCompetitor2.Name = "lblCompetitor2";
            this.lblCompetitor2.Size = new System.Drawing.Size(0, 13);
            this.lblCompetitor2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.Color.Red;
            this.lblGameOver.Location = new System.Drawing.Point(1218, 665);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(209, 29);
            this.lblGameOver.TabIndex = 6;
            this.lblGameOver.Text = "The match is over!";
            this.lblGameOver.Visible = false;
            // 
            // LblWinner
            // 
            this.LblWinner.AutoSize = true;
            this.LblWinner.Location = new System.Drawing.Point(1220, 718);
            this.LblWinner.Name = "LblWinner";
            this.LblWinner.Size = new System.Drawing.Size(76, 13);
            this.LblWinner.TabIndex = 7;
            this.LblWinner.Text = "The winner is: ";
            this.LblWinner.Visible = false;
            // 
            // lblWinReason
            // 
            this.lblWinReason.AutoSize = true;
            this.lblWinReason.Location = new System.Drawing.Point(199, 117);
            this.lblWinReason.Name = "lblWinReason";
            this.lblWinReason.Size = new System.Drawing.Size(0, 13);
            this.lblWinReason.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1085, 704);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1084, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Competitors:";
            // 
            // lblCompetitors
            // 
            this.lblCompetitors.AutoSize = true;
            this.lblCompetitors.Location = new System.Drawing.Point(861, 68);
            this.lblCompetitors.Name = "lblCompetitors";
            this.lblCompetitors.Size = new System.Drawing.Size(0, 13);
            this.lblCompetitors.TabIndex = 11;
            // 
            // txtEvents
            // 
            this.txtEvents.Location = new System.Drawing.Point(1085, 372);
            this.txtEvents.Multiline = true;
            this.txtEvents.Name = "txtEvents";
            this.txtEvents.Size = new System.Drawing.Size(293, 262);
            this.txtEvents.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1085, 640);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Setup start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pCompetitors
            // 
            this.pCompetitors.Location = new System.Drawing.Point(1082, 68);
            this.pCompetitors.Name = "pCompetitors";
            this.pCompetitors.Size = new System.Drawing.Size(296, 298);
            this.pCompetitors.TabIndex = 14;
            this.pCompetitors.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1210, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 29);
            this.button3.TabIndex = 15;
            this.button3.Text = "Choose map";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BattleGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 920);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pCompetitors);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtEvents);
            this.Controls.Add(this.lblCompetitors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblWinReason);
            this.Controls.Add(this.LblWinner);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCompetitor2);
            this.Controls.Add(this.lblCompetitor1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCompetitor1);
            this.Name = "BattleGui";
            this.Text = "Tron battle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCompetitors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCompetitor1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblCompetitor1;
        private System.Windows.Forms.Label lblCompetitor2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label LblWinner;
        private System.Windows.Forms.Label lblWinReason;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompetitors;
        private System.Windows.Forms.TextBox txtEvents;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pCompetitors;
        private System.Windows.Forms.Button button3;
    }
}

