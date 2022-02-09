import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticateRequest } from '../core/generated-models';
import { AuthenticationService } from '../core/services';
import { UpdateService } from '../core/services/update.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  constructor(
    private router: Router,
    public translate: TranslateService,
    public updateService: UpdateService,
    public authenticationService: AuthenticationService
  ) {
    
  }

  ngOnInit() {
  }

  setLang(lang: string)
  {
    localStorage.setItem("language",lang);
    this.translate.use(lang)
  }

  checkForUpdate() {
    console.log('header');
    this.updateService.checkForUpdate(); 
  }
}
