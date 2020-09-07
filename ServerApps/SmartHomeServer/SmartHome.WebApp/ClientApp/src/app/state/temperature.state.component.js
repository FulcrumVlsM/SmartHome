var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
let TemperatureStateComponent = class TemperatureStateComponent {
    constructor(stateService) {
        this.stateService = stateService;
        this.averageTemp = 0;
        this.sensors = [];
        this.history = [];
        this.updateState = (state) => {
            this.averageTemp = state.temperatureState.average;
            this.sensors = state.temperatureState.sensors;
            this.history = state.temperatureState.history;
        };
    }
    ngOnInit() {
        this.stateService.addReceiveDataHandler(this.updateState);
    }
};
TemperatureStateComponent = __decorate([
    Component({
        selector: 'temperature-state',
        templateUrl: './temperature.state.component.html'
    })
], TemperatureStateComponent);
export { TemperatureStateComponent };
//# sourceMappingURL=temperature.state.component.js.map