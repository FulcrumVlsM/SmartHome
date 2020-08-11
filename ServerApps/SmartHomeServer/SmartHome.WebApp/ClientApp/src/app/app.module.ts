import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SettingsModule } from './settings/settings.module'
import { AppComponent } from './app.component';
@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, SettingsModule],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }