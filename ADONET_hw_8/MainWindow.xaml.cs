using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicDb;
using Microsoft.EntityFrameworkCore;

namespace ADONET_hw_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Music2Context db = new();
        public MainWindow()
        {
            InitializeComponent();

            ICollection<Song> songs = db.Songs.ToArray();
            ICollection<Artist> artists = db.Artists.ToArray();

            foreach (Song song in songs)
            {
                cb_Song.Items.Add(song);
            }
            foreach (Artist artist in artists)
            {
                cb_Artist.Items.Add(artist);
            }


            ICollection<SongArtist> songArtists = db.SongArtists
                .Include(songArtist => songArtist.Artist)
                .Include(songArtist => songArtist.Song)
                .ToArray();

            DataContext = songArtists;
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            Song song = (Song)cb_Song.SelectedItem;
            Artist artist = (Artist)cb_Artist.SelectedItem;
            //db.Database.ExecuteSql($"update SongArtist set SongId = {song.Id}, ArtistId = {artist.Id}");
        }
    }
}