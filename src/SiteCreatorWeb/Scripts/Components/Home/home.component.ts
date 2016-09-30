import { Component } from '@angular/core'
import { FroalaEditorDirective, FroalaViewDirective } from '../../Froala-editor/froala.directives';

@Component({
    selector: 'home',
    templateUrl: './appScripts/Components/Home/home.component.html',
})

export class HomeComponent {
    public titleOptions: Object = {
        placeholderText: 'Edit Your Content Here!',
        charCounterCount: false,
        toolbarInline: true,
        events: {
            'froalaEditor.initialized': function () {
                console.log('initialized');
            }
        }
    }
    public myTitle: string;


    // Sample 2 model
    public content: string = '<span>My Document\'s Title</span>';


    // Sample 3 model
    public twoWayContent;

    // Sample 4 models
    public sample3Text;
    public initControls;
    public deleteAll;
    public initialize(initControls) {
        console.log(initControls);
        this.initControls = initControls;
        this.deleteAll = function () {
            this.initControls.getEditor()('html.set', '');
            this.initControls.getEditor()('undo.reset');
            this.initControls.getEditor()('undo.saveStep');
        };
    }

    // Sample 5 model
    public imgModel: Object = {
        src: 'http://weknowyourdreams.com/images/stars/stars-05.jpg'
    };

    // Sample 6 model
    public buttonModel: Object = {
        innerHTML: 'Click Me'
    };

    // Sample 7 models
    public inputModel: Object = {
        placeholder: 'I am an input!'
    };
    public inputOptions: Object = {
        angularIgnoreAttrs: ['class', 'ng-model', 'id', 'froala', 'ng-reflect-froala-editor', 'ng-reflect-froala-model']
    }

    // Sample 8 model
    public initializeLink = function (linkInitControls) {
        this.linkInitControls = linkInitControls;
    };
    public linkModel: Object = {
        href: 'https://www.froala.com/wysiwyg-editor'
    };
}

