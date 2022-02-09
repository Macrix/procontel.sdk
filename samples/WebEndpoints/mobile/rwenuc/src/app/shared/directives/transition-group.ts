import {  ContentChildren, Directive, ElementRef, Input, QueryList } from '@angular/core';

@Directive({
  selector: '[app-transition-group-item]'
})
export class TransitionGroupItemDirective {
  prevPos: any;
  newPos: any;
  el: HTMLElement;
  moved: boolean = false;
  moveCallback: any;

  constructor(elRef: ElementRef) {
    this.el = elRef.nativeElement;
  }
}

@Directive({
  selector: '[app-transition-group]'
})
export class TransitionGroupComponent {
  @Input('app-transition-group') class: string = "";

  @ContentChildren(TransitionGroupItemDirective) items: QueryList<TransitionGroupItemDirective> = new QueryList<TransitionGroupItemDirective>();

  ngAfterContentInit() {
    this.refreshPositionPrevPos();
    this.items.changes.subscribe(items => {
      items.forEach((item: TransitionGroupItemDirective) => {
        item.prevPos = item.newPos || item.prevPos;
        item.prevPos = item.prevPos || item.el.getBoundingClientRect();
      });

      items.forEach(this.runCallback);
      this.refreshPositionNewPos();
      items.forEach(this.applyTranslation);

      // force reflow to put everything in position
      const offSet = document.body.offsetHeight;
      this.items.forEach(this.runTransition.bind(this));
    })
  }

  runCallback(item: TransitionGroupItemDirective) {
    if(item.moveCallback) {
      item.moveCallback();
    }
  }

  runTransition(item: TransitionGroupItemDirective) {
    if (!item.moved) {
      return;
    }
    const cssClass = this.class + '-move';
    let el = item.el;
    let style: any = el.style;
    el.classList.add(cssClass);
    style.transform = style.WebkitTransform = style.transitionDuration = '';
    el.addEventListener('transitionend', item.moveCallback = (e: any) => {
      if (!e || /transform$/.test(e.propertyName)) {
        el.removeEventListener('transitionend', item.moveCallback);
        item.moveCallback = null;
        el.classList.remove(cssClass);
      }
    });
  }

  refreshPositionPrevPos() {
    this.items.forEach((item: TransitionGroupItemDirective) => {
      item.prevPos = item.el.getBoundingClientRect();
    });
  }

  refreshPositionNewPos() {
    this.items.forEach((item: TransitionGroupItemDirective) => {
      item.newPos = item.el.getBoundingClientRect();
    });
  }

  applyTranslation(item: TransitionGroupItemDirective) {
    item.moved = false;
    const dx = item.prevPos.left - item.newPos.left;
    const dy = item.prevPos.top - item.newPos.top;
    if (dx || dy) {
      item.moved = true;
      let style: any = item.el.style;
      style.transform = style.WebkitTransform = 'translate(' + dx + 'px,' + dy + 'px)';
      style.transitionDuration = '0s';
    }
  }
}
