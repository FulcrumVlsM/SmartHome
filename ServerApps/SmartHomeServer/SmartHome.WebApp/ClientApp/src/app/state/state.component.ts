import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';


@Component({
    selector: 'state',
    templateUrl: './state.component.html'
})
export class StateComponent implements OnInit {

    constructor(private stateService: StateService) { }


    ngOnInit(): void {
        this.stateService.startConnection();
        this.stateService.addReceiveDataListener();
        console.log('StateComponent OnInit(). stateService connection started.')
    }

}