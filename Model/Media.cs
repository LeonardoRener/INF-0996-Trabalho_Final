using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace INF_0996_Trabalho.Model
{
    public class Media : ObservableObject, ICloneable
    {
        private string _path;
        private Uri _source;
        private string? _name;
        private string? _author;
        private string? _genre;
        private string? _duration;

        public Media(string path)
        {
            this._path = path;
            this._source = new Uri(path);
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
        public string Name
        {
            get { return _name ?? string.Empty; }
            set { SetProperty(ref _name, value); }
        }
        public string Author
        {
            get { return _author ?? string.Empty; }
            set { SetProperty(ref _author, value); }
        }
        public string Genre
        {
            get { return _genre ?? string.Empty; }
            set { SetProperty(ref _genre, value); }
        }
        public string Duration
        {
            get { return _duration ?? string.Empty; }
            set { SetProperty(ref _duration, value); }
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}