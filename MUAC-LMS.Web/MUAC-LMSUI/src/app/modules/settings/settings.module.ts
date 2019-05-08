import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { SettingsRoutingModule } from "./settings-routing.module";
import { SharedModule } from "../shared/shared.module";
import { StudentCreateComponent } from "./student/student-create/student-create.component";
import { StudentDetailsComponent } from "./student/student-details/student-details.component";
import { TeacherCreateComponent } from "./teacher/teacher-create/teacher-create.component";
import { TeacherDetailsComponent } from "./teacher/teacher-details/teacher-details.component";
import { MainCategoryCreateComponent } from "./category/main-category/main-category-create/main-category-create.component";
import { MainCategoryDetailsComponent } from "./category/main-category/main-category-details/main-category-details.component";
import { SubCategoryCreateComponent } from "./category/sub-category/sub-category-create/sub-category-create.component";
import { SubCategoryDetailsComponent } from "./category/sub-category/sub-category-details/sub-category-details.component";
import { MainCategoryViewComponent } from "./category/main-category/main-category-view/main-category-view.component";
import { SubCategoryViewComponent } from "./category/sub-category/sub-category-view/sub-category-view.component";
import { StudentViewComponent } from "./student/student-view/student-view.component";
import { TeacherViewComponent } from "./teacher/teacher-view/teacher-view.component";
import { PaginationModule } from "ngx-bootstrap/pagination";

@NgModule({
  declarations: [
    StudentCreateComponent,
    StudentDetailsComponent,
    TeacherCreateComponent,
    TeacherDetailsComponent,
    MainCategoryCreateComponent,
    MainCategoryDetailsComponent,
    SubCategoryCreateComponent,
    SubCategoryDetailsComponent,
    MainCategoryViewComponent,
    SubCategoryViewComponent,
    StudentViewComponent,
    TeacherViewComponent
  ],
  imports: [
    PaginationModule.forRoot(),
    CommonModule,
    SettingsRoutingModule,
    SharedModule
  ]
})
export class SettingsModule {}
