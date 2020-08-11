import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
if (environment.production) {
    enableProdMode();
    console.log("prodmode:enable");
}
else {
    console.log("prodmode:disable");
}
const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);
//# sourceMappingURL=main.js.map