import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ForsideComponent } from './forside/forside.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { OpskriftComponent } from './opskrift/opskrift.component';

@NgModule({
  declarations: [
    AppComponent,
    ForsideComponent,
    NavBarComponent,
    OpskriftComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
