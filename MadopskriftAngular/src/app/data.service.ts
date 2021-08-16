import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Opskrift } from './data/Opskrift';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  opskriftUrl = "https://localhost:5001/api/Opskrift";

  constructor(private http: HttpClient) { }

  getAllOpskrift(): Observable<Opskrift[]> {
    return this.http.get<Opskrift[]>(this.opskriftUrl);
  }
}
