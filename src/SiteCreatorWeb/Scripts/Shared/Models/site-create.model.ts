import { Tag } from './tag.model';

export class SiteCreate {
    id: number;
    dateCreated: string;
    name: string;
    userId: string;
    styleMenuId: number;
    tags: Tag[] = [];
    newTags: string[];
}