import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UrlConstants } from '@utils/index';

import { SecurityService, MaterialService } from '@services/index';
import { IUserModel } from '@models/index';

@Component({
  selector: 'app-login.component',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  form: FormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private securityService: SecurityService,
    private materialService: MaterialService) {
  }
    
  ngOnInit(): void {}
  
  login(event: Event): any {
    event.preventDefault();
    if (this.form.valid) {
      const value = this.form.value;
      this.securityService.login(value.email, value.password).then((user: IUserModel) => {
        if (user) {
          this.securityService.setUser(user);
          this.router.navigateByUrl(`/${UrlConstants.URL_HOME}`);
        }
      }).catch(err => {
        this.materialService.openSnackBar(err);
        console.error(`ERROR login: ${err}`);
      });
    }
  }

  navigateToSignup(): void {
    this.router.navigateByUrl(`/${UrlConstants.URL_SIGNUP}`);
  }
}
