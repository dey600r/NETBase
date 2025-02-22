

import { inject, Injectable } from '@angular/core';

// MODELS
import { IUserModel } from '@models/index';

// PORTS
import { ISecurityApiPort, SecurityApiPort, SignupUIPort } from '@ports/index';

@Injectable({
  providedIn: 'root'
})
export class SignUpDomain implements SignupUIPort {

    // INJECTABLES
    private readonly _securityApi: ISecurityApiPort = inject(SecurityApiPort);

    signup(firstName: string, lastName: string, location: string, userName: string, email: string, password: string): Promise<IUserModel> {
        return this._securityApi.signup(firstName, lastName, location, userName, email, password);
    }
}