import { Component, OnInit, NgModule } from '@angular/core'
import { FroalaModule } from '../../Froala-editor/froala.module'
import { DndModule } from 'ng2-dnd';
import { DynamicComponentModule } from "angular2-dynamic-component";

import { SiteContent } from '../../Shared/Models/site.content.model';
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';

declare var $: any;



@Component({
    selector: 'about',
    templateUrl: './appScripts/Components/Users/users.component.html'
})

export class UsersComponent implements OnInit {
    availableElements = [];
    elements = [];
    currentElement = {};
    trash = [];

    editable = "true";

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

    ngOnInit() {
    }

    addElement(data, elements) {
        let obj = JSON.parse(JSON.stringify(data));
        obj.inputData.addElement = this.addElement;
        obj.inputData.editable = this.editable;
        this.elements.push(obj);
        console.log(this.currentElement);
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

    click() {
        //     $('#preview').empty();

        // this.elements.forEach(element => {
        //     $('#preview').append(element.element);
        // });
        // console.log($('#preview').html());
        // $('dynamiccomponent[ng-reflect-component-template]').remove();
        // $('div[contenteditable]').removeAttr('contenteditable');
        // $('[dnd-sortable]').removeAttr('dnd-sortable');   
        // $('[dnd-droppable]').removeAttr('dnd-droppable'); 
        // $('[dnd-draggable]').removeAttr('dnd-draggable'); 
        // $('[draggable]').removeAttr('draggable');

        // this.editable = !this.editable;
        // let target = '#Site';
        // this.removeAttributes(target, 'dnd');
        // this.removeAttributes(target, 'drag');
        // this.removeAttributes(target, 'ng-');
        // this.removeAttributes(target, 'contentEditable');
        this.elements.forEach(element => {
            element.inputData.editable = false;
        });

        this.editable = null;

        console.log($('#Site').html());
    }

    removeAttributes(target, attr) {

        var i,
            $target = $(target),
            attrName,
            dataAttrsToDelete = [],
            dataAttrs = $target.get(0).attributes,
            dataAttrsLen = dataAttrs.length;

        for (i = 0; i < dataAttrsLen; i++) {
            if (attr === dataAttrs[i].name.substring(0, attr.length)) {
                dataAttrsToDelete.push(dataAttrs[i].name);
            }
        }
        $.each(dataAttrsToDelete, function (index, attrName) {
            $target.removeAttr(attrName);
        })
    };

}