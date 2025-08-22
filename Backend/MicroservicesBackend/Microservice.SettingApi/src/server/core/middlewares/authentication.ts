import { Response, NextFunction } from 'express';
import Token from '../token';

export const validateToken = (req: any, res: Response, next: NextFunction) => {

    //let token: string = req.get('x-token') || '';
    
    //if (token === '') res.sendStatus(401);
    
    let token: string = '';
    const bearerHeader = req.headers['authorization'];
    if (typeof bearerHeader !== undefined)
        token = bearerHeader.split(' ')[1];
    console.log('Validating Token JWT', token);
    Token.verifyToken(token)
        .then((decoded: any) => {
            console.log('Decoded', decoded);
            req.user = decoded.UserName;
            next();
        })
        .catch((err: any) => {
            console.error('ERROR TOKEN VERIFICATION', err);
            res.sendStatus(401);
        });
    
        
}