﻿// <auto-generated />
using System;
using FlightManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210621100759_updateflightnumber")]
    partial class updateflightnumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("FlightManagement.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("FlightID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoOfPax")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PassengerName")
                        .HasColumnType("TEXT");

                    b.HasKey("BookingID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FlightManagement.Models.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeparterCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PassengerCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("FlightID");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            FlightID = 1,
                            ArrivalCity = "Tp.Hochiminh",
                            DeparterCity = "Danang",
                            EndTime = "183758",
                            FlightNumber = "VN117",
                            IsAvailable = true,
                            PassengerCapacity = 10,
                            StartTime = "170758"
                        },
                        new
                        {
                            FlightID = 2,
                            ArrivalCity = "Phuquoc",
                            DeparterCity = "Danang",
                            EndTime = "193758",
                            FlightNumber = "VN399",
                            IsAvailable = true,
                            PassengerCapacity = 5,
                            StartTime = "170758"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}