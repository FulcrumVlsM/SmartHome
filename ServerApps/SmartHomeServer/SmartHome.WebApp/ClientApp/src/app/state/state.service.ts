import * as signalR from '@aspnet/signalr';
import { State } from "./state";


export class StateService {
    private handlers: { (state: State): void; }[] = [];
    private hubConnection: signalR.HubConnection;

    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl('http://localhost:2133/api/state')
            .build();

        this.hubConnection
            .start()
            .then(() => console.log('Connection started'))
            .catch(err => console.log('Error while starting connection ' + err));
    }

    public addReceiveDataListener = () => {
        console.log('StateServiceaddReceiveDataListener()')
        this.hubConnection.on('receiveStateData', (data) => {
            const state: State = data;
            console.log(state);
            this.trigger(state);
        });
    }

    public addReceiveDataHandler(handler: { (state: State): void }): void {
        this.handlers.push(handler);
    }

    public removeReceiveDataHandler(handler: { (state: State): void }): void {
        this.handlers = this.handlers.filter(h => h !== handler);
    }

    private trigger(state: State) {
        this.handlers.forEach(handler => handler(state));
    }
}