import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { TagSite } from '../Models/tag-site.model'
import { Service } from './service'


@Injectable()
export class TagSiteService {

    private url = 'api/TagSite/';

    constructor(private service: Service) {

    }

    getTagSites(): Promise<TagSite[]> {
        return this.service.get(this.url);
    }
}