namespace ComputerGraphics6
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
            buttonDownload = new Button();
            buttonAddNoisePoints = new Button();
            buttonAddNoiseLines = new Button();
            buttonAddNoiseCircles = new Button();
            buttonUniformFilter = new Button();
            buttonMedianFilter = new Button();
            buttonEmbossing = new Button();
            buttonReset = new Button();
            pictureBox = new PictureBox();
            textBoxAddNoisePoints = new TextBox();
            textBoxAddNoiseLines = new TextBox();
            textBoxAddNoiseCircles = new TextBox();
            textBoxUniformFilterRadius = new TextBox();
            textBoxMedianFilterRadius = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(12, 12);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(217, 29);
            buttonDownload.TabIndex = 0;
            buttonDownload.Text = "Загрузить изображение";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // buttonAddNoisePoints
            // 
            buttonAddNoisePoints.Location = new Point(147, 49);
            buttonAddNoisePoints.Name = "buttonAddNoisePoints";
            buttonAddNoisePoints.Size = new Size(217, 29);
            buttonAddNoisePoints.TabIndex = 1;
            buttonAddNoisePoints.Text = "Добавить шум (точки)";
            buttonAddNoisePoints.UseVisualStyleBackColor = true;
            buttonAddNoisePoints.Click += buttonAddNoisePoints_Click;
            // 
            // buttonAddNoiseLines
            // 
            buttonAddNoiseLines.Location = new Point(147, 84);
            buttonAddNoiseLines.Name = "buttonAddNoiseLines";
            buttonAddNoiseLines.Size = new Size(217, 29);
            buttonAddNoiseLines.TabIndex = 2;
            buttonAddNoiseLines.Text = "Добавить шум (линии)";
            buttonAddNoiseLines.UseVisualStyleBackColor = true;
            buttonAddNoiseLines.Click += buttonAddNoiseLines_Click;
            // 
            // buttonAddNoiseCircles
            // 
            buttonAddNoiseCircles.Location = new Point(147, 119);
            buttonAddNoiseCircles.Name = "buttonAddNoiseCircles";
            buttonAddNoiseCircles.Size = new Size(217, 29);
            buttonAddNoiseCircles.TabIndex = 3;
            buttonAddNoiseCircles.Text = "Добавить шум (окружности)";
            buttonAddNoiseCircles.UseVisualStyleBackColor = true;
            buttonAddNoiseCircles.Click += buttonAddNoiseCircles_Click;
            // 
            // buttonUniformFilter
            // 
            buttonUniformFilter.Location = new Point(147, 154);
            buttonUniformFilter.Name = "buttonUniformFilter";
            buttonUniformFilter.Size = new Size(217, 29);
            buttonUniformFilter.TabIndex = 4;
            buttonUniformFilter.Text = "Равномерный фильтр";
            buttonUniformFilter.UseVisualStyleBackColor = true;
            buttonUniformFilter.Click += buttonUniformFilter_Click;
            // 
            // buttonMedianFilter
            // 
            buttonMedianFilter.Location = new Point(147, 189);
            buttonMedianFilter.Name = "buttonMedianFilter";
            buttonMedianFilter.Size = new Size(217, 29);
            buttonMedianFilter.TabIndex = 5;
            buttonMedianFilter.Text = "Медианный фильтр";
            buttonMedianFilter.UseVisualStyleBackColor = true;
            buttonMedianFilter.Click += buttonMedianFilter_Click;
            // 
            // buttonEmbossing
            // 
            buttonEmbossing.Location = new Point(12, 221);
            buttonEmbossing.Name = "buttonEmbossing";
            buttonEmbossing.Size = new Size(217, 29);
            buttonEmbossing.TabIndex = 6;
            buttonEmbossing.Text = "Тиснение";
            buttonEmbossing.UseVisualStyleBackColor = true;
            buttonEmbossing.Click += buttonEmbossing_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(12, 256);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(217, 29);
            buttonReset.TabIndex = 7;
            buttonReset.Text = "Сбросить";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(370, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(500, 500);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            // 
            // textBoxAddNoisePoints
            // 
            textBoxAddNoisePoints.Location = new Point(15, 49);
            textBoxAddNoisePoints.Name = "textBoxAddNoisePoints";
            textBoxAddNoisePoints.Size = new Size(125, 27);
            textBoxAddNoisePoints.TabIndex = 9;
            // 
            // textBoxAddNoiseLines
            // 
            textBoxAddNoiseLines.Location = new Point(16, 86);
            textBoxAddNoiseLines.Name = "textBoxAddNoiseLines";
            textBoxAddNoiseLines.Size = new Size(125, 27);
            textBoxAddNoiseLines.TabIndex = 10;
            // 
            // textBoxAddNoiseCircles
            // 
            textBoxAddNoiseCircles.Location = new Point(16, 118);
            textBoxAddNoiseCircles.Name = "textBoxAddNoiseCircles";
            textBoxAddNoiseCircles.Size = new Size(125, 27);
            textBoxAddNoiseCircles.TabIndex = 11;
            // 
            // textBoxUniformFilterRadius
            // 
            textBoxUniformFilterRadius.Location = new Point(16, 156);
            textBoxUniformFilterRadius.Name = "textBoxUniformFilterRadius";
            textBoxUniformFilterRadius.Size = new Size(125, 27);
            textBoxUniformFilterRadius.TabIndex = 12;
            // 
            // textBoxMedianFilterRadius
            // 
            textBoxMedianFilterRadius.Location = new Point(16, 191);
            textBoxMedianFilterRadius.Name = "textBoxMedianFilterRadius";
            textBoxMedianFilterRadius.Size = new Size(125, 27);
            textBoxMedianFilterRadius.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 553);
            Controls.Add(textBoxMedianFilterRadius);
            Controls.Add(textBoxUniformFilterRadius);
            Controls.Add(textBoxAddNoiseCircles);
            Controls.Add(textBoxAddNoiseLines);
            Controls.Add(textBoxAddNoisePoints);
            Controls.Add(pictureBox);
            Controls.Add(buttonReset);
            Controls.Add(buttonEmbossing);
            Controls.Add(buttonMedianFilter);
            Controls.Add(buttonUniformFilter);
            Controls.Add(buttonAddNoiseCircles);
            Controls.Add(buttonAddNoiseLines);
            Controls.Add(buttonAddNoisePoints);
            Controls.Add(buttonDownload);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDownload;
        private Button buttonAddNoisePoints;
        private Button buttonAddNoiseLines;
        private Button buttonAddNoiseCircles;
        private Button buttonUniformFilter;
        private Button buttonMedianFilter;
        private Button buttonEmbossing;
        private Button buttonReset;
        private PictureBox pictureBox;
        private TextBox textBoxAddNoisePoints;
        private TextBox textBoxAddNoiseLines;
        private TextBox textBoxAddNoiseCircles;
        private TextBox textBoxUniformFilterRadius;
        private TextBox textBoxMedianFilterRadius;
    }
}
