import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms';
import { LayoutConfigComponent } from './layout-config.component';
import { AppSidebarModule } from 'src/app/@coreui/lib/sidebar/app-sidebar.module';
import { AppSidebarComponent } from 'src/app/@coreui/lib/sidebar/app-sidebar.component';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { environment } from '../../../environments/environment';

@NgModule({
  declarations: [
    LayoutConfigComponent,
  ],
  imports: [
    CommonModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    }),
    ReactiveFormsModule,
    AppRoutingModule,
    AppSidebarModule
  ],
  providers: [

  ]
})
export class LayoutConfigModule { }
