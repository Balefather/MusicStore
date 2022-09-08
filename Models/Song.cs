namespace MusicStore.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string? Title { get; set; }
        public Album? Album { get; set; }
        public ICollection<SongPlaylist>? SongPlaylists { get; set; }
    }
}
