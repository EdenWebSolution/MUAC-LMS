import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { PaginationBase } from "../../../../modules/shared/models/paginationBase";
import { TeacherDetails } from "../../models/teacherDetails";
import { TeacherService } from "./../../services/teacher.service";
import { FormBuilder } from "@angular/forms";
import swal from "sweetalert";

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

  isShowCreate = false;
  editTeacherId: string; // Teacher ID passed from Parent to Child component

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

  addNewTeacher() {
    this.isShowCreate = true;
    this.editTeacherId = "";
  }

  closeNewTeacherEventClicked(event: Event) {
    this.isShowCreate = !this.isShowCreate;
  }

  addNewTeacherEventSaved(event: Event) {
    this.currentPage = 1;
    this.getTeacherDetails();
  }

  editTeacher(teacherId: string) {
    this.isShowCreate = true;
    this.editTeacherId = teacherId;
  }

  deleteTeacher(studentId: string) {
    swal({
      title: "Are you sure you want to Delete?",
      icon: "warning",
      buttons: ["No", "Yes"],
      dangerMode: true
    }).then(willDelete => {
      if (willDelete) {
        // this.studentService.deleteStudent(studentId).subscribe(
        //   res => {
        //     this.currentPage = 1;
        //   this.getStudentDetails();

        //   },
        //   error => {
        //     console.log(error);
        //   }
        // );
        this.isShowCreate = !this.isShowCreate;
        swal("Poof! Your imaginary file has been deleted!", {
          icon: "success"
        });
      }
    });
  }
}
