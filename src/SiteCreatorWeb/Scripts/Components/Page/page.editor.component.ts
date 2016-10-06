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

    editable: boolean = true;

    public extraModules = [FroalaModule, DndModule.forRoot()];

    constructor(private account: Account, private route: ActivatedRoute,
        private pageService: PageService, private page: Page) {

        this.id = +this.route.snapshot.params['id'];

        if (!this.id) this.newPage();
        else this.getPage();

        this.availableElements.push({
            previous: `<div class="text-center"><button class="btn btn-default">
                <i class="fa fa-tint" aria-hidden="true"></i> text</button></div>`,
            element: `<div *ngIf="editable" [froalaEditor]="options" [(froalaModel)]="content[0]"></div>
                        <div *ngIf="!editable" [froalaView]="content[0]"></div>`,
            inputData: {
                options: {
                    placeholderText: 'Edit Your Content Here!',
                    charCounterCount: false,
                    toolbarInline: true,
                },
                content: [""],
            }
        },
            {
                previous: `<div class="text-center"><button class="btn btn-default">
                    <i class="fa fa-tint" aria-hidden="true"></i> panel</button></div>`,
                element: `
                            <div class="panel panel-default">
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
                    options: {
                        placeholderText: 'Edit Your Content Here!',
                        charCounterCount: false,
                        toolbarInline: true,
                    },
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
        if (this.page.id == this.id) {
            this.parseContent();
        }
        else {
            this.pageService.getPage(this.id).then(res => {
                this.parseContent();
            });
        }
    }

    parseContent() {
        if (this.page.content) {
            this.elements = JSON.parse(this.page.content);
            this.editOn();
            console.log(this.page.content);
        }
    }

    editOn() {
        this.elements.forEach(p => p.inputData.editable = true);
        this.editable = true;
    }

    editOff() {
        this.elements.forEach(p => p.inputData.editable = false);
        this.editable = false;
    }


    save() {
        if (!this.id) this.create();
        else this.saveChanges();
    }

    create() {
        if (this.page.siteId == 0) {
            console.log("Error. Need site Id");
            return;
        }
        this.setContent();
        console.log(this.page);
        this.pageService.createPage(this.page).then(res => {
            console.log(res);
            this.id = res;
        });
    }

    saveChanges() {

    }

    setContent() {
        if (this.elements) {
            console.log(this.page);
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