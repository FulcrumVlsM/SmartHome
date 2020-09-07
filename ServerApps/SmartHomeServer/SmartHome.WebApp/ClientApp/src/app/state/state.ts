import { TemperatureState } from "./temperature.state";
import { HumidityState } from "./humidity.state";
import { DioxideState } from "./dioxide.state";
import { BoolActionDevice } from "./bool_action_device.state";

export class State {
    constructor(
        public temperatureState?: TemperatureState,
        public humidityState?: HumidityState,
        public dioxideState?: DioxideState,
        public activeDevices?: Array<BoolActionDevice>
    ) { }
}