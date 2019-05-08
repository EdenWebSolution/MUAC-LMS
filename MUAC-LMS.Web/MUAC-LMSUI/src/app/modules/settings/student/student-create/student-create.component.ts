import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { StudentModel } from "../../models/studentModel";
import { Router } from "@angular/router";
import { NotificationService } from "../../../shared/services/notification.service";
import { StudentService } from "./../../services/student.service";

@Component({
  selector: "app-student-create",
  templateUrl: "./student-create.component.html",
  styleUrls: ["./student-create.component.scss"]
})
export class StudentCreateComponent implements OnInit {
  studentForm: FormGroup;
  studentObj = new StudentModel();
  studentGrades: { value: number; text: string }[];
  studentFormSubmitted: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private notificationService: NotificationService,
    private studentService: StudentService
  ) {
    this.studentGrades = [
      { value: 1, text: "Grade 1" },
      { value: 2, text: "Grade 2" },
      { value: 3, text: "Grade 3" },
      { value: 4, text: "Grade 4" },
      { value: 5, text: "Grade 5" },
      { value: 6, text: "Grade 6" },
      { value: 7, text: "Grade 7" }
    ];
  }

  ngOnInit() {
    this.createStudentForm();
  }

  createStudentForm(): any {
    this.studentForm = this.fb.group({
      name: ["", [Validators.required]],
      studentGrades: [1]
    });
  }

  saveStudent(): any {
    this.studentFormSubmitted = true;
    if (this.studentForm.invalid) return;

    this.studentObj = Object.assign({}, this.studentForm.value);
    this.studentService.addStudent(this.studentObj).subscribe(
      response => {
        this.notificationService.successMessage("Student added successfully");
        this.studentForm.reset({
          name: "",
          studentGrades: 1
        });
        this.studentFormSubmitted = false;
      },
      error => {
        this.notificationService.errorMessage(
          error.message !== undefined && error.message !== null
            ? error.message
            : "Something went wrong, refresh page again"
        );
      }
    );
  }
}
