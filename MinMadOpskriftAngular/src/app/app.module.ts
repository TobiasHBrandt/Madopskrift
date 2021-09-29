import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { ForsideComponent } from './forside/forside.component';
import { OpretBrugerComponent } from './opret-bruger/opret-bruger.component';
import { OpretOpskriftComponent } from './opret-opskrift/opret-opskrift.component';
import { ApiService } from './api.service';
import { OpskriftComponent } from './opskrift/opskrift.component';
import { NavComponent } from './nav/nav.component';
import { MineOpskrifterComponent } from './mine-opskrifter/mine-opskrifter.component';
import { RedigerOpskriftComponent } from './rediger-opskrift/rediger-opskrift.component';
import { LoginComponent } from './login/login.component';
import { ProfilSideComponent } from './profil-side/profil-side.component';

@NgModule({
  declarations: [
    AppComponent,
    ForsideComponent,
    OpretBrugerComponent,
    OpretOpskriftComponent,
    OpskriftComponent,
    NavComponent,
    MineOpskrifterComponent,
    RedigerOpskriftComponent,
    LoginComponent,
    ProfilSideComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
