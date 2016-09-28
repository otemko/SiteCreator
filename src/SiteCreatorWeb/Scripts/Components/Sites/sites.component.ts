import { Component, Input, Output } from '@angular/core'

import { Site } from '../../Shared/Models/site.model';
import { SiteItemComponent } from './site-item.component';
import { SiteService } from '../../Shared/Services/sites.service'

@Component({
    selector: 'sites',
    templateUrl: './appScripts/Components/Sites/sites.component.html',
    providers: [SiteService]
})

export class SitesComponent {
    sites: Site[];

    constructor(private siteService: SiteService) {
        this.sites = this.siteService.getSites();
    }
}
