import { Component } from '@angular/core'

import { Account } from '../../../Shared/Models/account.model'
import { Service } from '../../../Shared/Services/service'

@Component({
    selector: 'account-panel',
    templateUrl: './appScripts/Components/Account/AccountPanel/accountPanel.component.html',
})

export class AccountHeaderComponent {

    constructor(private account: Account, private service: Service) {

    }

    externalLogin(provider: string) {
        let body = { provider: provider };
        this.post('/Account/ExternalLogin', body, '');
    }

    post(path, params, method) {
        method = method || "post";

        var form = document.createElement("form");
        form.setAttribute("method", method);
        form.setAttribute("action", path);

        for (var key in params) {
            if (params.hasOwnProperty(key)) {
                var hiddenField = document.createElement("input");
                hiddenField.setAttribute("type", "hidden");
                hiddenField.setAttribute("name", key);
                hiddenField.setAttribute("value", params[key]);

                form.appendChild(hiddenField);
            }
        }

        document.body.appendChild(form);
        form.submit();
    }

}