using System;
using SQLite;

namespace Mobility.DB
{
    [Table("Moneys")]
    public class Money
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int NoteTypeId { get; set; }
        public int ExpenseTypeId { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}