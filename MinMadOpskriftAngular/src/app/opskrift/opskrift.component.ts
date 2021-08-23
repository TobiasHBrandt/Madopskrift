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
    
    this.getOpskrift(this.id);
  }

  getOpskrift(id): void {
    this.id = this.route.snapshot.params['id']
    this.apiService.getOpskriftById(id).subscribe((data: Opskrift) => {
      this.opskrift = data;
    })
  }
}
