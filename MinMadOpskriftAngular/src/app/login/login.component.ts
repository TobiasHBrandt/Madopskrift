import { TokenStorageService } from './../token-storage.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: any = {
    email: null,
    password: null
  };
  isLoggedIn = false;
  isLoginFailed = false;
  roles: string[] = [];

  submitted: boolean = false;
  

  constructor(private apiService: ApiService, private router: Router,
     private tokenStorage: TokenStorageService) { }

  ngOnInit(): void{
   if (this.tokenStorage.getToken()) {
     this.isLoggedIn = true;
     this.roles = this.tokenStorage.getBruger().roles;
   }
  }

  onSubmit() {
   const { email, password} = this.form;

   this.apiService.login(email, password).subscribe(data => {
     this.tokenStorage.saveToken(data.accessToken);
     this.tokenStorage.saveBruger(data);

     this.isLoginFailed = false;
     this.isLoggedIn = true;
     this.roles = this.tokenStorage.getBruger().roles;
     this.reloadPage();
   })
  }

  reloadPage(): void {
    window.location.reload();
  }

}
