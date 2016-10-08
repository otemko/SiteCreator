import { Component } from '@angular/core'
import { Language } from '../../Shared/Models/language.model'
import { LanguageService } from '../../Shared/Services/language.service'

@Component({
    selector: 'language-panel',
    templateUrl: './appScripts/Components/LanguagePanel/languagePanel.component.html',
})

export class LanguagePanelComponent {
    languages = [];

    constructor(private l: Language,
        private languageService: LanguageService) {
        this.languageService.getAvailableLanguages().then(res => {
            for (let l in res) {
                this.languages.push({ key: l, value: res[l] });
            }
        })
    }

    changeLanguage(language: string) {
        this.languageService.getLanguage(language);
    }

}