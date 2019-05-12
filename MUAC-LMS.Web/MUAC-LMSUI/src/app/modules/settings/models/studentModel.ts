import { StudentGrades } from "../../core/enums/studentGrades";

export class StudentModel {
  storeUserId: string;
  name: string;
  studentGrades: StudentGrades;

  constructor() {
    this.name = "";
  }
}
