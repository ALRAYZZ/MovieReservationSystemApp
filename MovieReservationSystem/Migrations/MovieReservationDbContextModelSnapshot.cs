﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieReservationSystem.DataAccess;

#nullable disable

namespace MovieReservationSystem.Migrations
{
    [DbContext(typeof(MovieReservationDbContext))]
    partial class MovieReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieReservationSystem.Models.GenreModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Sci-Fi"
                        });
                });

            modelBuilder.Entity("MovieReservationSystem.Models.MovieModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("PosterImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "An action movie",
                            GenreId = 5,
                            PosterImage = "action.jpg",
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A comedy movie",
                            GenreId = 2,
                            PosterImage = "comedy.jpg",
                            Title = "The Hangover"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A drama movie",
                            GenreId = 3,
                            PosterImage = "drama.jpg",
                            Title = "The Notebook"
                        });
                });

            modelBuilder.Entity("MovieReservationSystem.Models.ReservationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ReservationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("ShowtimeId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

                    b.HasIndex("ShowtimeId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.SeatModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsReserved = false,
                            Number = 1
                        },
                        new
                        {
                            Id = 2,
                            IsReserved = false,
                            Number = 2
                        },
                        new
                        {
                            Id = 3,
                            IsReserved = false,
                            Number = 3
                        },
                        new
                        {
                            Id = 4,
                            IsReserved = false,
                            Number = 4
                        },
                        new
                        {
                            Id = 5,
                            IsReserved = false,
                            Number = 5
                        },
                        new
                        {
                            Id = 6,
                            IsReserved = false,
                            Number = 6
                        },
                        new
                        {
                            Id = 7,
                            IsReserved = false,
                            Number = 7
                        },
                        new
                        {
                            Id = 8,
                            IsReserved = false,
                            Number = 8
                        },
                        new
                        {
                            Id = 9,
                            IsReserved = false,
                            Number = 9
                        },
                        new
                        {
                            Id = 10,
                            IsReserved = false,
                            Number = 10
                        });
                });

            modelBuilder.Entity("MovieReservationSystem.Models.ShowtimeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Showtimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new DateTime(2025, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 1,
                            StartTime = new DateTime(2025, 2, 2, 10, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new DateTime(2025, 2, 2, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 2,
                            StartTime = new DateTime(2025, 2, 2, 14, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            EndTime = new DateTime(2025, 2, 2, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 3,
                            StartTime = new DateTime(2025, 2, 2, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MovieReservationSystem.Models.ShowtimeSeat", b =>
                {
                    b.Property<int>("ShowtimeId")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.HasKey("ShowtimeId", "SeatId");

                    b.HasIndex("SeatId");

                    b.ToTable("ShowtimeSeats");

                    b.HasData(
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 1,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 2,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 3,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 4,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 5,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 6,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 7,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 8,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 9,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 1,
                            SeatId = 10,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 1,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 2,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 3,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 4,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 5,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 6,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 7,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 8,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 9,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 2,
                            SeatId = 10,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 1,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 2,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 3,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 4,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 5,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 6,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 7,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 8,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 9,
                            IsReserved = false
                        },
                        new
                        {
                            ShowtimeId = 3,
                            SeatId = 10,
                            IsReserved = false
                        });
                });

            modelBuilder.Entity("MovieReservationSystem.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            Name = "Admin User",
                            Password = "$2a$11$GhtbVptXh0i6yWo4A2SB.uc7ZpmZHOD7sUgi4s0NbG8TMRatmuC8y",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@example.com",
                            Name = "Regular User",
                            Password = "$2a$11$4el6ajuECWSdJO8otbCOKuI57CzIVRyaOFz5H8e8cHAM5xcDE20Hu",
                            Role = "User",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("MovieReservationSystem.Models.MovieModel", b =>
                {
                    b.HasOne("MovieReservationSystem.Models.GenreModel", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.ReservationModel", b =>
                {
                    b.HasOne("MovieReservationSystem.Models.SeatModel", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieReservationSystem.Models.ShowtimeModel", "Showtime")
                        .WithMany("Reservations")
                        .HasForeignKey("ShowtimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieReservationSystem.Models.UserModel", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Seat");

                    b.Navigation("Showtime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.ShowtimeModel", b =>
                {
                    b.HasOne("MovieReservationSystem.Models.MovieModel", "Movie")
                        .WithMany("Showtimes")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.ShowtimeSeat", b =>
                {
                    b.HasOne("MovieReservationSystem.Models.SeatModel", "Seat")
                        .WithMany("ShowtimeSeats")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieReservationSystem.Models.ShowtimeModel", "Showtime")
                        .WithMany("ShowtimeSeats")
                        .HasForeignKey("ShowtimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Seat");

                    b.Navigation("Showtime");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.GenreModel", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.MovieModel", b =>
                {
                    b.Navigation("Showtimes");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.SeatModel", b =>
                {
                    b.Navigation("ShowtimeSeats");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.ShowtimeModel", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("ShowtimeSeats");
                });

            modelBuilder.Entity("MovieReservationSystem.Models.UserModel", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
