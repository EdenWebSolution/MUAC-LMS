import { StudentGrades } from "../../core/enums/studentGrades";

export class StudentModel {
  name: string;
  studentGrades: StudentGrades;

  constructor() {
    this.name = "";
  }
}
