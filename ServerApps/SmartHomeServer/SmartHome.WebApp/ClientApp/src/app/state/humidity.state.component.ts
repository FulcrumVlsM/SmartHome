import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';
import { HumiditySensor } from './humidity_sensor.state';
import { State } from './state';


@Component({
    selector: 'humidity-state',
    templateUrl: './humidity.state.component.html'
})
export class HumidityStateComponent implements OnInit {
    public averageHumid: number = 0;
    public sensors: HumiditySensor[] = [];

    constructor(private stateService: StateService) { }

    ngOnInit(): void {
        this.stateService.addReceiveDataHandler(this.updateState);
    }

    private updateState = (state: State) => {
        this.averageHumid = state.humidityState.average;
        this.sensors = state.humidityState.sensors;
    }
}