import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Opskrift } from '../data/Opskrift';

@Component({
  selector: 'app-forside',
  templateUrl: './forside.component.html',
  styleUrls: ['./forside.component.scss']
})
export class ForsideComponent implements OnInit {

  opskrift: Opskrift[] = [];

  constructor(public dataService: DataService) { }


  ngOnInit(): void {
    this.dataService.getAllOpskrift().subscribe((data: Opskrift[]) => {
      this.opskrift = data;
      
    })
  }

}
