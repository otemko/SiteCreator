import { Component } from '@angular/core'

import { Language } from '../../../Shared/Models/language.model'
import { Account } from '../../../Shared/Models/account.model'
import { AccountService } from '../../../Shared/Services/account.service'
import { ActivatedRoute } from '@angular/router'

@Component({
    selector: 'account-panel',
    templateUrl: './appScripts/Components/Account/AccountPanel/accountPanel.component.html',
})

export class AccountHeaderComponent {

    constructor(private account: Account,
        public route: ActivatedRoute,
        private service: AccountService,
        private l: Language) {

    }

    externalLogin(provider: string) {
        this.service.externalLogin(provider, document.URL);
    }

    logoff() {
        this.service.logoff('/');
    }
}