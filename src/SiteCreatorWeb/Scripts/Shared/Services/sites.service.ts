import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { Site } from '../Models/site.model'
import { SiteCreate } from '../Models/site-create.model'
import { Service } from './service'


@Injectable()
export class SiteService {

    allSites: Site[] = new Array();

    private url =  'api/Sites/';

    constructor(private service: Service) {

    }

    getSites(): Promise<Site[]> {
        return this.service.get(this.url);
    }

    getSiteById(siteId: number): Promise<Site> {
        return this.service.get(this.url+'siteId/'+siteId);
    }

    getSitesByUserId(userId: string): Promise<Site[]> {
        return this.service.get(this.url + userId);
    }

    getSitesByTag(tagId: number): Promise<Site[]> {
        return this.service.get(this.url + tagId);
    }

    deleteSite(id: number): Promise<number> {
        return this.service.delete(this.url + id);
    }

    createSite(newSite: SiteCreate): Promise<SiteCreate> {
        return this.service.post(this.url, newSite);
    }

    updateSite(site: SiteCreate): Promise<SiteCreate> {
        return this.service.put(this.url, site);
    }
}