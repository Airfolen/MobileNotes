using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //InitializeComponent();

            var stackLayout = new StackLayout();
            var listView = new ListView();

            for (int i = 1; i < 20; i++)
            {
                var frame = new Frame
                {
                    BorderColor = Color.DarkBlue
                };

                frame.Content = new Label
                {
                    Text = "Метка " + i,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                };

            }

            var list = new ListView();
            list.ItemTapped += TappedNotesList;

            var scrollView = new ScrollView();
            scrollView.Content = stackLayout;

            this.Content = scrollView;
        }

        private void TappedNotesList(object sender, ItemTappedEventArgs e)
        {
            Console.WriteLine($"sdfsdfsfsdfsdfsfs");
        }
    }
}
