import { Component, OnInit } from "@angular/core";
import { PaginationBase } from "../../../../modules/shared/models/paginationBase";
import { StudentService } from "./../../services/student.service";
import { FormBuilder } from "@angular/forms";
import { StudentDetails } from "./../../models/studentDetails";

@Component({
  selector: "app-student-details",
  templateUrl: "./student-details.component.html",
  styleUrls: ["./student-details.component.scss"]
})
export class StudentDetailsComponent implements OnInit {
  pagination = new PaginationBase();
  students: StudentDetails[];

  totalItems: number;
  currentPage = 1;

  constructor(
    private studentService: StudentService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.getStudentDetails();
  }

  getStudentDetails(): any {
    this.studentService.getStudentDetails(this.pagination).subscribe(
      res => {
        this.totalItems = res.totalRecords;
        this.students = res.details;
      },
      error => {
        console.log(error);
      }
    );
  }

  pageChanged(event: any): void {
    this.pagination.skip = (event.page - 1) * this.pagination.take;
    this.currentPage = event.page;
    this.getStudentDetails();
  }
}
