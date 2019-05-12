import {
  Component,
  OnInit,
  Output,
  EventEmitter,
  Input,
  OnChanges
} from "@angular/core";
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
export class TeacherCreateComponent implements OnInit, OnChanges {
  teacherForm: FormGroup;
  teacherObj = new TeacherModel();
  teacherFormSubmitted: boolean = false;

  @Output() closeNewTeacherClicked = new EventEmitter<Event>();
  @Output() addNewTeacherSaved = new EventEmitter<Event>();
  @Input() teacherId: string;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private notificationService: NotificationService,
    private teacherService: TeacherService
  ) {}

  ngOnInit() {
    this.createTeacherForm();
  }

  ngOnChanges() {
    if (this.teacherId != "") this.getTeacherById(this.teacherId);
    else this.createTeacherForm();
  }

  createTeacherForm(): any {
    this.teacherForm = this.fb.group({
      name: ["", [Validators.required]]
    });
  }

  saveTeacher(event: Event): any {
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
        this.addNewTeacherSaved.emit(event);
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

  updateTeacher(): any {
    this.teacherObj = Object.assign({}, this.teacherForm.value);
    this.teacherObj.id = this.teacherId;

    this.teacherService.updateTeacher(this.teacherObj).subscribe(
      res => {
        this.addNewTeacherSaved.emit();
        this.closeNewTeacherClicked.emit(event);
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

  getTeacherById(teacherId: string): any {
    this.teacherService.getTeacherById(teacherId).subscribe(
      res => {
        console.log(res);
        this.patchTeacherForm(res);
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

  patchTeacherForm(teacherModel: TeacherModel): any {
    this.teacherForm.patchValue({
      name: teacherModel.name
    });
  }

  closeNewTeacher(event: Event): void {
    this.closeNewTeacherClicked.emit(event);
  }
}
