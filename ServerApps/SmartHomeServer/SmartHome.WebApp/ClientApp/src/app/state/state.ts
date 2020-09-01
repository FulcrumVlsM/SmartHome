import { TemperatureState } from "./temperature.state";
import { HumidityState } from "./humidity.state";
import { DioxideState } from "./dioxide.state";
import { BoolActionDevice } from "./bool_action_device.state";

export class State {
    constructor(
        public TemperatureState?: TemperatureState,
        public HumidityState?: HumidityState,
        public DioxideState?: DioxideState,
        public ActiveDevices?: Array<BoolActionDevice>
    ) { }
}