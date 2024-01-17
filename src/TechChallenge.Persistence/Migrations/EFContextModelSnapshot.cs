﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechChallenge.Persistence;

#nullable disable

namespace TechChallenge.Persistence.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechChallenge.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte>("IdPriority")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("IdPriority");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPriority = (byte)4,
                            IsDeleted = false,
                            Name = "Indisponibilidade"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPriority = (byte)3,
                            IsDeleted = false,
                            Name = "Lentidão"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPriority = (byte)2,
                            IsDeleted = false,
                            Name = "Requisição"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPriority = (byte)1,
                            IsDeleted = false,
                            Name = "Dúvida"
                        });
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.Priority", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Sla")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("priorities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Baixa",
                            Sla = 48
                        },
                        new
                        {
                            Id = (byte)2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Média",
                            Sla = 24
                        },
                        new
                        {
                            Id = (byte)3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Alta",
                            Sla = 8
                        },
                        new
                        {
                            Id = (byte)4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Crítico",
                            Sla = 4
                        });
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.Role", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Administrador"
                        },
                        new
                        {
                            Id = (byte)2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Geral"
                        },
                        new
                        {
                            Id = (byte)3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Analista"
                        });
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CancellationReason")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<byte>("IdStatus")
                        .HasColumnType("tinyint");

                    b.Property<int?>("IdUserAssigned")
                        .HasColumnType("int");

                    b.Property<int>("IdUserRequester")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdUserAssigned");

                    b.HasIndex("IdUserRequester");

                    b.HasIndex("LastUpdatedBy");

                    b.ToTable("tickets", (string)null);
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.TicketStatus", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("ticketstatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Novo"
                        },
                        new
                        {
                            Id = (byte)2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Atribuído"
                        },
                        new
                        {
                            Id = (byte)3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Em andamento"
                        },
                        new
                        {
                            Id = (byte)4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Em espera"
                        },
                        new
                        {
                            Id = (byte)5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Concluído"
                        },
                        new
                        {
                            Id = (byte)6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            Name = "Cancelado"
                        });
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte>("IdRole")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("_passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PasswordHash");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 10000,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdRole = (byte)1,
                            IsDeleted = false,
                            Name = "Administrador",
                            Surname = "(built-in)",
                            _passwordHash = "MUKOsLOjfoh4YY1ZZLlp+CTyODjmgHhvPAp7PxFiCAWgXo1wibTbOrqht1UhnQi1"
                        },
                        new
                        {
                            Id = 10001,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdRole = (byte)2,
                            IsDeleted = false,
                            Name = "Ailton",
                            Surname = "(built-in)",
                            _passwordHash = "LFhLAgFT8oinF3iXkk63ccZhEllpvGtr/OHG28On+hqniGeX+AIYe8UhNnqztEIm"
                        },
                        new
                        {
                            Id = 10002,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdRole = (byte)3,
                            IsDeleted = false,
                            Name = "Bruno",
                            Surname = "(built-in)",
                            _passwordHash = "yobUq3aH9/R2x//xYdfaxqX2+FVBBLKzLipbFZILjsTo2sJ9cU/f2F4q6vvwIRzs"
                        },
                        new
                        {
                            Id = 10003,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdRole = (byte)2,
                            IsDeleted = false,
                            Name = "Cecília",
                            Surname = "(built-in)",
                            _passwordHash = "LSHTSlFvEBDMS0tjoK2po682H7rLfgL2sXssgm/djzWWouzW4lIydGie7PbmX/1P"
                        },
                        new
                        {
                            Id = 10004,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdRole = (byte)3,
                            IsDeleted = false,
                            Name = "Cesar",
                            Surname = "(built-in)",
                            _passwordHash = "q1EyG7yB1S6Cwm7DGuDo3P8ZraEvVHTdBbKHZ1QW3TMG5JWVCnb3EO3UslYiiGeL"
                        },
                        new
                        {
                            Id = 10005,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdRole = (byte)2,
                            IsDeleted = false,
                            Name = "Paulo",
                            Surname = "(built-in)",
                            _passwordHash = "XAro1VAlABuvkw5sxcSPEUdCeuTZRcM+9qLOumd79674Ro2V0bvvnlgb3zIkA7Yt"
                        });
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.Category", b =>
                {
                    b.HasOne("TechChallenge.Domain.Entities.Priority", null)
                        .WithMany()
                        .HasForeignKey("IdPriority")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("TechChallenge.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TechChallenge.Domain.Entities.TicketStatus", null)
                        .WithMany()
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TechChallenge.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("IdUserAssigned")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TechChallenge.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("IdUserRequester")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TechChallenge.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("LastUpdatedBy")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("TechChallenge.Domain.Entities.User", b =>
                {
                    b.HasOne("TechChallenge.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("TechChallenge.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("nvarchar(256)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.HasData(
                                new
                                {
                                    UserId = 10000,
                                    Value = "admin@techchallenge.app"
                                },
                                new
                                {
                                    UserId = 10001,
                                    Value = "ailton@techchallenge.app"
                                },
                                new
                                {
                                    UserId = 10002,
                                    Value = "bruno@techchallenge.app"
                                },
                                new
                                {
                                    UserId = 10003,
                                    Value = "cecilia@techchallenge.app"
                                },
                                new
                                {
                                    UserId = 10004,
                                    Value = "cesar@techchallenge.app"
                                },
                                new
                                {
                                    UserId = 10005,
                                    Value = "paulo@techchallenge.app"
                                });
                        });

                    b.Navigation("Email");
                });
#pragma warning restore 612, 618
        }
    }
}