import { Component, Injectable } from '@angular/core'

import 'rxjs/add/operator/toPromise';

import { Account } from '../Models/account.model'
import { Service } from './service'

@Injectable()
export class AccountService {

    private url = 'api/Manage/';

    constructor(private account: Account, private service: Service) {
    }

    getAccountInfo(): Promise<any> {
        this.account.loading = true;
        return this.service.get(this.url)
            .then(account => {
                Object.assign(this.account, account);
                this.account.loading = false;
            });
    }   

    updateName(userName: string): Promise<any> {
        return this.service.put(this.url, userName);
        
    }

    externalLogin(provider: string, returnUrl: string) {
        let body = { provider: provider, returnUrl: returnUrl };
        this.service.postForm('/Account/ExternalLogin', body, '');
    }

    logoff(returnUrl: string) {
        let body = { returnUrl: returnUrl };
        this.service.postForm(`/Account/logoff?returnUrl=${returnUrl}`, null, '');
    }

}