using System;

namespace MobileTodoApp.Persistence
{
    public interface IFileHelper
    {
        string GetLocalFilePath(String filename);
    }
}
