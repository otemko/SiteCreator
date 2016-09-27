import { Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { Account } from './account.model'
import { Service } from '../service'

@Injectable()
export class AccountService {

    private url: 'api/Account/';

    constructor(private service: Service) {

    }

    getAccountInfo(): Promise<Account> {
        return this.service.get(this.url);
    }

}