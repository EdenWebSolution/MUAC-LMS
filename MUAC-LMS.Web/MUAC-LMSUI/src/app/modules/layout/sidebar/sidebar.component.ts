import { Component, OnInit } from "@angular/core";

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  {
    path: "/muac/dashboard",
    title: "Dashboard",
    icon: "business_chart-bar-32",
    class: ""
  },
  {
    path: "/muac/book/details",
    title: "Books",
    icon: "location_map-big",
    class: ""
  },
  {
    path: "/muac/borrow",
    title: "Borrowing",
    icon: "arrows-1_share-66",
    class: ""
  },
  {
    path: "/muac/reports",
    title: "Reports",
    icon: "files_single-copy-04",
    class: ""
  },
  {
    path: "/muac/settings",
    title: "Settings",
    icon: "ui-1_settings-gear-63",
    class: ""
  }
];

@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.scss"]
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() {}

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
    if (window.innerWidth > 991) {
      return false;
    }
    return true;
  }
}
