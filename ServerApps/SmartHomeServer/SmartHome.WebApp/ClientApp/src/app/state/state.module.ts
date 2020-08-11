import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { StateComponent } from './state.component';
import { TemperatureStateComponent } from './temperature.state.component';
import { HimidityStateComponent } from './himidity.state.component';
import { DioxideStateComponent } from './dioxide.state.component'

@NgModule({
    imports: [BrowserModule, HttpClientModule],
    declarations: [StateComponent, TemperatureStateComponent, HimidityStateComponent, DioxideStateComponent],
    bootstrap: [StateComponent]
})
export class StateModule { }