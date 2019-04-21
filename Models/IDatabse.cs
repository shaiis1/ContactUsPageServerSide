using System;

namespace Softwave_Server_Side.Models
{
    public interface IDatabse<T> : IDisposable
    {
        void CreateEntity(T entity);
    }
}