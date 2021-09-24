import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-opret-bruger',
  templateUrl: './opret-bruger.component.html',
  styleUrls: ['./opret-bruger.component.scss']
})
export class OpretBrugerComponent implements OnInit {

  // det samler værdierne og holder styr på det
  form: FormGroup;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void{

    /* her er der angivet værdier som også er 
    tilknyttet formControllerName på input tagget i html*/
    this.form = new FormGroup({
      Brugernavn: new FormControl(''),
      Password: new FormControl(''),
      Alder: new FormControl(''),
      Email: new FormControl(''),
      })

      // this.form = this.formbuilder.group({
    //   "Brugernavn": ['', Validators.minLength(2)],
    //   "Password": ['', Validators.minLength(6)],
    //   "Alder": [],
    //   "Email": ['', Validators.minLength(4)]
    // })
  }

  // kalder på metoden i apiservice med værdierne fra formgroup
  onSubmit() {
    
    this.apiService.createBruger(this.form.value)
    .subscribe();
  }

}
