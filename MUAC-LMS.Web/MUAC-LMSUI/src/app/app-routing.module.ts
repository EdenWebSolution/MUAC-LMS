import { NgModule } from "@angular/core";
import { Routes, RouterModule, PreloadAllModules } from "@angular/router";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { LayoutComponent } from "./modules/layout/layout/layout.component";
import { LoginComponent } from "./modules/security/login/login.component";

export const routes: Routes = [
  {
    path: "",
    component: LoginComponent
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "muac",
    component: LayoutComponent,
    children: [
      {
        path: "dashboard",
        loadChildren: "./modules/dashboard/dashboard.module#DashboardModule"
      },
      {
        path: "book",
        loadChildren: "./modules/book/book.module#BookModule"
      },
      {
        path: "security",
        loadChildren: "./modules/security/security.module#SecurityModule"
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
