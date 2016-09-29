import { Tag } from './tag.model';

export class Site{
    id: number;
    dateCreated: string;    
    name: string;
    userName: string;
    userId: string;
    tags: Tag[];
}