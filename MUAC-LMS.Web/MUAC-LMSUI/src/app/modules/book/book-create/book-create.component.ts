import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";

@Component({
  selector: "app-book-create",
  templateUrl: "./book-create.component.html",
  styleUrls: ["./book-create.component.scss"]
})
export class BookCreateComponent implements OnInit {
  @Output() closeBookClicked = new EventEmitter<Event>();

  constructor() {}

  ngOnInit() {}

  closeNewBook(event: Event): void {
    this.closeBookClicked.emit(event);
  }
}
