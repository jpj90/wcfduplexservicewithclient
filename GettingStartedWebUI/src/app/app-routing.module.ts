import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SignalRConnectionResolver } from './infrastructure/connectionresolver.signalr';
import { ChildComponent } from './components/child/child.component';

const routes: Routes = [
  { path: '', component: ChildComponent, resolve: { connection: SignalRConnectionResolver } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
