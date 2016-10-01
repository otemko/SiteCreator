import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { Account } from '../../Shared/Models/account.model'
import { SiteService } from '../../Shared/Services/sites.service'

@Component({
    selector: 'site-user-item',
    templateUrl: './AppScripts/Components/Sites/site-user-item.component.html',
    providers: [SiteService]
})

export class SiteUserItemComponent {
    @Input() site: Site;

    constructor(private siteService: SiteService, private account: Account, private route: Router)
    {
    }

    delete(id: number): void {
        this.siteService.deleteSite(id).then(resId => {
            if (id == resId)
            {
                setTimeout(() => { this.route.navigateByUrl("/sites-user/" + this.account.id); }, 100); 
                console.log('Succeed');
            }
            else
                alert("You can't do it");
        });
        
    }

    edit(id: number): void {
        this.route.navigate(['/site-create', id]);
    }
}