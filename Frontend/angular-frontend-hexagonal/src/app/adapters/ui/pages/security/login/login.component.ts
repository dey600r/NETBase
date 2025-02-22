import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { LoginModule } from './login.module';

// MODELS
import { IUserModel } from '@models/index';
import { UrlConstants } from '@utils/index';

// PORTS
import { ILoginUIPort, LoginUIPort, IUserUIPort, UserUIPort } from '@ports/index';

// OTHERS
import { MaterialService } from '@helpers/index';

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
  private readonly _loginPort: ILoginUIPort = inject(LoginUIPort);
  private readonly _userPort: IUserUIPort = inject(UserUIPort);
  
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
      this._loginPort.login(value.email, value.password).then((user: IUserModel) => {
        if (user) {
          this._userPort.setUser(user);
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
