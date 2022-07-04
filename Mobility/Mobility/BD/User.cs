using System;
using SQLite;

namespace Mobility.DB
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
    }
}