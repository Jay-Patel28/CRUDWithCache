﻿// <auto-generated />
using System;
using CRUDWithCache;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUDWithCache.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20220913105021_init4")]
    partial class init4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CRUDWithCache.Entities.AuthorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CRUDWithCache.Entities.AuthorOfBookEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RelatedAuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RelatedBookId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RelatedAuthorId");

                    b.HasIndex("RelatedBookId");

                    b.ToTable("AuthorsOfBooks");
                });

            modelBuilder.Entity("CRUDWithCache.Entities.BookEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CRUDWithCache.Entities.AuthorOfBookEntity", b =>
                {
                    b.HasOne("CRUDWithCache.Entities.AuthorEntity", "RelatedAuthor")
                        .WithMany("RelatedAauthorOfBookEntities")
                        .HasForeignKey("RelatedAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRUDWithCache.Entities.BookEntity", "RelatedBook")
                        .WithMany("RelatedAauthorOfBookEntities")
                        .HasForeignKey("RelatedBookId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("RelatedAuthor");

                    b.Navigation("RelatedBook");
                });

            modelBuilder.Entity("CRUDWithCache.Entities.AuthorEntity", b =>
                {
                    b.Navigation("RelatedAauthorOfBookEntities");
                });

            modelBuilder.Entity("CRUDWithCache.Entities.BookEntity", b =>
                {
                    b.Navigation("RelatedAauthorOfBookEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
