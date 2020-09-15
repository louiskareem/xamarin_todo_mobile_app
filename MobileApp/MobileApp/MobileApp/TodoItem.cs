using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTodoApp
{
    public class TodoItem : BaseFodyObservable
    {
        public int ID { get; set; }

        public String Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
