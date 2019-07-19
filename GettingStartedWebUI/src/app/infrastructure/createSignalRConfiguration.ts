import { SignalRConfiguration } from "ng2-signalr";

export function createSignalRConfiguration() {
    const config = new SignalRConfiguration();
    config.hubName = 'mathHub';
    config.withCredentials = true;
    config.url = ''; // filled on connect
    config.logging = false;
    return config;
}