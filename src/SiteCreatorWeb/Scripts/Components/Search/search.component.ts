import { Component, Input } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { SearchResult } from '../../Shared/Models/search.model'
import { Language } from '../../Shared/Models/language.model'

import { AppComponent } from '../../app.component'

@Component({
    selector: 'search',
    templateUrl: './appScripts/Components/Search/search.component.html'    
})

export class SearchComponent {

    sr = new SearchResult(); 

    constructor(private l: Language,
        private searchResult: SearchResult,
        private route: ActivatedRoute) {
        this.sr = searchResult;
    }

}