﻿import { Component, OnInit } from '@angular/core';
import { StateService } from './state.service';


@Component({
    selector: 'dioxide-state',
    templateUrl: './dioxide.state.component.html'
})
export class DioxideStateComponent implements OnInit {

    constructor(private stateService: StateService) { }

    ngOnInit(): void {
        
    }

}