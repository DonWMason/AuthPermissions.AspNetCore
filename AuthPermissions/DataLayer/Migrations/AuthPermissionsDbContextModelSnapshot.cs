﻿// <auto-generated />
using System;
using AuthPermissions.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthPermissions.DataLayer.Migrations
{
    [DbContext(typeof(AuthPermissionsDbContext))]
    partial class AuthPermissionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("authp")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.AuthUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("ROWVERSION");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("AuthUsers");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.RefreshToken", b =>
                {
                    b.Property<string>("TokenValue")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("AddedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("ROWVERSION");

                    b.Property<bool>("IsInvalid")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("TokenValue");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.RoleToPermissions", b =>
                {
                    b.Property<string>("RoleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("ROWVERSION");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackedPermissionsInRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleName");

                    b.ToTable("RoleToPermissions");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("ROWVERSION");

                    b.Property<bool>("IsHierarchical")
                        .HasColumnType("bit");

                    b.Property<string>("ParentDataKey")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParentTenantId")
                        .HasColumnType("int");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TenantId");

                    b.HasIndex("ParentDataKey");

                    b.HasIndex("ParentTenantId");

                    b.HasIndex("TenantName")
                        .IsUnique();

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.UserToRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("ROWVERSION");

                    b.HasKey("UserId", "RoleName");

                    b.HasIndex("RoleName");

                    b.ToTable("UserToRoles");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.AuthUser", b =>
                {
                    b.HasOne("AuthPermissions.DataLayer.Classes.Tenant", "UserTenant")
                        .WithMany()
                        .HasForeignKey("TenantId");

                    b.Navigation("UserTenant");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.Tenant", b =>
                {
                    b.HasOne("AuthPermissions.DataLayer.Classes.Tenant", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentTenantId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.UserToRole", b =>
                {
                    b.HasOne("AuthPermissions.DataLayer.Classes.RoleToPermissions", "Role")
                        .WithMany()
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthPermissions.DataLayer.Classes.AuthUser", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.AuthUser", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("AuthPermissions.DataLayer.Classes.Tenant", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
