import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'
import { SignalRModule } from "ng2-signalr";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignalRConnectionResolver } from './infrastructure/connectionresolver.signalr';
import { createSignalRConfiguration } from './infrastructure/createSignalRConfiguration';
import { ChildComponent } from './components/child/child.component';

@NgModule({
  declarations: [
    AppComponent,
    ChildComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SignalRModule.forRoot(createSignalRConfiguration)
  ],
  providers: [SignalRConnectionResolver],
  bootstrap: [AppComponent]
})
export class AppModule { }
