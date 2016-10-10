import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model';
import { SiteUserItemComponent } from './site-user-item.component';
import { SiteService } from '../../Shared/Services/sites.service'
import { Account } from '../../Shared/Models/account.model'
import { Language } from '../../Shared/Models/language.model'

@Component({
    selector: 'sites-user',
    templateUrl: './appScripts/Components/Sites/sites-user.component.html',
    providers: [SiteService]
})

export class SitesUserComponent 
{
    sites: Site[] = new Array();
    id: string;

    constructor(private l: Language,
        private siteService: SiteService,
        private route: ActivatedRoute,
        private account: Account) {        
        this.update();
    }

    update() {
        this.id = "" + this.route.snapshot.params['id'];
        this.siteService.getSitesByUserId(this.id).then(sites => {
            this.sites = sites;
        });
    }

    checkPermission() {
        if (this.account.id == this.id)
            return true;
        return false;
    }
}
