using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasKagitMakas
{
    enum Secenek// Oyuncunun ve bilgisayarın seçimlerini temsil eden enum
    {
        Tas = 1,
        Kagit = 2,
        Makas = 3
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // Türkçe karakterlerin konsolda düzgün görünmesi için
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool tekrarOyna = true;// Oyuncunun tekrar oynamak isteyip istemediğini kontrol eden değişken

            while (tekrarOyna)// Oyun döngüsü, oyuncu tekrar oynamak istediği sürece devam eder
            {
                OyunuBaslat();
                tekrarOyna = TekrarOynaIste();
            }

            Console.WriteLine("\nOynadığınız için teşekkürler");
        }

        static void OyunuBaslat()// Oyunun ana akışını yöneten metod
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("   TAŞ - KAĞIT - MAKAS OYUNU     ");
            Console.WriteLine("=================================\n");

            //Oyun Modu Seçimi
            int hedefSkor = OyunModuSec();

            int oyuncuSkoru = 0;// Oyuncunun skorunu tutan değişken
            int bilgisayarSkoru = 0;// Bilgisayarın skorunu tutan değişken
            int turSayisi = 1;// Oyun tur sayısını tutan değişken

            Random random = new Random();// Bilgisayarın rastgele seçim yapabilmesi için Random sınıfı

            // Belirlenen skora (3 veya 5) ilk ulaşan oyunu kazanır
            while (oyuncuSkoru < hedefSkor && bilgisayarSkoru < hedefSkor)
            {
                Console.WriteLine($"\n--- {turSayisi}. TUR ---");// Mevcut tur numarasını gösterir
                Console.WriteLine($"Skor: Siz [{oyuncuSkoru}] - [{bilgisayarSkoru}] Bilgisayar");// Mevcut skoru gösterir

                //Kullanıcının Seçimi
                Secenek oyuncuSecimi = OyuncuSecimAl();

                // Bilgisayarın Seçimi
                Secenek bilgisayarSecimi = (Secenek)random.Next(1, 4);

                Console.WriteLine($"\nSizin Seçiminiz     : {oyuncuSecimi}");
                Console.WriteLine($"Bilgisayarın Seçimi : {bilgisayarSecimi}");

                // Tur Sonucunun Belirlenmesi
                TurSonucuBelirle(oyuncuSecimi, bilgisayarSecimi, ref oyuncuSkoru, ref bilgisayarSkoru);

                turSayisi++;
            }

            //Oyun Sonu ve Genel Kazananın Açıklanması
            OyunSonucunuGoster(oyuncuSkoru, bilgisayarSkoru, hedefSkor);
        }

        static int OyunModuSec()// Oyuncunun oyun modunu seçmesini sağlayan metod
        {
            while (true)// Kullanıcı geçerli bir seçim yapana kadar döngü devam eder
            {
                Console.WriteLine("Oyun Modunu Seçin:");// Oyuncuya oyun modunu seçmesi için seçenekler sunar
                Console.WriteLine("1 - 3 Tura Ulaşan Kazanır");// Oyuncu 3 tura ulaşırsa kazanır
                Console.WriteLine("2 - 5 Tura Ulaşan Kazanır");// Oyuncu 5 tura ulaşırsa kazanır
                Console.Write("Tercihiniz (1 veya 2): ");// Oyuncudan seçim yapmasını ister

                string secim = Console.ReadLine();// Oyuncunun girdiği değeri alır
                if (secim == "1") return 3;// Oyuncu 1'i seçerse hedef skor 3 olur
                if (secim == "2") return 5;// Oyuncu 2'yi seçerse hedef skor 5 olur

                Console.WriteLine("Hatalı seçim! Lütfen 1 veya 2 girin.\n");// Oyuncu geçersiz bir seçim yaparsa hata mesajı gösterir ve döngü devam eder
            }
        }

        static Secenek OyuncuSecimAl()// Oyuncunun seçim yapmasını sağlayan metod
        {
            while (true)// Kullanıcı geçerli bir seçim yapana kadar döngü devam eder
            {
                Console.WriteLine("Seçiminizi yapın:");//   Oyuncuya seçim yapması için seçenekler sunar
                Console.WriteLine("1 - Taş");// Oyuncu 1'i seçerse taş seçmiş olur
                Console.WriteLine("2 - Kağıt");// Oyuncu 2'yi seçerse kağıt seçmiş olur
                Console.WriteLine("3 - Makas");// Oyuncu 3'ü seçerse makas seçmiş olur
                Console.Write("Seçiminiz (1-3): ");// Oyuncudan seçim yapmasını ister

                string girdi = Console.ReadLine();// Oyuncunun girdiği değeri alır
                if (int.TryParse(girdi, out int secim) && secim >= 1 && secim <= 3)// Oyuncunun girdiği değerin geçerli bir sayı olup olmadığını kontrol eder
                {
                    return (Secenek)secim;// Oyuncunun geçerli bir seçim yapması durumunda, seçimi Secenek enum'ına dönüştürerek geri döndürür
                }

                Console.WriteLine("Geçersiz seçim! Lütfen 1, 2 veya 3 girin.\n");// Oyuncu geçersiz bir seçim yaparsa hata mesajı gösterir ve döngü devam eder
            }
        }

        static void TurSonucuBelirle(Secenek oyuncu, Secenek bilgisayar, ref int oyuncuSkoru, ref int bilgisayarSkoru)// Tur sonucunu belirleyen metod
        {
            if (oyuncu == bilgisayar)// Oyuncu ve bilgisayarın seçimleri aynı ise berabere durumunu gösterir
            {
                Console.WriteLine(">> Bu tur BERABERE!");// Berabere durumunda skor değişmez
            }
            // Oyuncunun kazandığı durumlar
            else if ((oyuncu == Secenek.Tas && bilgisayar == Secenek.Makas) ||
                     (oyuncu == Secenek.Kagit && bilgisayar == Secenek.Tas) ||
                     (oyuncu == Secenek.Makas && bilgisayar == Secenek.Kagit))
            {
                Console.WriteLine(">> Bu turu SİZ KAZANDINIZ!");
                oyuncuSkoru++;
            }
            else
            {
                Console.WriteLine(">> Bu turu BİLGİSAYAR KAZANDI!");
                bilgisayarSkoru++;
            }
        }

        static void OyunSonucunuGoster(int oyuncuSkoru, int bilgisayarSkoru, int hedefSkor)// Oyun sonucunu gösteren metod
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("          OYUN BİTTİ!            ");
            Console.WriteLine("=================================");
            Console.WriteLine($"Sonç Skor: Siz [{oyuncuSkoru}] - [{bilgisayarSkoru}] Bilgisayar");

            if (oyuncuSkoru == hedefSkor)// Oyuncu hedef skora ulaştıysa kazandığını gösterir
            {
                Console.WriteLine("Tebrikler, Oyunu SİZ KAZANDINIZ! 🏆");
            }
            else// Bilgisayar hedef skora ulaştıysa kazandığını gösterir
            {
                Console.WriteLine("Maalesef, Oyunu BİLGİSAYAR KAZANDI! 🤖");
            }
        }

        static bool TekrarOynaIste()// Oyuncuya tekrar oynamak isteyip istemediğini soran metod
        {
            Console.Write("\nYeniden oynamak ister misiniz? (E/H): ");
            string cevap = Console.ReadLine().Trim().ToUpper();
            return cevap == "E";
        }
    }
}
