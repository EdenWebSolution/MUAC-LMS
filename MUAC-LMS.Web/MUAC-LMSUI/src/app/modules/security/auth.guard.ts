// import { Injectable } from "@angular/core";
// import { CanActivate, ActivatedRouteSnapshot, Router } from "@angular/router";
// import { BaseService } from "app/modules/core/services/base.service";
// import { HttpClient } from "@angular/common/http";
// import { Observable } from "rxjs/Rx";
// import { NotificationService } from "../shared/services/notification.service";
// @Injectable({
//   providedIn: "root"
// })
// export class AuthGuard extends BaseService implements CanActivate {
//   constructor(
//     private router: Router,
//     private notificationService: NotificationService
//   ) {
//     super();
//   }
//   canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | boolean {
//     if (
//       sessionStorage.getItem("GemSto-TokenId") === null ||
//       sessionStorage.getItem("GemSto-TokenId") === undefined
//     ) {
//       sessionStorage.removeItem("GemSto-TokenId");
//       this.notificationService.errorMessage(
//         "Your login time has been expired, login again"
//       );

//       this.router.navigate(["/login"]);
//       return false;
//     } else {
//       return true;
//     }
//   }
// }
