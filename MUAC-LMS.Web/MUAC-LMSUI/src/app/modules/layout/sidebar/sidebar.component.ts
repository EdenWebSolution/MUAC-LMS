import { Component, OnInit } from "@angular/core";

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
  isSubPath: boolean;
}
export const ROUTES: RouteInfo[] = [
  {
    path: "/muac/dashboard",
    title: "لوحة القيادة (dashboard)",
    icon: "business_chart-bar-32",
    class: "",
    isSubPath: false
  },
  {
    path: "/muac/book/details",
    title: "كتب (book)",
    icon: "location_map-big",
    class: "",
    isSubPath: false
  },
  {
    path: "/muac/borrow",
    title: "الاقتراض (borrow)",
    icon: "arrows-1_share-66",
    class: "",
    isSubPath: false
  },
  {
    path: "/muac/reports",
    title: "تقارير (reports)",
    icon: "files_single-copy-04",
    class: "",
    isSubPath: false
  },
  {
    path: "",
    title: "الإعدادات (Settings)",
    icon: "ui-1_settings-gear-63",
    class: "",
    isSubPath: false
  },
  {
    path: "/muac/settings/teacher/view",
    title: "مدرس (teacher)",
    icon: "ui-1_settings-gear-63",
    class: "",
    isSubPath: true
  },
  {
    path: "/muac/settings/student/view",
    title: "طالب علم (student)",
    icon: "ui-1_settings-gear-63",
    class: "",
    isSubPath: true
  },
  {
    path: "/muac/settings/maincategory/view",
    title: "الفئة العامة (Main Category)",
    icon: "ui-1_settings-gear-63",
    class: "",
    isSubPath: true
  },
  {
    path: "/muac/settings/subcategory/view",
    title: "الفئة الفرعية (Sub Category)",
    icon: "ui-1_settings-gear-63",
    class: "",
    isSubPath: true
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
