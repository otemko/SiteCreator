import { Injectable, ApplicationModule } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable'

import 'rxjs/add/operator/toPromise';


@Injectable()
export class Service {
    
    constructor(private http: Http) {}

    get(url: string): Promise<any> {
        return this.getPromise<any>(
            this.http.get(url));
    }

    post<T>(url: string, item: T): Promise<T> {
        let body = JSON.stringify(item);
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers });

        return this.getPromise<T>((this.http.post(url, 'provider=Twitter', options)));
    }

    
    private getPromise<T>(response: Observable<Response>) : Promise<T> {
        return response.toPromise()
            .then(res => res.json())
            .catch(this.handleError);
    }


    private handleError(error: any): Promise<void> {
        console.log('Error12456', error);
        return Promise.reject(error.message || error);
    }
}