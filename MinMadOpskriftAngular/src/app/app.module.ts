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

@NgModule({
  declarations: [
    AppComponent,
    ForsideComponent,
    OpretBrugerComponent,
    OpretOpskriftComponent,
    OpskriftComponent,
    NavComponent
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
