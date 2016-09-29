import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { Account } from '../../Shared/Models/account.model'

@Component({
    selector: 'site-user-item',
    templateUrl: './AppScripts/Components/Sites/site-user-item.component.html'
})

export class SiteUserItemComponent {
    @Input() site: Site;

    constructor(private account: Account, private route: Router)
    {
    }

    delete(): void {
        console.log('del');
        this.route.navigate(['/sites-user', this.account.id])
    }

    edit(): void { console.log('ed'); }
}