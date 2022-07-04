using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobility.DB
{
    [Table("ExpenseTypes")]
    public class ExpenseType
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}