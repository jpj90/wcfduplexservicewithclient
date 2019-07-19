import { Subject } from "rxjs";

// modified version of BroadCastEventListener to work in es2018
export class BroadCastEventListenerMod<T> extends Subject<T> {

    constructor(public event: string) {
        super();
        if (event == null || event === '') {
            throw new Error('Failed to create BroadcastEventListener. Argument \'event\' cannot be empty');
        }
    }
}