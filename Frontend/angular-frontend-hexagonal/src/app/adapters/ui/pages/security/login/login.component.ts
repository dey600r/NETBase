import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

import { LoginModule } from './login.module';

import { UrlConstants } from '@utils/index';
import { LoginDomain, UserDomain } from '@domain/core/security/index';
import { ILoginUIPort, IUserUIPort } from '@ports/index';
import { IUserModel } from '@models/index';
import { MaterialService } from '@helpers/index';

import { ProviderInterceptorApp } from '@providers/index';

@Component({
  selector: 'app-login',
  imports: [ LoginModule ],
  providers: [ProviderInterceptorApp],
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  
  // INJECTOS
  private readonly _router: Router = inject(Router);
  private readonly _snackBar = inject(MatSnackBar);
  private readonly _materialService = inject(MaterialService);
  private readonly _loginDomain: ILoginUIPort = inject(LoginDomain);
  private readonly _userDomain: IUserUIPort = inject(UserDomain);
  
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
      this._loginDomain.login(value.email, value.password).then((user: IUserModel) => {
        if (user) {
          this._userDomain.setUser(user);
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
