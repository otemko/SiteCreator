import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { Tag } from '../Models/tag.model'
import { Service } from './service'


@Injectable()
export class TagService {

    private url = 'api/Tag/';

    constructor(private service: Service) {

    }

    getTags(): Promise<Tag[]> {
        return this.service.get(this.url);
    }
}