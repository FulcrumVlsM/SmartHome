import { HumiditySensor } from "./humidity_sensor.state";

export class HumidityState {
    constructor(
        public Average?: number,
        public Sensors?: Array<HumiditySensor>
    ) { }
}