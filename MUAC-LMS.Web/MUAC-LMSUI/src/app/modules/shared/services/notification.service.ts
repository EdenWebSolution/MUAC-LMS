import { Injectable } from "@angular/core";
import { NotificationsComponent } from "./../../../modules/shared/notifications/notifications.component";
import { ToastrService } from "ngx-toastr";

@Injectable({
  providedIn: "root"
})
export class NotificationService {
  notificationComponent = new NotificationsComponent();

  constructor(private toastr: ToastrService) {}

  successMessage(message: string) {
    this.notificationComponent.showNotification(
      "success",
      message,
      this.toastr
    );
  }

  errorMessage(message: string) {
    this.notificationComponent.showNotification("error", message, this.toastr);
  }

  warningMessage(message: string) {
    this.notificationComponent.showNotification(
      "warning",
      message,
      this.toastr
    );
  }

  infoMessage(message: string) {
    this.notificationComponent.showNotification("info", message, this.toastr);
  }
}
