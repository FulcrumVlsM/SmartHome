import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';


@Component({
    selector: 'active-devices',
    templateUrl: './active_devices.state.component.html'
})
export class ActiveDevicesStateComponent implements OnInit {

    constructor(private stateService: StateService) { }

    ngOnInit(): void {

    }

}