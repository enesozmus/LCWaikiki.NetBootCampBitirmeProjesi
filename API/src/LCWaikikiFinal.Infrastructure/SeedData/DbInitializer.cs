using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LCWaikikiFinal.Infrastructure.SeedData
{
        public class DbInitializer
        {
                public static void Initialize(IApplicationBuilder applicationBuilder)
                {
                        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                        {
                                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                                context.Database.Migrate();

                                #region Categories

                                if (!context.Categories.Any())
                                {
                                        context.Categories.AddRange(new List<Category>()
                                        {
                                                new Category {Name = "Mont", Description = "Soğuk kış günleri üşümeyin diye", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Category {Name = "Hırka ve Süveter", Description = "Soğuk kış günleri üşümeyin diye", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Category {Name = "Kazak", Description = "Soğuk kış günleri üşümeyin diye", CreatedDate =new DateTime(2022, 04, 16) },
                                                new Category {Name = "Bluz", Description = "7/24 Basic Trend", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Category {Name = "Gömlek", Description = "Keten Rahatlığı", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Category {Name = "Tişört", Description = "Güneşin keyfini çıkar", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Category {Name = "Sweatshirt", Description = "Favorilerini seç, en trend ürünleri keşfet", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Category {Name = "Jean", Description = "Sezonun en hit parçalarını keşfet", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Category {Name = "Yeni", Description = "Developer", CreatedDate = new DateTime(2022, 04, 16) },
                                        });
                                        context.SaveChanges();
                                }

                                #endregion

                                #region Colors

                                if (!context.Colors.Any())
                                {
                                        context.Colors.AddRange(new List<Color>()
                                        {
                                                new Color { Name = "Ekru", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Kırmızı", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Lacivert", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Açık Kahverengi", CreatedDate = new DateTime(2022, 04, 16)},
                                                new Color { Name = "Mavi", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Antrasit", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Koyu Gri", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Canlı Turuncu", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Bej Çizgili", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Beyaz", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Gri", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "İndigo Melanj", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Koyu Rodeo", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Color { Name = "Optik Beyaz", CreatedDate = new DateTime(2022, 04, 16) }
                                        });
                                        context.SaveChanges();
                                }

                                #endregion

                                #region Brands

                                if (!context.Brands.Any())
                                {
                                        context.Brands.AddRange(new List<Brand>()
                                        {
                                                new Brand { Name = "LCWAIKIKI", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Brand { Name = "LCWAIKIKI Limited", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Brand { Name = "LCWAIKIKI Modest", CreatedDate = new DateTime(2022, 04, 16)},
                                                new Brand { Name = "LCWAIKIKI Casual", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Brand { Name = "LCWAIKIKI Vision", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Brand { Name = "MIZALLE", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Brand { Name = "BENETTON", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Brand { Name = "BIANCA", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Brand { Name = "QOOQ STORE", CreatedDate = new DateTime(2022, 04, 16) }
                                        });
                                        context.SaveChanges();
                                }

                                #endregion

                                #region Sizes

                                if (!context.Sizes.Any())
                                {
                                        context.Sizes.AddRange(new List<Size>()
                                        {
                                                new Size { Name = "XS", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Size { Name = "S", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Size { Name = "M", CreatedDate = new DateTime(2022, 04, 16)},
                                                new Size { Name = "L", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Size { Name = "XL", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Size { Name = "2XL", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Size { Name = "3XL", CreatedDate = new DateTime(2022, 04, 16) }
                                        });
                                        context.SaveChanges();
                                }

                                #endregion

                                #region Lifecycle

                                if (!context.Lifecycles.Any())
                                {
                                        context.Lifecycles.AddRange(new List<Lifecycle>()
                                        {
                                                new Lifecycle { Description = "Yeni & Etiketli", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Lifecycle { Description = "Yeni", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Lifecycle { Description = "Defolu", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Lifecycle { Description = "Az Kullanılmış", CreatedDate = new DateTime(2022, 04, 16) },
                                                new Lifecycle { Description = "Çok Kullanılmış", CreatedDate = new DateTime(2022, 04, 16)}
                                        });
                                        context.SaveChanges();
                                }

                                #endregion

                                #region Products

                                if (!context.Products.Any())
                                {
                                        context.Products.AddRange(new List<Product>()
                                        {
                                                new Product { CategoryId = 1, AppUserId = 1, LifecycleId= 1, SizeId = 1, BrandId = 1, ColorId = 1, IsOfferable = true, IsSold = false, ImageUrl ="item1.jpg", Name = "Dik Yaka Erkek Deri Mont", AmountOfStock = 400,  Price = 2699.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 1, AppUserId = 1, LifecycleId= 2, SizeId = 1, BrandId = 2, ColorId = 2, IsOfferable = true, IsSold = false, ImageUrl ="item2.jpg", Name = "Biker Yaka Erkek Deri Mont", AmountOfStock = 400, Price = 2199.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 1, AppUserId = 1, LifecycleId= 3, SizeId = 2, BrandId = 3, ColorId = 3, IsOfferable = true, IsSold = true, ImageUrl ="item3.jpg", Name = "Gömlek Yaka Erkek Şişme Mont", AmountOfStock = 400, Price = 599.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 2, AppUserId = 1, LifecycleId= 4, SizeId = 2, BrandId = 4, ColorId = 4, IsOfferable = true, IsSold = false, ImageUrl ="item4.jpg", Name = "Kuşak Detaylı Uzun Kollu Kadın Triko Hırka", AmountOfStock = 400, Price = 499.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 2, AppUserId = 2, LifecycleId= 5, SizeId = 3, BrandId = 5, ColorId = 5, IsOfferable = true, IsSold = false, ImageUrl ="item5.jpg", Name = "Kapüşonlu Kendinden Desenli Kadın Süveter", AmountOfStock = 400, Price = 189.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 3, AppUserId = 2, LifecycleId= 1, SizeId = 3, BrandId = 6, ColorId = 6, IsOfferable = true, IsSold = false, ImageUrl ="item6.jpg", Name = "Balıkçı Yaka Uzun Kollu Erkek Triko Kazak", AmountOfStock = 400, Price = 79.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 3, AppUserId = 2, LifecycleId= 2, SizeId = 4, BrandId = 7, ColorId = 7, IsOfferable = true, IsSold = false, ImageUrl ="item7.jpg", Name = "Bisiklet Yaka Uzun Kollu Çizgili Erkek Triko Kazak", AmountOfStock = 400, Price = 149.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 4, AppUserId = 2, LifecycleId= 3, SizeId = 4, BrandId = 8, ColorId = 8, IsOfferable = false, IsSold = false, ImageUrl ="item8.jpg", Name = "Kalp Yaka Kolsız Kadın Blız", AmountOfStock = 400, Price = 449.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 4, AppUserId = 3, LifecycleId= 4, SizeId = 5, BrandId = 9, ColorId = 9, IsOfferable = true, IsSold = true, ImageUrl ="item1.jpg", Name = "Renk Bloklu Uzun Kollu Kadın Bluz", AmountOfStock = 400, Price = 599.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 5, AppUserId = 3, LifecycleId= 5, SizeId = 5, BrandId = 1, ColorId = 10, IsOfferable = true, IsSold = false, ImageUrl ="item2.jpg", Name = "Uzun Kollu Poplin Erkek Gömlek", AmountOfStock = 400, Price = 349.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 5, AppUserId = 3, LifecycleId= 1, SizeId = 6, BrandId = 2, ColorId = 11, IsOfferable = true, IsSold = false, ImageUrl ="item3.jpg", Name = "Uzun Kollu Keten Erkek Gömlek", AmountOfStock = 400, Price = 349.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 6, AppUserId = 3, LifecycleId= 2, SizeId = 6, BrandId = 3, ColorId = 12, IsOfferable = false, IsSold = false, ImageUrl ="item4.jpg", Name = "Tül Detaylı Kadın Lima Tişört", AmountOfStock = 400, Price = 199.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 6, AppUserId = 4, LifecycleId= 3, SizeId = 7, BrandId = 4, ColorId = 13, IsOfferable = true, IsSold = false, ImageUrl ="item5.jpg", Name = "Bisiklet Yaka Baskılı Kadın Tişört", AmountOfStock = 400, Price = 199.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 7, AppUserId = 5, LifecycleId= 4, SizeId = 7, BrandId = 5, ColorId = 14, IsOfferable = true, IsSold = false, ImageUrl ="item6.jpg", Name = "Baskılı Erkek Sweatshirt", AmountOfStock = 400, Price = 299.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 7, AppUserId = 6, LifecycleId= 5, SizeId = 1, BrandId = 6, ColorId = 11, IsOfferable = true, IsSold = true, ImageUrl ="item7.jpg", Name = "Outdoor Kapüşonlu Erkek Sweatshirt", AmountOfStock = 400, Price = 269.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 8, AppUserId = 7, LifecycleId= 1, SizeId = 1, BrandId = 7, ColorId = 12, IsOfferable = true, IsSold = false, ImageUrl ="item8.jpg", Name = "Tül Kemer Detaylı Kadın Jean", AmountOfStock = 400, Price = 349.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                                new Product { CategoryId = 8, AppUserId = 8, LifecycleId= 2, SizeId = 2, BrandId = 8, ColorId = 10, IsOfferable = true, IsSold = true, ImageUrl ="item1.jpg", Name = "Cepli Kadın Flare Jean", AmountOfStock = 400, Price = 269.99m, CreatedDate = new DateTime(2022, 04, 16) },
                                        });
                                        context.SaveChanges();
                                }

                                #endregion

                                #region ProductDetail

                                if (!context.ProductDetails.Any())
                                {
                                        context.ProductDetails.AddRange(new List<ProductDetail>()
                                        {
                                                new ProductDetail { ProductId = 1, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Deri", Pattern ="Düz", ShortDescription = "İki yandan cepli, Fermuar kapamalı"},
                                                new ProductDetail { ProductId = 2, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Deri", Pattern ="Düz", ShortDescription = "Fermuarlı cepli, Fermuar kapamalı"},
                                                new ProductDetail { ProductId = 3, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Deri", Pattern ="Düz", ShortDescription = "Kapaklı çift göğüs cepli, Fermuar kapamalı"},
                                                new ProductDetail { ProductId = 4, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Triko", Pattern ="Düz", ShortDescription = "%100 yünlü triko kumaştan", LongDescription ="Özel yıkama uygulaması sonrası vücuda batmayan yapı ile farklı bir yün hissiyatı yaşatır."},
                                                new ProductDetail { ProductId = 5, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Polyester", Pattern ="Kendinden Desenli", ShortDescription = "Bağcıklı sabit kapüşon, Önde kanguru cepli"},
                                                new ProductDetail { ProductId = 6, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Akrilik", Pattern ="Düz", ShortDescription = "Akrilik karışımlı kumaş"},
                                                new ProductDetail { ProductId = 7, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Pamuk", Pattern ="Çizgili", ShortDescription = "%100 pamuklu kumaştan"},
                                                new ProductDetail { ProductId = 8, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Polyester", Pattern ="Düz", ShortDescription = "Işıltılı, coşkulu, rengarenk"},
                                                new ProductDetail { ProductId = 9, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Polyester", Pattern ="Renk Bloğu", ShortDescription = "QOOQ STORE"},                               
                                                new ProductDetail { ProductId = 10, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Poplin", Pattern ="Düz", ShortDescription = "Düğmeli yaka, %100 keten kumaştan"},
                                                new ProductDetail { ProductId = 11, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Keten", Pattern ="Düz", ShortDescription = "Apolet detaylı, Düğmeli yaka"},
                                                new ProductDetail { ProductId = 12, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Polyester", Pattern ="Çiçekli", ShortDescription="Havalı, trend, sıra dışı...", LongDescription = "tül tasarımıyla tüm bakışları üzerine taşıyor, farkını konuşturuyor"},
                                                new ProductDetail { ProductId = 13, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Polyester", Pattern ="Desenli", ShortDescription = "Önde tek göğüs cepli"},
                                                new ProductDetail { ProductId = 14, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Pamuk", Pattern ="Baskılı", ShortDescription = "Fermuar detaylı, Bilekleri ve alt kısmı ribanalı"},
                                                new ProductDetail { ProductId = 15, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Pamuk/Polyester", Pattern ="Düz", ShortDescription = "Kanguru cepli, Bilekleri ve alt kısmı ribanalı"},
                                                new ProductDetail { ProductId = 16, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Pamuk/Polyester", Pattern ="Düz", ShortDescription = "Havalı, trend, sıra dışı…", LongDescription ="Tül detaylı kemer ürüne dahildir."},
                                                new ProductDetail { ProductId = 17, CreatedDate = new DateTime(2022, 04, 16), Fabric= "Denim", Pattern ="Düz", ShortDescription = "İspanyol Paça, Flare, Yüksek Pamuk"},
                                        });
                                        context.SaveChanges();
                                }
                                #endregion

                                #region Offer

                                if (!context.Offers.Any())
                                {
                                        context.Offers.AddRange(new List<Offer>()
                                        {
                                                new Offer { OfferPrice = 50, CreatedDate = new DateTime(2022, 04, 16), ProductId = 1, AppUserId = 1 },
                                                new Offer { OfferPrice = 50, CreatedDate = new DateTime(2022, 04, 16), ProductId = 1, AppUserId = 2 },
                                                new Offer { OfferPrice = 50, CreatedDate = new DateTime(2022, 04, 16), ProductId = 1, AppUserId = 3 },
                                                new Offer { OfferPrice = 70, CreatedDate = new DateTime(2022, 04, 16), ProductId = 2, AppUserId = 1},
                                                new Offer { OfferPrice = 70, CreatedDate = new DateTime(2022, 04, 16), ProductId = 3, AppUserId = 1},
                                                new Offer { OfferPrice = 90, CreatedDate = new DateTime(2022, 04, 16), ProductId = 4, AppUserId = 1},
                                                new Offer { OfferPrice = 90, CreatedDate = new DateTime(2022, 04, 16), ProductId = 5, AppUserId = 1},
                                                new Offer { OfferPrice = 50, CreatedDate = new DateTime(2022, 04, 16), ProductId = 6, AppUserId = 1},
                                        });
                                        context.SaveChanges();
                                }

                                #endregion

                        }
                }
        }
}
