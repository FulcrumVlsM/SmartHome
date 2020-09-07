import { TemperatureSensor } from "./temperature_sensor.state";

export class TemperatureState {
    constructor(
        public average?: number,
        public sensors?: Array<TemperatureSensor>,
        public history?: Array<[Date, number]>
    ) { }
}