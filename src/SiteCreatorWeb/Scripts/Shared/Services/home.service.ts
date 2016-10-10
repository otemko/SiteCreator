import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { Site } from '../Models/site.model'
import { Page } from '../Models/page.model'
import { Service } from './service'

@Injectable()
export class HomeService {

    private url = 'api/Home/';

    constructor(private service: Service) { }

    getLastCreatedSites() : Promise<Site[]> {
        return this.service.get(this.url + 'LastCreatedSites');
    }

    getMostCommentedPages() : Promise<Site[]> {
        return this.service.get(this.url + 'MostCommentedPages');
    }

    getMostRatedPages() : Promise<Site[]> {
        return this.service.get(this.url + 'MostRatedPages');
    }

}