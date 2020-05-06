import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BoolSensor } from './bool_sensor';

@Injectable()
export class BoolSensorDataService {
    private url = "/api/BoolSensors";

    constructor(private http: HttpClient) { }

    getSensors() {
        return this.http.get(this.url);
    }

    getSensor(id: number) {
        return this.http.get(this.url + "/" + id);
    }

    createSensor(sensor: BoolSensor) {
        return this.http.post(this.url, sensor);
    }

    updateSensor(sensor: BoolSensor) {
        return this.http.put(this.url, sensor);
    }

    deleteSensor(id: number) {
        return this.http.delete(this.url + "/" + id);
    }
}