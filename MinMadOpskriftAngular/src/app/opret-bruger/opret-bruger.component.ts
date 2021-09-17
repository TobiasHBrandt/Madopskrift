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

  submitted: boolean = false;
  form: FormGroup;

  constructor(private apiService: ApiService, private router: Router, private formbuilder: FormBuilder) { }

  ngOnInit(): void{
    this.form = this.formbuilder.group({
      "Brugernavn": ['', Validators.minLength(2)],
      "Password": ['', Validators.minLength(6)],
      "Alder": [],
      "Email": ['', Validators.minLength(4)]
    })
  }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.apiService.createBruger(this.form.value)
    .subscribe(data => {
      this.router.navigateByUrl('');
    });
  }

}
