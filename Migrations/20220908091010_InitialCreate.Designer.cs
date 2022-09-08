﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicStore.Data;

#nullable disable

namespace MusicStore.Migrations
{
    [DbContext(typeof(MusicStoreContext))]
    [Migration("20220908091010_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicStore.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"), 1L, 1);

                    b.Property<string>("AlbumArtUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("MusicStore.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Artist");
                });

            modelBuilder.Entity("MusicStore.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MusicStore.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("MusicStore.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongId"), 1L, 1);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicStore.Models.SongPlaylist", b =>
                {
                    b.Property<int>("SongPlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SongPlaylistId"), 1L, 1);

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.HasKey("SongPlaylistId");

                    b.HasIndex("PlaylistId");

                    b.HasIndex("SongId");

                    b.ToTable("SongPlaylists");
                });

            modelBuilder.Entity("MusicStore.Models.Group", b =>
                {
                    b.HasBaseType("MusicStore.Models.Artist");

                    b.Property<DateTime?>("DateOfEstablishment")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Group");
                });

            modelBuilder.Entity("MusicStore.Models.SoloArtist", b =>
                {
                    b.HasBaseType("MusicStore.Models.Artist");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("SoloArtist");
                });

            modelBuilder.Entity("MusicStore.Models.Album", b =>
                {
                    b.HasOne("MusicStore.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicStore.Models.Song", b =>
                {
                    b.HasOne("MusicStore.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicStore.Models.SongPlaylist", b =>
                {
                    b.HasOne("MusicStore.Models.Playlist", "Playlist")
                        .WithMany("SongPlaylists")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore.Models.Song", "Song")
                        .WithMany("SongPlaylists")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Song");
                });

            modelBuilder.Entity("MusicStore.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicStore.Models.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicStore.Models.Genre", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicStore.Models.Playlist", b =>
                {
                    b.Navigation("SongPlaylists");
                });

            modelBuilder.Entity("MusicStore.Models.Song", b =>
                {
                    b.Navigation("SongPlaylists");
                });
#pragma warning restore 612, 618
        }
    }
}
