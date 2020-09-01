import { DioxideSensor } from "./dioxide_sensor.state";

export class DioxideState {
    constructor(
        public Average?: number,
        public Sensors?: Array<DioxideSensor>
    ) { }
}