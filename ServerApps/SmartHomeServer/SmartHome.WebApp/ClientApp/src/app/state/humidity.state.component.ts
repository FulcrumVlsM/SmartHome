import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';


@Component({
    selector: 'humidity-state',
    templateUrl: './humidity.state.component.html'
})
export class HumidityStateComponent implements OnInit {

    constructor(private stateService: StateService) { }

    ngOnInit(): void {
        
    }

}