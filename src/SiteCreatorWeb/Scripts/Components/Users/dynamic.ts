import {
    Component,
    Directive,
    ComponentFactory,
    ComponentFactoryResolver,
    Input,
    ReflectiveInjector,
    ViewContainerRef,
    NgModule,
    ViewChild,
    ComponentRef,
    Injectable,
    OnChanges,
    OnInit,
    OnDestroy

} from '@angular/core'

@Injectable()
@Component({
    selector: "dyndyn",
    template: "<p>Hello</p>"
})
export class DynamicComponent {
}


export function createComponentFactory(src: string) {
    
    @Component({
        template: '<p>Bye</p>'
    })
    class Dynamic extends DynamicComponent {}


    return Dynamic;
}

@Injectable()
@Component({
    selector: 'dynamic-html-outlet',
    template: '<div #dynamicTarget></div>'
})
export class DynamicHTMLOutlet implements OnChanges, OnInit, OnDestroy {

    private componentReference: ComponentRef<any>;
    private isViewInitialized = false;
    @Input() src: string;

    @ViewChild('dynamicTarget', { read: ViewContainerRef })
    private dynamicTarget: any;

    constructor(private vcRef: ViewContainerRef, private resolver: ComponentFactoryResolver) {
    }

    ngOnInit() {
        this.isViewInitialized = true;
        this.updateComponent();
    }
    ngOnChanges() {
        this.updateComponent();
    }
    ngOnDestroy() {
        if (this.componentReference) {
            this.componentReference.destroy();
        }
    }

    updateComponent() {
        if (!this.src) return;

        let componentFactory = this.resolver.resolveComponentFactory(createComponentFactory(this.src));
        this.componentReference = this.dynamicTarget.createComponent(componentFactory);
    }
}
