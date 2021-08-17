import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { Opskrift } from '../data/Opskrift';

@Component({
  selector: 'app-forside',
  templateUrl: './forside.component.html',
  styleUrls: ['./forside.component.scss']
})
export class ForsideComponent implements OnInit {

  // opskrift: Opskrift[] = [];
     opskrift: Opskrift[] = [];

  constructor(public dataService: DataService, private changeDetectorRef: ChangeDetectorRef) { }


  ngOnInit(): void {
    this.dataService.getAllOpskrift().subscribe(data => {
      this.opskrift = data;
      console.log(this.opskrift);
    })
    // this.dataService.getAllOpskrift().subscribe(data => this.opskrift = data)
  }

}
