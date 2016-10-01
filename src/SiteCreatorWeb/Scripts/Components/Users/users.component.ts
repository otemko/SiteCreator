import { Component, Pipe, PipeTransform, Sanitizer, SecurityContext } from '@angular/core'
import { DomSanitizer, SafeHtml, SafeUrl, SafeResourceUrl, SafeStyle } from '@angular/platform-browser';

@Component({
    selector: 'about',
    templateUrl: './appScripts/Components/Users/users.component.html'
})
@Pipe({
    name: 'sanitizeHtml'
})
export class UsersComponent implements PipeTransform {
    availableProducts = [];
    shoppingBasket = [];

    constructor(private _sanitizer: DomSanitizer) {
        this.availableProducts.push('<b>Hello</b>');
        this.availableProducts.push('<div>Hello</div>');
        this.availableProducts.push(`<div class="panel panel-default">
                                        <div class="panel-heading">Hello</div>
                                        <div class="panel-body">Hello</div>
                                    </div>`);
        this.availableProducts.push(`<div class="form-group">
                                        <label>Tittle:</label>
                                        <input type="text" class="form-control">
                                    </div>
                                    <button class="btn btn-default">Submit</button>
                                </div>`);
        this.availableProducts.push(`<span>12312312</span>
                                    <span>
                                        <img  style="z-index: 0" src='http://vignette4.wikia.nocookie.net/mrmen/images/5/52/Small.gif/revision/latest?cb=20100731114437'>
                                    </span>`);

    }

    transform(v: string) {
        return this._sanitizer.bypassSecurityTrustHtml(v);
    }

    tr(v: string) {
        return this._sanitizer.bypassSecurityTrustUrl(v);
    }

    orderedProduct(orderedProduct: any) {
        console.log(orderedProduct);
    }
    addToBasket($event) {
        let newProduct = $event.dragData;
        this.shoppingBasket.push(newProduct);
    }
}

