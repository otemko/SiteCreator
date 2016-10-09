import { Component, Input, Output, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Page } from '../../../Shared/Models/page.model';
import { HomeService } from '../../../Shared/Services/home.service'

@Component({
    selector: 'most-commented-pages',
    templateUrl: './appScripts/Components/Home/Parts/most-commented-pages.component.html',
    providers: [HomeService]
})

export class MostCommentedPages implements OnInit {
    pages: Page[] = new Array();

    constructor(private homeService: HomeService) {
    }

    ngOnInit() {
        this.homeService.getMostCommentedPages().then(res => {
            Object.assign(this.pages, res);
        })
    }
}
