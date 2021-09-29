
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';
import { Bruger } from '../bruger';
import { TokenStorageService } from '../token-storage.service';

@Component({
  selector: 'app-profil-side',
  templateUrl: './profil-side.component.html',
  styleUrls: ['./profil-side.component.scss']
})
export class ProfilSideComponent implements OnInit {

  id: number;
  form: FormGroup;
  brugernavn: string;
  alder: number;
  email: string;
  test: string = "ewfeflp";
  

  constructor(private apiService: ApiService, private router: Router,
     private tokenStorage: TokenStorageService) { }

  ngOnInit(): void{

    
    
    // henter værdien fra token
    this.brugernavn = this.tokenStorage.getCostumToken("brugernavn");
    this.alder = Number(this.tokenStorage.getCostumToken("alder"));
    this.email = this.tokenStorage.getCostumToken("email");
   
    /* her er der angivet værdier som også er 
    tilknyttet formControllerName på input tagget i html*/
    this.form = new FormGroup({
      Brugernavn: new FormControl(''),
      Alder: new FormControl(''),
      Email: new FormControl(''),
      })
  }

  // kalder på metoden i apiservice med værdierne fra formgroup
  onSubmit() {
    
    this.apiService.updateBruger(this.form.value, Number(this.tokenStorage.getCostumToken("id")))
    .subscribe();
  }

  deleteBruger(){
    this.apiService.deleteBruger(this.tokenStorage.getCostumToken("id")).subscribe(res => {
      this.id = Number(res);
      this.router.navigateByUrl('');
    })
  }

}
