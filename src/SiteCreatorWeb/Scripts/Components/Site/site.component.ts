import { Component, Input } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { SiteService } from '../../Shared/Services/sites.service'

@Component({
    selector: 'site',
    templateUrl: './appScripts/Components/Site/site.component.html',
    providers: [SiteService]
})

export class SiteComponent {
    site = new Site();

    tagsView: string[] = new Array();

    constructor(private siteService: SiteService, private route: ActivatedRoute) {
        let id = +this.route.snapshot.params['id'];
        this.siteService.getSiteById(id).then(site => {
            this.site.name = site.name;
            this.site.styleMenuId = site.styleMenuId;
            this.site.id = site.id;
            this.site.userId = site.userId;
            this.site.dateCreated = site.dateCreated;

            for (let i = 0; i < site.tags.length; i++) {
                this.tagsView.push(site.tags[i].name);
            }
        });
    }

    submit() {
        //this.siteService.updateSite(this.site);
    }

}