import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MainCategoryViewComponent } from "./category/main-category/main-category-view/main-category-view.component";
import { SubCategoryViewComponent } from "./category/sub-category/sub-category-view/sub-category-view.component";
import { StudentDetailsComponent } from "./student/student-details/student-details.component";
import { TeacherDetailsComponent } from "./teacher/teacher-details/teacher-details.component";
import { AuthGuard } from "../security/auth.guard";

const routes: Routes = [
  {
    path: "teacher/details",
    component: TeacherDetailsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "student/details",
    component: StudentDetailsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "maincategory/view",
    component: MainCategoryViewComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "subcategory/view",
    component: SubCategoryViewComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule {}
