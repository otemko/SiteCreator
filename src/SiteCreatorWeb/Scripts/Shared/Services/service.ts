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

    post<T>(url: string, item: T): Promise<any> {
        let body = JSON.stringify(item);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers });
        return this.getPromise<any>((this.http.post(url, body, options)));
    }

    delete(url: string): Promise<any> {        
        return this.getPromise<any>(
            this.http.delete(url));
    }

    put<T>(url: string, item: T): Promise<T> {
        let body = JSON.stringify(item);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers });
        return this.getPromise<any>((this.http.put(url, body, options)));
    }

    private getPromise<T>(response: Observable<Response>) : Promise<T> {
        return response.toPromise()
            .then(res => {
                 if (res.status == 204)  return null;
                 else return res.json()
                })
            .catch(this.handleError);
    }



    private handleError(error: any): Promise<void> {
        console.log('Error12456', error);
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