import { Component, OnInit, NgModule } from '@angular/core'
import { FroalaModule } from '../../Froala-editor/froala.module'
import { DndModule } from 'ng2-dnd';
import { DynamicComponentModule } from "angular2-dynamic-component";
import { ActivatedRoute } from '@angular/router'

import { SiteContent } from '../../Shared/Models/site.content.model';
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';

import { Page } from '../../Shared/Models/page.model'
import { PageService } from '../../Shared/Services/pages.service'
import { Account } from '../../Shared/Models/account.model'

declare var $: any;

@Component({
    selector: 'page-editor',
    templateUrl: './appScripts/Components/Page/page.editor.component.html',
})

export class PageEditorComponent {
    availableElements = [];
    elements = [];
    trash = [];
    id;
    loading: boolean = false;
    failload: boolean = false;
    options: any;

    editable: boolean = true;

    public nameModel = { innerHTML: this.page.name || "Unnamed" };
    public previewModel = {
        src: this.page.previev || 'http://www.iconarchive.com/download/i94287/bokehlicia/captiva/browser-web.ico',
    };

    public previewEditor = {
        	imageEditButtons: ['imageReplace', '|', '-', 'imageStyle']
    };

    public extraModules = [FroalaModule, DndModule.forRoot()];

    constructor(private account: Account, private route: ActivatedRoute,
        private pageService: PageService, private page: Page) {

        this.id = +this.route.snapshot.params['id'];

        if (!this.id) this.newPage();
        else this.getPage();

        this.options = {
            placeholderText: 'Edit Your Content Here...',
            charCounterCount: false,
            toolbarInline: true,
            disableRightClick: true,
            toolbarVisibleWithoutSelection: true,
            dragInline: false,
            enter: $.FroalaEditor.ENTER_BR,
            imageDefaultDisplay: 'inline',
            pluginsEnabled: ['align', 'codeBeautifier', 'codeView', 'image', 'link', 'video', 'file',
                'fontFamily', 'paragraphFormat', 'forms', 'imageManager', 'inlineStyle',
                'lists', 'paragraphStyle',
                'quote', 'table', 'url', 'save', 'entities', 'emoticons',
                'draggable', 'colors'],
        };

        this.availableElements.push({
            previous: `<button class="btn btn-default"><i class="fa fa-tint" aria-hidden="true"></i> Text</button>`,
            element: `<div *ngIf="editable" [froalaEditor]="options" [(froalaModel)]="content[0]"></div>
                        <div *ngIf="!editable" [froalaView]="content[0]"></div>`,
            inputData: {
                options: this.options,
                content: [""],
            }
        },
            {
                previous: `<button class="btn btn-default"><i class="fa fa-tint" aria-hidden="true"></i> Panel</button>`,
                element: `<div class="panel panel-default">
                                <div class="panel-heading">
                                    <div *ngIf="editable" [froalaEditor]="options" [(froalaModel)]="content[0]"></div>
                                        <div *ngIf="!editable" [froalaView]="content[0]"></div>
                                </div>
                                <div class="row">
                                <div class="panel-body">
                                    <div style="min-height: 20px" class="col-sm-6">
                                        <div *ngIf="editable" [froalaEditor]="options" [(froalaModel)]="content[1]"></div>
                                        <div *ngIf="!editable" [froalaView]="content[1]"></div>
                                    </div>
                                    <div style="min-height: 20px" class="col-sm-6">
                                        <div *ngIf="editable" [froalaEditor]="options" [(froalaModel)]="content[2]"></div>
                                        <div *ngIf="!editable" [froalaView]="content[2]"></div>
                                    </div>
                                </div>
                            </div>
                        </div>`,
                inputData: {
                    options: this.options,
                    content: ["", "", ""],
                },
            }
        );



    }

    addElement(data, elements) {
        let obj = JSON.parse(JSON.stringify(data));
        obj.inputData.editable = this.editable;
        this.elements.push(obj);
    }

    newPage(userId = null) {
        if (!userId)
            this.page.userId = this.account.id;
        else
            this.page.userId = userId;
    }

    getPage() {
        this.pageService.getPage(this.id).then(res => {
            this.parseContent();
        });
    }

    parseContent() {
        if (this.page.content) {
            this.elements = JSON.parse(this.page.content);
            this.elements.forEach(p => p.inputData.options = this.options);
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
        if (!this.id) this.createPage();
        else this.saveChangesToDb();
    }

    createPage() {
        this.pageService.createPage(this.page).then(res => {
            this.id = res;
            this.loaded();
        }).catch(res => this.failloaded());
    }

    saveChangesToDb() {
        console.log(this.page);
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
            let content = [];
            let elements = JSON.parse(JSON.stringify(this.elements));

            elements.forEach(p => {
                let obj = { element: p.element, inputData: p.inputData };
                obj.inputData.editable = null;
                content.push(obj);
            });

            this.page.content = JSON.stringify(content);
        }
    }
}