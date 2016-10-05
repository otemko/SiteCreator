import { Component, OnInit, NgModule } from '@angular/core'
import { FroalaModule } from '../../Froala-editor/froala.module'
import { DndModule } from 'ng2-dnd';
import { DynamicComponentModule } from "angular2-dynamic-component";

import { SiteContent } from '../../Shared/Models/site.content.model';
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';

declare var $: any;

@Component({
    selector: 'page-editor',
    templateUrl: './appScripts/Components/Page/page.editor.component.html'
})

export class PageEditorComponent {
    availableElements = [];
    elements = [];
    currentElement = {};
    trash = [];

    editable : boolean = true;

    public extraModules = [FroalaModule, DndModule.forRoot()];

    constructor() {
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
        console.log(this.currentElement);
    }

    click() {
        this.editable = !this.editable;
        this.elements.forEach(element => {
            element.inputData.editable = this.editable;
        });
    }
}