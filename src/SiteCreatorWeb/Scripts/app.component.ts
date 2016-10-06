import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Router } from '@angular/router'

import { Account } from './Shared/Models/account.model'
import { Service } from './Shared/Services/service'
import { AccountService } from './Shared/Services/account.service'

@Component({
    selector: 'my-app',
    templateUrl: './appScripts/app.component.html',
    styleUrls: ['./appScripts/app.component.css'],
    providers: [Account, Service, AccountService],
})
export class AppComponent {

    valueSearch: string;

    constructor(public location: Location, private accountService: AccountService,
        private route: Router) { 
            this.accountService.getAccountInfo();
    }

    search()
    {
        if (this.valueSearch != "" && this.valueSearch != undefined) {
            this.route.navigate(['/search', this.valueSearch]);
        }
    }

 }