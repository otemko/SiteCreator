export class Account {
    id: string;
    name: string;

    read(account : Account) {
        this.id = account.id;
        this.name = account.name;
    }
}

