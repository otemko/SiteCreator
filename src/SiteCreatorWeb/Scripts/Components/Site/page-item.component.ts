import { Component, Input, Injectable, Output, EventEmitter} from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { Page } from '../../Shared/Models/page.model'

@Injectable()
@Component({
    selector: 'page-item',
    templateUrl: './AppScripts/Components/Site/page-item.component.html'
})

export class PageItemComponent {
    @Input() page: Page;
    @Output() delete = new EventEmitter();


    onDelete(id: number) {
        this.delete.emit(id);
    }

}