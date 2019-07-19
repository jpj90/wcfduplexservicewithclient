import { Component, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { SignalRConnection } from 'ng2-signalr';
import { untilComponentDestroyed } from "@w11k/ngx-componentdestroyed";
import { ActivatedRoute } from '@angular/router';
import { BroadCastEventListenerMod } from 'src/app/infrastructure/broadcasteventlistener.mod';


@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.sass']
})
export class ChildComponent implements OnInit, OnDestroy {

  signalRConnection: SignalRConnection;

  constructor(
    private activatedRoute: ActivatedRoute,
    private httpClient: HttpClient
  ) {
    this.signalRConnection = this.activatedRoute.snapshot.data["connection"];
    console.log(this.signalRConnection);
  }

  ngOnInit() {
    if (this.signalRConnection != null) {
      this.signalRConnection.start()
      .then(() => console.log("SignalR Connection resolved and started"))
      .catch(error => console.error("Error during resolving SignalR connection: " + error));
      this.addListener();
    }
    else
      console.error("SignalR connection not resolved");
  }

  addListener() {
    const onDisplay$ = new BroadCastEventListenerMod<any>("display");
    this.signalRConnection.listen(onDisplay$);
    onDisplay$
    .pipe(untilComponentDestroyed(this)) //ensure unsubscribe on component destroyed
    .subscribe((value: string) => this.addNodeToDom(value));
  }

  callApi() {
    this.httpClient.get('http://localhost:59033/api/default/callwcf')
    .pipe(untilComponentDestroyed(this)) //ensure unsubscribe on component destroyed
    .subscribe(resultMessage => console.log(resultMessage));
  }

  addNodeToDom(content: string) {
    const parent = document.getElementById('messages');
    const li = document.createElement('li');
    li.setAttribute('style', 'font-weight: bold');
    li.textContent = `Value received from WCF/API/SignalR is: ${content}`;
    if (parent != null)
      parent.appendChild(li)
  }

  ngOnDestroy() {}
}
