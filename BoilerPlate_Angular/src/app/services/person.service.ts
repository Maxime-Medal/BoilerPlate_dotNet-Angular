import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, tap } from 'rxjs';
import { IPerson, Person } from '../models/person.model';
import { Skill } from '../models/skill.model';

const API_BASE_URL = 'https://localhost:7075/api';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private http: HttpClient) {}

  getList(): Observable<Person[]> {
    return this.http
      .get<IPerson[]>(`${API_BASE_URL}/Personne/GetAllPersonnes`)
      .pipe(
        map((persons) =>
          persons.map(
            (person) =>
              new Person(
                person.id,
                person.lastName,
                person.firstName,
                person.birthDate,
                person.skills.map(
                  (skill) =>
                    new Skill(skill.id, skill.name, skill.type, skill.level)
                )
              )
          )
        ),
        catchError((err) =>
          of([
            new Person(
              'person3',
              'Antoine',
              'Test',
              new Date('1997/08/19').toString(),
              [
                new Skill('1', 'Communiquante', 'simple', 5),
                new Skill('2', 'Aimable', 'difficile', 2),
                new Skill('3', 'Aimable', 'difficile', 3),
              ]
            ),
            new Person(
              'person3',
              'Poui',
              'Moui',
              new Date('1997/08/19').toString(),
              [
                new Skill('1', 'Communiquante', 'simple', 1),
                new Skill('2', 'Aimable', 'difficile', 2),
                new Skill('3', 'Aimable', 'difficile', 2),
                new Skill('4', 'Aimable', 'difficile', 2),
                new Skill('5', 'Aimable', 'difficile', 2),
              ]
            ),
            new Person(
              'person2',
              'Diane',
              'Nom',
              new Date('1984/08/14').toString(),
              [new Skill('1', 'Communiquante', 'simple', 5)]
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
