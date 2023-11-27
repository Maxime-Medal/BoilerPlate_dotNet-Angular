import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap } from 'rxjs';
import { IPerson, Person } from '../models/person.model';

const API_BASE_URL = 'https://localhost:7075/api';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient) { }

  getAllPersonne(): Observable<Person[]> {
    return this.http.get<Person[]>(`${API_BASE_URL}/Personne/GetAllPersonnes`)
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
