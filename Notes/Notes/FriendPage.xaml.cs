using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Clients.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendPage : ContentPage
	{
        public NoteModel Model { get; private set; }
        public ApplicationViewModel ViewModel { get; private set; }
        public FriendPage(NoteModel model, ApplicationViewModel viewModel)
        {
            InitializeComponent();
            Model = model;
            ViewModel = viewModel;
            this.BindingContext = this;
        }
    }
}