import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-mine-opskrifter',
  templateUrl: './mine-opskrifter.component.html',
  styleUrls: ['./mine-opskrifter.component.scss']
})
export class MineOpskrifterComponent implements OnInit {

  opskrifts: [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.getAllOpskrift();
    
  }

  getAllOpskrift(): void {
    this.apiService.getOpskrift().subscribe((data: any) => {
      this.opskrifts = data;
    })
  }

}
