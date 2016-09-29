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

export class SitesUserComponent {
    sites: Site[] = new Array();

    constructor(private siteService: SiteService/*, private route: ActivatedRoute*/) {
        //let id = ""+this.route.snapshot.params['id'];

        this.siteService.getSitesByUserId('8a8475e1-9945-41be-96e7-cd038ad2a876').then(sites => this.sites = sites);
    }



}
