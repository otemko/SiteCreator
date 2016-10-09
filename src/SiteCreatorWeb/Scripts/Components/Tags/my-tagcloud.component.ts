//import { Component, Input} from '@angular/core';
//import { TagCloudComponent } from '../../tag-cloud/tag-cloud.component';
//import { TagSiteService } from '../../Shared/Services/tag-site.service';
//import { TagSite } from '../../Shared/Models/tag-site.model'

//@Component({
//    selector: 'my-tagcloud',
//    templateUrl: './appScripts/Components/Tags/my-tagcloud.component.html',
//    styleUrls: ['./appScripts/Components/Tags/my-tagcloud.component.css'],
//    providers: [TagSiteService]
//})

//export class MyTagCloudComponent{
//    public size = 10;
//    public latestSelected: string = "";
//    public showSize: boolean = true;


//    private tagSite: TagSite[] = new Array();
//    tagSiteView: string = "asd";

//    constructor(private tagSiteService: TagSiteService) {
//        this.tagSiteView;
//        this.tagSiteService.getTagSites().then(res => {
//            this.tagSite = res;
//            this.tagSiteView = this.createString(this.tagSite);
//            console.log(this.tagSiteView);
//        });
//    }

//    ss() { console.log('ss'); console.log('ss') };

//    onSelectedTag(name: string) {
//        console.log(name);
//        this.latestSelected = name;
//    }

//    createString(tagSite: TagSite[]): string {
//        let result = "";
//        tagSite.forEach(ts => result += ts.tagName + ' ');
//        return result;
//    }
//}

import {Component, OnInit, EventEmitter, Directive} from '@angular/core';
import {Tag} from '../../Tag-cloud/tag';
import {TagCloud} from '../../Tag-cloud/tag-cloud';
import {TagBadgeComponent} from '../../Tag-cloud/tag-badge.component';
import {TagCloudService} from '../../Tag-cloud/tag-cloud.service';
import { TagSiteService } from '../../Shared/Services/tag-site.service';
import { TagSite } from '../../Shared/Models/tag-site.model'
import { Router } from '@angular/router'

@Component({
    selector: 'my-tagcloud',
    templateUrl: './appScripts/Components/Tags/my-tagcloud.component.html',
    styleUrls: ['./appScripts/Components/Tags/my-tagcloud.component.css'],
    providers: [TagCloudService, TagSiteService]
})

export class MyTagCloudComponent implements OnInit {
    public text: string;
    public maxWords: number = Number.MAX_SAFE_INTEGER;
    public highlightFunction: (word: string) => boolean;
    public ignoreFunction: (word: string) => boolean;
    public showSize: boolean = true;
    public maxSizeRatio: number = 1.5;
    public selectedTag: EventEmitter<string> = new EventEmitter<string>();
    public tagCloud: TagCloud;
    public sizeRatio: number = 4;


    private tagSite: TagSite[] = new Array();

    constructor(private _tagCloudService: TagCloudService,
        private tagSiteService: TagSiteService,
        private router: Router
    ) { }

    createString(tagSite: TagSite[]): string {
        let str = "";
        tagSite.forEach(ts => str += ts.tagName + ' ');        
        return str.substring(0, str.length - 1);
    }

    ngOnInit() {
        this.tagSiteService.getTagSites().then(res => {
            this.tagSite = res;
            this.text = this.createString(this.tagSite);
            this._tagCloudService.getTagCloudF(this.text, this.maxWords, this.highlightFunction, this.ignoreFunction).then(tagCloud => {
                this.tagCloud = tagCloud;
                this.sizeRatio = (this.maxSizeRatio * 100 - 100) / (this.tagCloud.max - 1);
            });
        });        
    }


    tagClick(tagName: string) {
        let id = this.searchIdByTagName(tagName);        
        this.router.navigate(['/sites', id]);
    }
    
    searchIdByTagName(tagName: string): number {
        let id: number;
        for (let i = 0; i < this.tagSite.length; i++) {
            if (this.tagSite[i].tagName.toLowerCase() == tagName.toLowerCase()) {
                id = this.tagSite[i].tagId;          
            }
        }
        return id; 
    }
}