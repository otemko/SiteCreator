import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../../Shared/Models/site.model';
import { HomeService } from '../../../Shared/Services/home.service'

@Component({
    selector: 'sites',
    templateUrl: './appScripts/Components/Sites/sites.component.html',
    providers: [HomeService]
})

export class MostRatedPages{
    sites: Site[] = new Array();

    constructor(private homeService: HomeService) {
        
        this.homeService.getLastCreatedSites().then(res => {
            Object.assign(this.sites, res);
        })
    }
}
