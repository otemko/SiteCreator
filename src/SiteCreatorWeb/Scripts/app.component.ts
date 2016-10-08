import { Component, OnInit } from '@angular/core';
import { Location, } from '@angular/common';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Router } from '@angular/router'

import { Account } from './Shared/Models/account.model'
import { Page } from './Shared/Models/page.model'
import { Service } from './Shared/Services/service'
import { AccountService } from './Shared/Services/account.service'
import { SiteService } from './Shared/Services/sites.service'
import { PageService } from './Shared/Services/pages.service'
import { CommentService } from './Shared/Services/comments.service'

import { Language } from './Shared/Models/language.model'
import { LanguageService } from './Shared/Services/language.service'

import { Elements } from './Shared/Models/elements.model'
import { ElementService } from './Shared/Services/elements.service'

import { GlobalService } from './Shared/Services/global.service'

@Component({
    selector: 'my-app',
    templateUrl: './appScripts/app.component.html',
    styleUrls: ['./appScripts/app.component.css'],
    providers: [Account, Page, Service, AccountService, SiteService, PageService, GlobalService, CommentService,
                Language, LanguageService, Elements, ElementService],
})
export class AppComponent {

    valueSearch: string;

    constructor(public location: Location,
        private accountService: AccountService,
        private languageService: LanguageService,
        private l: Language,
        private route: Router) { 
            this.accountService.getAccountInfo();
            this.languageService.getLanguage();
    }

    search()
    {
        if (this.valueSearch != "" && this.valueSearch != undefined) {
            this.route.navigate(['/search', this.valueSearch]);
        }
    }

 }