export class DataTableFilter {
    public sort: string;
    public pageSize: number;
    public pageIndex: number;
    public columnFilter: Array<ColumnInformation>;
  }

  export class ColumnInformation {
    columnName: string;
    value: string;
    operation: string;
    text: string;
    operationText: string;
    databaseColumnName: string;
    description: string;
  }