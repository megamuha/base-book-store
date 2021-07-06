using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.OrderedBooks
{
    public class OrderedBookAppService :
        CrudAppService<
            OrderedBook, //The Book entity
            OrderedBookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOrderedBookDto>, //Used to create/update a book
        IOrderedBookAppService //implement the IBookAppService
    {
        public OrderedBookAppService(IRepository<OrderedBook, Guid> repository)
            : base(repository)
        {

        }
    }
}
