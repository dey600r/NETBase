export interface IConfigServer {
	expressSettings: IConfigExpress;
	jwtSettings: IConfigJWT;
	mongoSettings: IConfigMongo;
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