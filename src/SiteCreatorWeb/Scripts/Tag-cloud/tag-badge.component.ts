import {Component, OnInit, EventEmitter} from '@angular/core';
import {Tag} from './tag';

@Component({
	selector: 'tag-badge',
	template: `
			<span [ngStyle]="setStyles()" [ngClass]="setClasses()" (click)="tagSelected()">{{tag.name}} </span><span *ngIf="showSize">({{tag.size}})</span>
	`,
	inputs: ['tag', 'showSize', 'sizeRatio'],
	outputs: ['selected']
})
export class TagBadgeComponent implements OnInit {
	public tag: Tag;
	public showSize: boolean = false;
	public sizeRatio: number = 10;
	public selected:EventEmitter<Tag> = new EventEmitter<Tag>();
	private classes: Object;
	private styles: Object;

	ngOnInit() {
		this.classes = {
			badge: true,
			highlight: this.tag.highlight
		}
		this.styles = {
			fontSize: 100 - this.sizeRatio + (this.tag.size * this.sizeRatio) +'%',
			opacity: this.tag.highlight ? 1   : (1 - (1 / this.tag.size)) > 0.5 ? 1 - (1 / this.tag.size) : 0.5
		}
	}
			
	setStyles(){
		return this.styles;
	}
	setClasses(){
		return this.classes;
	}

	tagSelected(){
		this.selected.emit(this.tag);
	}

}
