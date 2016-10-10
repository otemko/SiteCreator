import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { Account } from '../../Shared/Models/account.model'
import { SiteService } from '../../Shared/Services/sites.service'
import { SitesUserComponent } from './sites-user.component'
import { Language } from '../../Shared/Models/language.model'

import { GlobalService } from '../../Shared/Services/global.service'

@Component({
    selector: 'site-user-item',
    templateUrl: './AppScripts/Components/Sites/site-user-item.component.html',
    providers: [SiteService]
})

export class SiteUserItemComponent {
    @Input() site: Site;

    isHavePermisssion = false;


    constructor(private l: Language,
        private suc: SitesUserComponent,
        private siteService: SiteService,
        private account: Account,
        private route: Router,
        private gs: GlobalService) {
    }
    

    delete(id: number): void {
        this.siteService.deleteSite(id).then(res => {
            this.route.navigate(['/sites-user', this.account.id]);
            this.suc.update();
        }).catch(res => alert("You can't do it"))
    }

    edit(id: number): void {
        this.route.navigate(['/site-create', id]);
        this.gs.prevUrl = this.route.url;
    }

    checkPermission() {
        if (this.account.role == 'admin')
            return true;
        if (this.account.id == this.site.userId)
            return true;
        return false;
    }
}