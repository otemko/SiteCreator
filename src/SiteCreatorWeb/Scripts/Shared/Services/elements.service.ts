import { Component, Injectable } from '@angular/core'

import 'rxjs/add/operator/toPromise';

import { Element, Elements } from '../Models/elements.model'
import { Service } from './service'

@Injectable()
export class ElementService {

    private elementsUrl = 'elements/elements.json';
    private optionsUrl = 'elements/options.json';

    constructor(private elements: Elements, private service: Service) {
    }

    getElements() : Promise<any> {
        this.elements.loading = true;
        let options = {};
        let elements = [];

        return this.service.get(this.elementsUrl)
            .then(res => {
                Object.assign(elements, res);
                this.service.get(this.optionsUrl)
                    .then(res => {
                        Object.assign(options, res);
                        Object.assign(this.elements.options, res);
                    });
            })
            .then(res => {
                this.pushElements(elements, options);
                this.elements.loading = false;
            });
    }

    private pushElements(elements, options) {
        elements.forEach(p => {
            p.inputData = {
                options: options,
                content: p.content
            };
            delete p.content;
        });
        Object.assign(this.elements.all, elements);
    }
}