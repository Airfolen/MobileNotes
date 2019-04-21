using Newtonsoft.Json;
using Notes.Clients;
using Notes.Clients.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace Notes
{
    class FriendsService
    {
        private readonly HttpClient httpClient;

        private readonly INotesService _notesService;

        public FriendsService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://10.0.2.2:5000")
            };

            _notesService = RestService.For<INotesService>(httpClient);
        }

        // получаем всех друзей
        public async Task<IEnumerable<NoteModel>> Get()
        {
            var notes = await _notesService.GetNotes();
            return notes;
//            return new List<Friend>()
//            {
//                new Friend(){Email = "fdsfds", Name = "sdfdsf", Phone = "sfdsfsdf"},
//                new Friend(){Email = "fdsfds", Name = "sdfdsf", Phone = "sfdsfsdf"},
//                new Friend(){Email = "fdsfds", Name = "sdfdsf", Phone = "sfdsfsdf"},
//                new Friend(){Email = "fdsfds", Name = "sdfdsf", Phone = "sfdsfsdf"},
//                new Friend(){Email = "fdsfds", Name = "sdfdsf", Phone = "sfdsfsdf"},
//                new Friend(){Email = "fdsfds", Name = "sdfdsf", Phone = "sfdsfsdf"}
//            };
        }

        // добавляем одного друга
        public async Task<NoteModel> Add(NoteModel note)
        {
            var dtoModel = new NoteInfo
            {
                Title = note.Title,
                Content = note.Content,
                Category = Clients.Enums.NoteCategory.Work
            };

            var result = await _notesService.CreateWithMobile(dtoModel);

            return result;
        }
        // обновляем друга
        public async Task<NoteModel> Update(NoteModel friend)
        {
           

            return friend;
        }
        // удаляем друга
        public async Task<NoteModel> Delete(Guid noteGuid)
        {
            
            return new NoteModel();
        }
    }
}
