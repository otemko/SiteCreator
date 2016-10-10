import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model';
import { SiteItemComponent } from './site-item.component';
import { SiteService } from '../../Shared/Services/sites.service'
import { Language } from '../../Shared/Models/language.model';

@Component({
    selector: 'sites',
    templateUrl: './appScripts/Components/Sites/sites.component.html',
    providers: [SiteService]
})

export class SitesComponent{
    sites: Site[] = new Array();

    typeSort = -1;

    constructor(private l: Language, private siteService: SiteService, private route: ActivatedRoute) {
        let id = +this.route.snapshot.params['id'];
        this.update(id);        
    }

    update(id : number) {
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

    sortBy() {
        if (this.typeSort == 0) {
            this.sortByUserName();
        }
        if (this.typeSort == 1) {
            this.sortBySiteName();
        }
        if (this.typeSort == 2) {
            this.sortByDate();
        }

    }

    sortByUserName() {
        this.sites.sort(
            function compare(a: Site, b: Site) {
                if (a.userName < b.userName)
                    return -1;
                if (a.userName > b.userName)
                    return 1;
                return 0;
            });
        
    }

    sortBySiteName() {
        this.sites.sort(
            function compare(a: Site, b: Site) {
                if (a.name < b.name)
                    return -1;
                if (a.name > b.name)
                    return 1;
                return 0;
            });
    }

    sortByDate() {
        this.sites.sort(function (a: Site, b: Site) {
            return new Date(a.dateCreated).getTime() - new Date(b.dateCreated).getTime()
        });
        this.sites.reverse();
    }

}
