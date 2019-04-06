import { Component, OnInit, EventEmitter, Output } from "@angular/core";

@Component({
  selector: "app-book-details",
  templateUrl: "./book-details.component.html",
  styleUrls: ["./book-details.component.scss"]
})
export class BookDetailsComponent implements OnInit {
  @Output() showBookClicked = new EventEmitter<Event>();

  constructor() {}

  ngOnInit() {}

  addNewBook(event: Event): void {
    this.showBookClicked.emit(event);
  }
}
