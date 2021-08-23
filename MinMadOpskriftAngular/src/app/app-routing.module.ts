import { OpskriftComponent } from './opskrift/opskrift.component';
import { OpretBrugerComponent } from './opret-bruger/opret-bruger.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ForsideComponent } from './forside/forside.component';
import { OpretOpskriftComponent } from './opret-opskrift/opret-opskrift.component';


const routes: Routes = [{ path: '', component: ForsideComponent},
{ path: 'opretOpskrift', component: OpretOpskriftComponent},
{ path: 'opretBruger', component: OpretBrugerComponent},
{ path: 'opskrift/:id/show', component: OpskriftComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponent = {ForsideComponent, OpretOpskriftComponent, OpretBrugerComponent,
OpskriftComponent};
