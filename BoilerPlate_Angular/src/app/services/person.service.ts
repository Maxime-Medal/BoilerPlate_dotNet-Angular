import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { IPerson, Person } from '../models/person.model';
import { ELEMENT_DATA } from './mock';

const API_BASE_URL = 'http://localhost:3000/api/v1/';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient) {}

  getList(): Observable<Person[]> {
    console.log(
      new Person(
        'person.id',
        'person.lastName',
        'person.firstName',
        new Date('1997/08/19').toString(),
        []
      )
    );

    return this.http.get<IPerson[]>(`${API_BASE_URL}users`).pipe(
      map((persons) =>
        persons.map(
          (person) =>
            new Person(
              person.id,
              person.lastName,
              person.firstName,
              person.birthDate,
              person.skills
            )
        )
      ),
      catchError((err) =>
        of([
          new Person(
            'person.id',
            'Bernard',
            'Pouet',
            new Date('1997/08/19').toString(),
            [
              {
                id: '1',
                level: 2,
                type: 'Oui',
                name: 'Pouet',
              },
            ]
          ),
        ])
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
