namespace PacMan
{
    partial class Level3
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
            this.components = new System.ComponentModel.Container();
            this.Score_Label = new System.Windows.Forms.Label();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pacManMovement = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.redGhost = new System.Windows.Forms.PictureBox();
            this.pinkGhost = new System.Windows.Forms.PictureBox();
            this.blueGhost = new System.Windows.Forms.PictureBox();
            this.orangeGhost = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redGhost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinkGhost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueGhost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangeGhost)).BeginInit();
            this.SuspendLayout();
            // 
            // Score_Label
            // 
            this.Score_Label.AutoSize = true;
            this.Score_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score_Label.ForeColor = System.Drawing.Color.White;
            this.Score_Label.Location = new System.Drawing.Point(12, 804);
            this.Score_Label.Name = "Score_Label";
            this.Score_Label.Size = new System.Drawing.Size(107, 36);
            this.Score_Label.TabIndex = 0;
            this.Score_Label.Text = "Score:";
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Location = new System.Drawing.Point(0, 0);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(787, 800);
            this.PCT_CANVAS.TabIndex = 1;
            this.PCT_CANVAS.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(368, 437);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pacManMovement
            // 
            this.pacManMovement.Enabled = true;
            this.pacManMovement.Tick += new System.EventHandler(this.pacManMovement_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox2.Location = new System.Drawing.Point(765, 358);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox3.Location = new System.Drawing.Point(-7, 356);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(249, 804);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lives:";
            // 
            // redGhost
            // 
            this.redGhost.BackColor = System.Drawing.Color.Black;
            this.redGhost.Location = new System.Drawing.Point(368, 356);
            this.redGhost.Name = "redGhost";
            this.redGhost.Size = new System.Drawing.Size(30, 30);
            this.redGhost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.redGhost.TabIndex = 8;
            this.redGhost.TabStop = false;
            // 
            // pinkGhost
            // 
            this.pinkGhost.BackColor = System.Drawing.Color.Black;
            this.pinkGhost.Location = new System.Drawing.Point(438, 437);
            this.pinkGhost.Name = "pinkGhost";
            this.pinkGhost.Size = new System.Drawing.Size(30, 30);
            this.pinkGhost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pinkGhost.TabIndex = 9;
            this.pinkGhost.TabStop = false;
            // 
            // blueGhost
            // 
            this.blueGhost.BackColor = System.Drawing.Color.Black;
            this.blueGhost.Location = new System.Drawing.Point(332, 356);
            this.blueGhost.Name = "blueGhost";
            this.blueGhost.Size = new System.Drawing.Size(30, 30);
            this.blueGhost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.blueGhost.TabIndex = 10;
            this.blueGhost.TabStop = false;
            // 
            // orangeGhost
            // 
            this.orangeGhost.BackColor = System.Drawing.Color.Black;
            this.orangeGhost.Location = new System.Drawing.Point(227, 356);
            this.orangeGhost.Name = "orangeGhost";
            this.orangeGhost.Size = new System.Drawing.Size(30, 30);
            this.orangeGhost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.orangeGhost.TabIndex = 11;
            this.orangeGhost.TabStop = false;
            // 
            // Level3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(884, 929);
            this.Controls.Add(this.orangeGhost);
            this.Controls.Add(this.blueGhost);
            this.Controls.Add(this.pinkGhost);
            this.Controls.Add(this.redGhost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PCT_CANVAS);
            this.Controls.Add(this.Score_Label);
            this.Name = "Level3";
            this.Text = "PacMan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Level3_FormClosing);
            this.Load += new System.EventHandler(this.Level3_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redGhost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinkGhost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueGhost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orangeGhost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Score_Label;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer pacManMovement;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox redGhost;
        private System.Windows.Forms.PictureBox pinkGhost;
        private System.Windows.Forms.PictureBox blueGhost;
        private System.Windows.Forms.PictureBox orangeGhost;
    }
}

