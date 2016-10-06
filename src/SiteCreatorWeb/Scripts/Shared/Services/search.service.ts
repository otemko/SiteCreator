import { Component, Injectable } from '@angular/core'

import 'rxjs/add/operator/toPromise';

import { SearchResult } from '../Models/search.model'
import { Service } from './service'

@Injectable()
export class SearchService {

    private url = 'api/Search/';

    constructor(private service: Service) {
    }

    getSearchResultByTerm(term: string): Promise<SearchResult> {
        return this.service.post(this.url, term);
    }
}