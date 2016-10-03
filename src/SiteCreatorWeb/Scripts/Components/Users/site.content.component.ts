import { Component, ViewChild, ElementRef, Input, OnInit, NgModule, Compiler, Injectable } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';


@Injectable()
@Component({
    selector: "site-content",
    template: "<div #data></div>",
})
@NgModule({
    imports: [BrowserModule]
})
export class SiteContentComponent implements OnInit {
    @Input() element: string;
    @ViewChild('data') dataContainer: ElementRef;

    constructor(private compiler: Compiler) {
    }

    ngOnInit() {
        console.log(this.dataContainer.nativeElement);
        this.dataContainer.nativeElement.innerHTML = this.element;
    }

}

