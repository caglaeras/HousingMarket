using Housing.Data;
using Housing.Models;

namespace Housing.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Kurye bilgilerini ekle
            if (!context.DeliveryContacts.Any())
            {
                var contacts = new DeliveryContact[]
                {
                    new DeliveryContact { Name = "Hızlı Taşıma", PhoneNumber = "0555-111-2233", ServiceArea = "İstanbul Avrupa Yakası", Notes = "Ortalama ücret: 300 TL" },
                    new DeliveryContact { Name = "Ekonomik Nakliyat", PhoneNumber = "0555-222-3344", ServiceArea = "Anadolu Yakası", Notes = "Uygun fiyatlı, zamanında teslim" },
                    new DeliveryContact { Name = "Güler Yüzlü Kurye", PhoneNumber = "0555-333-4455", ServiceArea = "Tüm İstanbul", Notes = "Hafta sonu da hizmet verir" },
                    new DeliveryContact { Name = "Öğrenci Dostu Taşıma", PhoneNumber = "0555-444-5566", ServiceArea = "Üniversite çevreleri", Notes = "Öğrencilere %20 indirim" },
                    new DeliveryContact { Name = "Metro Kargo", PhoneNumber = "0555-555-6677", ServiceArea = "İstanbul Geneli", Notes = "Aynı gün teslimat" },
                    new DeliveryContact { Name = "Şehir İçi Mini Taşıma", PhoneNumber = "0555-666-7788", ServiceArea = "Merkez semtler", Notes = "Küçük eşyalar için ideal" }
                };
                context.DeliveryContacts.AddRange(contacts);
            }

            // Mobilya ilanlarını ekle
            if (!context.Furniture.Any())
            {
                var items = new Furniture[]
                {
                    new Furniture {
                        Title = "Kitaplık",
                        Description = "5 raflı, geniş kitaplık. Temiz ve sağlam.",
                        Category = "Depolama",
                        Condition = "İyi",
                        Location = "Kadıköy",
                        DatePosted = DateTime.Now.AddDays(-2),
                        ImagePath = "/images/furniture/kitaplik.png",
                        IsReadOnly = true
                    },
                    new Furniture {
                        Title = "Çalışma Masası",
                        Description = "Modern tasarımlı masa, öğrenciler için ideal.",
                        Category = "Masa",
                        Condition = "Yeni gibi",
                        Location = "Beşiktaş",
                        DatePosted = DateTime.Now.AddDays(-1),
                        ImagePath = "/images/furniture/calismamasa.png",
                        IsReadOnly = true
                    },
                    new Furniture {
                        Title = "Tekli Koltuk",
                        Description = "Konforlu koltuk, kitap okumak için harika.",
                        Category = "Oturma",
                        Condition = "Orta",
                        Location = "Bakırköy",
                        DatePosted = DateTime.Now.AddDays(-3),
                        ImagePath = "/images/furniture/tekli.png",
                        IsReadOnly = true
                    },
                    new Furniture {
                        Title = "Yemek Masası",
                        Description = "4 kişilik, az kullanılmış masa.",
                        Category = "Masa",
                        Condition = "İyi",
                        Location = "Şişli",
                        DatePosted = DateTime.Now.AddDays(-4),
                        ImagePath = "/images/furniture/masa.png",
                        IsReadOnly = true
                    },
                    new Furniture {
                        Title = "Küçük Kitaplık",
                        Description = "3 raflı, beyaz renkli. Minimalist dekor için uygun.",
                        Category = "Depolama",
                        Condition = "Yeni gibi",
                        Location = "Üsküdar",
                        DatePosted = DateTime.Now.AddDays(-5),
                        ImagePath = "/images/furniture/minikitaplik.png",
                        IsReadOnly = true
                    },
                    new Furniture {
                        Title = "Oturma Koltuğu",
                        Description = "Kırmızı renkli, geniş tekli koltuk.",
                        Category = "Oturma",
                        Condition = "İyi",
                        Location = "Ataşehir",
                        DatePosted = DateTime.Now.AddDays(-6),
                        ImagePath = "/images/furniture/kirmizitekli.png",
                        IsReadOnly = true
                    }
                };
                context.Furniture.AddRange(items);
            }

            // Veritabanına işle
            context.SaveChanges();
        }
    }
}
