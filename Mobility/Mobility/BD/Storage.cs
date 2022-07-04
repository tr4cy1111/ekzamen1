using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;

namespace Mobility.DB
{
    public class Storage
    {
        SQLiteConnection database;
        public Storage(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Money>();
            database.CreateTable<NoteType>();
            database.CreateTable<ExpenseType>();
            database.CreateTable<User>();

            
        }

        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                database.Update(user);
                return user.Id;
            }
            else
            {
                return database.Insert(user);
            }
        }
        public int SaveExpenseType(ExpenseType expenseType)
        {
            if (expenseType.Id != 0)
            {
                database.Update(expenseType);
                return expenseType.Id;
            }
            else
            {
                return database.Insert(expenseType);
            }
        }
        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public User GetUser(string login, string password)
        {
            return GetUsers().Where(user => user.Login == login && user.Password == password).FirstOrDefault();
        }
        public User SearchEmail(string email)
        {
            return GetUsers().Where(user => user.EMail == email).FirstOrDefault();
        }
        public User SearchUser(string login)
        {
            return GetUsers().Where(user => user.Login == login).FirstOrDefault();
        }



        public int SaveMoney(Money money)
        {
            if (money.Id != 0)
            {
                database.Update(money);
                return money.Id;
            }
            else
            {
                return database.Insert(money);
            }
        }

        public void EditMoney(Money oldMoney, int noteTypeId, int expenseTypeId, double sum, string description, int userId)
        {
            Money money = oldMoney;
            money.NoteTypeId = noteTypeId;
            money.ExpenseTypeId = expenseTypeId;
            money.Sum = sum;
            money.Description = description;
            money.UserId = userId;
            database.Update(money);
        }

        public IEnumerable<Money> GetMoneys()
        {
            return database.Table<Money>().ToList();
        }
        public ExpenseType GetExpenseType(int id)
        {
            return GetExpenseTypes().Where(x => x.Id == id).FirstOrDefault();
        }

        public NoteType GetNoteType(int id)
        {
            return GetNoteTypes().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Money> GetUsersMoney(int userId)
        {
            return GetMoneys().Where(money => money.UserId == userId);
        }

        public int DeleteMoney(int idMoney)
        {
            return database.Delete<Money>(idMoney);
        }



        public int SaveNoteType(NoteType noteType)
        {
            if (noteType.Id != 0)
            {
                database.Update(noteType);
                return noteType.Id;
            }
            else
            {
                return database.Insert(noteType);
            }
        }

        public IEnumerable<NoteType> GetNoteTypes()
        {
            return database.Table<NoteType>().ToList();
        }




        public IEnumerable<ExpenseType> GetExpenseTypes()
        {
            return database.Table<ExpenseType>().ToList();
        }

    }
}
