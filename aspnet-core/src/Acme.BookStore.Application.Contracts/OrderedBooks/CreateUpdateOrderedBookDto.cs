using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.OrderedBooks
{
    public class CreateUpdateOrderedBookDto
    {

        public Guid BookId { get; set; }
        public Guid ClientId { get; set; }
       // public bool Status { get; set; }

    }
}