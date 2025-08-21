import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { LoginModule } from './login.module';

// MODELS
import { UrlConstants } from '@app-utils/index';

// LIBS
import { MaterialService, SecurityAbstractService, IUserModel, UserService } from 'security-lib';

@Component({
  selector: 'app-login',
  imports: [ LoginModule ],
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  
  // INJECTOS
  private readonly _router: Router = inject(Router);
  private readonly _materialService = inject(MaterialService);
  private readonly _securityService: SecurityAbstractService = inject(SecurityAbstractService);
  private readonly _userService: UserService = inject(UserService);
  
  // ATRIBUTES
  form: FormGroup = inject(FormBuilder).group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });

  constructor() {}

    
  ngOnInit(): void {}
  
  login(event: Event): any {
    event.preventDefault();
    if (this.form.valid) {
      const value = this.form.value;
      this._securityService.login(value.email, value.password).then((user: IUserModel) => {
        if (user) {
          this._userService.setUser(user);
          this._router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
        }
      }).catch(err => {
        this._materialService.openSnackBar(err);
        console.error(`ERROR login: ${err}`);
      });
    }
  }

  navigateToSignup(): void {
    this._router.navigateByUrl(`/${UrlConstants.URL_SIGNUP}`);
  }
}
