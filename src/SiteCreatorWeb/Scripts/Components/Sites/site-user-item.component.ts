import { Component, Input } from '@angular/core'

import { Site } from '../../Shared/Models/site.model'

@Component({
    selector: 'site-user-item',
    templateUrl: './AppScripts/Components/Sites/site-user-item.component.html'
})

export class SiteUserItemComponent {
    @Input() site: Site;
}