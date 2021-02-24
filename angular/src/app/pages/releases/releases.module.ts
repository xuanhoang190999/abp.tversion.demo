import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// module
import { ReactiveFormsModule } from '@angular/forms';
import { ReleasesRoutingModule } from './releases-routing.module';
import { PipeModule } from 'src/app/shared/pipes/pipe.module';

// component
import { ReleasesComponent } from './releases.component';
import { ChangelogsComponent } from './changelogs.component';
import { PackagesComponent } from './packages.component';

@NgModule({
  declarations: [
    ReleasesComponent,
    ChangelogsComponent,
    PackagesComponent
  ],
  imports: [
    CommonModule,
    ReleasesRoutingModule,
    ReactiveFormsModule,
    PipeModule.forRoot(),
  ]
})
export class ReleasesModule { }
