import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ChangelogsComponent } from './changelogs.component';

const routes: Routes = [
  {
    path: '',
    component: ChangelogsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChangelogsRoutingModule { }
