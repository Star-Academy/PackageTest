using System.Collections.Generic;
using Education.Models;

namespace Education.Repository
{
    public interface IResource<T> 
    {
        IEnumerable<T> ReadAll();

        void WriteAll(IEnumerable<T> entities);
    }
}