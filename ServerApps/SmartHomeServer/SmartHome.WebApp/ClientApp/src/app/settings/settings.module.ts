import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SettingsComponent } from './settings.component';
import { BoolSensorSettingsComponent } from './bool-sensors.settings.component'


@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [SettingsComponent, BoolSensorSettingsComponent],
    bootstrap: [SettingsComponent],
    exports: [SettingsComponent]
})
export class SettingsModule { }