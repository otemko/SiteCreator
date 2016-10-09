import {Component, OnInit} from '@angular/core';
import {TagCloudComponent} from './tag-cloud.component';
import {TagCloudService} from './tag-cloud.service';


@Component({
	selector: 'simple-tag-cloud',
	template: `
    	<tag-cloud (selectedTag)="true" [text]="text" [showSize]="showSize" [maxWords]="maxWords" ></tag-cloud>
	`,
	inputs: ['text', 'maxWords', 'minLength', 'highlight', 'ignore', 'masSizeRatio','showSize'],
    outputs: ['selectedTag'],
	providers: [TagCloudService]
})
export class SimpleTagCloudComponent extends TagCloudComponent {

	constructor(_tagCloudService: TagCloudService) {
		super(_tagCloudService);
	}

}
