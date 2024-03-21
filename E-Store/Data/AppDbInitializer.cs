using E_Store.Data.Static;
using E_Store.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //CPU
                if (!context.CPUs.Any())
                {
                    context.CPUs.AddRange(new List<CPU>()
                    {
                        new CPU()
                        {
                            Name = "Snapdragon 8 Gen 2",
                            Description = "Octa-core 4 nm"
                        },
                        new CPU()
                        {
                            Name = "Mediatek Dimensity 8200",
                            Description = "Octa-core 4 nm"
                        },
                        new CPU()
                        {
                            Name = "Samsung Exynos 1380 5G",
                            Description = "Octa-core 5 nm"
                        },
                        new CPU()
                        {
                            Name = "Snapdragon 8+ Gen 1 4G",
                            Description = "Octa-core 4 nm"
                        },
                        new CPU()
                        {
                            Name = "Snapdragon 695 5G",
                            Description = "Octa-core 6 nm"
                        },
						 new CPU()
						{
							Name = "Snapdragon 8 Gen 3 5G",
							Description = "Octa-core 4 nm"
						},
					});
                    context.SaveChanges();
                }
               
                //Memories
                if (!context.Memories.Any())
                {
                    context.Memories.AddRange(new List<Memory>()
                    {
                        new Memory()
                        {
                            Name = "12/1TB",
                            Description = "UFS 3.2",

                        },
                        new Memory()
                        {
                            Name = "8/256GB",
                            Description = "UFS 3.1",
                        },
                        new Memory()
                        {
                            Name = "8/128GB",
                            Description = "UFS 3.0",
                        },
                        new Memory()
                        {
                            Name = "12/512GB",
                            Description = "UFS 3.1",
                        },
                        new Memory()
                        {
                            Name = "12/256GB",
                            Description = "UFS 3.0",
                        }
                    });
                    context.SaveChanges();
                }
                //Phones
                if (!context.Phones.Any())
                {
                    context.Phones.AddRange(new List<Phone>()
                    {
                        new Phone()
                        {
                            Name = "Sony Xperia 1 V",
                            Description = "Released 2023, 187g, 8.3mm thickness, Android 12, up to Android 13",
                            Price = 1270,
                            ImageURL = "https://fdn2.gsmarena.com/vv/bigpic/sony-xperia-1-v.jpg",
                            CPUId = 1,
                            MemoryId = 1,
                            PhoneColour = PhoneColour.Black
                        },
                        new Phone()
                        {
                            Name = "Xiaomi Redmi Note 12T Pro",
                            Description = "Released 2023, 200g, 8.9mm thickness, Android 13, MIUI 14",
                            Price = 750,
                            ImageURL = "https://fdn2.gsmarena.com/vv/bigpic/xiaomi-redmi-note-12t-pro.jpg",
                            CPUId = 2,
                            MemoryId = 2,
                            PhoneColour = PhoneColour.Black
                        },
                        new Phone()
                        {
                            Name = "Samsung Galaxy F54",
                            Description = "Released 2023, 199g, 8.4mm thickness, Android 13, One UI 5.1",
                            Price = 870,
                            ImageURL = "https://fdn2.gsmarena.com/vv/bigpic/samsung-galaxy-f54-5g.jpg",
                            CPUId = 3,
                            MemoryId = 3,
                            PhoneColour = PhoneColour.White
                        },
                        new Phone()
                        {
                            Name = "Huawei P60",
                            Description = "Released 2023, 197g, 8.3mm thickness, HarmonyOS 3.1, EMUI 13.1",
                            Price = 950,
                            ImageURL = "https://fdn2.gsmarena.com/vv/bigpic/huawei-p60.jpg",
                            CPUId = 4,
                            MemoryId = 4,
                            PhoneColour = PhoneColour.Green
                        },
                        new Phone()
                        {
                            Name = "OnePlus Nord N30",
                            Description = "Released 2023, 195g, 8.3mm thickness, Android 13, OxygenOS 13.1",
                            Price = 830,
                            ImageURL = "https://fdn2.gsmarena.com/vv/bigpic/oneplus-nord-n30-5g.jpg",
                            CPUId = 5,
                            MemoryId = 5,
                            PhoneColour = PhoneColour.Green
                        },
						new Phone()
						{
							Name = "Nubia Z60 Ultra",
							Description = "Released 2023, December 29, 246g, 8.8mm thickness, Android 14, MyOS 14",
							Price = 1623,
							ImageURL = "https://reebelo.co.nz/_next/image?url=https%3A%2F%2Fcdn.shopify.com%2Fs%2Ffiles%2F1%2F0548%2F9495%2F2604%2Ffiles%2FBLA-image-0_dbb33116-aab5-41b8-bfd0-0b9ac457cd1b.jpg%3Fv%3D1710282101&w=375&q=75",
							CPUId = 6,
							MemoryId = 4,
							PhoneColour = PhoneColour.Black
						},
						new Phone()
						{
							Name = "Vivo X100 Pro",
							Description = "Released 2023, November 21 221g or 225g, 8.9mm thickness Android 14, Funtouch 14, OriginOS 4",
							Price = 1850,
							ImageURL = "https://m.media-amazon.com/images/I/61xGAkBG8CL._AC_SL1100_.jpg",
							CPUId = 6,
							MemoryId = 4,
							PhoneColour = PhoneColour.Blue
						},
						new Phone()
						{
							Name = "Xiaomi 14 Ultra",
							Description = "Released 2024, February 22 219.8 / 224.4 / 229.5g, 9.2mm thickness Android 14, HyperOS",
							Price = 2050,
							ImageURL = "https://img.myipadbox.com/sec/product_l/EDA006200103C.jpg",
							CPUId = 6,
							MemoryId = 1,
							PhoneColour = PhoneColour.Blue
						},
						new Phone()
						{
							Name = "Samsung Galaxy S24 Ultra",
							Description = "Released 2024, January 24 232g or 233g, 8.6mm thickness Android 14, One UI 6.1",
							Price = 2030,
							ImageURL = "https://fdn2.gsmarena.com/vv/pics/samsung/samsung-galaxy-s24-ultra-5g-sm-s928-0.jpg",
							CPUId = 6,
							MemoryId = 1,
							PhoneColour = PhoneColour.Gold
						},
						new Phone()
						{
							Name = "Realme GT5 Pro",
							Description = "Released 2023, December 14 218g / 224g, 9.2mm thickness Android 14, Realme UI 5.0",
							Price = 1980,
							ImageURL = "https://fdn2.gsmarena.com/vv/pics/realme/realme-gt5-pro-1.jpg",
							CPUId = 6,
							MemoryId = 1,
							PhoneColour = PhoneColour.Orange
						}

					});
                    context.SaveChanges();
                }
                
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

               // Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminsUserName = "admin";
                string adminsEmail = "admin@estore.com";

                var adminUser = await userManager.FindByNameAsync(adminsUserName);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Application Admin",
                        UserName = "Admin",
                        Email = adminsEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin12345*");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string usersUserName = "user";
                string usersEmail = "user@estore.com";

                //var appUser = await userManager.FindByNameAsync(usersUserName);
                //if (appUser == null)
                //{
                //    var newAppUser = new ApplicationUser()
                //    {
                //        FullName = "Application User",
                //        UserName = "User",
                //        Email = usersEmail,
                //        EmailConfirmed = true
                //    };
                //    await userManager.CreateAsync(newAppUser, "User12345*");
                //    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                //}
            }
        }
    }
}
