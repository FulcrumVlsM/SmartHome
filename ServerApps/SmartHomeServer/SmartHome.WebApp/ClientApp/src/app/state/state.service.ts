import * as signalR from '@aspnet/signalr';
import { State } from "./state";


export class StateService {
    public data: State;

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
            this.data = data;
            console.log(data);
        });
    }
}