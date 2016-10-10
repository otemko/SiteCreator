import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../../Shared/Models/site.model';
import { Tag } from '../../../Shared/Models/tag.model';
import { HomeService } from '../../../Shared/Services/home.service'

@Component({
    selector: 'last-created-sites',
    templateUrl: './appScripts/Components/Home/Parts/last-created-sites.component.html',
    providers: [HomeService]
})

export class LastCreatedSitesComponent{
    sites: Site[] = new Array();

    constructor(private homeService: HomeService) {
        
        this.homeService.getLastCreatedSites().then(res => {
            Object.assign(this.sites, res);
        })
    }
}