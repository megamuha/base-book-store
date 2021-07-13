import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { OrderedBookService, OrderedBookDto } from '@proxy/ordered-books';



@Component({
  selector: 'app-ordered-books',
  templateUrl: './ordered-books.component.html',
  styleUrls: ['./ordered-books.component.scss'],
  providers: [ListService],
})
export class OrderedBooksComponent implements OnInit {

  book = { items: [], totalCount: 0 } as PagedResultDto<OrderedBookDto>;

  constructor(public readonly list: ListService, private orderedBookService: OrderedBookService, private confirmation: ConfirmationService) {}

  ngOnInit() {
   this.allBooksList();
   this.usersBookList();
  }

  allBooksList(){
    const bookStreamCreator = (query) => this.orderedBookService.getList(query);
    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.book = response;
    });
  }

  usersBookList(){
    const bookStreamCreator = (query) => this.orderedBookService.getClientList(query);
    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.book = response;
    });
  }

  delete(id: string) {
    this.confirmation.info('', '::Delete this book?').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        console.log(true)
        this.orderedBookService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  updateStatus(id: string) {
    this.confirmation.info('', 'Change status?').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        console.log(true)
        this.orderedBookService.updateStatus(id).subscribe(() => this.list.get());
      }
    });
  }


}
