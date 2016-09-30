import { Component, Input } from '@angular/core'

import { Site } from '../../Shared/Models/site.model'
import { Tag } from '../../Shared/Models/tag.model'
import { Account } from '../../Shared/Models/account.model'
import { StyleMenu } from '../../Shared/Models/style-menu.model'

import { SiteService } from '../../Shared/Services/sites.service'
import { StyleMenuService } from '../../Shared/Services/style-menu.service'
import { TagService } from '../../Shared/Services/tag.service'

@Component({
    selector: 'site-create',
    styleUrls: ['./appScripts/Components/Sites/site-create.component.css'],
    templateUrl: './appScripts/Components/Sites/site-create.component.html',
    providers: [SiteService, StyleMenuService, TagService ]
})

export class SiteCreateComponent {
    site: Site;  
    styleMenus: StyleMenu[];
    tags: Tag[];

    constructor(private siteService: SiteService, private styleMenuService: StyleMenuService,
        private tagService: TagService, private account: Account) {

        this.site = new Site();
        this.styleMenuService.getStyleMenus().then(styleMenus => {
            this.styleMenus = styleMenus;
            console.log(this.styleMenus)
        });
        this.tagService.getTags().then(tags => {
            this.tags = tags;
            console.log(this.tags)
        });
    }

    onSubmit() {
        let date = new Date();
        let time = date.getDate() + '.' + (date.getMonth()+1) + '.' + date.getFullYear() + ' '
            + date.getHours() + '.' + date.getMinutes() + '.' + date.getSeconds(); 
        this.site.dateCreated = time;
        this.site.userId = this.account.id;
        console.log(this.site);
        this.siteService.createSite(this.site).then(resId => { console.log(resId); });
    }
}