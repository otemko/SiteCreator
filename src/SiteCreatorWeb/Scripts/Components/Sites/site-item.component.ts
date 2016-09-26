import { Component, Input } from '@angular/core'

import { Site } from '../Site/site.model'

@Component({
    selector: 'site-item',
    templateUrl: './AppScripts/Components/Sites/site-item.component.html'
})

export class SiteItemComponent {
    @Input() site: Site;

}