import { Resolve } from "@angular/router";
import { SignalR, SignalRConnection, IConnectionOptions } from "ng2-signalr";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable(({providedIn: "root"}) as any)
export class SignalRConnectionResolver implements Resolve<SignalRConnection> {

    constructor(private readonly signalR: SignalR) {}

    resolve(): Observable<any> | Promise<any> | any {
        const options: IConnectionOptions = { url: "http://localhost:59033/"}
        return this.signalR.connect(options);
    }
}