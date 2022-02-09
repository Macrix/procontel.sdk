import { Component } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationService } from './core/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'rwenuc';
  constructor(
    router: Router,
    matIconRegistry: MatIconRegistry,
    domSanitizer: DomSanitizer,
    translateService: TranslateService,
    authenticationService: AuthenticationService) {
    
      matIconRegistry.addSvgIcon(
        `rwe_logout`,
        domSanitizer.bypassSecurityTrustResourceUrl(`../assets/icons/exit_to_app_black_24dp.svg`)
      );

      matIconRegistry.addSvgIcon(
        `rwe_headermenu`,
        domSanitizer.bypassSecurityTrustResourceUrl(`../assets/icons/more_vert_black_24dp.svg`)
      );

      matIconRegistry.addSvgIcon(
        `rwe_icon`,
        domSanitizer.bypassSecurityTrustResourceUrl(`../assets/icons/Nuclear_symbol.svg`)
      );

      var langs = ['en','de'];
      translateService.addLangs(langs);
      translateService.setDefaultLang('en');

      if (localStorage.getItem('language') && langs.includes(localStorage.getItem('language')!)) {      
        translateService.use(localStorage.getItem('language')!);
      } 

      authenticationService.currentUser
      .subscribe({
        next: (u) => { if (!u) { router.navigate(['/']);} }      
      });
  }
}
