import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bruger } from './data/Bruger';
import { Opskrift } from './data/Opskrift';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  opskriftUrl = "https://localhost:5001/api/Opskrift";
  brugerUrl = "https://localhost:5001/api/Bruger";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private http: HttpClient) { }

  getAllOpskrift(): Observable<Opskrift[]> {
    return this.http.get<Opskrift[]>(this.opskriftUrl);
  }

  createBruger(bruger: Bruger): Observable<Bruger> {
    return this.http.post<Bruger>(this.brugerUrl, JSON.stringify(bruger), this.httpOptions)
  }
}
