import { Injectable } from '@angular/core';
import { PlatformLocation } from '@angular/common';
import { environment } from 'src/environments/environment';


export function AppConfigFactory(s: PlatformLocation, configService: AppConfigService, file: string, property: string) {
    if (environment.production) {
        return `${ s.protocol }\\\\${s.hostname}:${s.port}`;
    } else {
        return configService.loadJSON(file)[property];
    }
}

@Injectable()
export class AppConfigService {

    public config: any;
    constructor() {
    }

    loadJSON(filePath: string) {
        const json = this.loadTextFileAjaxSync(filePath, 'application/json');
        return JSON.parse(json);
    }

    loadTextFileAjaxSync(filePath: string, mimeType: string) : string {
        const xmlhttp = new XMLHttpRequest();
        xmlhttp.open('GET', filePath, false);
        if (mimeType != null) {
            if (xmlhttp.overrideMimeType) {
                xmlhttp.overrideMimeType(mimeType);
            }
        }
        xmlhttp.send();
        if (xmlhttp.status === 200) {
            return xmlhttp.responseText;
        } else {
            return '{}';
        }
    }
}
