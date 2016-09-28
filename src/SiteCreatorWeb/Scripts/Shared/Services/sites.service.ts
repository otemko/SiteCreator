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
        return this.service.get(this.url)
    }

    //getSite(id: number): Site {
    //    return sites.find(s => s.id == id);
    //}

    //updateSite(site: Site): void {
    //    let index = sites.findIndex(p => p.id == site.id);
    //    if (~index) {
    //        sites[index] = site;
    //    }
    //}
}