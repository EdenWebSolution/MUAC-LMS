import { Component, OnInit } from "@angular/core";
import { PaginationBase } from "../../../../modules/shared/models/paginationBase";
import { TeacherDetails } from "../../models/teacherDetails";
import { TeacherService } from "./../../services/teacher.service";
import { FormBuilder } from "@angular/forms";

@Component({
  selector: "app-teacher-details",
  templateUrl: "./teacher-details.component.html",
  styleUrls: ["./teacher-details.component.scss"]
})
export class TeacherDetailsComponent implements OnInit {
  pagination = new PaginationBase();
  teachers: TeacherDetails[];

  totalItems: number;
  currentPage = 1;

  constructor(
    private teacherService: TeacherService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.getTeacherDetails();
  }

  getTeacherDetails(): any {
    this.teacherService.getTeacherDetails(this.pagination).subscribe(
      res => {
        this.totalItems = res.totalRecords;
        this.teachers = res.details;
      },
      error => {
        console.log(error);
      }
    );
  }

  pageChanged(event: any): void {
    this.pagination.skip = (event.page - 1) * this.pagination.take;
    this.currentPage = event.page;
    this.getTeacherDetails();
  }
}
