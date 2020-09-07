import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';
import { DioxideSensor } from './dioxide_sensor.state';
import { State } from './state';


@Component({
    selector: 'dioxide-state',
    templateUrl: './dioxide.state.component.html'
})
export class DioxideStateComponent implements OnInit {
    public averageLevel: number = 0;
    public sensors: DioxideSensor[] = [];

    constructor(private stateService: StateService) { }

    ngOnInit(): void {
        this.stateService.addReceiveDataHandler(this.updateState);
    }

    private updateState = (state: State) => {
        this.averageLevel = state.dioxideState.average;
        this.sensors = state.dioxideState.sensors;
    }
}