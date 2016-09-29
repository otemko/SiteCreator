import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

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

    constructor(private siteService: SiteService, private route: ActivatedRoute) {
        let id = +this.route.snapshot.params['id'];
        console.log(id);
        if (id) {
            this.siteService.getSitesByTag(id).then(sites => {
                this.sites = sites;
            });
        }
        else {
            this.siteService.getSites().then(sites => {
                this.sites = sites;
            });
        }
    }
}
