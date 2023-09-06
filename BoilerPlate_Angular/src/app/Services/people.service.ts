import { Injectable } from '@angular/core';
import { People } from '../Models/people';
import { environment } from 'src/environments/environment.development';
import { BehaviorSubject, Observable, concatWith, of, tap } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {
  public peoples: People[] = [];
  public peoples$ = new BehaviorSubject<People[]>(null)
  private peopleUrl = `${environment.apiUrl}/People`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private _http: HttpClient
  ) {
    this.getPeoples().subscribe();
  }

  public getPeoples(): Observable<People[]> {
    return of(this.peoples)
      .pipe(
        concatWith(this._http.get<People[]>(this.peopleUrl)),
        tap((p) => {
          this.peoples = p;
          this.peoples$.next(p);
        })
      );
  }

  public sendPeople(people: People): Observable<People> {
    return this._http.post<People>(this.peopleUrl, people);
  }
}
