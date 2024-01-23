import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { AuthGuard } from '@app/core/guards/user.guard';
import { UrlConstants } from '@app/core/utils';

const routes: Routes = [
  { 
    path: '', 
    component: HomeComponent,
    children: [
      {
        path: UrlConstants.URL_SETTING,
        loadChildren: () => import('./setting/setting.module').then(mod => mod.SettingModule),
        canActivate: [AuthGuard]
      },
      {
        path: UrlConstants.URL_VEHICLE,
        loadChildren: () => import('./vehicle/vehicle.module').then(mod => mod.VehicleModule),
        canActivate: [AuthGuard]
      },
      {
        path: UrlConstants.URL_MAINTENANCE,
        loadChildren: () => import('./maintenance/maintenance.module').then(mod => mod.MaintenanceModule),
        canActivate: [AuthGuard]
      }
    ]
  }  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
