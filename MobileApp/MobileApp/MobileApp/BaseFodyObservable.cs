using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MobileTodoApp
{
    public abstract class BaseFodyObservable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
