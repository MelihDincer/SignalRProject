## **SignalR ile QR Kodlu Restoran Projesi**
#### Merhaba, bu projemizde bir restoran web sayfası yapmaya çalıştık. Projede eksik bölümler zamanla tamamlanacaktır.

### **Proje İçeriği**
#### Bu projede; misafirlerimizin restoranımız ile ilgili bilgilere ulaşabileceği, menümüzü görüntüleyebileceği, ürünleri mevcut sepetine ekleyip kendi sepetini görüntüleyebileceği ve ürün fiyatlarının ve otomatik olarak hesaplanan ücretleri görüntüleyebileceği, yeni bir rezervasyon oluşturabileceği bir vitrin paneli; admin yetkisine sahip yetkili kişilerin de mevcut sayfa üzerinde(UI paneli) değişiklikler yapabileceği, SignalR ile gerçekleştirilmiş anlık istatistik sayfalarını görüntüleyebileceği, oluşturulan rezervasyon bilgilerini görüntüleyip bu rezervasyonları onaylama-iptal etme-silme ve güncelleme işlemlerini yapabildiği, aynı zamanda istenilen bir mail adresine mail gönderebildiği ve de bir QR Kod oluşturabileceği bir sayfanın yer aldığı Admin Paneli gibi özellikler mevcuttur. Backend tarafında kullandığımız Api yapısını UI tarafında consume ederek işlemlerimizi gerçekleştirdik. Projede mümkün olduğunca mimariye ve solid prensiplerine sadık kalarak clean code prensiplerinde kod yazdık. Proje geliştirilmeye açık bir proje olup, eksik kısımlar yer almaktadır. Eksik olan kısımlar farklı projelerde yapıldığından ve de bu projenin de bir eğitim projesi olduğunu düşünürsek yeterli alt yapıya sahip olduğunu söyleyebilirim. Proje ekran görüntülerini sizinle paylaşıyor olacağım...

*Bu Projede Değinilen Konu Başlıkları:*
#### Asp.Net Core 6.0, Asp.Net Core Api, SignalR, Dto, AutoMapper, N Tier Architecture, İlişkili Tablolar ve MSSQL, HTML-CSS-BootStrap, JavaScript, Ajax, EntityFramework-Linq, SweetAlert, Sepet İşlemleri, Rezervasyon İşlemleri, Anlık İstatistikler, Anlık Mesajlaşma, Anlık Bildirimler, MailKit Kütüphanesi ile Mail Gönderme İşlemleri ve daha fazlası...

### **Proje İçerisinden Bazı Görseller:**
![1](https://github.com/MelihDincer/SignalRProject/assets/115299123/1cc08934-3b09-4456-a0ee-0104bbf89703)
![2](https://github.com/MelihDincer/SignalRProject/assets/115299123/7748fde2-ba2d-43fb-b2bc-8f71d324ef58)
![3](https://github.com/MelihDincer/SignalRProject/assets/115299123/b6ceb88a-0dae-4d48-b355-c8b1c5249728)
![4](https://github.com/MelihDincer/SignalRProject/assets/115299123/dd4d9c3b-0db5-46c6-9e7a-34fbf4cbf4a7)
![5](https://github.com/MelihDincer/SignalRProject/assets/115299123/6c48d23c-711b-4968-9cdd-9755bff0c391)
![6](https://github.com/MelihDincer/SignalRProject/assets/115299123/2466ca1d-1d85-4bbf-80b1-efd4c91e27d4)
![7](https://github.com/MelihDincer/SignalRProject/assets/115299123/765aad42-25f6-43c9-b231-728a52734263)
![8](https://github.com/MelihDincer/SignalRProject/assets/115299123/85203fb1-d8d9-4eab-9754-58df76530410)
![9](https://github.com/MelihDincer/SignalRProject/assets/115299123/8a558299-ab2d-411e-b68d-9666171bee61)
![10](https://github.com/MelihDincer/SignalRProject/assets/115299123/85c9bb26-ee36-4bde-8adb-610141ac9316)
![11](https://github.com/MelihDincer/SignalRProject/assets/115299123/0dc24546-c82c-4430-8bb8-ede182184d4b)
![12](https://github.com/MelihDincer/SignalRProject/assets/115299123/210e8f28-b26a-44ac-a197-7121f8da8f18)
![13](https://github.com/MelihDincer/SignalRProject/assets/115299123/d18cfbf4-e80e-46c9-9ccb-fbaa0e63c5d8)
![14](https://github.com/MelihDincer/SignalRProject/assets/115299123/ec33d428-d315-4dc1-be31-5baca88b63a9)
![15](https://github.com/MelihDincer/SignalRProject/assets/115299123/d3828608-f26e-4cd3-8803-524e1fdd8a76)
![16](https://github.com/MelihDincer/SignalRProject/assets/115299123/3fe11f89-fd49-4770-bd05-dc022f48d85d)
![17](https://github.com/MelihDincer/SignalRProject/assets/115299123/5bd00b61-454a-49fb-a33b-98b2b938b137)
![18](https://github.com/MelihDincer/SignalRProject/assets/115299123/4f5995b3-39e7-4bd9-b7f0-3267531ba8b7)
![19](https://github.com/MelihDincer/SignalRProject/assets/115299123/01da919c-859d-472a-9889-91444876e01f)
![20](https://github.com/MelihDincer/SignalRProject/assets/115299123/56fcde5e-8f1e-4105-89a2-38d2f20dedcd)
