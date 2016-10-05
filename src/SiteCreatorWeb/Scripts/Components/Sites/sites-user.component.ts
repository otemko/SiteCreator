import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model';
import { SiteUserItemComponent } from './site-user-item.component';
import { SiteService } from '../../Shared/Services/sites.service'
import { Account } from '../../Shared/Models/account.model'

@Component({
    selector: 'sites-user',
    templateUrl: './appScripts/Components/Sites/sites-user.component.html',
    providers: [SiteService]
})

export class SitesUserComponent 
{
    sites: Site[] = new Array();

    constructor(private siteService: SiteService, private route: ActivatedRoute) {        
        this.update();
    }

    update() {
        let id = "" + this.route.snapshot.params['id'];
        this.siteService.getSitesByUserId(id).then(sites => {
            this.sites = sites;
        });
    }
}
