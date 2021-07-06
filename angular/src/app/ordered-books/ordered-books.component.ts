import { ListService, PagedResultDto } from '@abp/ng.core';
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

  constructor(public readonly list: ListService, private orderedBookService: OrderedBookService) {}

  ngOnInit() {
    const bookStreamCreator = (query) => this.orderedBookService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.book = response;
    });
  }
}
