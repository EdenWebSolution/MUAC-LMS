import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BaseService } from "../../core/services/base.service";
import { StudentModel } from "../models/studentModel";
import { catchError } from "rxjs/operators";
import { PaginationBase } from "./../../shared/models/paginationBase";
import { PaginationModel } from "../../shared/models/paginationModel";
import { StudentDetails } from "../models/studentDetails";

@Injectable({
  providedIn: "root"
})
export class StudentService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  addStudent(studentModel: StudentModel) {
    return this.http
      .post(`${this.baseEndPoint}/api/Student`, studentModel, this.httpOptions)
      .pipe(catchError(this.handleError));
  }

  getStudentDetails(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<StudentDetails>>(
        `${this.baseEndPoint}/api/Student/getAll?Skip=${pagination.skip}&Take=${
          pagination.take
        }&SearchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }
}
