import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-notifications",
  templateUrl: "./notifications.component.html",
  styleUrls: ["./notifications.component.css"]
})
export class NotificationsComponent implements OnInit {
  constructor() {}

  showNotification(type: string, message: string, toastr: ToastrService) {
    switch (type) {
      case "info":
        toastr.info(
          `<span class="now-ui-icons ui-1_bell-53"></span> ${message}`,
          "",
          {
            timeOut: 8000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-info alert-with-icon",
            positionClass: "toast-top-left"
          }
        );
        break;
      case "success":
        toastr.success(
          `<span class="now-ui-icons ui-1_bell-53"></span> ${message}`,
          "",
          {
            timeOut: 8000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-success alert-with-icon",
            positionClass: "toast-top-left"
          }
        );
        break;
      case "warning":
        toastr.warning(
          `<span class="now-ui-icons ui-1_bell-53"></span> ${message}`,
          "",
          {
            timeOut: 8000,
            closeButton: true,
            enableHtml: true,
            toastClass: "alert alert-warning alert-with-icon",
            positionClass: "toast-top-left"
          }
        );
        break;
      case "error":
        toastr.error(
          `<span class="now-ui-icons ui-1_bell-53"></span> ${message}`,
          "",
          {
            timeOut: 8000,
            enableHtml: true,
            closeButton: true,
            toastClass: "alert alert-danger alert-with-icon",
            positionClass: "toast-top-left"
          }
        );
        break;
      //  case 5:
      //  this.toastr.show('<span class="now-ui-icons ui-1_bell-53"></span> Welcome to <b>Now Ui Dashboard</b> - a beautiful freebie for every web developer.', '', {
      //     timeOut: 8000,
      //     closeButton: true,
      //     enableHtml: true,
      //     toastClass: "alert alert-primary alert-with-icon",
      //     positionClass: 'toast-' + from + '-' +  align
      //   });
      // break;
      default:
        break;
    }
  }
  ngOnInit() {}
}
