import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MainCategoryViewComponent } from "./category/main-category/main-category-view/main-category-view.component";
import { SubCategoryViewComponent } from "./category/sub-category/sub-category-view/sub-category-view.component";
import { StudentDetailsComponent } from "./student/student-details/student-details.component";
import { TeacherDetailsComponent } from "./teacher/teacher-details/teacher-details.component";

const routes: Routes = [
  {
    path: "teacher/details",
    component: TeacherDetailsComponent
  },
  {
    path: "student/details",
    component: StudentDetailsComponent
  },
  {
    path: "maincategory/view",
    component: MainCategoryViewComponent
  },
  {
    path: "subcategory/view",
    component: SubCategoryViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule {}
