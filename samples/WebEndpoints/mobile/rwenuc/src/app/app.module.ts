import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HeaderComponent } from './header/header.component';
import { SharedModule } from './shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UpdateService } from './core/services/update.service';
import { API_BASE_URL, AppConfigFactory, AppConfigService, AuthenticationService, JwtService } from './core/services';
import { UserOrderListComponent } from './user-order-list/user-order-list.component';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { QrScannerComponent } from './qr-scanner/qr-scanner.component';
import { FormsModule } from '@angular/forms';
import { PlatformLocation } from '@angular/common';

// AoT requires an exported function for factories
export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient);
}

const appRoutes: Routes = [
  {
      path: '',
      redirectTo: '/login',
      pathMatch: 'full'
  },  
  {
      path: 'login',
      component: LoginComponent
  },  
  {
      path: 'oderlist',
      component: UserOrderListComponent
  }
  ];
  
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    UserOrderListComponent,
    QrScannerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,    
    HttpClientModule,
    ZXingScannerModule,
    SharedModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production,
      // Register the ServiceWorker as soon as the app is stable
      // or after 30 seconds (whichever comes first).
      registrationStrategy: 'registerWhenStable:30000'
    }),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: false
    }),
  ],
  exports: [RouterModule],
  providers: [
    { provide: 'CONFIGPATH', useValue: '/assets/config/config.json' },
    { provide: 'APIURL-VAR', useValue: 'API_BASE_URL' },
    {
      provide: API_BASE_URL,
      useFactory: AppConfigFactory,
      deps: [PlatformLocation, AppConfigService, 'CONFIGPATH', 'APIURL-VAR']
    },
    UpdateService,
    JwtService,
    AuthenticationService
  ],
  bootstrap: [AppComponent],
  entryComponents: [QrScannerComponent]
})
export class AppModule { }
