using System;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using INF_0996_Trabalho.ViewModel;

namespace INF_0996_Trabalho
{
    /// <summary>
    /// Interaction logic for AppMediaPlayer.xaml
    /// </summary>
    public partial class AppMediaPlayer : Window
    {
        public AppMediaPlayer()
        {
            this.InitializeComponent();

            WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, (r,m) =>
            {
                var fw = new PlayMediaWindow(m.Value);

                fw.ShowDialog();
            });

			DataContext = new MediaListViewModel();
        }
    }
}
