import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { Site } from '../Models/site.model'
import { Service } from './service'


@Injectable()
export class SiteService {

    private url =  'api/Sites/';

    constructor(private service: Service) {

    }

    getSites(): Promise<Site[]> {
        return this.service.get(this.url);
    }

    getSitesByUserId(userId: string): Promise<Site[]> {
        console.log(this.url + userId);
        return this.service.get(this.url + userId);
    }

    getSitesByTag(tagId: number): Promise<Site[]> {
        return this.service.get(this.url + tagId);
    }

    deleteSite(id: number): Promise<number> {
        return this.service.delete(this.url + id);
    }

    createSite(site: Site): Promise<Site> {
        return this.service.post(this.url, site);
    }

    //updateSite(site: Site): void {
    //    let index = sites.findIndex(p => p.id == site.id);
    //    if (~index) {
    //        sites[index] = site;
    //    }
    //}
}