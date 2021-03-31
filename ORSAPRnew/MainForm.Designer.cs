namespace ORSAPRnew
{
    partial class MainForm
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
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LengthCompartmentTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.WidthCompartmentTextBox = new System.Windows.Forms.TextBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(221, 32);
            this.HeightTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(89, 22);
            this.HeightTextBox.TabIndex = 0;
            this.HeightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(221, 77);
            this.LengthTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(89, 22);
            this.LengthTextBox.TabIndex = 1;
            this.LengthTextBox.TextChanged += new System.EventHandler(this.LengthTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Высота коробки (мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Длина коробки (мм)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ширина коробки (мм)";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(221, 127);
            this.WidthTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(89, 22);
            this.WidthTextBox.TabIndex = 4;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Длина каждого отсека (мм)";
            // 
            // LengthCompartmentTextBox
            // 
            this.LengthCompartmentTextBox.Location = new System.Drawing.Point(224, 37);
            this.LengthCompartmentTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.LengthCompartmentTextBox.Name = "LengthCompartmentTextBox";
            this.LengthCompartmentTextBox.Size = new System.Drawing.Size(89, 22);
            this.LengthCompartmentTextBox.TabIndex = 6;
            this.LengthCompartmentTextBox.TextChanged += new System.EventHandler(this.LengthCompartmentTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ширина каждого отсека (мм)";
            // 
            // WidthCompartmentTextBox
            // 
            this.WidthCompartmentTextBox.Location = new System.Drawing.Point(224, 81);
            this.WidthCompartmentTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.WidthCompartmentTextBox.Name = "WidthCompartmentTextBox";
            this.WidthCompartmentTextBox.Size = new System.Drawing.Size(89, 22);
            this.WidthCompartmentTextBox.TabIndex = 8;
            this.WidthCompartmentTextBox.TextChanged += new System.EventHandler(this.WidthCompartmentTextBox_TextChanged);
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(310, 350);
            this.BuildButton.Margin = new System.Windows.Forms.Padding(3, 2, 4, 4);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(100, 28);
            this.BuildButton.TabIndex = 10;
            this.BuildButton.Text = "Построить";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HeightTextBox);
            this.groupBox1.Controls.Add(this.LengthTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.WidthTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(399, 174);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры коробки";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.WidthCompartmentTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.LengthCompartmentTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(8, 201);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(402, 131);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры отсеков";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(422, 393);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BuildButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 440);
            this.MinimumSize = new System.Drawing.Size(440, 440);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Box Builder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LengthCompartmentTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox WidthCompartmentTextBox;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

