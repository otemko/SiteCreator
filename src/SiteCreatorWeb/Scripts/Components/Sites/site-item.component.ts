import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { SitesComponent } from './sites.component'

@Component({
    selector: 'site-item',
    templateUrl: './AppScripts/Components/Sites/site-item.component.html'
})

export class SiteItemComponent {
    @Input() site: Site;

    constructor(private sc: SitesComponent, private route: Router) {
    }

    tagClick(id: number): void {
        this.sc.update(id);
    }
}