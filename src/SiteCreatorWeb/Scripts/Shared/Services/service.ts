import { Injectable, ApplicationModule } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Router } from '@angular/router'
import { Observable } from 'rxjs/Observable'

import 'rxjs/add/operator/toPromise';


@Injectable()
export class Service {

    constructor(private http: Http, private route: Router) { }

    get(url: string): Promise<any> {
        return this.getPromise<any>(
            this.http.get(url));
    }

    post(url: string, item): Promise<any> {
        let body = JSON.stringify(item);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers });
        return this.getPromise<any>((this.http.post(url, body, options)));
    }

    delete(url: string): Promise<any> {
        return this.getPromise<any>(
            this.http.delete(url));
    }

    put(url: string, item): Promise<any> {
        let body = JSON.stringify(item);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers });
        return this.getPromise<any>((this.http.put(url, body, options)));
    }

    private getPromise<T>(response: Observable<Response>): Promise<T> {
        return response.toPromise()
            .then(res => {
                if (!res.text()) return null;
                else return res.json()
            }).catch(res => this.handleError(res));
    }



    private handleError(error: any): Promise<void> {
        if (error.status === 403) {
            this.route.navigate(['/lockout']);
        }
        console.log('Error', error);
        return Promise.reject(error.message || error);
    }

    postForm(path, params, method) {
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