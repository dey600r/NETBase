import express from 'express';

export default class Server {

    public app: express.Application;
    public port: number;
    public hostName: string;

    constructor(hostname: string, port: number) {
        this.app = express();
        this.hostName = hostname;
        this.port = port;
    }

    start(callback: () => void) {
        this.app.listen(this.port, this.hostName, callback);
    }

}