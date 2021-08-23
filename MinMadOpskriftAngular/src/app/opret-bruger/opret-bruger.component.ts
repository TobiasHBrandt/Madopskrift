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
      "Brugernavn": ['', Validators.required],
      "Password": ['', Validators.required],
      "Alder": ['', Validators.required],
      "Email": ['', Validators.required]
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

  // ngOnInit(): void {
  //   this.form = new FormGroup({
  //     Brugernavn: new FormControl('', [Validators.required]),
  //     Password: new FormControl('', [Validators.required]),
  //     Alder: new FormControl('', [Validators.required]),
  //     Email: new FormControl('', [Validators.required])
  //   });
  // }

  // submit(){
  //   console.log(this.form.value);
  //   this.apiService.createOpskrift(this.form.value);
  //   this.router.navigateByUrl('')
  // }

}
