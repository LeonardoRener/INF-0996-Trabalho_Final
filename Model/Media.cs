using System;
using TagLib;
using INF_0996_Trabalho.Constants;
using CommunityToolkit.Mvvm.ComponentModel;
using TagLib.Id3v2;
using System.IO;

namespace INF_0996_Trabalho.Model
{
    public class Media : ObservableObject, ICloneable
    {
        private string _path;
        private Uri _source;
        private string? _album;
        private string? _title;
        private string? _artist;
        private string? _participatingArtist;
        private string? _genre;
        private string? _size;
        private string? _duration;

        public Media(string path)
        {
            this._path = path;
            this._source = new Uri(path);
            LoadMediaInfo();
        }

        private void LoadMediaInfo()
        {
            TagLib.File? file = null;
            FileInfo? fileInfo = null;
            
            try
            {
                file = TagLib.File.Create(Path);
                fileInfo = new FileInfo(Path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error creating media, exception: {e}");
            }

            if (file != null)
            {
                this._album = file.Tag.Album;
                this._title = file.Tag.Title;
                this._artist = file.Tag.FirstAlbumArtist;
                this._participatingArtist = file.Tag.FirstPerformer;
                this._genre = file.Tag.FirstGenre;
                this._size = $"{fileInfo?.Length / 1000000} MB";
                this._duration = file.Properties.Duration.ToString(@"hh\:mm\:ss");
            }
        }

        public string Path
        {
            get { return _path; }
            set { SetProperty(ref _path, value); }
        }
        public Uri Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }
        public string Album
        {
            get { return String.IsNullOrEmpty(_album) ? MediaConstants.UNKNOWN_ALBUM : _album; }
            set { SetProperty(ref _album, value); }
        }
        public string Title
        {
            get { return String.IsNullOrEmpty(_title) ? MediaConstants.UNKNOWN_TITLE : _title; }
            set { SetProperty(ref _title, value); }
        }
        public string Artist
        {
            get { return String.IsNullOrEmpty(_artist) ? MediaConstants.UNKNOWN_ARTIST : _artist; }
            set { SetProperty(ref _artist, value); }
        }
        public string ParticipatingArtist
        {
            get { return _participatingArtist ?? String.Empty; }
            set { SetProperty(ref _participatingArtist, value); }
        }
        public string Genre
        {
            get { return String.IsNullOrEmpty(_genre) ? MediaConstants.UNKNOWN_GENRE : _genre; }
            set { SetProperty(ref _genre, value); }
        }
        public string Size
        {
            get { return _size ?? string.Empty; }
            set { SetProperty(ref _size, value); }
        }
        public string Duration
        {
            get { return _duration ?? TimeSpan.Zero.ToString(@"hh\:mm\:ss"); }
            set { SetProperty(ref _duration, value); }
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}