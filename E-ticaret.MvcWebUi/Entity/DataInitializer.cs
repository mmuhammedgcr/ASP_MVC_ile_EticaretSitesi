using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_ticaret.MvcWebUi.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category(){Name="Kamera", Description="Kamera Urunleri"},
                new Category() { Name="Telefon", Description="Telefon Urunleri"},
                new Category(){Name="Bilgisayar", Description="Bilgisayar Urunleri"},
                new Category() { Name="Elektirik", Description="Elektrik Urunleri"},
                new Category(){Name="Beyaz Eşya", Description="Beyaz Eşya Urunleri"},
               
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            List<Product> Urunler = new List<Product>()
            {
                new Product(){Name="Apple iPhone 11 - 64GB 2 Yıl Apple Türkiye Garantili",Description="Tüm Türkiye için kargo ücretsizdir. Verilen siparişler 1 iş günü içerisinde kargoya verilir. Hafta sonları verilen siparişlerde,haftanın ilk işgünü süreç başlatılmaktadır. Sipariş etmiş olduğunuz ürünü kargodan teslim almadan evvel ürünün içeriği kontrol edilmeli ,hasarlı ürün gelmiş ise kargo firmasına rapor tutturulmalıdır. Hasar raporsuz şekilde gönderilerden firmamız mesul değildir. Ürünlerin Faturaları Dış Ambalajlarındaki şeffaf zarflar içersindedir. Gelen ürününüzün, dış ambalajı üzerinde Faturası yok ise ,lütfen teslim almadan kargoyu geri çeviriniz. CAYMA HAKKI Bazı istisnalar dışında İlgili Kanun gereğince koşulsuz 7 gün içersinde iade edilebilir. Ayıplı ve Arızalı ürünler; Tüketicinin Korunması Hakkındaki Kanun, Mal teslim tarihinden sonraki 30 gün içinde üründe ayıp olduğunun yetkili teknik servis tarafından tespit edilmesi durumunda, tüketiciye iade hakkını vermektedir",Price=3800,Stock=14, IsApproved=true, Cargo=true, CategoryId=2 ,Image="phone1.jpg"},
                new Product(){Name="KODAK PIXPRO FZ43 kompakt Dijital Kamera",Description="Dijital Fotoğraf Makinelerinin yeni Kodak PIXPRO koleksiyonundaki FZ43, Friendly Zoom ürününün tanıtımı. Kompakt, sezgisel ve kullanımı çok kolay olan FZ43, gittiğiniz her yere götüren mükemmel bir kameradır. Tek tuşla video, kırmızı göz giderme, yüz tanıma ve AA piller sadece bir başlangıç. Kodak PIXPRO Dijital Fotoğraf Makineleri. Hikayeni anlat.Kodak PIXPRO FZ43 Dijital Fotoğraf Makinesi:16.15 megapiksel çözünürlük ile yüksek kaliteli hareketsiz görüntüler ve video kayıtlarıOtomatik, Standart ve Panorama Efektleri, Sahne Seçici, 720p HD Film Kaydı, Yüz Algılama Teknolojisi, Optik Görüntü Sabitleme ve Göz Kırpma Algılama özelliği4.9 - 19.6 mm zumlu lens, 4x optik zoom / 6x dijital zoomAna",Price=1500,Stock=70, IsApproved=true,  Cargo=false, CategoryId=1,Image="camera1.jpg"},
                new Product(){Name="Intel i5m 8GB Ram 500GB Hdd 18,5'' Monitörlü Masaüstü Bilgisayar",Description="Bilgisayar  Makinelerinin yeni Kodak PIXPRO koleksiyonundaki FZ43, Friendly Zoom ürününün tanıtımı. Kompakt, sezgisel ve kullanımı çok kolay olan FZ43, gittiğiniz her yere götüren mükemmel bir kameradır. Tek tuşla video, kırmızı göz giderme, yüz tanıma ve AA piller sadece bir başlangıç. Kodak PIXPRO Dijital Fotoğraf Makineleri. Hikayeni anlat.Kodak PIXPRO FZ43 Dijital Fotoğraf Makinesi:16.15 megapiksel çözünürlük ile yüksek kaliteli hareketsiz görüntüler ve video kayıtlarıOtomatik, Standart ve Panorama Efektleri, Sahne Seçici, 720p HD Film Kaydı, Yüz Algılama Teknolojisi, Optik Görüntü Sabitleme ve Göz Kırpma Algılama özelliği4.9 - 19.6 mm zumlu lens, 4x optik zoom / 6x dijital zoomAna",Price=4500,Stock=100, IsApproved=true,  Cargo=true, CategoryId=3,Image="pc1.jpg"},
                new Product(){Name="Samsung S9 - 32GB 2 Yıl samsung Türkiye Garantili",Description="Tüm Türkiye için kargo ücretsizdir. Verilen siparişler 1 iş günü içerisinde kargoya verilir. Hafta sonları verilen siparişlerde,haftanın ilk işgünü süreç başlatılmaktadır. Sipariş etmiş olduğunuz ürünü kargodan teslim almadan evvel ürünün içeriği kontrol edilmeli ,hasarlı ürün gelmiş ise kargo firmasına rapor tutturulmalıdır. Hasar raporsuz şekilde gönderilerden firmamız mesul değildir. Ürünlerin Faturaları Dış Ambalajlarındaki şeffaf zarflar içersindedir. Gelen ürününüzün, dış ambalajı üzerinde Faturası yok ise ,lütfen teslim almadan kargoyu geri çeviriniz. CAYMA HAKKI Bazı istisnalar dışında İlgili Kanun gereğince koşulsuz 7 gün içersinde iade edilebilir. Ayıplı ve Arızalı ürünler; Tüketicinin Korunması Hakkındaki Kanun, Mal teslim tarihinden sonraki 30 gün içinde üründe ayıp olduğunun yetkili teknik servis tarafından tespit edilmesi durumunda, tüketiciye iade hakkını vermektedir",Price=5800,Stock=7, IsApproved=true, Cargo=true, CategoryId=5,Image="camasir1.jpg"},
                new Product(){Name="xamio kl 11 - 64GB 2 Yıl Apple Türkiye Garantili",Description="Tüm Türkiye için kargo ücretsizdir. Verilen siparişler 1 iş günü içerisinde kargoya verilir. Hafta sonları verilen siparişlerde,haftanın ilk işgünü süreç başlatılmaktadır. Sipariş etmiş olduğunuz ürünü kargodan teslim almadan evvel ürünün içeriği kontrol edilmeli ,hasarlı ürün gelmiş ise kargo firmasına rapor tutturulmalıdır. Hasar raporsuz şekilde gönderilerden firmamız mesul değildir. Ürünlerin Faturaları Dış Ambalajlarındaki şeffaf zarflar içersindedir. Gelen ürününüzün, dış ambalajı üzerinde Faturası yok ise ,lütfen teslim almadan kargoyu geri çeviriniz. CAYMA HAKKI Bazı istisnalar dışında İlgili Kanun gereğince koşulsuz 7 gün içersinde iade edilebilir. Ayıplı ve Arızalı ürünler; Tüketicinin Korunması Hakkındaki Kanun, Mal teslim tarihinden sonraki 30 gün içinde üründe ayıp olduğunun yetkili teknik servis tarafından tespit edilmesi durumunda, tüketiciye iade hakkını vermektedir",Price=4700,Stock=14, IsApproved=true, Cargo=false, CategoryId=2,Image="phone2.png"},
                new Product(){Name="ASUS as 4 - 14GB 2 Yıl Apple Türkiye Garantili",Description="Tüm Türkiye için kargo ücretsizdir. Verilen siparişler 1 iş günü içerisinde kargoya verilir. Hafta sonları verilen siparişlerde,haftanın ilk işgünü süreç başlatılmaktadır. Sipariş etmiş olduğunuz ürünü kargodan teslim almadan evvel ürünün içeriği kontrol edilmeli ,hasarlı ürün gelmiş ise kargo firmasına rapor tutturulmalıdır. Hasar raporsuz şekilde gönderilerden firmamız mesul değildir. Ürünlerin Faturaları Dış Ambalajlarındaki şeffaf zarflar içersindedir. Gelen ürününüzün, dış ambalajı üzerinde Faturası yok ise ,lütfen teslim almadan kargoyu geri çeviriniz. CAYMA HAKKI Bazı istisnalar dışında İlgili Kanun gereğince koşulsuz 7 gün içersinde iade edilebilir. Ayıplı ve Arızalı ürünler; Tüketicinin Korunması Hakkındaki Kanun, Mal teslim tarihinden sonraki 30 gün içinde üründe ayıp olduğunun yetkili teknik servis tarafından tespit edilmesi durumunda, tüketiciye iade hakkını vermektedir",Price=2000,Stock=14, IsApproved=true,  Cargo=true, CategoryId=1,Image="camera1.jpg"},
                new Product(){Name="AMD i5m 12GB Ram 500GB Hdd 18,5'' Monitörlü Masaüstü Bilgisayar",Description="Bilgisayar  Makinelerinin yeni Kodak PIXPRO koleksiyonundaki FZ43, Friendly Zoom ürününün tanıtımı. Kompakt, sezgisel ve kullanımı çok kolay olan FZ43, gittiğiniz her yere götüren mükemmel bir kameradır. Tek tuşla video, kırmızı göz giderme, yüz tanıma ve AA piller sadece bir başlangıç. Kodak PIXPRO Dijital Fotoğraf Makineleri. Hikayeni anlat.Kodak PIXPRO FZ43 Dijital Fotoğraf Makinesi:16.15 megapiksel çözünürlük ile yüksek kaliteli hareketsiz görüntüler ve video kayıtlarıOtomatik, Standart ve Panorama Efektleri, Sahne Seçici, 720p HD Film Kaydı, Yüz Algılama Teknolojisi, Optik Görüntü Sabitleme ve Göz Kırpma Algılama özelliği4.9 - 19.6 mm zumlu lens, 4x optik zoom / 6x dijital zoomAna",Price=1500,Stock=100, IsApproved=false,  Cargo=true, CategoryId=3,Image="pc1.jpg"},
                new Product(){Name="LENOVO i5m 28GB Ram 500GB Hdd 18,5'' Monitörlü Masaüstü Bilgisayar",Description="Bilgisayar  Makinelerinin yeni Kodak PIXPRO koleksiyonundaki FZ43, Friendly Zoom ürününün tanıtımı. Kompakt, sezgisel ve kullanımı çok kolay olan FZ43, gittiğiniz her yere götüren mükemmel bir kameradır. Tek tuşla video, kırmızı göz giderme, yüz tanıma ve AA piller sadece bir başlangıç. Kodak PIXPRO Dijital Fotoğraf Makineleri. Hikayeni anlat.Kodak PIXPRO FZ43 Dijital Fotoğraf Makinesi:16.15 megapiksel çözünürlük ile yüksek kaliteli hareketsiz görüntüler ve video kayıtlarıOtomatik, Standart ve Panorama Efektleri, Sahne Seçici, 720p HD Film Kaydı, Yüz Algılama Teknolojisi, Optik Görüntü Sabitleme ve Göz Kırpma Algılama özelliği4.9 - 19.6 mm zumlu lens, 4x optik zoom / 6x dijital zoomAna",Price=4500,Stock=100, IsApproved=true, Cargo=false, CategoryId=5,Image="camasir1.jpg"},
            };

            foreach (var urun in Urunler)
            {
                context.Products.Add(urun);

            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}