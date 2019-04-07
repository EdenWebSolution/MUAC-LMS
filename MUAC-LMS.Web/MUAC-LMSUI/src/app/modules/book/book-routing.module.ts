import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookCreateComponent } from './book-create/book-create.component';
import { BookDetailsComponent } from './book-details/book-details.component';

const routes: Routes = [
  {
    path: 'create',
    component: BookCreateComponent
  },
  {
    path: 'details',
    component: BookDetailsComponent
  },
  {
    path: '',
    redirectTo: '/muac/book/details'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookRoutingModule {}
