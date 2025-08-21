import { Component, inject, Input } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { Router } from '@angular/router';

// MODULES
import { SharedModule } from '@app-modules/shared.module';

// MODELS
import { UrlConstants } from '@app-utils/index';

// SERVICES
import { IUserModel, SecurityAbstractService } from 'security-lib';

@Component({
  selector: 'app-header',
  imports: [ SharedModule ],
  standalone: true,
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  private readonly _securityService: SecurityAbstractService = inject(SecurityAbstractService);
  private readonly _router: Router = inject(Router);

  @Input() drawer: MatDrawer | null = null;
  
  userName: string = '';
  userLocation: string = '';
  userRole: string[] = [];

  constructor() {
  }

  ngOnInit(): void {
    this._securityService.user().then((user: IUserModel) => {
        this.userName = `${user.firstName} ${user.lastName}`;
        this.userLocation = user.location;
        this.userRole = user.roles;
        //user.roles.forEach((x, index) => this.userRole += `${(index != 0 ? ',' : '')}${x}`);
      })
      .catch(err => console.error(err));
  }

  logout(): void {
    this._securityService.logout();
  }

  navigateToHome(): void {
    this._router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
  }
}
