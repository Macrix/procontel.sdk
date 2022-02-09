import { Injectable } from '@angular/core';
import { AuthenticateResponse } from '../generated-models';

@Injectable()
export class JwtService {

    private static TOKEN_KEY = 'userRWENUC';

    getUser(): AuthenticateResponse | null {
        const user = localStorage.getItem(JwtService.TOKEN_KEY);
        if (user) {
            return JSON.parse(user);
        }
        else {
            return null;
        }
    }

    saveUser(user: AuthenticateResponse) {
        localStorage.setItem(JwtService.TOKEN_KEY, JSON.stringify(user));
    }

    destroyUser() {
        localStorage.removeItem(JwtService.TOKEN_KEY);
    }

    getToken(): string | null {
        const user = this.getUser();
        if (user && user.token) {
            return user.token;
        }
        else {
            return null;
        }
    }
}
