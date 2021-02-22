import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule, getBaseApi, getBaseUrl } from './app/app.module';
import { environment } from './environments/environment';



// (window as any).global = window;

// const providers = [
//   { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
//   { provide: 'BASE_API', useValue: getBaseApi() },
//   // { provide: 'BASE_SignalR', useValue: getSignalR() }
// ];

if (environment.production) {
  enableProdMode();
}

// document.addEventListener('DOMContentLoaded', () => {
//   platformBrowserDynamic(providers).bootstrapModule(AppModule, {
//     // useJit: true,
//     preserveWhitespaces: true
//   })
//     .catch(err => console.log(err));
// });

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch(err => console.error(err));
