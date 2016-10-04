import { NgModule } from '@angular/core'
import { FroalaEditorDirective, FroalaViewDirective } from './froala.directives'
import { DynamicComponentModule, DynamicComponent, DynamicComponentMetadata } from "angular2-dynamic-component";

@NgModule({
    declarations: [FroalaEditorDirective, FroalaViewDirective],
    exports: [FroalaEditorDirective, FroalaViewDirective]
})
export class FroalaModule { }