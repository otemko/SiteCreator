import {
  Component,
  ComponentFactoryResolver,
  Directive,
  ViewContainerRef,
  Input,
  Injector,
  ApplicationRef,
} from "@angular/core";

/**

  This component render an HTML code with inner directives on it.
  The @Input innerContent receives an array argument, the first array element
  is the code to be parsed. The second index is an array of Components that
  contains the directives present in the code.

  Example:

  <div [innerContent]="[
    'Go to <a [routerLink]="[Home]">Home page</a>',
    [RouterLink]
  ]">

**/
@Directive({
  selector: '[innerContent]'
})
@Component({
  selector: 'gen-node',
    template: '',
})
export class InnerContent {

  @Input()
  set innerContent(content){
    this.renderTemplate(
      content[0]
    )
  }

  constructor(
    private elementRef: ViewContainerRef,
    private injector: Injector,
    private app: ApplicationRef,
    private resolver:ComponentFactoryResolver){
  }

  public renderTemplate(template) {
    let dynComponent = this.toComponent(template)

    let component = this.resolver.resolveComponentFactory(
      dynComponent
    ).create(
        this.injector, null, this.elementRef.element.nativeElement
      );

      (<any>this.app)._loadComponent(component);
      component.onDestroy(() => {
        (<any>this.app)._unloadComponent(component);
      });
      return component;
    };

private toComponent(template) {
  @Component({
    selector: 'gen-node',
    template: template,
  })
  class DynComponent {}
    return DynComponent;
  }
}