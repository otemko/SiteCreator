import { Component, OnInit } from '@angular/core';
import { Location, } from '@angular/common';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { Account } from './Shared/Models/account.model'
import { Page } from './Shared/Models/page.model'
import { Service } from './Shared/Services/service'
import { AccountService } from './Shared/Services/account.service'
import { SiteService } from './Shared/Services/sites.service'
import { PageService } from './Shared/Services/pages.service'



@Component({
    selector: 'my-app',
    templateUrl: './appScripts/app.component.html',
    styleUrls: ['./appScripts/app.component.css'],
    providers: [Account, Page, Service, AccountService, SiteService, PageService],
})
export class AppComponent {

    constructor(public location: Location, private accountService: AccountService) { 
            this.accountService.getAccountInfo();
    }
 }