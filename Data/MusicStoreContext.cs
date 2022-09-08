using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext (DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public DbSet<MusicStore.Models.Album> Album { get; set; } = default!;
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<SoloArtist> SoloArtists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPlaylist> SongPlaylists { get; set; }
    }
}
