import { Component } from '@angular/core'

import { Account } from '../../Shared/Models/account.model'
import { AccountService } from '../../Shared/Services/account.service'


@Component({
    selector: 'account',
    templateUrl: './appScripts/Components/Account/account.component.html'
})

export class AccountComponent {

    constructor(private account: Account){
        }
}