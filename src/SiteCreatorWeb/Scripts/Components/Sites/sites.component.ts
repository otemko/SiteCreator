import { Component, Input, Output, OnInit } from '@angular/core'

import { Site } from '../../Shared/Models/site.model';
import { SiteItemComponent } from './site-item.component';
import { SiteService } from '../../Shared/Services/sites.service'

@Component({
    selector: 'sites',
    templateUrl: './appScripts/Components/Sites/sites.component.html',
    providers: [SiteService]
})

export class SitesComponent{
    sites : Site[] = new Array();

    constructor(private siteService: SiteService) {
        this.siteService.getSites().then(sites => {
            
            this.sites = sites;
            console.log(this.sites);
        });
    }



}
