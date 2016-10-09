import { Component, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { Page } from '../../Shared/Models/page.model'
import { SiteService } from '../../Shared/Services/sites.service'
import { PageService } from '../../Shared/Services/pages.service'
import { PageEditorComponent } from '../Page/page.editor.component'


@Component({
    selector: 'site',
    templateUrl: './appScripts/Components/Site/site.component.html'
})

export class SiteComponent {
    site: Site = new Site();

    constructor(private siteService: SiteService, private pageService: PageService,
            private activatedRoute: ActivatedRoute, private currentPage: Page, private route: Router) {
        this.updateModel();
    }

    updateModel() {
        let id = +this.activatedRoute.snapshot.params['id'];
        this.siteService.getSiteById(id).then(res => {
            Object.assign(this.site, res)
        });
    }

    onDelete(id: number) {
        this.pageService.deletePage(id).then(res => this.updateModel());
    }

}