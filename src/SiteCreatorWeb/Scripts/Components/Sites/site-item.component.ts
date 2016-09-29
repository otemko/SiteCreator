import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'

@Component({
    selector: 'site-item',
    templateUrl: './AppScripts/Components/Sites/site-item.component.html'
})

export class SiteItemComponent {
    @Input() site: Site;

    constructor(private route: Router) {
    }

    tagClick(id: number): void {
        console.log(id);
        this.route.navigate(['/sites/', id]);
    }
}