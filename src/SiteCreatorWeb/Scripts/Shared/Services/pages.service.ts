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
            .then(res => Object.assign(this.page, res));
    }

    parseContentFromDb(options) {
        let elements = [];
        let elementsFromDb = JSON.parse(this.page.elements);
        let contentFromDb = JSON.parse(this.page.content);
        for (let i = 0; i < elementsFromDb.length; i++) {
            elements.push({
                element: elementsFromDb[i],
                inputData: {
                    options: options,
                    content: contentFromDb[i]
                }
            });
        }
        return elements;
    }

    createPage(page: Page): Promise<number> {
        return this.service.post(this.url, page);
    }

    savePage(page: Page): Promise<any> {
        return this.service.put(this.url + page.id, page);
    };

    deletePage(id: number): Promise<any> {
        return this.service.delete(this.url + id);
    }
}