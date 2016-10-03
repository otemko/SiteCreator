import {Directive} from '@angular/core';
import {ElementRef} from '@angular/core';


@Directive({
    selector: "[html-unsafe]",
})
export class HtmlUnsafe{
    constructor(private elem: ElementRef){

    }

    set htmlUnsafe(value){
        setTimeout(() => {
            this.elem.nativeElement.innerHTML = value;
        },0);
    }
}