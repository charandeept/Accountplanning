import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeModel, HttpHelper } from '../@core';
import { ChartApiModel } from './models/chart-api-response';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private data:ChartApiModel[]=[{
    programName:'Program1',
    coursesCompleted:10,
    coursesNotStarted:5,
    coursesInprogress:3
  },
    {
      programName: 'Program2',
      coursesCompleted: 8,
      coursesNotStarted: 4,
      coursesInprogress: 1
    },
    {
      programName: 'Program3',
      coursesCompleted: 25,
      coursesNotStarted: 2,
      coursesInprogress: 0
    },
    {
      programName: 'Program4',
      coursesCompleted: 10,
      coursesNotStarted: 5,
      coursesInprogress: 3
    },
    {
      programName: 'Program5',
      coursesCompleted: 8,
      coursesNotStarted: 4,
      coursesInprogress: 1
    },
    {
      programName: 'Program6',
      coursesCompleted: 25,
      coursesNotStarted: 2,
      coursesInprogress: 0
    }
  ]

  constructor(private http: HttpHelper) { }

  public GetEmployeeStats(employee: EmployeeModel):Observable<ChartApiModel[]> {
    //return this.http.get('api/LearningTrack/GetEmployeeStats/' + userID);
    return this.http.post('api/LearningTrack/GetEmployeeStats',employee);
    //return of(this.data);
  }

  public GetProgramsStats(employee: EmployeeModel): Observable<ChartApiModel[]> {
    //return this.http.get('api/LearningTrack/GetEmployeeStats/' + userID);
    return this.http.post('api/LearningTrack/GetProgramStats', employee);
    //return of(this.data);
  }
  public GetPendingRequestCount(userID: number): Observable<any> | null  {
    return this.http.get("api/Request/GetPendingRequestCount?requestUserID=" + userID);
  }
  public GetApprovedRequestCount(userID: number) :Observable<any> | null
  {
  return this.http.get("api/Request/GetApprovedRequestCount?requestUserID=" + userID);
  }
public GetEmployeeCompletedCourseCount(userID: number):Observable<any> | null 
  {
  return this.http.get("api/Course/GetEmployeeCompletedCourseCount?UserID="+userID);
  }
}
