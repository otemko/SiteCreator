import { Component, Injectable } from '@angular/core'
import { Http, Headers, RequestOptions, Response } from '@angular/http'

import 'rxjs/add/operator/toPromise';

import { User } from '../Models/user.model'
import { Service } from './service'


@Injectable()
export class UserService {

    private url = 'api/User/';

    constructor(private service: Service) {

    }

    getUsers(): Promise<User[]> {
        return this.service.get(this.url);
    }

    updateUsers(users: User[]): Promise<number> {
        return this.service.put(this.url, users);
    }

    deleteUser(id: string): Promise<number> {
        return this.service.delete(this.url + id);
    }
}