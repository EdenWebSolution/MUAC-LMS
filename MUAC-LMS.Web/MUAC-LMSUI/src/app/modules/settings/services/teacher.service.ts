import { Injectable } from "@angular/core";
import { TeacherModel } from "./../models/teacherModel";
import { HttpClient } from "@angular/common/http";
import { BaseService } from "../../core/services/base.service";
import { catchError } from "rxjs/operators";
import { PaginationBase } from "../../shared/models/paginationBase";
import { PaginationModel } from "../../shared/models/paginationModel";
import { TeacherDetails } from "../models/teacherDetails";

@Injectable({
  providedIn: "root"
})
export class TeacherService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  addTeacher(teacherModel: TeacherModel) {
    return this.http
      .post(`${this.baseEndPoint}/api/Teacher`, teacherModel, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getTeacherDetails(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<TeacherDetails>>(
        `${this.baseEndPoint}/api/Teacher/getAll?Skip=${pagination.skip}&Take=${
          pagination.take
        }&SearchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }

  getTeacherById(teacherId: string) {
    return this.http
      .get<TeacherModel>(
        `${this.baseEndPoint}/api/Teacher/GetTeacherById/${teacherId}`,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }

  updateTeacher(teacherModel: TeacherModel) {
    return this.http
      .put(
        `${this.baseEndPoint}/api/Teacher/UpdateTeacher`,
        teacherModel,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }

  deleteTeacher(teacherId: string) {
    return this.http
      .delete(
        `${this.baseEndPoint}/api/Teacher/DeleteTeacher/${teacherId}`,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }
}
