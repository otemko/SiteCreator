export class Account {
    id: string;
    nickName: string;
    firstName: string;
    lastName: string;
    languageId: number;
    styleId: number;

    read(account) {
        this.id = account.id;
        this.nickName = account.nickName;
    }
}

