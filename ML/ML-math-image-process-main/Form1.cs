using System;
using System.Drawing; // Resim işlemleri için kütüphane
using System.Windows.Forms; // Form elemanları için kütüphane

namespace ML_math_image_process
{
    public partial class Form1 : Form
    {
        // Yüklenen orijinal resmi hafızada tutmak için değişken
        private Bitmap originalImage;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. BUTON: Bilgisayardan Resim Yükleme
        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Resmi dosyadan okuyoruz
                originalImage = new Bitmap(openFileDialog.FileName);
                // Ekranda gösteriyoruz
                pictureBox1.Image = originalImage;
            }
        }

        // 2. BUTON: Griye Çevirme İşlemi
        private void btnGriYap_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return; // Resim yoksa işlem yapma

            // OOP Mantığı: Interface üzerinden sınıfı çağırıyoruz (Polimorfizm)
            IFilter filter = new GrayscaleFilter();

            // İşlenmiş resmi alıp ekrana basıyoruz
            pictureBox1.Image = filter.Apply(originalImage);
        }

        // 3. BUTON: Siyah Beyaz (Threshold) İşlemi
        private void btnSiyahBeyaz_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            // OOP Mantığı: Threshold sınıfını çağırıyoruz
            // 128 eşik değeridir.
            IFilter filter = new ThresholdFilter(128);

            pictureBox1.Image = filter.Apply(originalImage);
        }
    }

    // =============================================================
    // OOP CLASS YAPISI BURADA BAŞLIYOR (ML ve MATH MANTIKLARI)
    // =============================================================

    // [INTERFACE] 
    // Tüm filtreler bu kalıbı kullanmak zorunda.
    // Bu sayede kodumuz genişletilebilir oluyor.
    public interface IFilter
    {
        Bitmap Apply(Bitmap sourceImage);
    }

    // [CLASS 1] Gri Tonlama Filtresi
    // ML Ön İşleme: Renkli resimdeki 3 kanalı (R,G,B) tek kanala indirir.
    public class GrayscaleFilter : IFilter
    {
        public Bitmap Apply(Bitmap sourceImage)
        {
            // Orijinal resmin boyutunda boş bir resim oluştur
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            // Resmin her bir pikselini (noktasını) tek tek geziyoruz
            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    // O anki pikselin rengini al
                    Color pixelColor = sourceImage.GetPixel(x, y);

                    // --- MATH KISMI ---
                    // İnsan gözü yeşili daha parlak görür, bu yüzden ağırlıklı ortalama alıyoruz.
                    // Formül: Gray = 0.3*R + 0.59*G + 0.11*B
                    int grayValue = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));

                    // Yeni rengi oluştur (Gri olması için R, G ve B aynı olmalı)
                    Color newColor = Color.FromArgb(grayValue, grayValue, grayValue);

                    // Yeni resme bu rengi işle
                    resultImage.SetPixel(x, y, newColor);
                }
            }
            return resultImage;
        }
    }

    // [CLASS 2] Eşikleme (Threshold) Filtresi
    // ML Ön İşleme: Resmi sadece 0 ve 1'lerden (Siyah ve Beyaz) oluşan bir matrise çevirir.
    // Bu işlem genellikle yazı okuma (OCR) veya nesne ayıklama için kullanılır.
    public class ThresholdFilter : IFilter
    {
        private int _threshold; // Eşik değeri (Örn: 128)

        public ThresholdFilter(int threshold)
        {
            _threshold = threshold;
        }

        public Bitmap Apply(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int x = 0; x < sourceImage.Width; x++)
            {
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color pixelColor = sourceImage.GetPixel(x, y);

                    // Önce gri tonu hesaplamamız lazım (çünkü kıyaslama tek sayı üzerinden yapılır)
                    int grayValue = (int)((pixelColor.R * 0.3) + (pixelColor.G * 0.59) + (pixelColor.B * 0.11));

                    // --- MATH ve MANTIK KISMI ---
                    // Eğer pikselin parlaklığı eşik değerinden büyükse BEYAZ yap, değilse SİYAH yap.
                    Color newColor;
                    if (grayValue >= _threshold)
                    {
                        newColor = Color.White; // 255, 255, 255
                    }
                    else
                    {
                        newColor = Color.Black; // 0, 0, 0
                    }

                    resultImage.SetPixel(x, y, newColor);
                }
            }
            return resultImage;
        }
    }
}
