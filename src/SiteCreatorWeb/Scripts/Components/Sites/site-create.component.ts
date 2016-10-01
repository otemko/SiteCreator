﻿import { Component, Input } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router'

import { SiteCreate } from '../../Shared/Models/site-create.model'
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
    providers: [SiteService, StyleMenuService, TagService]
})

export class SiteCreateComponent {
    newSite: SiteCreate;
    styleMenus: StyleMenu[];
    tags: Tag[];

    tagNames: string[] = new Array();    
    filteredTags: any[];
    resultTag = "";

    tagsView: string[] = new Array();

    oldTags: Tag[] = new Array();
    newTags: string[] = new Array();

    constructor(private siteService: SiteService, private styleMenuService: StyleMenuService,
        private route: Router, private tagService: TagService, private account: Account,
        private r: ActivatedRoute) {
            
        this.newSite = new SiteCreate();     
        
        this.styleMenuService.getStyleMenus().then(styleMenus => {
            this.styleMenus = styleMenus;
        });

        this.tagService.getTags().then(tags => {
            this.tags = tags;
            for (let i = 0; i < this.tags.length; i++) {
                this.tagNames.push(this.tags[i].name);                
            }                  
        });        
    }

    onSubmit() {

        if (this.tagsView.length == 0) {
            let element = document.getElementById("invalid-tags");
            element.hidden = false;
        }
        else {
            this.newSite.dateCreated = this.getDate();

            this.newSite.userId = this.account.id;

            this.getTags();
            this.newSite.oldTags = this.oldTags;
            this.newSite.newTags = this.newTags;
            
            this.siteService.createSite(this.newSite).then(resId => { console.log(resId); });
            this.route.navigate(['/sites-user', this.account.id]);

        }
    }

    private getDate(): string {
        let date = new Date();
        return date.getDate() + '.' + (date.getMonth() + 1) + '.' + date.getFullYear() + ' '
            + date.getHours() + '.' + date.getMinutes() + '.' + date.getSeconds();
    }

    getTags(): void {
        for (let i = 0; i < this.tagsView.length; i++) {
            let check = false;
            let oldTag: Tag;
            for (let j = 0; j < this.tags.length; j++) {
                if (this.tags[j].name == this.tagsView[i]) {
                    check = true;
                    oldTag = this.tags[j];
                    break;
                }
            }
            if (check) {
                this.oldTags.push(oldTag);
            }
            else {
                this.newTags.push(this.tagsView[i]);
            }
        }
    }

    filterTags(event) {
        this.filteredTags = [];
        for (let i = 0; i < this.tagNames.length; i++) {
            let tag = this.tagNames[i];
            if (tag.toLowerCase().indexOf(event.query.toLowerCase()) == 0) {
                this.filteredTags.push(tag);
            }
        }
    }
    
    handleDropdownClick() {
        this.filteredTags = [];
         setTimeout(() => {
             this.filteredTags = this.tagNames;
        }, 100)
    }

    addTag() {
        let element = document.getElementById("invalid-tags");
        element.hidden = true;

        if (this.resultTag != "") {
            let check = true;
            for (let i = 0; i < this.tagsView.length; i++) {
                if (this.tagsView[i].toLowerCase() == this.resultTag.toLowerCase()) {
                    check = false;
                    break;
                }
            }
            if (check) {
                this.tagsView.push(this.resultTag);
                this.resultTag = "";
            }
        }
        this.filteredTags = [];
    }

    deleteTag(tagName: string) {
        let index = -1;
        for (let i = 0; i < this.tagsView.length; i++) {
            if (this.tagsView[i].toLowerCase() == tagName.toLowerCase()) {
                index = i;
                break;
            }
        }
        if (index != -1)
            this.tagsView.splice(index, 1);
    }
}