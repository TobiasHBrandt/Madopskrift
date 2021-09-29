import { Injectable } from '@angular/core';

const TOKEN_KEY = "auth-token";
const USER_KEY = "auth-bruger";

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor() { }

  signOut(): void {
    window.sessionStorage.clear();
  }

  

  public saveToken(token: string, value: string): void {
    // window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(token, value);
  }

 

  public getCostumToken(token: string): string | null {
    return window.sessionStorage.getItem(token);
  }

  
  
}
