using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileTodoApp
{
    public class TodoItem : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public String Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
