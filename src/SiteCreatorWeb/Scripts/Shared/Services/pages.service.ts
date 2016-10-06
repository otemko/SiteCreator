import { Component, Injectable } from '@angular/core'
import { Page } from '../Models/page.model'

import 'rxjs/add/operator/toPromise';

import { Account } from '../Models/account.model'
import { Service } from './service'

@Injectable()
export class PageService {

    private url = 'api/Pages/';
    constructor(private service: Service, private page: Page) {
    }

    getPage(id: number): Promise<any> {
        return this.service.get(this.url + id)
            .then(res => Object.assign(this.page, res ));
    }

    createPage(page: Page): Promise<number> {
        return this.service.post(this.url, page);
    }

    savePage(page: Page): Promise<number> {
        return this.service.put(this.url + page.id, page);
    };
}