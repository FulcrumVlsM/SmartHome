var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { StateComponent } from './state.component';
import { TemperatureStateComponent } from './temperature.state.component';
import { HumidityStateComponent } from './humidity.state.component';
import { DioxideStateComponent } from './dioxide.state.component';
let StateModule = class StateModule {
};
StateModule = __decorate([
    NgModule({
        imports: [BrowserModule, HttpClientModule],
        declarations: [StateComponent, TemperatureStateComponent, HumidityStateComponent, DioxideStateComponent],
        bootstrap: [StateComponent],
        exports: [StateComponent]
    })
], StateModule);
export { StateModule };
//# sourceMappingURL=state.module.js.map