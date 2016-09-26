export interface ISite {
    id: number,
    tittle: string;
    description: string;
    tags: string[];
}

export class Site implements ISite {
    id: number;
    tittle: string;
    description: string;
    tags: string[];

    constructor(id: number, tittle: string, description: string, tags: string[]) {
        this.id = id;
        this.tittle = tittle;
        this.description = description;
        this.tags = tags;
    }
}