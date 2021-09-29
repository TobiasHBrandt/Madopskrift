import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../token-storage.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  brugernavn: string;
  isLoggedIn: boolean = false;

  constructor(private tokenStorage: TokenStorageService) { }

  ngOnInit(): void {
    this.brugernavn = this.tokenStorage.getCostumToken("brugernavn");
    if (this.brugernavn != null) {
      this.isLoggedIn = true;
    }
  }

  onSubmit() {
    this.tokenStorage.signOut();
    this.reloadPage();
  }

  reloadPage(): void {
    window.location.reload();

  }

}
