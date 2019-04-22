using System;

namespace Softwave_Server_Side.Interfaces
{
    public interface IDatabse<T> : IDisposable
    {
        void CreateEntity(T entity);
    }
}