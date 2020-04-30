import { Component, OnInit } from '@angular/core';
import { BoolSensorDataService } from './bool_sensor.data.service';
import { BoolSensor } from './bool_sensor';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [BoolSensorDataService]
})
export class AppComponent implements OnInit {

    sensor: BoolSensor = new BoolSensor();
    sensors: BoolSensor[];
    tableMode: boolean = true;

    constructor(private dataService: BoolSensorDataService) { }

    ngOnInit() {
        this.loadSensors();
    }

    loadSensors() {
        this.dataService.getSensors().subscribe((data: BoolSensor[]) => this.sensors = data);
    }

    save() {
        if (this.sensor.ID == null) {
            this.dataService.createSensor(this.sensor).subscribe((data: BoolSensor) => this.sensors.push(data));
        }
        else {
            this.dataService.updateSensor(this.sensor).subscribe(data => this.loadSensors());
        }
        this.cancel();
    }

    editSensor(sensor: BoolSensor) {
        this.sensor = sensor;
    }

    cancel() {
        this.sensor = new BoolSensor();
        this.tableMode = true;
    }

    delete(sensor: BoolSensor) {
        this.dataService.deleteSensor(sensor.ID).subscribe(data => this.loadSensors());
    }

    add() {
        this.cancel();
        this.tableMode = false;
    }
}