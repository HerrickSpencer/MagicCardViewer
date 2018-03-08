using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MagicCardViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this.ViewModel;
        }

        public MainViewModel ViewModel = new MainViewModel();

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var json = await GetJson();
            var answer = JsonConvert.DeserializeObject<CardSetCollection>(json);

            this.ViewModel.CardSets.AddRange(answer.CardSets);
        }

        public async Task<string> GetJson()
        {
            string filename = "AllSets.json";

            var json = "";
            StorageFile sFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Assets/" + filename));
            using (Stream fileStream = await sFile.OpenStreamForReadAsync())
            {
                TextReader tr = new StreamReader(fileStream);
                json = tr.ReadToEnd();
                //tr.Close();
                //fileStream.Close();
            }
            return json;
        }

    }
}
