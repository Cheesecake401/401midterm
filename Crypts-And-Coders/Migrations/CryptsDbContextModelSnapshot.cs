﻿// <auto-generated />
using System;
using Crypts_And_Coders.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crypts_And_Coders.Migrations
{
    [DbContext(typeof(CryptsDbContext))]
    partial class CryptsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crypts_And_Coders.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int?>("CurrentLocationId")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Species")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentLocationId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = 3,
                            LocationId = 1,
                            Name = "Galdifor",
                            Species = 1,
                            WeaponId = 1
                        },
                        new
                        {
                            Id = 2,
                            Class = 0,
                            LocationId = 1,
                            Name = "Dragorn",
                            Species = 3,
                            WeaponId = 1
                        },
                        new
                        {
                            Id = 3,
                            Class = 4,
                            LocationId = 1,
                            Name = "Glen",
                            Species = 0,
                            WeaponId = 1
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.CharacterInventory", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("CharacterInventory");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            ItemId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            ItemId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            ItemId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            ItemId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            ItemId = 1
                        },
                        new
                        {
                            CharacterId = 3,
                            ItemId = 3
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.CharacterStat", b =>
                {
                    b.Property<int>("StatId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("StatId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("StatSheet");

                    b.HasData(
                        new
                        {
                            StatId = 1,
                            CharacterId = 1,
                            Level = 0
                        },
                        new
                        {
                            StatId = 2,
                            CharacterId = 1,
                            Level = 0
                        },
                        new
                        {
                            StatId = 2,
                            CharacterId = 2,
                            Level = 0
                        },
                        new
                        {
                            StatId = 3,
                            CharacterId = 2,
                            Level = 0
                        },
                        new
                        {
                            StatId = 1,
                            CharacterId = 3,
                            Level = 0
                        },
                        new
                        {
                            StatId = 3,
                            CharacterId = 3,
                            Level = 0
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.DTOs.LocationDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocationDTO");
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.Enemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Species")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enemy");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abilities = "Slash",
                            Species = 6,
                            Type = "Warrior"
                        },
                        new
                        {
                            Id = 2,
                            Abilities = "Smash",
                            Species = 7,
                            Type = "Beast"
                        },
                        new
                        {
                            Id = 3,
                            Abilities = "Firebreath",
                            Species = 8,
                            Type = "Mythical"
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.EnemyInLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationDTOId")
                        .HasColumnType("int");

                    b.HasKey("LocationId", "EnemyId");

                    b.HasIndex("EnemyId");

                    b.HasIndex("LocationDTOId");

                    b.ToTable("EnemyInLocation");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            EnemyId = 1
                        },
                        new
                        {
                            LocationId = 1,
                            EnemyId = 2
                        },
                        new
                        {
                            LocationId = 2,
                            EnemyId = 3
                        },
                        new
                        {
                            LocationId = 2,
                            EnemyId = 2
                        },
                        new
                        {
                            LocationId = 3,
                            EnemyId = 1
                        },
                        new
                        {
                            LocationId = 3,
                            EnemyId = 3
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.EnemyLoot", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("EnemyLoot");
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Health Potion",
                            Value = 25
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cup",
                            Value = 5
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dungeon Key",
                            Value = 100
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Occupied by the forces of evil, Faldor consists of open, hilly plains that separate it's eastern border with towering mountains.",
                            Name = "Faldor"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Plagued by the great war, Murkden remains uninhibited from all intelligent life forms, although various beasts still dwell in the deep marshes.",
                            Name = "Murkden"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lyderton is full of simpletons who prefer to keep war and conflict outside of their borders. It is rich farmland with dense amounts of beautiful wildlife.",
                            Name = "Lyderton"
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stat");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Strength"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cunning"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Constitution"
                        });
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseDamage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Weapon");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseDamage = 15,
                            Name = "Claymore",
                            Type = "Close Range"
                        },
                        new
                        {
                            Id = 2,
                            BaseDamage = 18,
                            Name = "Wizard Staff",
                            Type = "Magical"
                        },
                        new
                        {
                            Id = 3,
                            BaseDamage = 10,
                            Name = "Longbow",
                            Type = "Long Range"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.Character", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.DTOs.LocationDTO", "CurrentLocation")
                        .WithMany()
                        .HasForeignKey("CurrentLocationId");

                    b.HasOne("Crypts_And_Coders.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.CharacterInventory", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.Character", "Character")
                        .WithMany("Inventory")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypts_And_Coders.Models.Item", "Item")
                        .WithMany("CharacterInventory")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.CharacterStat", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.Character", "Character")
                        .WithMany("StatSheet")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypts_And_Coders.Models.Stat", "Stat")
                        .WithMany("StatSheet")
                        .HasForeignKey("StatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.EnemyInLocation", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.Enemy", "Enemy")
                        .WithMany("EnemyInLocation")
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypts_And_Coders.Models.DTOs.LocationDTO", null)
                        .WithMany("Enemies")
                        .HasForeignKey("LocationDTOId");

                    b.HasOne("Crypts_And_Coders.Models.Location", "Location")
                        .WithMany("Enemies")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Crypts_And_Coders.Models.EnemyLoot", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.Character", "Character")
                        .WithMany("EnemyLoot")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypts_And_Coders.Models.Item", "Item")
                        .WithMany("EnemyLoot")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypts_And_Coders.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Crypts_And_Coders.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
