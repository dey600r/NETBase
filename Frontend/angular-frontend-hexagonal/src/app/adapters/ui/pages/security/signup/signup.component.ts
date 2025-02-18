import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { UrlConstants } from '@utils/index';

import { IUserModel } from '@models/index';
import { IUserUIPort } from '@ports/index';
import { UserDomain } from '@domain/core/security/index';
import { MaterialService } from '@helpers/index';
import { SignupModule } from './signup.module';

@Component({
  selector: 'app-signup',
  imports: [ SignupModule ],
  standalone: true,
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent {

  // INJECTOS
  private readonly _router: Router = inject(Router);
  private readonly _materialService = inject(MaterialService);
  // private readonly _loginDomain: ILoginUIPort = inject(LoginDomain);
  private readonly _userDomain: IUserUIPort = inject(UserDomain);
  
  // ATRIBUTES
  form: FormGroup = inject(FormBuilder).group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    location: ['', [Validators.required]],
    userName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });
  
  constructor(){}
  
  signup(event: Event): any {
    event.preventDefault();
    if (this.form.valid) {
      const value = this.form.value;
      // this.securityService.signup(value.firstName, value.lastName, value.location, value.userName, value.email, value.password).then((user: IUserModel) => {
      //   if (user) {
      //     this.securityService.setUser(user);
      //     this._router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
      //   }
      // }).catch(err => {
      //   this._materialService.openSnackBar(err);
      //   console.error(`ERROR SignUp: ${err}`);
      // });
    }
  }
}
