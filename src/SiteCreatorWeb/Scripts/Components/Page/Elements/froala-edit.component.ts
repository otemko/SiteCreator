import { Component, OnInit, Input } from '@angular/core'

@Component({
    selector: 'froala-edit',
    templateUrl: './appScripts/Components/Page/Elements/froala-edit.component.html',
})
export class FroalaEditComponent {

    @Input() edidatable: boolean = true;

    options = {
        placeholderText: 'Edit Your Content Here!',
        charCounterCount: false,
        toolbarInline: true,
    };
    content = '';
}
