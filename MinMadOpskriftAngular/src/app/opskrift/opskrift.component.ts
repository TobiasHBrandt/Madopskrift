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
  constructor(private apiService: ApiService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    
    //this.id = this.route.params['id']
    // this.route.params.subscribe(data2 => {
    //   this.id = data2.id;
    // })
    const routeParams = this.route.snapshot.paramMap;
    this.id = Number(routeParams.get('id'));
    this.apiService.getOpskriftById(this.id).subscribe((data: Opskrift) => {
      this.opskrift = data;
      console.log(data);
      // this.opskrift = new Opskrift();
      // this.opskrift.titel = "bacon";
    });
  }

  getOpskrift(): void {
    
  }
}
