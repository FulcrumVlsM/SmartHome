import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { StateComponent } from './state.component';
import { TemperatureStateComponent } from './temperature.state.component';
import { HumidityStateComponent } from './humidity.state.component';
import { DioxideStateComponent } from './dioxide.state.component';
import { ActiveDevicesStateComponent } from './active_devices.state.component';
import { StateService } from './state.service'

@NgModule({
    imports: [BrowserModule, HttpClientModule],
    declarations: [StateComponent, TemperatureStateComponent, HumidityStateComponent, DioxideStateComponent, ActiveDevicesStateComponent],
    bootstrap: [StateComponent],
    exports: [StateComponent],
    providers: [StateService]
})
export class StateModule { }