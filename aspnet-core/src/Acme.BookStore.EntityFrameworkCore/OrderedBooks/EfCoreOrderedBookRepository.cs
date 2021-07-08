using Acme.BookStore.EntityFrameworkCore;
using Acme.BookStore.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;


namespace Acme.BookStore.OrderedBooks
{
   public class EfCoreOrderedBookRepository : EfCoreRepository<BookStoreDbContext, OrderedBook, Guid>,
            IOrderedBookRepository, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;

        public EfCoreOrderedBookRepository(
            IDbContextProvider<BookStoreDbContext> dbContextProvider, ICurrentUser currentUser)
            : base(dbContextProvider)
        {
            _currentUser = currentUser;
        }

        public async Task<List<OrderedBook>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<OrderedBook> FindOrderAsync(OrderedBook input)
        {
            var dbSet = await GetDbSetAsync();

            return dbSet.Where(
                    order => order.ClientId == input.ClientId
                 ).Where(order => order.BookId == input.BookId)
                .FirstOrDefault();
        }

        public async Task<List<Guid>> GetAllBooksOrder(Guid id)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.Where(
                    order => order.BookId == id
                 ).Select(order => order.Id).ToListAsync();
        }
        public async Task<List<Guid>> GetAllBookOrder(Guid id)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.Where(
                    order => order.BookId == id
                 ).Select(order => order.Id).ToListAsync();
        }
    }
}