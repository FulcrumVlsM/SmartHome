import { TemperatureSensor } from "./temperature_sensor.state";

export class TemperatureState {
    constructor(
        public Average?: number,
        public Sensors?: Array<TemperatureSensor>,
        public History?: Array<[Date, number]>
    ) { }
}