import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';
import { State } from './state';
import { BoolActionDevice } from './bool_action_device.state';


@Component({
    selector: 'active-devices',
    templateUrl: './active_devices.state.component.html'
})
export class ActiveDevicesStateComponent implements OnInit {
    public activeDevices: BoolActionDevice[] = [];

    constructor(private stateService: StateService) { }

    ngOnInit(): void {
        this.stateService.addReceiveDataHandler(this.updateState);
    }

    private updateState = (state: State) => {
        this.activeDevices = state.activeDevices;
    }
}