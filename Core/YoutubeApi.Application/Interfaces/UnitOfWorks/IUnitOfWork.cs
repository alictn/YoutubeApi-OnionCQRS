using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepositories<T> GetReadRepositories<T>() where T : class, IEntityBase, new();
        IWriteRepositories<T> GetWriteRepositories<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync();
        int Save();
    }
}
