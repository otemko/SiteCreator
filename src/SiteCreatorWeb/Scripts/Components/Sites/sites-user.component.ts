﻿import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model';
import { SiteUserItemComponent } from './site-user-item.component';
import { SiteService } from '../../Shared/Services/sites.service'
import { Account } from '../../Shared/Models/account.model'
import { AccountService } from '../../Shared/Services/account.service'

declare var $;

@Component({
    selector: 'sites-user',
    templateUrl: './appScripts/Components/Sites/sites-user.component.html',
    providers: [SiteService]
})

export class SitesUserComponent {
    sites: Site[] = new Array();
    id: string;
    loading: boolean;
    invalidMsg: string;
    nameModel: any = {};

    constructor(private siteService: SiteService,
        private route: ActivatedRoute,
        private account: Account,
        private accountService: AccountService) {
        this.update();

    }

    update() {
        this.id = "" + this.route.snapshot.params['id'];
        this.siteService.getSitesByUserId(this.id).then(sites => {
            this.setPageName();
            console.log(sites);
            this.sites = sites;

        });
    }

    checkPermission() {
        if (this.account.id == this.id)
            return true;
        return false;
    }

    setPageName() {
        this.nameModel = { innerHTML: this.account.userName };
        $('.fr-submit').click(console.log(this.nameModel));
    }

    invalidate(msg: string) {
        this.invalidMsg = msg;
        this.loading = false;
    }

    validate() {
        this.update();
        this.invalidMsg = "";
        this.loading = false;
    }

    updateName() {
        this.loading = true;
        console.log(this.nameModel.innerHTML);
        this.accountService.updateName(this.nameModel.innerHTML).then(res => {
            this.accountService.getAccountInfo().then(res => {
                if (this.account.userName != this.nameModel.innerHTML) {
                    this.invalidate("Invalid input");
                }
                else {
                    this.validate;
                }
            })
        }).catch(res => {
            this.invalidate("User with this name exists");
        })
    }


}
