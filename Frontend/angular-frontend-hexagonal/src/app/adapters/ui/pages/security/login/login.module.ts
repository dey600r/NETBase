import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MaterialModule } from '@modules/material.module';

import { ProviderInterceptorApp } from '@providers/index';

@NgModule({
  exports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ProviderInterceptorApp],
  schemas :[ CUSTOM_ELEMENTS_SCHEMA ]
})
export class LoginModule { }
