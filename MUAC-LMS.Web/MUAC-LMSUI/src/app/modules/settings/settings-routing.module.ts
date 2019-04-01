import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { TeacherCreateComponent } from "./teacher/teacher-create/teacher-create.component";
import { TeacherDetailsComponent } from "./teacher/teacher-details/teacher-details.component";
import { StudentCreateComponent } from "./student/student-create/student-create.component";
import { StudentDetailsComponent } from "./student/student-details/student-details.component";
import { MainCategoryCreateComponent } from "./category/main-category/main-category-create/main-category-create.component";
import { MainCategoryDetailsComponent } from "./category/main-category/main-category-details/main-category-details.component";
import { SubCategoryCreateComponent } from "./category/sub-category/sub-category-create/sub-category-create.component";
import { SubCategoryDetailsComponent } from "./category/sub-category/sub-category-details/sub-category-details.component";

const routes: Routes = [
  {
    path: "teacher/create",
    component: TeacherCreateComponent
  },
  {
    path: "teacher/details",
    component: TeacherDetailsComponent
  },
  {
    path: "student/create",
    component: StudentCreateComponent
  },
  {
    path: "student/details",
    component: StudentDetailsComponent
  },
  {
    path: "maincategory/create",
    component: MainCategoryCreateComponent
  },
  {
    path: "maincategory/details",
    component: MainCategoryDetailsComponent
  },
  {
    path: "subcategory/create",
    component: SubCategoryCreateComponent
  },
  {
    path: "subcategory/details",
    component: SubCategoryDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule {}
