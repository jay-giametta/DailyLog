﻿// <auto-generated />
using AODMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AODMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210520210540_AddDailyLogTable")]
    partial class AddDailyLogTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AODMS.Models.DailyLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<string>("Location")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DailyLog");
                });
#pragma warning restore 612, 618
        }
    }
}
