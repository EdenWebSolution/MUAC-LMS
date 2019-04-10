import { Injectable } from "@angular/core";
import { BaseService } from "../../core/services/base.service";
import { HttpClient } from "@angular/common/http";
import { LoginModel } from "./../models/loginModel";
import { catchError } from "rxjs/operators";

@Injectable({
  providedIn: "root"
})
export class LoginService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  baseEndPoint = this.baseEndPoint;

  authenticateUser(loginModel: LoginModel) {
    return this.http
      .post<LoginModel>(
        `${this.baseEndPoint}/api/Account/Authenticate`,
        loginModel,
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }
}
