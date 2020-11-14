namespace FormSnakeOOP
{
    partial class SnakeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GameFieldPictueBox = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameFieldPictueBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 35);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.GameFieldPictueBox);
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 504);
            this.panel2.TabIndex = 1;
            // 
            // GameFieldPictueBox
            // 
            this.GameFieldPictueBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameFieldPictueBox.Location = new System.Drawing.Point(0, 0);
            this.GameFieldPictueBox.Name = "GameFieldPictueBox";
            this.GameFieldPictueBox.Size = new System.Drawing.Size(500, 500);
            this.GameFieldPictueBox.TabIndex = 0;
            this.GameFieldPictueBox.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 601);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SnakeForm";
            this.Text = "Snke with classes";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GameFieldPictueBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox GameFieldPictueBox;
    }
}

