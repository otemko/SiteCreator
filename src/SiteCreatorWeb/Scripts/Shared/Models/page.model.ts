export class Page {
    id: number;
    name: string;
    preview: string;
    elements: string;
    content: string;
    userId: string;
    userName: string;
    siteId: number;
    siteName: string;
    commentsEnabled: boolean;

    setNull() : Page {
        this.id = 0;
        this.siteId = 0;
        this.userId = "";
        this.userName = "";
        this.siteName = "";
        this.commentsEnabled = true;
        this.content = "";
        this.elements = "";
        this.preview = "";
        this.name = "";

        return this;
    }
}