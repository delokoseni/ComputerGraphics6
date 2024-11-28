using System;
using System.Drawing;
using System.Drawing.Imaging;
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
                textBoxMedianFilterRadius.Text = "";
                textBoxUniformFilterRadius.Text = "";
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
            if (originalImage != null && ValidateNoiseInput(textBoxAddNoisePoints, out int pointCount))
            {
                currentImage = AddPointNoise(currentImage, pointCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonAddNoiseLines_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateNoiseInput(textBoxAddNoiseLines, out int lineCount))
            {
                currentImage = AddLineNoise(currentImage, lineCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonAddNoiseCircles_Click(object sender, EventArgs e)
        {
            if (originalImage != null && ValidateNoiseInput(textBoxAddNoiseCircles, out int circleCount))
            {
                currentImage = AddCircleNoise(currentImage, circleCount);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonUniformFilter_Click(object sender, EventArgs e)
        {
            if (currentImage != null && ValidateRadiusInput(textBoxUniformFilterRadius, out int radius))
            {
                currentImage = ApplyUniformFilter(currentImage, radius);
                pictureBox.Image = currentImage;
            }
        }

        private void buttonMedianFilter_Click(object sender, EventArgs e)
        {
            if (currentImage != null && ValidateRadiusInput(textBoxMedianFilterRadius, out int radius))
            {
                currentImage = ApplyMedianFilter(currentImage, radius);
                pictureBox.Image = currentImage;
            }
        }

        // Метод обрабатывающий нажатие на кнопку "Тиснение"
        private void buttonEmbossing_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                currentImage = ApplyEmbossing(currentImage);
                pictureBox.Image = currentImage;
            }
        }

        private bool ValidateNoiseInput(TextBox textBox, out int noiseCount)
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

        private bool ValidateRadiusInput(TextBox textBox, out int radius)
        {
            radius = 0;

            if (originalImage == null)
            {
                MessageBox.Show("Сначала загрузите изображение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (int.TryParse(textBox.Text, out int parsedRadius) && parsedRadius > 0)
            {
                int maxRadius = Math.Min(originalImage.Width, originalImage.Height) / 2; 
                if (parsedRadius <= maxRadius)
                {
                    radius = parsedRadius;
                    return true;
                }
                else
                {
                    MessageBox.Show($"Введите радиус меньше или равный {maxRadius}.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректное значение радиуса больше 0.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        // Метод добавляющий точечные шумы на изображение
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

        // Метод добавляющий шумы в виде линий на изображение
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

        // Метод добавляющий шумы в виде окружностей на изображение
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

        // Метод применяющий равномерный фильтр
        private Bitmap ApplyUniformFilter(Bitmap bitmap, int radius)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            int size = radius * 2 + 1;
            int[,] kernel = new int[size, size];

            // Предварительное создание ядра
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    kernel[x, y] = 1; // Все значения равны 1 для равномерного размытия
                }
            }

            // Применение размытия
            for (int x = radius; x < bitmap.Width - radius; x++)
            {
                for (int y = radius; y < bitmap.Height - radius; y++)
                {
                    Color newColor = GetAverageColor(bitmap, x, y, radius);
                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }

        // Метод для получения среднего значения цвета в указанном радиусе
        private Color GetAverageColor(Bitmap bitmap, int centerX, int centerY, int radius)
        {
            long r = 0, g = 0, b = 0;
            int count = 0;

            Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2 + 1, radius * 2 + 1);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int x = 0; x < data.Width; x++)
                {
                    for (int y = 0; y < data.Height; y++)
                    {
                        int pixelIndex = (y * data.Stride) + (x * 4); 
                        b += ptr[pixelIndex];
                        g += ptr[pixelIndex + 1];
                        r += ptr[pixelIndex + 2];
                        count++;
                    }
                }
            }

            bitmap.UnlockBits(data);

            return Color.FromArgb((int)(r / count), (int)(g / count), (int)(b / count));
        }

        // Метод применяющий медианный фильтр
        private Bitmap ApplyMedianFilter(Bitmap bitmap, int radius)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = radius; x < bitmap.Width - radius; x++)
            {
                for (int y = radius; y < bitmap.Height - radius; y++)
                {
                    Color newColor = GetMedianColor(bitmap, x, y, radius);
                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }

        // Метод для получения медианного значения цвета в указанном радиусе
        private Color GetMedianColor(Bitmap bitmap, int centerX, int centerY, int radius)
        {
            var colors = new List<Color>();

            Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2 + 1, radius * 2 + 1);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int x = 0; x < data.Width; x++)
                {
                    for (int y = 0; y < data.Height; y++)
                    {
                        int pixelIndex = (y * data.Stride) + (x * 4); // Предполагаем формат BGRA
                        colors.Add(Color.FromArgb(ptr[pixelIndex + 2], ptr[pixelIndex + 1], ptr[pixelIndex])); // BGRA в ARGB
                    }
                }
            }

            bitmap.UnlockBits(data);

            return GetMedian(colors);
        }

        // Метод для получения медианного цвета в указанном радиусе
        private Color GetMedian(System.Collections.Generic.List<Color> colors)
        {
            if (colors.Count == 0) return Color.Black;

            // Сортируем цвета по яркости
            var sortedColors = colors.OrderBy(c => c.ToArgb()).ToList();
            int middleIndex = sortedColors.Count / 2;

            // Если количество цветовых значений нечётное, вернуть средний элемент.
            if (sortedColors.Count % 2 == 1)
                return sortedColors[middleIndex];
            else
            {
                // В случае чётного количества цветов, вернуть средний между двумя центральными.
                Color avgColor = AverageColor(sortedColors[middleIndex - 1], sortedColors[middleIndex]);
                return avgColor;
            }
        }

        // Метод для подсчета среднего цвета
        private Color AverageColor(Color c1, Color c2)
        {
            return Color.FromArgb(
                (c1.R + c2.R) / 2,
                (c1.G + c2.G) / 2,
                (c1.B + c2.B) / 2);
        }

        // Метод для применения тиснения к изображению
        private Bitmap ApplyEmbossing(Bitmap bitmap)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);

            // Проходим по каждому пикселю, кроме краев
            for (int x = 1; x < bitmap.Width - 1; x++)
            {
                for (int y = 1; y < bitmap.Height - 1; y++)
                {
                    // Получаем цвета соседних пикселей
                    Color current = bitmap.GetPixel(x, y);
                    Color right = bitmap.GetPixel(x + 1, y);
                    Color bottom = bitmap.GetPixel(x, y + 1);

                    // Вычисляем разности для создания эффекта тиснения
                    int r = Clamp(current.R - right.R + 128);
                    int g = Clamp(current.G - right.G + 128);
                    int b = Clamp(current.B - bottom.B + 128);

                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return result;
        }

        private int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }
}
