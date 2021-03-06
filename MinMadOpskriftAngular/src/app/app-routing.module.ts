import { OpskriftComponent } from './opskrift/opskrift.component';
import { OpretBrugerComponent } from './opret-bruger/opret-bruger.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ForsideComponent } from './forside/forside.component';
import { OpretOpskriftComponent } from './opret-opskrift/opret-opskrift.component';
import { MineOpskrifterComponent } from './mine-opskrifter/mine-opskrifter.component';
import { RedigerOpskriftComponent } from './rediger-opskrift/rediger-opskrift.component';
import { LoginComponent } from './login/login.component';
import { ProfilSideComponent } from './profil-side/profil-side.component';


const routes: Routes = [{ path: '', component: ForsideComponent},
{ path: 'opretOpskrift', component: OpretOpskriftComponent},
{ path: 'opretBruger', component: OpretBrugerComponent},
{ path: 'opskrift/:Id', component: OpskriftComponent},
{ path: 'mineOpskrifter', component: MineOpskrifterComponent},
{ path: 'redigerOpskrift/:id', component: RedigerOpskriftComponent},
{ path: 'login', component: LoginComponent},
{ path: 'profil', component: ProfilSideComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponent = {ForsideComponent, OpretOpskriftComponent, OpretBrugerComponent,
OpskriftComponent, MineOpskrifterComponent, RedigerOpskriftComponent, LoginComponent, ProfilSideComponent};
