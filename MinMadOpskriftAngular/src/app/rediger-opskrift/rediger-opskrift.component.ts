import { Opskrift } from './../opskrift';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-rediger-opskrift',
  templateUrl: './rediger-opskrift.component.html',
  styleUrls: ['./rediger-opskrift.component.scss']
})
export class RedigerOpskriftComponent implements OnInit {

  id: number;
  data: any;
  opskrift: Opskrift;
  submitted: boolean = false;
  form: FormGroup;

  constructor(private apiService: ApiService, private route: ActivatedRoute,
     private router: Router, private formbuilder: FormBuilder) { }

  ngOnInit(): void{

    const routeParams = this.route.snapshot.paramMap;
    this.id = Number(routeParams.get('id'));
    this.apiService.getOpskriftById(this.id).subscribe((data: Opskrift) => {
      this.opskrift = data;
      console.log(data);
    })
    this.form = this.formbuilder.group({
      "titel": ['', Validators.required],
      "beskrivelse": ['', Validators.required],
      "ingredienser": ['', Validators.required]
      
    })
  }

  onSubmit() {
    
    this.apiService.updateOpskrift(this.form.value, this.id)
    .subscribe(data => {
      this.router.navigateByUrl('');
    });
  }
}
