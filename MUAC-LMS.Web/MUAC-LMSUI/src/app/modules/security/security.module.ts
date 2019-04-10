import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { SecurityRoutingModule } from "./security-routing.module";
import { LoginComponent } from "./login/login.component";
import { SharedModule } from "../shared/shared.module";
import { LoginService } from "./services/login.service";

@NgModule({
  declarations: [LoginComponent],
  imports: [CommonModule, SecurityRoutingModule, SharedModule],
  providers: [LoginService]
})
export class SecurityModule {}
