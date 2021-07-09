using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.OrderedBooks
{
    public class OrderedBookDto : AuditedEntityDto<Guid>
    {
        public Guid ClientId { get; set; }

        public Guid BookId { get; set; }

        public string BookName { get; set; }

        public string ClientName { get; set; }
     
    }
}
