import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shape } from '../Models/shape';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ShapesService {
  public shapes = Observable<Shape>;
  private shapeUrl = `${environment.apiUrl}/Shapes`;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private _http: HttpClient
  ) { }

  public getShapes(): Observable<Shape[]> {
    return this._http.get<Shape[]>(this.shapeUrl)
  }
}
