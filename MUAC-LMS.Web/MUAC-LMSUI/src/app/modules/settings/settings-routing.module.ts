import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { MainCategoryViewComponent } from "./category/main-category/main-category-view/main-category-view.component";
import { SubCategoryViewComponent } from "./category/sub-category/sub-category-view/sub-category-view.component";
import { TeacherViewComponent } from "./teacher/teacher-view/teacher-view.component";
import { StudentViewComponent } from "./student/student-view/student-view.component";
import { AuthGuard } from "../security/auth.guard";

const routes: Routes = [
  {
    path: "teacher/view",
    component: TeacherViewComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "student/view",
    component: StudentViewComponent,
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
