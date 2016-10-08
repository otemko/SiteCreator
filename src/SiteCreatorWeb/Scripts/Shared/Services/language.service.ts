import { Component, Injectable } from '@angular/core'

import 'rxjs/add/operator/toPromise';

import { Language } from '../Models/language.model'
import { Service } from './service'

@Injectable()
export class LanguageService {

    private url = 'api/Resource/language';

    constructor(private language: Language, private service: Service) {
    }

    getLanguage(language: string = null): void {
        this.language.loading = true;
        let url = this.url;
        if (language != null) url = this.setUrlAndCookie(language);
        this.service.get(url)
            .then(res => {
                Object.assign(this.language, res);
                this.language.loading = false;
            });
    }

    private setUrlAndCookie(language: string) {
            let date = new Date(new Date().getFullYear() + 1, 0);
            document.cookie = `Language=${language}; path=/; expires=` + date.toUTCString();
            return `languages/${language}.json`;
    }

    getAvailableLanguages(): Promise<any> {
        return this.service.get('languages/availableLanguages.json');
    }
}