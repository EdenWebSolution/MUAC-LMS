import { PaginationBase } from "./paginationBase";

export class PaginationModel<T> extends PaginationBase {
  totalRecords: number;
  details: Array<T>;
  extensionData: any;

  constructor(take: number) {
    super();
    this.details = new Array<T>();
    this.skip = 0;
    this.take = take;
    this.totalRecords = 0;
  }
}
