import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { OrderedBooksRoutingModule } from './ordered-books-routing.module';
import { OrderedBooksComponent } from './ordered-books.component';


@NgModule({
  declarations: [OrderedBooksComponent],
  imports: [
    SharedModule,
    OrderedBooksRoutingModule
  ]
})
export class OrderedBooksModule { }
