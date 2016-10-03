import { Component, ViewContainerRef, Compiler, OnInit, NgModule, ApplicationModule } from '@angular/core'
import { Directive, ElementRef, Renderer, Input, Output, Optional, EventEmitter } from '@angular/core';

import { DomSanitizer, SafeHtml, SafeUrl, SafeResourceUrl, SafeStyle, BrowserModule } from '@angular/platform-browser';
import { SiteContent } from '../../Shared/Models/site.content.model';
import { AppModule } from '../../app.module'
import { SiteContentComponent } from './site.content.component'
import { InnerContent } from './innerContent';
import { DynamicHTMLOutlet } from './dynamic'
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';
import {DynamicComponent, DynamicComponentMetadata} from 'angular2-dynamic-component';
import { DndModule } from 'ng2-dnd';

@Component({
    selector: 'about',
    templateUrl: './appScripts/Components/Users/users.component.html'
})

export class UsersComponent implements OnInit {

    siteElements: Array<SiteContent> = [];


    constructor(private _sanitizer: DomSanitizer, private view: ViewContainerRef,
        private compiler: Compiler) {
        this.siteElements.push({
            element: `<div class="sample">
                        <h2>Sample 1: Inline Edit</h2>
                        <div [froalaEditor]="titleOptions" [(froalaModel)]="myTitle"></div>
                    </div>`,
            content: { src: 'http://weknowyourdreams.com/images/stars/stars-05.jpg' }
        }, {
                element: `<div dnd-draggable [dragEnabled]="true" [dragData]="element" [dropZones]="['demo1']">
                        <span>Hello</span></div>
                        <div dnd-draggable [dragEnabled]="true" [dragData]="element" [dropZones]="['demo1']">
                        helo</div>`
                , content: "12"
            },
            {
                element: `<account></account>`
                , content: "12"
            });
    }

    public titleOptions: Object = {
        placeholderText: 'Edit Your Content Here!',
        charCounterCount: false,
        toolbarInline: true,
        events: {
            'froalaEditor.initialized': function () {
                console.log('initialized');
            }
        }
    }
    public myTitle: string;
    public extraModules = [ Dyn ];

    ngOnInit() {
    }

    log(event) {
        console.log(event);
    }

}


@NgModule({
    imports: [DndModule],
    declarations: [FroalaEditorDirective, FroalaViewDirective],
    exports: [FroalaEditorDirective, FroalaViewDirective]
})
export class Dyn { }