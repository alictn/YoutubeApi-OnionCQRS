using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Persistence.Context;
using YoutubeApi.Persistence.Repositories;

namespace YoutubeApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();



        public int Save() => dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();

        IReadRepositories<T> IUnitOfWork.GetReadRepositories<T>() => new ReadRepositories<T>(dbContext);

        IWriteRepositories<T> IUnitOfWork.GetWriteRepositories<T>() => new WriteRepositories<T>(dbContext);
    }
}
