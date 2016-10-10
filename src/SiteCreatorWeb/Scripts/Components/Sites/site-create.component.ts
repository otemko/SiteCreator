import { Component, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router'

import { Site } from '../../Shared/Models/site.model'
import { Tag } from '../../Shared/Models/tag.model'
import { Account } from '../../Shared/Models/account.model'
import { StyleMenu } from '../../Shared/Models/style-menu.model'

import { SiteService } from '../../Shared/Services/sites.service'
import { StyleMenuService } from '../../Shared/Services/style-menu.service'
import { TagService } from '../../Shared/Services/tag.service'

import { Page } from '../../Shared/Models/page.model'
import { PageService } from '../../Shared/Services/pages.service'

import { Language } from '../../Shared/Models/language.model'
import { GlobalService } from '../../Shared/Services/global.service'


@Component({
    selector: 'site-create',
    styleUrls: ['./appScripts/Components/Sites/site-create.component.css'],
    templateUrl: './appScripts/Components/Sites/site-create.component.html',
    providers: [SiteService, StyleMenuService, TagService]
})

export class SiteCreateComponent {
    isReady: boolean;
    site: Site = new Site();
    styleMenus: StyleMenu[];
    tags: Tag[];
    id;
    loading: boolean;
    tagNames: string[] = new Array();
    filteredTags: any[];
    resultTag = "";
    public previewEditor = {
        imageEditButtons: ['imageReplace']
    };
    public previewModel: any = {};

    tagsView: string[] = new Array();

    constructor(private siteService: SiteService,
        private styleMenuService: StyleMenuService,
        private route: Router,
        private tagService: TagService,
        private account: Account,
        private r: ActivatedRoute,
        private pageService: PageService,
        private currentPage: Page,
        private gs: GlobalService,
        private l: Language) {

        this.id = +this.r.snapshot.params['id'];
        this.updateSite();
        this.site.pages = [];

        this.styleMenuService.getStyleMenus().then(styleMenus => {
            this.styleMenus = styleMenus;
        });
    }

    updateSite() {
        if (this.id) {
            this.loading = true;
            this.siteService.getSiteById(this.id).then(res => {
                Object.assign(this.site, res);
                this.getPagesOrder();
                this.tagsView = [];
                res.tags.forEach(p => this.tagsView.push(p.name));
                this.loading = false;
                this.isReady = true;
                this.setPreview();
            });
        }
        else {
            this.isReady = true;
            this.setPreview();
        }

        this.tagService.getTags().then(tags => {
            this.tags = tags;
            this.tagNames = [];
            tags.forEach(p => this.tagNames.push(p.name));
        });
    }

    setPreview() {
        this.previewModel = {
            src: this.site.preview || 'http://icons2.iconarchive.com/download/i85581/graphicloads/100-flat/home.ico'
        };
    }

    getPreview() {
        this.site.preview = this.previewModel.src || 'http://icons2.iconarchive.com/download/i85581/graphicloads/100-flat/home.ico';
    }

    newPage() {
        let page = new Page().setNull();
        Object.assign(this.currentPage, page);
        this.currentPage.siteId = this.site.id;
        this.route.navigate(['/page-edit']);
    }

    onDelete(id: number) {
        this.pageService.deletePage(id).then(res => this.updateSite());
    }

    onSubmit() {
        this.getTags();
        if (this.tagsView.length == 0) {
            let element = document.getElementById("invalid-tags");
            element.hidden = false;
        }
        else {
            this.loading = true;
            this.getPreview();
            if (this.id) {
                this.checkTheRights();
                let i = 0; this.site.pages.forEach(p => p.order = i++);
                this.siteService.updateSite(this.site).then(resId => {
                    this.updateSite();
                });
            }
            else {
                this.checkThePermission();
                this.site.userId = this.account.id;
                this.siteService.createSite(this.site).then(resId => {
                    this.id = resId;
                    this.updateSite();
                });
            }
        }
    }

    checkTheRights() {
        if (this.account.role != 'Admin' && this.account.id != this.site.userId)
            this.route.navigate(['/home']);
    }

    checkThePermission() {
        if (!this.account.id) {
            this.route.navigate(['/home']);
        }
    }

    getPagesOrder() {
        this.site.pages.sort((a, b) => a.order - b.order);
    }

    setPagesOrder() {

    }

    getTags(): void {
        this.site.tags = [];
        this.tagsView.forEach(tagView => {
            this.site.tags.push({ id: 0, name: tagView });
        });
    }

    addTag() {
        let element = document.getElementById("invalid-tags");
        element.hidden = true;
        if (this.resultTag != "" && !this.tagsView.find(p => p.toLowerCase() == this.resultTag.toLowerCase())) {
            this.tagsView.push(this.resultTag);
            this.resultTag = "";
        };
        this.filteredTags = [];
    }

    deleteTag(tagName: string) {
        let index = this.tagsView.findIndex(p => p.toLowerCase() == tagName.toLowerCase());
        if (index > -1) this.tagsView.splice(index, 1);
    }

    filterTags(event) {
        this.filteredTags = [];
        this.tagNames.forEach(tag => {
            if (tag.toLowerCase().indexOf(event.query.toLowerCase()) == 0)
                this.filteredTags.push(tag);
        });
    }

    handleDropdownClick() {
        this.filteredTags = [];
        setTimeout(() => {
            this.filteredTags = this.tagNames;
        }, 100)
    }


}