import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { StyleMenu } from '../Models/style-menu.model'
import { Service } from './service'


@Injectable()
export class StyleMenuService {

    private url = 'api/StyleMenu/';

    constructor(private service: Service) {

    }

    getStyleMenus(): Promise<StyleMenu[]> {
        return this.service.get(this.url);
    }
}