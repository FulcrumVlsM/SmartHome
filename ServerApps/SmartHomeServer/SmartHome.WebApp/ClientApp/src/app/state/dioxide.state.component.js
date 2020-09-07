var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
let DioxideStateComponent = class DioxideStateComponent {
    constructor(stateService) {
        this.stateService = stateService;
        this.averageLevel = 0;
        this.sensors = [];
        this.updateState = (state) => {
            this.averageLevel = state.dioxideState.average;
            this.sensors = state.dioxideState.sensors;
        };
    }
    ngOnInit() {
        this.stateService.addReceiveDataHandler(this.updateState);
    }
};
DioxideStateComponent = __decorate([
    Component({
        selector: 'dioxide-state',
        templateUrl: './dioxide.state.component.html'
    })
], DioxideStateComponent);
export { DioxideStateComponent };
//# sourceMappingURL=dioxide.state.component.js.map