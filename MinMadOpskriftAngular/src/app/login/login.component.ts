import { TokenStorageService } from './../token-storage.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';
import { Opskrift } from '../opskrift';
import { Bruger } from '../bruger';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  id: number;
  bruger: Bruger;
  //submitted: boolean = false;

  form: any = {
    email: null,
    password: null
  };
 
  constructor(private apiService: ApiService, private route: ActivatedRoute, private router: Router,
     private tokenStorage: TokenStorageService) { }

  ngOnInit(): void{
    
  }

  onSubmit() {
   const { email, password} = this.form;

    this.apiService.login(email, password).subscribe((data: Bruger) => {
      this.bruger = data;
      
      if (data == null) {
       
        alert("eafsdsdfe");
      }
      else {
        this.tokenStorage.saveToken("brugernavn", this.bruger.brugernavn);
        this.tokenStorage.saveToken("alder", String(this.bruger.alder));
        this.tokenStorage.saveToken("email", this.bruger.email);
        this.tokenStorage.saveToken("id", String(this.bruger.id));
        
        console.log(this.tokenStorage.getCostumToken("brugernavn"));
        this.reloadPage();
      } 
    })
  }

  reloadPage(): void {
    window.location.reload();
  }

}
