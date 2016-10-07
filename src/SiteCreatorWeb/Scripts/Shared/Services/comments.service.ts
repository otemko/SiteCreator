import { Component, Injectable } from '@angular/core'

import 'rxjs/add/operator/toPromise';

import { Comment } from '../Models/comment.model'
import { Service } from './service'

@Injectable()
export class CommentService {

    private url = 'api/Comments/';

    constructor(private service: Service) {
    }

    getComments(pageId: number): Promise<Comment[]> {
        return this.service.get(this.url + pageId);
    }

    createComment(comment: Comment): Promise<number>{
        return this.service.post(this.url, comment);
    }

    editComment(comment: Comment): Promise<any>{
        return this.service.put(this.url + comment.id, comment);
    }

    deleteComment(id: number): Promise<any>{
        return this.service.delete(this.url + id);
    }
}