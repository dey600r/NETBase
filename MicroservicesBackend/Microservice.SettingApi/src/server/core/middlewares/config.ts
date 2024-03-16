import * as config from '../../../assets/config.json';
import * as configProd from '../../../assets/config.production.json';
import { IConfigServer } from '../../core/models/utils/config-setting.model';

let cfg: IConfigServer = config as IConfigServer;
if (process.env.NODE_ENV === 'production') {
    console.log('Production Mode...');
    cfg = configProd as IConfigServer;
}

module.exports = { config: cfg };