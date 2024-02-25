import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UrlConstants } from '@utils/index';

import { SecurityService, MaterialService } from '@services/index';
import { IUserModel } from '@models/index';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent {

  form: FormGroup = this.formBuilder.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
    location: ['', [Validators.required]],
    userName: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });
  
  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private securityService: SecurityService,
    private materialService: MaterialService){}
  
  signup(event: Event): any {
    event.preventDefault();
    if (this.form.valid) {
      const value = this.form.value;
      this.securityService.signup(value.firstName, value.lastName, value.location, value.userName, value.email, value.password).then((user: IUserModel) => {
        if (user) {
          this.securityService.setUser(user);
          this.router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
        }
      }).catch(err => {
        this.materialService.openSnackBar(err);
        console.error(`ERROR SignUp: ${err}`);
      });
    }
  }
}
