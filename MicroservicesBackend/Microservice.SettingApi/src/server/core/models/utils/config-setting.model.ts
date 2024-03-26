export interface IConfigServer {
	expressSettings: IConfigExpress;
	jwtSettings: IConfigJWT;
	keycloackSettings: IConfigKeycloak;
	mongoSettings: IConfigMongo;
	keycloakEnabled: boolean;
}

export interface IConfigExpress {
	host: string;
	port: number;
}

export interface IConfigJWT {
	key: string;
}

export interface IConfigMongo {
	host: string;
	port: number;
	db: string;
	user: string;
	pwd: string;

}

export interface IConfigKeycloak {
	"realm": string;
  	"auth-server-url": string;
  	"ssl-required": string;
  	"resource": string;
  	"bearer-only": boolean;
}