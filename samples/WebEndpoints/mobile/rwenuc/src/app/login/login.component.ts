import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { debounceTime, first, skip, startWith, switchMap, takeUntil } from 'rxjs/operators';
import { AuthenticateRequest, UserDto } from '../core/generated-models';
import { AuthenticationService } from '../core/services';




@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  searchControl: FormControl = new FormControl('');
    
  users$: Observable<Array<UserDto>> = of([]);
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService) { }

  selectUser(user: UserDto) {
    this.authenticationService.login(new AuthenticateRequest({ email: user.name }))
    .pipe(first())
    .subscribe({
      next: (u) => {
        console.log('login: ' + u);
        this.router.navigate(['/oderlist']);
      },
      error: (err) => console.error(err)
    });
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.users$ = this.authenticationService.getUsers();
  }
}
