import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChangelogsRoutingModule } from './changelogs-routing.module';
import { ChangelogsComponent } from './changelogs.component';
import { PackageService } from '@proxy/services/package.service';
import { ReactiveFormsModule } from '@angular/forms';
// import { PackageService } from 'src/app/@core/service/package.service';
// import { HttpService } from 'src/app/@core/service/http.service';


@NgModule({
  declarations: [ChangelogsComponent],
  imports: [
    CommonModule,
    ChangelogsRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    // HttpService,
    PackageService
  ]
})
export class ChangelogsModule { }
