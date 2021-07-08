using Acme.BookStore.OrderedBooks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Orders
{
    public interface IOrderedBookRepository : IRepository<OrderedBook, Guid>
    {
        Task<List<OrderedBook>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}