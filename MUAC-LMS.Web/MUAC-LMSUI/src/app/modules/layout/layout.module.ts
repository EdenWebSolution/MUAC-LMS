import { NgModule } from "@angular/core";
import { LayoutComponent } from "./layout/layout.component";
import { SidebarComponent } from "./sidebar/sidebar.component";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";

@NgModule({
  declarations: [LayoutComponent, SidebarComponent],
  imports: [SharedModule, RouterModule]
})
export class LayoutModule {}
