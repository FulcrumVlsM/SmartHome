import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';
import { State } from './state';
import { TemperatureSensor } from './temperature_sensor.state';


@Component({
    selector: 'temperature-state',
    templateUrl: './temperature.state.component.html'
})
export class TemperatureStateComponent implements OnInit {
    public averageTemp: number = 0;
    public sensors: TemperatureSensor[] = [];
    public history: [Date, number][] = [];

    constructor(public stateService: StateService) { }

    ngOnInit(): void {
        this.stateService.addReceiveDataHandler(this.updateState);
    }


    private updateState = (state: State) => {
        this.averageTemp = state.temperatureState.average;
        this.sensors = state.temperatureState.sensors;
        this.history = state.temperatureState.history;
    }
    
}