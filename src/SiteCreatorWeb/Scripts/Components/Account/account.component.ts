import { Component } from '@angular/core'

import { Account } from '../../Shared/Account/account.model'
import { AccountService } from '../../Shared/Account/account.service'


@Component({
    selector: 'account',
    templateUrl: './appScripts/Components/Account/account.component.html'
})

export class AccountComponent {

    constructor(private account: Account){
        }
}