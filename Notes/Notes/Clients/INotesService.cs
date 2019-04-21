using Notes.Clients.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Clients
{
    /// <summary>
    /// Api для работы с заметками
    /// </summary>
    public interface INotesService
    {
        /// <summary>
        /// Получение заметок
        /// </summary>
        /// <returns>Выходная модель заметки</returns>
        [Get("/Note/GetNotes")]
        Task<List<NoteModel>> GetNotes();

        /// <summary>
        /// Создание заметки, используя телефон
        /// </summary>
        /// <param name="model">Входная модель заметки</param>
        [Post("/Note/CreateWithMobile")]
        Task<NoteModel> CreateWithMobile(NoteInfo model);
    }
}
