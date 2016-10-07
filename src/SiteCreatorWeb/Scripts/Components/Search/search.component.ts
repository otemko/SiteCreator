import { Component, Input } from '@angular/core'
import { ActivatedRoute } from '@angular/router'

import { SearchResult } from '../../Shared/Models/search.model'
import { SearchService } from '../../Shared/Services/search.service'
import { AppComponent } from '../../app.component'

@Component({
    selector: 'search',
    templateUrl: './appScripts/Components/Search/search.component.html',
    providers: [SearchService]
})

export class SearchComponent {

    sr = new SearchResult();    

    constructor(private searchService: SearchService, private route: ActivatedRoute) {
        this.update();        
    }

    update() {
        let id = "" + this.route.snapshot.params['id'];
        this.searchService.getSearchResultByTerm(id).then(res => {
            this.sr = res;
        });        
    }
}