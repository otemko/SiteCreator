import { Component, Input } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from './site.model'
import { SiteService } from '../../Shared/sites.service'

@Component({
    selector: 'site',
    templateUrl: './appScripts/Components/Site/site.component.html',
    providers: [SiteService]
})

export class SiteComponent {
    site: Site;

    constructor(private siteService: SiteService, private route: ActivatedRoute) {
        let id = +this.route.snapshot.params['id'];
        this.site = this.siteService.getSite(id);
    }

    submit() {
        this.siteService.updateSite(this.site);
    }

}