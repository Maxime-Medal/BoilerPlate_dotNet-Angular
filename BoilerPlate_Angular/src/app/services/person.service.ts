import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap } from 'rxjs';
import { IPerson, IPersonDTO, Person } from '../models/person.model';
import { Skill } from '../models/skill.model';

const API_BASE_URL = 'https://localhost:7075/api';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient) {}

  getList(): Observable<Person[]> {
    return this.http
      .get<IPersonDTO[]>(`${API_BASE_URL}/Personne/GetAllPersonnes`)
      .pipe(
        map((persons) =>
          persons.map(
            (person) =>
              new Person(person)
          )
        ),
        catchError((err) =>
          of([])
        )
      );
  }

  createPerson(person: IPerson): Observable<IPerson> {
    const headerDict = {
      'Content-Type': 'application/json',
      Accept: 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin': '*',
    };

    const requestOptions = {
      headers: new HttpHeaders(headerDict),
    };

    return this.http.post<IPerson>(
      `${API_BASE_URL}user`,
      {
        ...person,
      },
      requestOptions
    );
  }
}
