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
        }

        // добавляем одного друга
        public async Task<NoteModel> Add(NoteModel note)
        {
            var dtoModel = new NoteInfo
            {
                Title = note.Title,
                Content = note.Content,
                Category = Clients.Enums.NoteCategory.General
            };

            var result = await _notesService.CreateWithMobile(dtoModel);

            return result;
        }
        // обновляем друга
        public async Task<NoteModel> Update(NoteModel note)
        {
            var dtoModel = new NoteInfo
            {
                Title = note.Title,
                Content = note.Content,
                Category = Clients.Enums.NoteCategory.General
            };

            var result = await _notesService.UpdateWithMobile(note.NoteGuid, dtoModel);

            return note;
        }
        // удаляем друга
        public async Task<NoteModel> Delete(Guid noteGuid)
        {
            var result = await _notesService.RemoveWithMobile(noteGuid);

            return result;
        }
    }
}
