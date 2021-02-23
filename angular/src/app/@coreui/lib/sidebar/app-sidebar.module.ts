import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule } from '@angular/forms';
import { AppSidebarComponent } from './app-sidebar.component';
import { AppSidebarNavItemComponent } from './app-sidebar-nav-item';
import { SidebarNavHelper } from './sidebar.service';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppSidebarComponent,
    AppSidebarNavItemComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    AppSidebarNavItemComponent,
    AppSidebarComponent
  ],
  providers: [
   SidebarNavHelper
  ]
})
export class AppSidebarModule { }
