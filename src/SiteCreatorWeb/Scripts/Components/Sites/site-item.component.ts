import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { SitesComponent } from './sites.component'
import { SiteService } from '../../Shared/Services/sites.service'

import { Account } from '../../Shared/Models/account.model'
import { GlobalService } from '../../Shared/Services/global.service'

@Component({
    selector: 'site-item',
    templateUrl: './AppScripts/Components/Sites/site-item.component.html'
})

export class SiteItemComponent {
    @Input() site: Site;

    constructor(private account: Account,
        private sc: SitesComponent,
        private route: Router,
        private siteService: SiteService,
        private gs: GlobalService
    ) {
    }

    tagClick(id: number): void {
        this.sc.update(id);
    }

    delete(id: number): void {
        this.siteService.deleteSite(id).then(resId => {
            this.route.navigate([this.route.url]);
            this.sc.update(null);
        });
    }

    edit(id: number): void {
        this.route.navigate(['/site-create', id]);
        this.gs.prevUrl = this.route.url;
    }
}