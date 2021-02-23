import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <!-- <abp-loader-bar></abp-loader-bar>
    <app-sidebar></app-sidebar>
    <router-outlet></router-outlet> -->
    <!-- <abp-dynamic-layout></abp-dynamic-layout> -->

    <router-outlet></router-outlet>

  `,
})
export class AppComponent {}
