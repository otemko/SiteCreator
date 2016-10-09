import { Component, Input} from '@angular/core';
import { TagCloudComponent } from '../../tag-cloud/tag-cloud.component';
import { TagSiteService } from '../../Shared/Services/tag-site.service';
import { TagSite } from '../../Shared/Models/tag-site.model'

@Component({
    selector: 'my-tagcloud',
    templateUrl: './appScripts/Components/Tags/my-tagcloud.component.html',
    styleUrls: ['./appScripts/Components/Tags/my-tagcloud.component.css'],
    providers: [TagSiteService]
})

export class MyTagCloudComponent{
    public size = 10;
    public latestSelected: string = "";
    public showSize: boolean = true;


    private tagSite: TagSite[] = new Array();
    tagSiteView: string = "asd";

    constructor(private tagSiteService: TagSiteService) {
        this.tagSiteView;
        this.tagSiteService.getTagSites().then(res => {
            this.tagSite = res;
            this.tagSiteView = this.createString(this.tagSite);
            console.log(this.tagSiteView);
        });
    }

    ss() { console.log('ss'); console.log('ss') };

    onSelectedTag(name: string) {
        console.log(name);
        this.latestSelected = name;
    }

    createString(tagSite: TagSite[]): string {
        let result = "";
        tagSite.forEach(ts => result += ts.tagName + ' ');
        return result;
    }

    //public highlight: string[] = [];
    //public ignore: string[] = ['alla'];
    //public minWordLength: number = 1;

    //public highlightFunction = (word: string): boolean => {
    //    return this.arrayContainsWord(this.highlight, word);
    //}
    //public ignoreFunction = (word: string): boolean => {
    //    return (word.length <= this.minWordLength);
    //}    

    //private arrayContainsWord = (array: string[], word: string): boolean => {
    //    console.log(array);
    //    let lowerCaseWord = word.toLowerCase();
    //    return array.some(function (element, i) {
    //        if (lowerCaseWord === element.toLowerCase()) {
    //            return true;
    //        }
    //    });
    //}
}