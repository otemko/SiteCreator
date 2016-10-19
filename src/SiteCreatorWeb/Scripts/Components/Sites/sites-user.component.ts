import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model';
import { SiteUserItemComponent } from './site-user-item.component';
import { SiteService } from '../../Shared/Services/sites.service'
import { Account } from '../../Shared/Models/account.model'
import { AccountService } from '../../Shared/Services/account.service'
import { Language } from '../../Shared/Models/language.model'

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
    name: string;
    nameModel: any = {};

    constructor(private l: Language,
        private siteService: SiteService,
        private route: ActivatedRoute,
        private account: Account,
        private accountService: AccountService) {
        this.update();

    }

    update() {
        this.id = "" + this.route.snapshot.params['id'];
        this.siteService.getSitesByUserId(this.id).then(sites => {
            this.sites = sites;
            this.setPageName();
        });
    }

    checkPermission() {
        if (this.account.id == this.id)
            return true;
        return false;
    }
    
    setPageName() {
        if (this.sites.length) {
            console.log(this.sites);
            this.nameModel = { innerHTML: this.sites[0].userName };
            this.name = this.sites[0].userName;
        }
    }

    invalidate(msg: string) {
        this.invalidMsg = msg;
        this.loading = false;
    }

    validate() {
        this.invalidMsg = "";
        this.update();
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
                    this.validate();
                }
            })
        }).catch(res => {
            this.invalidate("User with this name exists");
        })
    }


}
