using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INF_0996_Trabalho.Model;
using Microsoft.Win32;

namespace INF_0996_Trabalho.ViewModel
{
    public class MediaListViewModel : ObservableObject
    {
        // Lista de mediaas.
        public ObservableCollection<Media> MediaList { get; set; }

        // Media selecionada.
        private Media? _selectedMedia;

        // Objeto que lida com o comando novo.
        public RelayCommand NewMedia { get; set; }

        // Objeto que lida com o comando deletar.
        public RelayCommand DeleteMedia { get; set; }

        // Objeto que lida com o comando play.
        public RelayCommand PlayMedia { get; set; }

        public Media? SelectedMedia
        {
            get { return _selectedMedia; }
            set { SetProperty(ref _selectedMedia, value);
                    DeleteMedia.NotifyCanExecuteChanged(); }
        }

        public MediaListViewModel()
        {
            this.NewMedia = new RelayCommand(NewCMD);
            this.PlayMedia = new RelayCommand(PlayCMD);
            this.DeleteMedia = new RelayCommand(DeleteCMD);
            this.MediaList = new ObservableCollection<Media>();
            LoadMediaList();
        }

        private void LoadMediaList()
        {
            var media1 = new Media(@"C:\Users\leona\Music\Imagine Dragons Enemy Audio");
            this.MediaList.Add(media1);

            if (this.MediaList.Count > 0)
                this.SelectedMedia = this.MediaList[0];
            else
                this.SelectedMedia = null;
        }

        #region Command Handling
        private void NewCMD()
        {
            Media media;
            OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.mp4)|*.mp3;*.mpg;*.mpeg;*.mp4|All files (*.*)|*.*";
			if(openFileDialog.ShowDialog() == true)
			{
                media = new Media(openFileDialog.FileName);
                this.MediaList.Add(media);
                this._selectedMedia = media;
			}
        }

        private void DeleteCMD()
        {
            if (this.SelectedMedia != null)
                this.MediaList.Remove(this.SelectedMedia);

            if (this.MediaList.Count > 0)
                this.SelectedMedia = this.MediaList[0];
            else
                this.SelectedMedia = null;
        }

        private void PlayCMD()
        {

        }
        #endregion
    }
}