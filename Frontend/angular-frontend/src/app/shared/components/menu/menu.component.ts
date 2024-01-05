import { Component, Input } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { UrlConstants } from '@utils/index';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {

  @Input() drawer: MatDrawer | null = null;
  
  constructor(private router: Router) {
    
  }

  navigateToHome(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
    this.drawer?.close();
  }

  navigateToSetting(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_HOME}/${UrlConstants.URL_SETTING}`);
    this.drawer?.close();
  }
  
}
