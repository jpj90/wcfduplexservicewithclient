import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { SignalR, BroadcastEventListener } from 'ng2-signalr';
import { SignalRConnectionResolver } from './infrastructure/connectionresolver.signalr';
import { SignalRConnection } from 'ng2-signalr';
import { untilComponentDestroyed } from "@w11k/ngx-componentdestroyed";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'WCF Duplex / Web API / SignalR project';
  ngOnInit() {}
  ngOnDestroy() {}
}
