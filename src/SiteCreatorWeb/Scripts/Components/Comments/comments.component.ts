import { Component, Input, OnInit } from '@angular/core'

import { Comment } from '../../Shared/Models/comment.model'
import { CommentService } from '../../Shared/Services/comments.service'
import { Account } from '../../Shared/Models/account.model'

@Component({
    selector: 'comments',
    templateUrl: './appScripts/Components/Comments/comments.component.html'
})

export class CommentComponent implements OnInit {
    @Input() pageId: number;
    comments: Comment[] = [];
    newComment: Comment = new Comment();

    constructor(private commentsService: CommentService, private account: Account) {
    }

    ngOnInit() {
        this.newComment.id = 0;
        this.newComment.userId = this.account.id;
        this.newComment.userName = this.account.userName;
        this.newComment.pageId = this.pageId;
        
        this.updateModel();
    }

    checkPermission() {        
        if (this.account.id)
            return true;
        return false;
    }

    canEdit(comment: Comment) {
        if (this.account.id == comment.userId || this.account.role == 'admin') return true;
        return false;
    }

    updateModel() {
        this.commentsService.getComments(this.pageId).then(res => {
            if (res) {
                this.comments = [];
                Object.assign(this.comments, res.reverse());
            }
        });
    }

    makeResponse(promise: Promise<any>) : Promise<any> {
        return promise.then(res => this.updateModel())
    }

    createComment(comment: Comment) : Promise<any> {
        return this.makeResponse(
            this.commentsService.createComment(comment));
    }

    editComment(comment: Comment) : Promise<any> {
        return this.makeResponse(
            this.commentsService.editComment(comment));
    }

    delete(id: number): Promise<any> {
        return this.makeResponse(
            this.commentsService.deleteComment(id));
    }
}