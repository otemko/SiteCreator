import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { SitesComponent } from './sites.component'
import { Account } from '../../Shared/Models/account.model'
import { SiteService } from '../../Shared/Services/sites.service'

@Component({
    selector: 'site-item',
    templateUrl: './AppScripts/Components/Sites/site-item.component.html'
})

export class SiteItemComponent {
    @Input() site: Site;

    constructor(private account: Account,
        private sc: SitesComponent,
        private route: Router,
        private siteService: SiteService) {
    }

    tagClick(id: number): void {
        this.sc.update(id);
    }

    delete(id: number): void {
        this.siteService.deleteSite(id).then(resId => {
            if (id == resId) {
                this.route.navigate([this.route.url]);
                this.sc.update(null);
            }
            else
                alert("You can't do it");
        });

    }

    edit(id: number): void {
        this.route.navigate(['/site-create', id]);
    }
}