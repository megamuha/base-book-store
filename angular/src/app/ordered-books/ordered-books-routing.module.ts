import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderedBooksComponent } from './ordered-books.component';

const routes: Routes = [{ path: '', component: OrderedBooksComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderedBooksRoutingModule { }
