import { Component, Input } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'

import { User } from '../../Shared/Models/user.model'
import { Account } from '../../Shared/Models/account.model'
import { UserService } from '../../Shared/Services/user.service'
import { UsersComponent } from './users.component'

@Component({
    selector: 'users-item',
    templateUrl: './AppScripts/Components/Users/users-item.component.html',
    providers: [UserService]
})

export class UsersItemComponent {
    @Input() user: User;

    constructor(private userService: UserService,
        private account: Account,
        private uc: UsersComponent) {
    }

    lockout(isLockoutEnabled: boolean) {
        if (isLockoutEnabled == true) {
            this.user.isLockoutEnabled = false;
        }
        else {
            this.user.isLockoutEnabled = true;
        }
    }

    delete(id: string) {
        this.userService.deleteUser(id).then(res => this.uc.update());
    }
}