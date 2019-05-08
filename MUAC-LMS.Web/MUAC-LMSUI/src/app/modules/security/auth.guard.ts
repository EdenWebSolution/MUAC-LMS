import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, Router } from "@angular/router";
import { BaseService } from "../core/services/base.service";
import { NotificationService } from "../shared/services/notification.service";
import { Observable } from "rxjs";
@Injectable({
  providedIn: "root"
})
export class AuthGuard extends BaseService implements CanActivate {
  constructor(
    private router: Router,
    private notificationService: NotificationService
  ) {
    super();
  }
  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | boolean {
    if (localStorage.getItem("TokenId") === null) {
      localStorage.removeItem("TokenId");
      this.notificationService.errorMessage(
        "Your login time has been expired, login again"
      );

      this.router.navigate(["/login"]);
      return false;
    } else {
      return true;
    }
  }
}
