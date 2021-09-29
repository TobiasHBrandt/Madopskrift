import { Opskrift } from './../opskrift';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-opskrift',
  templateUrl: './opskrift.component.html',
  styleUrls: ['./opskrift.component.scss']
})
export class OpskriftComponent implements OnInit {

  id: number;
  opskrift: Opskrift;

  currentOpskrift = null;
  constructor(private apiService: ApiService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    const routeParams = this.route.snapshot.paramMap;
    this.id = Number(routeParams.get('Id'));
    this.apiService.getOpskriftById(this.id).subscribe((data: Opskrift) => {
      this.opskrift = data;
      console.log(data);
    });
  }

  getOpskrift(): void {
    
  }
}
