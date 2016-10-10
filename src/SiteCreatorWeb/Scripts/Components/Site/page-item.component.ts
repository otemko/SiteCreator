import { Component, Input, Injectable, Output, EventEmitter} from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'
import { Account } from '../../Shared/Models/account.model'

import { Page } from '../../Shared/Models/page.model'

@Injectable()
@Component({
    selector: 'page-item',
    templateUrl: './AppScripts/Components/Site/page-item.component.html'
})

export class PageItemComponent {
    @Input() page: Page;
    @Output() delete = new EventEmitter();

    constructor(private account: Account) {
    }

    onDelete(id: number) {
        this.delete.emit(id);
    }

    checkPermission() {
        if (this.account.role == 'admin')
            return true;
        if (this.account.id == this.page.userId)
            return true;
        return false;
    }
}