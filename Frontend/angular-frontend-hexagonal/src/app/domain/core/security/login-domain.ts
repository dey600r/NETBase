import { inject } from "@angular/core";
import { MaterialService } from "@helpers/index";
import { IUserModel } from "@models/index";
import { LoginUIPort } from "@ports/index";

export class LoginUIPortImpl extends LoginUIPort {
    override login(email: string, password: string): Promise<IUserModel> {
        throw new Error("ONLY FOR JWT");
    }
    override validateToken(roles: string[]): boolean {
        throw new Error("ONLY FOR JWT");
    }
    override user(): Promise<IUserModel> {
        throw new Error("JWT & KEYCLOAK");
    }
    override logout(): void {
        throw new Error("JWT & KEYCLOAK");
    }
    validateRoles(rolesToken: string[], rolesPage: string[]): boolean {
        // Allow the user to to proceed if no additional roles are required to access the route.
        if (!(rolesPage instanceof Array) || rolesPage.length === 0) {
            return true;
        }
    
        const validated = rolesPage.some((role) => rolesToken.includes(role));
        if(!validated) {
            inject(MaterialService).openSnackBar('Unauthorized!!!');
        }
        return validated;
    };
}