import { Component, inject, Input } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { UrlConstants } from '@utils/index';
import { SharedModule } from '@modules/shared.module';

@Component({
  selector: 'app-menu',
  imports: [ SharedModule ],
  standalone: true,
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {

  private readonly router: Router = inject(Router);

  @Input() drawer: MatDrawer | null = null;
  
  constructor() {
    
  }

  navigateToHome(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
    this.drawer?.close();
  }

  navigateToSetting(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}/${UrlConstants.URL_SETTING}`);
    this.drawer?.close();
  }

  navigateToVehicle(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}/${UrlConstants.URL_VEHICLE}`);
    this.drawer?.close();
  }

  navigateToMaintenance(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}/${UrlConstants.URL_MAINTENANCE}`);
    this.drawer?.close();
  }
  
}
