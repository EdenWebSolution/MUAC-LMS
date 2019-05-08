import { NgModule } from "@angular/core";
import { Routes, RouterModule, PreloadAllModules } from "@angular/router";
import { LayoutComponent } from "./modules/layout/layout/layout.component";
import { LoginComponent } from "./modules/security/login/login.component";
import { AuthGuard } from "./modules/security/auth.guard";

export const routes: Routes = [
  {
    path: "",
    redirectTo: "muac/dashboard",
    pathMatch: "full",
    canActivate: [AuthGuard]
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
        path: "settings",
        loadChildren: "./modules/settings/settings.module#SettingsModule"
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
