import { Component, OnInit, NgModule } from '@angular/core'
import { FroalaModule } from '../../Froala-editor/froala.module'
import { DndModule } from 'ng2-dnd';
import { DynamicComponentModule } from "angular2-dynamic-component";

import { SiteContent } from '../../Shared/Models/site.content.model';
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';

@Component({
    selector: 'about',
    templateUrl: './appScripts/Components/Users/users.component.html'
})

export class UsersComponent implements OnInit {

    availableElements = [];
    elements = [];
    public extraModules = [ FroalaModule, DndModule.forRoot() ];

    constructor() {
        this.availableElements.push({
            previous: `<div class="text-center"><button class="btn btn-default">
                <i class="fa fa-tint" aria-hidden="true"></i> text</button></div>`,
            element: `<div [froalaEditor]="options" [(froalaModel)]="content"></div>`,
            inputData: {
                options: {
                    placeholderText: 'Edit Your Content Here!',
                    charCounterCount: false,
                    toolbarInline: true,
                },
                content: '',
                elements: []
            },

        },
            {
                previous: `<div class="text-center"><button class="btn btn-default">
                    <i class="fa fa-tint" aria-hidden="true"></i> panel</button></div>`,
                element: `<div class="row">
                            <div class="panel panel-default">
                                <div class="panel-heading" dnd-droppable (onDropSuccess)="addElement($event.dragData)" [dropZones]="['add']">
                                    <div *ngFor="let el of elements; let i = index" dnd-draggable [dragEnabled]="true" [dragData]="el" [dropZones]="['add','trash']">
                                         Hallo
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div style="min-height: 20px" class="col-sm-6" dnd-droppable (onDropSuccess)="addElement($event.dragData)" [dropZones]="['add']">
                                    </div>
                                    <div style="min-height: 20px" class="col-sm-6" dnd-droppable (onDropSuccess)="addElement($event.dragData)" [dropZones]="['add']">
                                    </div>
                                </div>
                            </div>
                        </div>`,
                inputData: {
                    content: '',
                    elements: []
                },
            }
        );
    }

    ngOnInit() {
    }

    addElement(data, elements) {
        let obj = JSON.parse(JSON.stringify(data));
        obj.inputData.addElement = this.addElement;
        this.elements.push(obj);
        console.log(obj);
    }

    removeElement(data) {
        let index = this.elements.indexOf(data, 0);
        if (index > -1)
            this.elements.splice(index, 1);
    }

    assign(obj) {
        let newObj = {};
        return newObj;
    }

    log(event) {
        console.log(event);
    }

}