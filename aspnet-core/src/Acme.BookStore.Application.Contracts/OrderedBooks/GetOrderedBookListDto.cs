using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.OrderedBooks
{
    public class GetOrderedBookListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}