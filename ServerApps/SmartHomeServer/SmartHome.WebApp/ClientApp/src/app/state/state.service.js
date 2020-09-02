"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var signalR = require("@aspnet/signalr");
var StateService = /** @class */ (function () {
    function StateService() {
        var _this = this;
        this.startConnection = function () {
            _this.hubConnection = new signalR.HubConnectionBuilder()
                .withUrl('http://localhost:2133/api/state')
                .build();
            _this.hubConnection
                .start()
                .then(function () { return console.log('Connection started'); })
                .catch(function (err) { return console.log('Error while starting connection ' + err); });
        };
        this.addReceiveDataListener = function () {
            console.log('StateServiceaddReceiveDataListener()');
            _this.hubConnection.on('receiveStateData', function (data) {
                _this.data = data;
                console.log(data);
            });
        };
    }
    return StateService;
}());
exports.StateService = StateService;
//# sourceMappingURL=state.service.js.map