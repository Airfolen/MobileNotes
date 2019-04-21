using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Notes.Clients.Models;
using Xamarin.Forms;

namespace Notes
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false; // была ли начальная инициализация
        NoteModel selectedFriend; // выбранный друг
        private bool isBusy; // идет ли загрузка с сервера

        public ObservableCollection<NoteModel> Friends { get; set; }
        FriendsService friendsService = new FriendsService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateFriendCommand { protected set; get; }
        public ICommand DeleteFriendCommand { protected set; get; }
        public ICommand SaveFriendCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }

        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ApplicationViewModel()
        {
            Friends = new ObservableCollection<NoteModel>();
            IsBusy = false;
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }

        public NoteModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value)
                {
                    var tempFriend = new NoteModel()
                    {
                        NoteGuid = value.NoteGuid,
                        FileGuid = value.FileGuid,
                        Content = value.Content,
                        CreationDate = value.CreationDate,
                        Title = value.Title
                    };

                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend, this));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateFriend()
        {
            await Navigation.PushAsync(new FriendPage(new NoteModel(), this));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetFriends()
        {
            if (initialized == true) return;
            IsBusy = true;
            var friends = await friendsService.Get();

            // очищаем список
            //Friends.Clear();
            while (Friends.Any())
                Friends.RemoveAt(Friends.Count - 1);

            // добавляем загруженные данные
            foreach (var f in friends)
                Friends.Add(f);
            IsBusy = false;
            initialized = true;
        }

        private async void SaveFriend(object friendObject)
        {
            var friend = friendObject as NoteModel;
            if (friend != null)
            {
                IsBusy = true;
                // редактирование
                if (Friends.Any(a => a.NoteGuid == friend.NoteGuid))
                {
                    var updatedFriend = await friendsService.Update(friend);
                    // заменяем объект в списке на новый
                    if (updatedFriend != null)
                    {
                        var pos = Friends.IndexOf(updatedFriend);
                        Friends.RemoveAt(pos);
                        Friends.Insert(pos, updatedFriend);
                    }
                }
                // добавление
                else
                {
                    var addedFriend = await friendsService.Add(friend);
                    if (addedFriend != null)
                        Friends.Add(addedFriend);
                }

                IsBusy = false;
            }

            Back();
        }

        private async void DeleteFriend(object friendObject)
        {
            var friend = friendObject as NoteModel;
            if (friend != null)
            {
                IsBusy = true;
                var deletedFriend = await friendsService.Delete(friend.NoteGuid);
                if (deletedFriend != null)
                {
                    Friends.Remove(deletedFriend);
                }

                IsBusy = false;
            }

            Back();
        }
    }
}