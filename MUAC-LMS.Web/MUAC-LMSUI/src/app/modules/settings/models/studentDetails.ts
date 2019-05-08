import { StudentGrades } from "../../core/enums/studentGrades";

export interface StudentDetails {
  storeUserId: string;
  name: string;
  studentGrades: StudentGrades;
}
