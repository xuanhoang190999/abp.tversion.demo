import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutConfigComponent } from './view/layout/layout-config.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutConfigComponent,
    // pathMatch: 'full',
    // loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule),
    children: [
      {
        path: 'identity',
        loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
      },
      {
        path: 'tenant-management',
        loadChildren: () =>
          import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
      },
      {
        path: 'setting-management',
        loadChildren: () =>
          import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
      },
      {
        path: 'releases',
        loadChildren: () =>
          import('./pages/releases/releases.module').then(m => m.ReleasesModule)
      },
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
