using System;
using SQLite;

namespace Mobility.DB
{
    [Table("NoteTypes")]
    public class NoteType
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}