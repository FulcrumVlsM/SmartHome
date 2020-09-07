import { DioxideSensor } from "./dioxide_sensor.state";

export class DioxideState {
    constructor(
        public average?: number,
        public sensors?: Array<DioxideSensor>
    ) { }
}