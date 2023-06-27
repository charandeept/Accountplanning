import { filter } from "rxjs"

export interface AccountDetails {
    customerMetric: string
    customerName: string
    service: string
}
export interface DashboardDTO {
    engagementHealths: []
    financialHealths: []
    metric: []
    noOfAccounts: []
}

export interface Filter {
  [x: string]: any;
}

export interface customerName{
  string : any;
}

export interface Enablers{

}

export interface EnablerCard{
  
}


export interface MetricsDTO {
    Id: number
    UserID: number
    MetricsID: number
    OperatorID: number
    Value: number
}

export interface Character {
    name: string;
    date: string;
    modifiedBy: string;
    modifiedOn: string;
  
}
export interface customerlist {
  info: {
    count: number;
    employeeID: number;
    pageNumber: number;
    rowsOfPage: number,
    sortingColumn: string,
    sortType: string
    next: string;
    prev: string;

  };
  results: Character[];
}

export let metricListName = [ "CSAT", "Customer Mood", "Engagement Health", "Financial Health"]
export let operatorListValues =  {
    "CSAT": ["Less than", "More than", "Equal to"],
    "Customer Mood": ["Equal to"],
    "Engagement Health": ["Less than", "More than", "Equal to"],
    "Financial Health": ["Less than", "More than", "Equal to"]
  };
export let operatorSelectValue=["Less than", "More than", "Equal to"]

export let metricListValues = {
    "Catalouge Awareness": [10, 20, 30, 40, 50, 60, 70, 80, 90, 100],
    "CSAT": [1, 2, 3, 4, 5],
    "Customer Mood": ["Bad", "Good", "Excellent"],
    "Engagement Health": [10, 20, 30, 40, 50, 60, 70, 80, 90, 100],
    "Financial Health": [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]
};

export let colors = {
  excColor : "green",
  goodColor : "orange",
  badColor : "red"
}
