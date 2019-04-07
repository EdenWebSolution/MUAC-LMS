import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { BookViewComponent } from "./book-view/book-view.component";

const routes: Routes = [
  {
    path: "details",
    component: BookViewComponent
  },
  {
    path: "",
    redirectTo: "/muac/book/details"
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookRoutingModule {}
