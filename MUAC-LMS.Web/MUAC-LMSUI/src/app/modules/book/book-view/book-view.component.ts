import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-book-view",
  templateUrl: "./book-view.component.html",
  styleUrls: ["./book-view.component.scss"]
})
export class BookViewComponent implements OnInit {
  isShowCreate = false;

  constructor() {}

  ngOnInit() {}

  showBookEventClicked(event: Event) {
    this.isShowCreate = !this.isShowCreate;
  }

  closeBookEventClicked(event: Event) {
    this.isShowCreate = !this.isShowCreate;
  }
}
