import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { IdentityConfigModule } from '@abp/ng.identity/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
import { ThemeBasicModule } from '@abp/ng.theme.basic';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxsModule } from '@ngxs/store';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppSidebarComponent } from './@coreui/lib/sidebar/app-sidebar.component';
import { LayoutConfigComponent } from './view/layout/layout-config.component';
import { AppSidebarModule } from './@coreui/lib/sidebar/app-sidebar.module';
// import { LayoutConfigModule } from './view/layout/layout-config.module';
// import { AppSidebarModule } from './@coreui/lib/sidebar/app-sidebar.module';
// import { AppSidebarModule } from './@coreui/lib/sidebar/app-sidebar.module';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

export function getBaseApi() {
  if (document.getElementsByTagName('server').length > 0) {
    return document.getElementsByTagName('server')[0].attributes['href'].value;
  } else {
    return '';
  }
}

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    }),
    ThemeSharedModule.forRoot(),
    IdentityConfigModule.forRoot(),
    TenantManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    NgxsModule.forRoot(),
    ThemeBasicModule.forRoot(),
    ReactiveFormsModule,
    NgbModule,
    AppSidebarModule,
    // LayoutConfigModule,
    // AppSidebarModule
    // AppSidebarModule,
  ],
  declarations: [AppComponent, LayoutConfigComponent],
  providers: [APP_ROUTE_PROVIDER],
  bootstrap: [AppComponent],
})
export class AppModule {}
