import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { Account } from './account.model'
import { Service } from '../service'

@Injectable()
export class AccountService {

    private url: 'api/Manage/';

    constructor(private account: Account, private service: Service) {

    }

    getAccountInfo(): void {
        this.service.get(this.url)
            .then(account => this.account.read(account));
    }

}