import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  Input,
  OnChanges
} from "@angular/core";
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
export class StudentCreateComponent implements OnInit, OnChanges {
  studentForm: FormGroup;
  studentObj = new StudentModel();
  studentGrades: { value: number; text: string }[];
  studentFormSubmitted: boolean = false;

  @Output() closeNewStudentClicked = new EventEmitter<Event>();
  @Output() addNewStudentSaved = new EventEmitter<Event>();
  @Input() studentId: string;

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

  ngOnChanges() {
    if (this.studentId != "") this.getStudentById(this.studentId);
    else this.createStudentForm();
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
        this.addNewStudentSaved.emit();
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

  updateStudent(): any {
    this.studentObj = Object.assign({}, this.studentForm.value);
    this.studentObj.storeUserId = this.studentId;

    this.studentService.updateStudent(this.studentObj).subscribe(
      res => {
        this.addNewStudentSaved.emit();
        this.closeNewStudentClicked.emit(event);
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

  getStudentById(studentId: string): any {
    this.studentService.getStudentById(studentId).subscribe(
      res => {
        console.log(res);
        this.patchStudentForm(res);
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

  patchStudentForm(studentModel: StudentModel): any {
    this.studentForm.patchValue({
      name: studentModel.name,
      studentGrades: studentModel.studentGrades
    });
  }

  closeNewStudent(event: Event): void {
    this.closeNewStudentClicked.emit(event);
  }
}
