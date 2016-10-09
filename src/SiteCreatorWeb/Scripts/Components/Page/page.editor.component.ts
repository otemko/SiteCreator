import { Component, OnInit, NgModule } from '@angular/core'
import { FroalaModule } from '../../Froala-editor/froala.module'
import { DndModule } from 'ng2-dnd';
import { DynamicComponentModule } from "angular2-dynamic-component";
import { ActivatedRoute, Router } from '@angular/router'

import { SiteContent } from '../../Shared/Models/site.content.model';
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';

import { Page } from '../../Shared/Models/page.model'
import { PageService } from '../../Shared/Services/pages.service'
import { Account } from '../../Shared/Models/account.model'
import { Elements } from '../../Shared/Models/elements.model'
import { ElementService } from '../../Shared/Services/elements.service'

declare var $: any;

@Component({
    selector: 'page-editor',
    templateUrl: './appScripts/Components/Page/page.editor.component.html',
})

export class PageEditorComponent implements OnInit {
    isReady: boolean;
    availableElements = [];
    elements = [];
    options;
    trash = [];
    id;
    loading: boolean = false;
    failload: boolean = false;
    editable: boolean = true;

    public nameModel: any = {};
    public previewModel: any = {};

    public previewEditor = {
        imageEditButtons: ['imageReplace']
    };

    public extraModules = [FroalaModule, DndModule.forRoot()];

    constructor(private account: Account, private route: ActivatedRoute, private router: Router,
        private pageService: PageService, private page: Page, private allElements: Elements,
        private elementService: ElementService) {
    }

    ngOnInit() {
        this.elementService.getElements().then(res => {
            this.availableElements = this.allElements.all;
            this.options = this.allElements.options;
            this.id = +this.route.snapshot.params['id'];
            if (!this.id) this.newPage();
            else this.getPage();
        });
    }

    checkTheRights() {
        if (this.account.role != 'Admin' && this.account.id != this.page.userId)
            this.router.navigate(['/home']);
    }


    addElement(data, elements) {
        let obj = JSON.parse(JSON.stringify(data));
        obj.inputData.editable = this.editable;
        this.elements.push(obj);
    }

    newPage(userId = null) {
        if (!this.page.siteId) this.router.navigate(['/home']);
        if (!userId)
            this.page.userId = this.account.id;
        else
            this.page.userId = userId;
        this.checkTheRights();
        this.setPreview();
        this.setPageName();
        this.isReady = true;
    }

    getPage() {
        this.pageService.getPage(this.id).then(res => {
            this.checkTheRights();
            this.parseContent();
            this.setPreview();
            this.setPageName();
            this.isReady = true;
        });
    }

    setPreview() {
        this.previewModel = {
            src: this.page.preview || 'http://www.iconsfind.com/wp-content/uploads/2016/04/20160406_5704784546154.png',
        };

    }

    setPageName() {
        this.nameModel = { innerHTML: this.page.name || "Unnamed" };
    }

    parseContent() {
        if (this.page.content) {
            this.elements = this.pageService.parseContentFromDb(this.options);
            this.changeEditable(true);
        }
    }

    changeEditable(value: boolean) {
        this.elements.forEach(p => p.inputData.editable = value);
        this.editable = value;
    }

    save() {
        if (this.loading) return;
        this.loading = true;
        this.setContent();
        if (!this.page.id) this.createPage();
        else this.saveChangesToDb();
    }

    createPage() {
        this.pageService.createPage(this.page).then(res => {
            this.page.id = res;
            this.loaded();
        }).catch(res => this.failloaded());
    }

    saveChangesToDb() {
        this.pageService.savePage(this.page).then(res => this.loaded())
            .catch(res => this.failloaded());
    }

    loaded() {
        this.loading = false;
        this.failload = false;
    }

    failloaded() {
        this.loading = false;
        this.failload = true;
    }

    setContent() {
        if (this.elements) {
            this.page.name = this.nameModel.innerHTML;
            if (!this.previewModel.src) this.setPreview();
            this.page.preview = this.previewModel.src;

            let elementsToSave = [];
            let contentToSave = [];

            this.elements.forEach(p => {
                elementsToSave.push(p.element);
                contentToSave.push(p.inputData.content);
            });
            this.page.content = JSON.stringify(contentToSave);
            this.page.elements = JSON.stringify(elementsToSave);
        }
    }
}