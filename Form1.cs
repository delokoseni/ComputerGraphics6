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
                    currentImage = new Bitmap(originalImage);
                    pictureBox.Image = currentImage;
                }
            }
        }

        private void buttonAddNoisePoints_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateInput(textBoxAddNoisePoints, out int pointCount))
            {
                currentImage = AddPointNoise(new Bitmap(originalImage), pointCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonAddNoiseLines_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateInput(textBoxAddNoiseLines, out int lineCount))
            {
                currentImage = AddLineNoise(new Bitmap(originalImage), lineCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonAddNoiseCircles_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateInput(textBoxAddNoiseCircles, out int circleCount))
            {
                currentImage = AddCircleNoise(new Bitmap(originalImage), circleCount);
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
    }
}
