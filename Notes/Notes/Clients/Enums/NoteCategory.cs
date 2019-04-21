using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Notes.Clients.Enums
{
    /// <summary>
    /// Категория заметки
    /// </summary>
    public enum NoteCategory
    {
        /// <summary>
        /// Общая
        /// </summary>
        [Description("Общая")]
        General = 0,

        /// <summary>
        /// Ежедневник
        /// </summary>
        [Description("Ежедневник")]
        Diary = 1,

        /// <summary>
        /// Работа
        /// </summary>
        [Description("Работа")]
        Work = 2
    }
}
