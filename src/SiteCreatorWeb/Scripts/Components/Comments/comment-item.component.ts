import { Component, Input, Output, EventEmitter } from '@angular/core'
import { Router, ActivatedRoute } from '@angular/router'
import { Comment } from '../../Shared/Models/comment.model'

declare var $: any;

@Component({
    selector: 'comment-item',
    templateUrl: './appScripts/Components/Comments/comment-item.component.html'
})

export class CommentItemComponent {
    @Input() comment: Comment;
    @Input() canEdit: boolean;
    @Input() editing: boolean;
    @Output() save = new EventEmitter();
    @Output() delete = new EventEmitter();
    @Output() create = new EventEmitter();

    costructor() {
        console.log(this.comment);
    }

    options = {
        placeholderText: 'Type here...',
        charCounterCount: false,
        toolbarInline: true,
        disableRightClick: true,
        toolbarVisibleWithoutSelection: true,
        enter: $.FroalaEditor.ENTER_BR,
        imageDefaultDisplay: 'inline',
        heightMax: 500,
        pluginsEnabled: ['align', 'link', 'file', 'lists', 'emoticons', 'draggable'],
    };
    oldContent = "";
    

    startEditing() {
        this.editing = true;
        this.oldContent = this.comment.content;
    }

    refuseEditing() {
        this.editing = false;
        this.comment.content = this.oldContent;
    }

    onCreateComment() {
        if (!this.comment.content) return;
        this.create.emit(this.comment);
        this.comment.content = "";
    }

    onSaveChanges() {
        if (!this.comment.content) return;
        this.editing = false;
        this.save.emit(this.comment);
    }

    onDelete() {
        this.delete.emit(this.comment.id);
    }
}