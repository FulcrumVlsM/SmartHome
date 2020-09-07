import * as signalR from '@aspnet/signalr';
export class StateService {
    constructor() {
        this.handlers = [];
        this.startConnection = () => {
            this.hubConnection = new signalR.HubConnectionBuilder()
                .withUrl('http://localhost:2133/api/state')
                .build();
            this.hubConnection
                .start()
                .then(() => console.log('Connection started'))
                .catch(err => console.log('Error while starting connection ' + err));
        };
        this.addReceiveDataListener = () => {
            console.log('StateServiceaddReceiveDataListener()');
            this.hubConnection.on('receiveStateData', (data) => {
                const state = data;
                console.log(state);
                this.trigger(state);
            });
        };
    }
    addReceiveDataHandler(handler) {
        this.handlers.push(handler);
    }
    removeReceiveDataHandler(handler) {
        this.handlers = this.handlers.filter(h => h !== handler);
    }
    trigger(state) {
        this.handlers.forEach(handler => handler(state));
    }
}
//# sourceMappingURL=state.service.js.map