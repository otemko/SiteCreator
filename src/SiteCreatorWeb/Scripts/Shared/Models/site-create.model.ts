import { Tag } from './tag.model';

export class SiteCreate {
    dateCreated: string;
    name: string;
    userId: string;
    styleMenuId: number;
    oldTags: Tag[];
    newTags: string[];
}