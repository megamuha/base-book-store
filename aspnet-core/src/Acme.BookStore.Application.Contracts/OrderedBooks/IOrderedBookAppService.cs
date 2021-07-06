using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.OrderedBooks
{
    public interface IOrderedBookAppService :
        ICrudAppService< //Defines CRUD methods
            OrderedBookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateOrderedBookDto> //Used to create/update a book
    {

    }
}