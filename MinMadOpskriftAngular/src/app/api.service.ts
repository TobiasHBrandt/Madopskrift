import { Bruger } from './bruger';
import { Opskrift } from './opskrift';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { catchError } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // api url i backend
  opskriftUrl = "https://localhost:5001/api/Opskrift";
  BrugerUrl = "https://localhost:5001/api/Bruger"
  Login = "https://localhost:5001/api/Bruger/login"

  // Angiver hvilken type af ressource det er som eksempel JSON
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  // Httpclient gør at mam kan lave http request
  constructor(private http: HttpClient) { }

  // methoderne returnere HTTP request

  getOpskrift(): Observable<Opskrift> {
    return this.http.get<Opskrift>(this.opskriftUrl)
  }

  getOpskriftById(id): Observable<any> {
    return this.http.get(this.opskriftUrl + "/" + id)
  }

  createOpskrift(data): Observable<Opskrift> {
    return this.http.post<Opskrift>(this.opskriftUrl, JSON.stringify(data), this.httpOptions)
  }
  
  createBruger(data): Observable<Bruger> {
    return this.http.post<Bruger>(this.BrugerUrl, JSON.stringify(data), this.httpOptions)
  }
  updateBruger(data, id): Observable<Bruger> {
    return this.http.put<Bruger>(this.BrugerUrl + "/" + id, JSON.stringify(data), this.httpOptions)
  }

  deleteBruger(id){
    return this.http.delete<Bruger>(this.BrugerUrl + "/" + id, this.httpOptions)
  }

  updateOpskrift(data, id): Observable<Opskrift> {
    return this.http.put<Opskrift>(this.opskriftUrl + "/" + Number(id), JSON.stringify(data), this.httpOptions)
  }

  deleteOpskrift(id){
    return this.http.delete<Opskrift>(this.opskriftUrl + "/" + id, this.httpOptions)
  }

  login(email: string, password: string): Observable<any> {
    return this.http.post<any>(this.Login, {email, password}, this.httpOptions)
  }
}
