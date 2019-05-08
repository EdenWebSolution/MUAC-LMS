import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { TeacherModel } from "../../models/teacherModel";
import { FormBuilder } from "@angular/forms";
import { Router } from "@angular/router";
import { NotificationService } from "./../../../shared/services/notification.service";
import { TeacherService } from "../../services/teacher.service";

@Component({
  selector: "app-teacher-create",
  templateUrl: "./teacher-create.component.html",
  styleUrls: ["./teacher-create.component.scss"]
})
export class TeacherCreateComponent implements OnInit {
  teacherForm: FormGroup;
  teacherObj = new TeacherModel();
  teacherFormSubmitted: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private notificationService: NotificationService,
    private teacherService: TeacherService
  ) {}

  ngOnInit() {
    this.createTeacherForm();
  }

  createTeacherForm(): any {
    this.teacherForm = this.fb.group({
      name: ["", [Validators.required]]
    });
  }

  saveTeacher(): any {
    this.teacherFormSubmitted = true;
    if (this.teacherForm.invalid) return;

    this.teacherObj = Object.assign({}, this.teacherForm.value);
    this.teacherService.addTeacher(this.teacherObj).subscribe(
      response => {
        this.notificationService.successMessage("Teacher added successfully");
        this.teacherForm.reset({
          name: ""
        });
        this.teacherFormSubmitted = false;
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
