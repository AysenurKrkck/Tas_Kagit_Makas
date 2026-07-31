# ✂️ Taş - Kağıt - Makas (Rock - Paper - Scissors) Console Game

C# ile geliştirilmiş, nesne yönelimli ve modüler bir konsol tabanlı **Taş - Kağıt - Makas** oyunu. Kullanıcı, bilgisayara karşı belirlenen hedef skora (3 veya 5 tur) ulaşmak için yarışır.

---

## 🌟 Öne Çıkan Özellikler

- **🎮 Dinamik Oyun Modları:** 3 Tura veya 5 Tura ulaşanın kazandığı mod seçenekleri.
- **🛡️ Güçlü Girdi Doğrulama (Input Validation):** Hatalı veya geçersiz kullanıcı girdilerinde oyunun çökmesini önleyen dinamik kontrol mekanizması.
- **🌐 Türkçe Karakter Desteği:** `UTF-8` konsol kodlaması sayesinde düzgün ve akıcı bir Türkçe arayüz.
- **🔀 Rastgele Hamle Üretimi:** `System.Random` kütüphanesi ile bilgisayar tarafında tamamen tarafsız hamle seçimleri.
- **🔄 Yeniden Oynama Seçeneği:** Oyun tamamlandığında uygulamadan çıkmadan hızlıca yeni oyun başlatabilme.
- **🧱 Temiz ve Modüler Kod Yapısı:** Enum kullanımı, `ref` parametreleri ve tek sorumluluk ilkesine (SRP) uygun fonksiyonel mimari.

---

## 🛠️ Teknolojiler ve Mimari

- **Dil:** C# (.NET Core / .NET Framework)
- **Uygulama Tipi:** Console Application
- **Veri Yapıları:** `enum` (Seçenekler için)

---

## 📂 Proje Yapısı ve Kod Mimarisi

Proje, okunabilirliği ve bakımı kolaylaştırmak adına modüler metotlara ayrılmıştır:

| Metot / Yapı | Açıklama |
| :--- | :--- |
| `enum Secenek` | `Tas (1)`, `Kagit (2)` ve `Makas (3)` seçimlerini sembolik olarak temsil eder. |
| `Main()` | Uygulama ana döngüsünü (`while`) ve UTF-8 Türkçe karakter yapılandırmasını yönetir. |
| `OyunuBaslat()` | Skor takibini, turları ve genel oyun akışını koordine eder. |
| `OyunModuSec()` | Kullanıcıya 3 veya 5 turluk hedef skor seçeneklerini sunar. |
| `OyuncuSecimAl()` | Kullanıcıdan geçerli bir hamle seçimi alır (`int.TryParse` kontrolü ile). |
| `TurSonucuBelirle()` | Hamleleri karşılaştırarak tur kazananını belirler ve skorları `ref` parametresiyle günceller. |
| `OyunSonucunuGoster()` | Hedef skora ulaşan kazananı şık bir konsol ekranı ile ilan eder. |
| `TekrarOynaIste()` | Kullanıcının yeni bir oyuna başlamak isteyip istemediğini sorar. |

---

---

## 📸 Ekran Görüntüsü / Örnek Çalışma

<img width="335" height="412" alt="1" src="https://github.com/user-attachments/assets/91e46d11-c906-4487-bff9-e2b5af73d30c" />

<img width="360" height="168" alt="3" src="https://github.com/user-attachments/assets/ab1a9ec6-12c0-4fe7-9bf9-333230d94a52" />

<img width="312" height="482" alt="2" src="https://github.com/user-attachments/assets/c56fd2fa-f5ac-41cc-9738-6a7d9bcde854" />


---
