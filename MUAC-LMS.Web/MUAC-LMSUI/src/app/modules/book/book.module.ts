import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { BookRoutingModule } from "./book-routing.module";
import { SharedModule } from "../shared/shared.module";
import { BookCreateComponent } from './book-create/book-create.component';
import { BookDetailsComponent } from './book-details/book-details.component';

@NgModule({
  declarations: [BookCreateComponent, BookDetailsComponent],
  imports: [CommonModule, BookRoutingModule, SharedModule]
})
export class BookModule {}
