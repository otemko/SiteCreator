import { Component } from '@angular/core'

import { User } from '../../Shared/Models/user.model'
import { Account } from '../../Shared/Models/account.model'
import { UserService } from '../../Shared/Services/user.service'
import { Language } from '../../Shared/Models/language.model'

@Component({
    selector: 'users',
    templateUrl: './appScripts/Components/Users/users.component.html',
    providers: [UserService]
})

export class UsersComponent {
    users: User[] = new Array();

    constructor(private l: Language,
        private userService: UserService,
        private account: Account) {
        this.update();
    }

    update() {
        this.userService.getUsers().then(users => {
            this.users = users;
            if (this.account.role == 'admin') {
                let index = -1;
                for (let i = 0; i < this.users.length; i++) {
                    if (this.users[i].role == 'admin') {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                    this.users.splice(index, 1);
                console.log(this.users);
            }
        });
    }

    save() {
        this.userService.updateUsers(this.users).then(res => {
            if (res == 0) {
                console.log('Succed');
            }
        });
    }
}