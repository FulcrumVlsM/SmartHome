import { HumiditySensor } from "./humidity_sensor.state";

export class HumidityState {
    constructor(
        public average?: number,
        public sensors?: Array<HumiditySensor>
    ) { }
}