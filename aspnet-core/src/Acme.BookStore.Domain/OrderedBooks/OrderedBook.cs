using Acme.BookStore.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.OrderedBooks
{
    public class OrderedBook : AuditedAggregateRoot<Guid>
    {

        public Guid ClientId { get; set; }

        public Guid BookId { get; set; }

        public bool Status { get; set; }

    }
}
