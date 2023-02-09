namespace PacMan
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Score_Label = new System.Windows.Forms.Label();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Score_Label
            // 
            this.Score_Label.AutoSize = true;
            this.Score_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score_Label.ForeColor = System.Drawing.Color.White;
            this.Score_Label.Location = new System.Drawing.Point(387, 37);
            this.Score_Label.Name = "Score_Label";
            this.Score_Label.Size = new System.Drawing.Size(107, 36);
            this.Score_Label.TabIndex = 0;
            this.Score_Label.Text = "Score:";
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Location = new System.Drawing.Point(44, 104);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(787, 800);
            this.PCT_CANVAS.TabIndex = 1;
            this.PCT_CANVAS.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(884, 929);
            this.Controls.Add(this.PCT_CANVAS);
            this.Controls.Add(this.Score_Label);
            this.Name = "Form1";
            this.Text = "PacMan";
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Score_Label;
        private System.Windows.Forms.PictureBox PCT_CANVAS;
    }
}

