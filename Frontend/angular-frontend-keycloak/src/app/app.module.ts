import { NgModule, Injector, APP_INITIALIZER, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClient, HttpClientModule } from '@angular/common/http';

// import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
// import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { environment } from '@environments/environment';
import { LOCATION_INITIALIZED } from '@angular/common';
import { AppConstants } from '@utils/constants';
import { SharedModule } from '@modules/shared.module';
import { ProviderInterceptorApp } from '@core/providers/index';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { AuthModule } from '@shared/modules/auth.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    SharedModule,
    AuthModule
    // TranslateModule.forRoot({
    //   loader: {
    //     provide: TranslateLoader,
    //     useFactory: (createTranslateLoader),
    //     deps: [HttpClient]
    //   }
    // })
  ],
  providers: [
    ProviderInterceptorApp,
    provideAnimationsAsync(),
    // {
    //   provide: APP_INITIALIZER,
    //   useFactory: appInitializerFactory,
    //   deps: [TranslateService, Injector],
    //   multi: true
    // }
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }

// export function createTranslateLoader(http: HttpClient): TranslateHttpLoader {
//   return new TranslateHttpLoader(http, environment.pathTranslate, '.json');
// }

// export function appInitializerFactory(translate: TranslateService, injector: Injector): any {
//   return () => new Promise<any>((resolve: any) => {
//     const locationInitialized = injector.get(LOCATION_INITIALIZED, Promise.resolve(null));
//     locationInitialized.then(() => {
//       let userLang = navigator.language.split('-')[0];
//       userLang = /(es|en)/gi.test(userLang) ? userLang : Constants.LANGUAGE_EN;
//       translate.setDefaultLang(userLang);
//       translate.use(userLang).subscribe(() => {
//         console.warn(`Successfully initialized '${userLang}' language.'`);
//       }, err => {
//         console.error(`Problem with '${userLang}' language initialization.'`);
//       }, () => {
//         resolve(null);
//       });
//     });
//   });
// }
