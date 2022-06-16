﻿using LCWaikikiFinal.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
        {
                public void Configure(EntityTypeBuilder<AppUser> builder)
                {
                        #region ForeingKey

                        // => kullanıcıyı sildiğimizde teklifler de silinsin.
                        builder.HasMany(x => x.Offers)
                                    .WithOne(x => x.AppUser)
                                    .HasForeignKey(x => x.AppUserId)
                                    .OnDelete(DeleteBehavior.Cascade);

                        // => kullanıcıyı sildiğimizde ürünler de silinsin.         ++++++
                        // => Kullanıcı programı terk etmeden, ayrılmadan ürünlerini silmesini isteyeceğiz.
                        builder.HasMany(x => x.Products)
                                    .WithOne(x => x.AppUser)
                                    .HasForeignKey(x => x.AppUserId)
                                    .OnDelete(DeleteBehavior.Restrict);

                        //.OnDelete(DeleteBehavior.Restrict);
                        //.OnDelete(DeleteBehavior.Cascade);

                        #endregion

                        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(15);
                        builder.Property(x => x.LastName).IsRequired().HasMaxLength(15);
                        builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
                        builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);

                        #region SeedData

                        var hasher = new PasswordHasher<AppUser>();

                        var user1 = new AppUser() { Id = 1, FirstName = "Enes", LastName = "Ozmus", Email = "enes@seeddata.com", EmailConfirmed = true, NormalizedEmail = " ENES@SEEDDATA.COM", UserName = "enesozmus", NormalizedUserName = "ENESOZMUS", PasswordHash = hasher.HashPassword(null, "Customer1*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user2 = new AppUser() { Id = 2, FirstName = "Umay", LastName = "Zengin", Email = "umay@seeddata.com", EmailConfirmed = true, NormalizedEmail = "UMAY@SEEDDATA.COM", UserName = "umayzengin", NormalizedUserName = "UMAYZENGIN", PasswordHash = hasher.HashPassword(null, "Customer2*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user3 = new AppUser() { Id = 3, FirstName = "Selim", LastName = "Karaca", Email = "selim@seeddata.com", EmailConfirmed = true, NormalizedEmail = "SELIM@SEEDDATA.COM", UserName = "selimkaraca", NormalizedUserName = "SELIMKARACA", PasswordHash = hasher.HashPassword(null, "Customer3*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user4 = new AppUser() { Id = 4, FirstName = "Emine", LastName = "Yıldırım", Email = "emine@seeddata.com", EmailConfirmed = true, NormalizedEmail = "EMINE@SEEDDATA.COM", UserName = "emineyıldırım", NormalizedUserName = "EMINEYILDIRIM", PasswordHash = hasher.HashPassword(null, "Customer4*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user5 = new AppUser() { Id = 5, FirstName = "İhsan", LastName = "Yenilmez", Email = "ihsan@seeddata.com", EmailConfirmed = true, NormalizedEmail = "IHSAN@SEEDDATA.COM", UserName = "ihsanyenilmez", NormalizedUserName = "IHSANYENILMEZ", PasswordHash = hasher.HashPassword(null, "Customer5*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user6 = new AppUser() { Id = 6, FirstName = "Berrin", LastName = "Miral", Email = "berrin@seeddata.com", EmailConfirmed = true, NormalizedEmail = "BERRIN@SEEDDATA.COM", UserName = "berrinmiral", NormalizedUserName = "BERRINMIRAL", PasswordHash = hasher.HashPassword(null, "Customer6*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user7 = new AppUser() { Id = 7, FirstName = "Salih", LastName = "Yurdakul", Email = "salih@seeddata.com", EmailConfirmed = true, NormalizedEmail = "SALIH@SEEDDATA.COM", UserName = "salihyurdakul", NormalizedUserName = "SALIHYURDAKUL", PasswordHash = hasher.HashPassword(null, "Customer7*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user8 = new AppUser() { Id = 8, FirstName = "Zafer", LastName = "Kırat", Email = "zafer@seeddata.com", EmailConfirmed = true, NormalizedEmail = "ZAFER@SEEDDATA.COM", UserName = "zaferkırat", NormalizedUserName = "ZAFERKIRAT", PasswordHash = hasher.HashPassword(null, "Customer8*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user9 = new AppUser() { Id = 9, FirstName = "Emre", LastName = "Demir", Email = "emre@seeddata.com", EmailConfirmed = true, NormalizedEmail = "EMRE@SEEDDATA.COM", UserName = "emredemir", NormalizedUserName = "EMREDEMIR", PasswordHash = hasher.HashPassword(null, "Customer9*123"), SecurityStamp = Guid.NewGuid().ToString("D") };
                        var user10 = new AppUser() { Id = 10, FirstName = "Hakan", LastName = "Filiz", Email = "hakan@seeddata.com", EmailConfirmed = true, NormalizedEmail = "HAKAN@SEEDDATA.COM", UserName = "hakanfiliz", NormalizedUserName = "HAKANFILIZ", PasswordHash = hasher.HashPassword(null, "Customer10*123"), SecurityStamp = Guid.NewGuid().ToString("D") };

                        builder.HasData(user1, user2, user3, user4, user5, user6, user7, user8, user9, user10);

                        #endregion
                }
        }
}
