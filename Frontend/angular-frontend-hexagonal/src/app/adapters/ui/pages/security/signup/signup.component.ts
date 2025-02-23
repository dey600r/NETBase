import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { SignupModule } from './signup.module';

// MODELS
import { IUserModel } from '@models/index';
import { UrlConstants } from '@utils/index';

// PORTS
import { ISignupUIPort, SignupUIPort, IUserUIPort, UserUIPort } from '@app/domain/ports/index';

// HELPERS
import { MaterialService } from '@helpers/index';

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
  private readonly _signupPort: ISignupUIPort = inject(SignupUIPort);
  private readonly _userPort: IUserUIPort = inject(UserUIPort);
  
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
      this._signupPort.signup(value.firstName, value.lastName, value.location, value.userName, value.email, value.password).then((user: IUserModel) => {
        if (user) {
          this._userPort.setUser(user);
          this._router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
        }
      }).catch(err => {
        this._materialService.openSnackBar(err);
        console.error(`ERROR SignUp: ${err}`);
      });
    }
  }
}
