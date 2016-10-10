import { Component, OnInit, NgModule } from '@angular/core'
import { FroalaModule } from '../../Froala-editor/froala.module'
import { DndModule } from 'ng2-dnd';
import { DynamicComponentModule } from "angular2-dynamic-component";
import { ActivatedRoute } from '@angular/router'

import { SiteContent } from '../../Shared/Models/site.content.model';
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';
import { Page } from '../../Shared/Models/page.model'
import { PageService } from '../../Shared/Services/pages.service'

declare var $: any;

@Component({
    selector: 'page-editor',
    templateUrl: './appScripts/Components/Page/page.component.html',
    providers: [PageService]
})

export class PageComponent {
    isReady: boolean;
    voted;
    elements = [];
    id;
    public extraModules = [FroalaModule, DndModule.forRoot()];

    constructor(private pageService: PageService, private page: Page, private route: ActivatedRoute) {
        this.id = +this.route.snapshot.params['id'];
        this.page.setNull();
        this.update(this.id);
    }

    update(id: number) {
        this.pageService.getPage(id).then(res => {
            if (this.page && this.page.content) {
                this.elements = this.pageService.parseContentFromDb(null);
            }
            this.isReady = true;
        });
    }

    vote(event) {
        this.voted = true;
        let rating = +event.target.title;
        this.pageService.vote(this.page.id, rating).then(res => {
            this.page.rating = res.rating;
            this.page.countRated = res.countRated; 
        });
    }
}