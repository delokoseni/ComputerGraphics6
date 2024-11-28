using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics6
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage; // Оригинальное изображение
        private Bitmap currentImage;  // Текущее изображение

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                currentImage = new Bitmap(originalImage);
                pictureBox.Image = currentImage;
                textBoxAddNoisePoints.Text = "";
                textBoxAddNoiseLines.Text = "";
                textBoxAddNoiseCircles.Text = "";
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    currentImage = new Bitmap(originalImage); // Устанавливаем текущее изображение равным оригиналу
                    pictureBox.Image = currentImage;
                }
            }
        }

        private void buttonAddNoisePoints_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateInput(textBoxAddNoisePoints, out int pointCount))
            {
                currentImage = AddPointNoise(currentImage, pointCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonAddNoiseLines_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateInput(textBoxAddNoiseLines, out int lineCount))
            {
                currentImage = AddLineNoise(currentImage, lineCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonAddNoiseCircles_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateInput(textBoxAddNoiseCircles, out int circleCount))
            {
                currentImage = AddCircleNoise(currentImage, circleCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonUniformFilter_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                currentImage = ApplyUniformBlur(currentImage, 5); // Например, радиус 5
                pictureBox.Image = currentImage;
            }
        }

        private bool ValidateInput(TextBox textBox, out int noiseCount)
        {
            noiseCount = 0;
            if (int.TryParse(textBox.Text, out int count) && count > 0)
            {
                if (originalImage != null)
                {
                    int maxCount = originalImage.Width * originalImage.Height;
                    if (count <= maxCount)
                    {
                        noiseCount = count;
                        return true;
                    }
                    MessageBox.Show($"Введите число меньше или равно {maxCount}.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Сначала загрузите изображение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректное число больше 0.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private Bitmap AddPointNoise(Bitmap bitmap, int pointCount)
        {
            Random rand = new Random();
            for (int i = 0; i < pointCount; i++)
            {
                int x = rand.Next(bitmap.Width);
                int y = rand.Next(bitmap.Height);
                Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                bitmap.SetPixel(x, y, randomColor);
            }
            return bitmap;
        }

        private Bitmap AddLineNoise(Bitmap bitmap, int lineCount)
        {
            Random rand = new Random();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < lineCount; i++)
                {
                    int startX = rand.Next(bitmap.Width);
                    int endX = rand.Next(bitmap.Width);
                    int y = rand.Next(bitmap.Height);
                    Pen pen = new Pen(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));
                    g.DrawLine(pen, startX, y, endX, y);
                }
            }
            return bitmap;
        }

        private Bitmap AddCircleNoise(Bitmap bitmap, int circleCount)
        {
            Random rand = new Random();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < circleCount; i++)
                {
                    int centerX = rand.Next(bitmap.Width);
                    int centerY = rand.Next(bitmap.Height);
                    int radius = rand.Next(5, 50); // Радиус окружности от 5 до 50
                    Pen pen = new Pen(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));
                    g.DrawEllipse(pen, centerX - radius, centerY - radius, radius * 2, radius * 2);
                }
            }
            return bitmap;
        }

        private Bitmap ApplyUniformBlur(Bitmap bitmap, int radius)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            int size = radius * 2 + 1;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color newColor = GetAverageColor(bitmap, x, y, radius);
                    result.SetPixel(x, y, newColor);
                }
            }
            return result;
        }

        private Color GetAverageColor(Bitmap bitmap, int centerX, int centerY, int radius)
        {
            int r = 0, g = 0, b = 0;
            int count = 0;

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int newX = centerX + x;
                    int newY = centerY + y;

                    if (newX >= 0 && newY >= 0 && newX < bitmap.Width && newY < bitmap.Height)
                    {
                        Color pixelColor = bitmap.GetPixel(newX, newY);
                        r += pixelColor.R;
                        g += pixelColor.G;
                        b += pixelColor.B;
                        count++;
                    }
                }
            }

            return Color.FromArgb(r / count, g / count, b / count);
        }
    }
}
