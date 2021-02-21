import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChangelogsRoutingModule } from './changelogs-routing.module';
import { ChangelogsComponent } from './changelogs.component';


@NgModule({
  declarations: [ChangelogsComponent],
  imports: [
    CommonModule,
    ChangelogsRoutingModule
  ]
})
export class ChangelogsModule { }
