using System.Windows;

namespace INF_0996_Trabalho
{
    /// <summary>
    /// Interaction logic for AppMediaPlayer.xaml
    /// </summary>
    public partial class AppMediaPlayer : Window
    {
        public AppMediaPlayer()
        {
            InitializeComponent();
			DataContext = new ViewModel.MediaListViewModel();
        }
    }
}
