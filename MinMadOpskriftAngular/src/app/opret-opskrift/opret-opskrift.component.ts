import { ApiService } from './../api.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-opret-opskrift',
  templateUrl: './opret-opskrift.component.html',
  styleUrls: ['./opret-opskrift.component.scss']
})
export class OpretOpskriftComponent implements OnInit {

  submitted: boolean = false;
  form: FormGroup;

  constructor(private apiService: ApiService, private router: Router, private formbuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formbuilder.group({
      "titel": [],
      "beskrivelse": [],
      "ingredienser": [],
      "fremgangsmoede": []
    })
  }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.apiService.createOpskrift(this.form.value)
    .subscribe(data => {
      this.router.navigateByUrl('');
    });
  }

  

}
