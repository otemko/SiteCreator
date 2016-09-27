import { Injectable } from '@angular/core';

import { ISite, Site } from '../Components/Site/site.model'
import { sites } from './sites.data'


@Injectable()
export class SiteService {

    getSites(): ISite[] {
        return sites;
    }

    getSite(id: number): Site {
        return sites.find(s => s.id == id);
    }

    updateSite(site: Site): void {
        let index = sites.findIndex(p => p.id == site.id);
        if (~index) {
            sites[index] = site;
        }
    }
}