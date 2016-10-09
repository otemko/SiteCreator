import {Injectable} from '@angular/core';

import {TagsMap} from './tags-map';
import {Tag} from './tag';
import {TagCloud} from './tag-cloud';

@Injectable()
export class TagCloudService{


	getTagCloud(text: string, maxWords: number, highlight: string[], minLength: number, ignore: string[]): Promise<TagCloud> {
		for (var i: number = 0; i < ignore.length; i++) {
			ignore[i] = ignore[i].toLowerCase();
		}
		for (var i:number= 0; i < highlight.length;i++){
			highlight[i] = highlight[i].toLowerCase();
		}
		var highlightFunction = (word: string): boolean => {
			return highlight.indexOf(word.toLowerCase()) >= 0;
		}
		var ignoreFunction = (word: string): boolean => {
			if(highlightFunction(word)){
				return false;
			} else {
				return (ignore.indexOf(word.toLowerCase()) >= 0) || (word.length <= minLength);
			}
		}
		return this.getTagCloudF(text, maxWords, highlightFunction, ignoreFunction);
	//	return Promise.resolve(this.getTagCloudAsync(text, maxWords, minLength, ignore, highlight));
	}


	getTagCloudF(text: string, maxWords: number, highlightFunction: (word: string) => boolean, ignoreFunction: (word: string) => boolean): Promise<TagCloud> {
		if (!ignoreFunction){
			ignoreFunction = (word: string) : boolean => {
    			return false;
	   		}
		}
		if (!highlightFunction){
			highlightFunction = (word: string) : boolean => {
		  		return false;
	   		}
		}
		return Promise.resolve(this.getTagCloudAsync(text, maxWords, highlightFunction, ignoreFunction));
	}

	private getTagCloudAsync(text: string, maxWords: number, highlightFunction: (word: string) => boolean, ignoreFunction: (word: string) => boolean): TagCloud {
//		var highlightMap = this.buildMap(highlight, (word: string) :  boolean => { return false;});
//		var ignoreMap = this.buildMap(ignore, highlightMap, minLength);
//		return this.buildTagCloud(text, maxWords, highlightMap, minLength, ignoreMap);
		return this.buildTagCloudF(text, maxWords, highlightFunction, ignoreFunction);
	}

	private buildTagCloudF(text: string, maxWords: number, highlightFunction: (word: string) => boolean, ignoreFunction: (word: string) => boolean): TagCloud {
        ///\W+/g
        text = text.replace('.*', " ");
		var words: string[] = text.split(" ");

		var buildMapFunction = (word: string): boolean => {
			if (highlightFunction(word)) {
				return false;
			} else {
				return (ignoreFunction(word));
			}
		}
		var map: TagsMap = this.buildMapF(words, buildMapFunction);
		var tags: Tag[] = [];
		var highlightVal: number = 0;
		for (var key in map) {
			tags.push({ "name": key, "size": map[key], "highlight": highlightFunction(key) });
		}
		tags.sort((a, b) => {
			if (a.highlight) return -1;
			if (b.highlight) return 1;
			if (a.size == b.size) return 0;
			if (a.size > b.size) return -1;
			return 1;
		});
		tags = tags.slice(0, maxWords);
		var max: number = 0;
		if (tags.length > 0) {
			var index: number = 0;
			while ( (tags[index]) && (tags[index].highlight) ) {
				if (tags[index].size > max){
					max = tags[index].size;
				}
				index++;
			}
			if (tags[index]) {
				if (tags[index].size > max) {
					max = tags[index].size;
				}
			}
		}
		tags.sort((a, b) => {
			if (a.name == b.name) return 0;
			if (a.name > b.name) return 1;
			return -1;
        });
        console.log({ "tags": tags, "max": max });
		return { "tags": tags, "max": max };
	}


	private buildMapF(words: string[], ignoreFunction: (word: string) => boolean): TagsMap {
		var map: TagsMap = {};
		for (var i = words.length - 1; i >= 0; i--) {
			if (!ignoreFunction(words[i])) {
				words[i] = words[i].toLowerCase();
				if (map[words[i]]) {
					map[words[i]]++;
				} else {
					map[words[i]] = 1;
				}
			}
		}
		return map;
	}

	// private buildMap(words: string[], ignore: TagsMap, minLength: number): TagsMap {
	// 	var map: TagsMap = {};
	// 	for (var i = words.length - 1; i >= 0; i--) {
	// 		words[i] = words[i].toLowerCase();
	// 		if (!ignore[words[i]]) {
	// 			if (words[i].length > minLength) {
	// 				if (map[words[i]]) {
	// 					map[words[i]]++;
	// 				} else {
	// 					map[words[i]] = 1;
	// 				}
	// 			}
	// 		}
	// 	}
	// 	return map;
	// }

	// private buildTagCloud(text: string, maxWords: number, highlight: TagsMap, minLength: number, ignore: TagsMap): TagCloud {
	// 	text = text.replace(/\W+/g, " ");
	// 	var words: string[] = text.split(" ");
	// 	var map: TagsMap = this.buildMap(words, ignore, minLength);
	// 	var tags: Tag[] = [];
	// 	for (var key in map) {
	// 		tags.push({ "name": key, "size": map[key], "highlight": highlight[key] });
	// 	}
	// 	tags.sort((a, b) => {
	// 		if (a.highlight) return -1;
	// 		if (b.highlight) return 1;
	// 		if (a.size == b.size) return 0;
	// 		if (a.size > b.size) return -1;
	// 		return 1;
	// 	});
	// 	tags = tags.slice(0, maxWords);
	// 	var max: number = 0;
	// 	if(tags.length>0){
	// 		var index: number = 0;
	// 		while(tags[index].highlight){
	// 			index++;
	// 		}
	// 		max = tags[index].size;
	// 	}

	// 	tags.sort((a, b) => {
	// 		if (a.name == b.name) return 0;
	// 		if (a.name > b.name) return 1;
	// 		return -1;
	// 	});
	// 	return {"tags": tags, "max": max};
	// }	

}