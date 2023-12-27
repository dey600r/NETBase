import jwt from 'jsonwebtoken';
import * as config from '../assets/config.json';
import * as forge from 'node-forge';
import * as crypto from 'crypto';
import { IConfigJWT, IConfigServer } from './models/utils/config-setting.model';

export default class Token {

    private static configJWT: IConfigJWT = (config as IConfigServer).jwtSettings;

    constructor() { }

    static verifyToken(userToken: string) {

        return new Promise((resolve, reject) => {

            jwt.verify(userToken, this.configJWT.key, (err, decoded) => {

                if (err) {
                    reject();
                } else {
                    resolve(decoded);
                }


            })

        });


    }
}


