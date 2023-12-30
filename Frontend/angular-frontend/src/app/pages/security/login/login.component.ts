import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login.component',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  /* AQUI DEFINIMOS LA TEMATICA DE NUESTRA IMAGEN*/
  styleImage = 'rain';

  form: FormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });

  constructor(private formBuilder: FormBuilder,
    private router: Router){
  }

  ngOnInit(): void {}

  login(event: Event): any {
    this.router.navigateByUrl('/home');
    // event.preventDefault();
    // if (this.form.valid) {
    //   const value = this.form.value;
    //   console.log(`'%c'USER: ${value.email} - PASSWORD: ${value.password}`, 'background: #222; color: #bada55');
    // }
  }
}
