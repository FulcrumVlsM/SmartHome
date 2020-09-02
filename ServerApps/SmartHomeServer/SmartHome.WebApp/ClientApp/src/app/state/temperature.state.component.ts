import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';


@Component({
    selector: 'temperature-state',
    templateUrl: './temperature.state.component.html'
})
export class TemperatureStateComponent implements OnInit {

    constructor(private stateService: StateService) { }

    ngOnInit(): void {
        
    }
    
}