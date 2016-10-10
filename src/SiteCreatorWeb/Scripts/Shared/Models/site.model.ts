import { Tag } from './tag.model';
import { Page } from './page.model'

export class Site{
    id: number;
    dateCreated: string;    
    name: string;
    userName: string;
    userId: string;
    styleMenuId: number;
    preview: string;
    tags: Tag[];
    pages: Page[];
    pagesCount: number;
}