import { Component, OnDestroy } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { Account } from '../../Shared/Models/account.model'
import { AccountService } from '../../Shared/Services/account.service'

@Component({
    selector: 'lockout',
    templateUrl: './appScripts/Components/Lockout/lockout.component.html',
    providers: [AccountService]
})

export class LockoutComponent implements OnDestroy {

    constructor(private account: Account, private accountService: AccountService, private route: ActivatedRoute) {
        
    }    

    ngOnDestroy(): void{
        console.log(this.account.id);
        if (this.account.id) {
            this.accountService.logoff('/');
        }
    }
}