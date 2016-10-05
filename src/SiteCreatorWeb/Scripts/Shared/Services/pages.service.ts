import { Component, Injectable } from '@angular/core'
import { Page } from '../Models/page.model'

import 'rxjs/add/operator/toPromise';

import { Account } from '../Models/account.model'
import { Service } from './service'

@Injectable()
export class PageService {

    private url = 'api/Pages/';
    constructor(private service: Service) {
    }

    getPage(id: number) {
        console.log("service");
        let page: Page = new Page();
        this.service.get(this.url + id)
            .then(res => {
                Object.assign(page, res);
                console.log(page);
            });
        return page;
    }



    

}