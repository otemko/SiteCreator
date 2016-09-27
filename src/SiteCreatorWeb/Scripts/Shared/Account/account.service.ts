import { Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { Account } from './account.model'
import { Service } from '../service'

@Injectable()
export class AccountService {

    private url: 'api/Manage/';

    constructor(private service: Service, private account: Account) {

    }

    getAccountInfo(): Account {
        this.service.get<Account>(this.url)
            .then(account => this.account = account);
        return this.account;
    }

}