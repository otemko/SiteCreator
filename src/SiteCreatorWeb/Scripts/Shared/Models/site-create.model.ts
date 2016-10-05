import { Tag } from './tag.model';

export class SiteCreate {
    id: number;
    dateCreated: string;
    name: string;
    userId: string;
    styleMenuId: number;
    oldTags: Tag[];
    newTags: string[];
}