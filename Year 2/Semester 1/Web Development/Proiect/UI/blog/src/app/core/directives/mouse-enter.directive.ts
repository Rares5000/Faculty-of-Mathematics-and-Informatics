import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appMouseEnter]',
  standalone: true
})
export class MouseEnterDirective {

  constructor(private htmlElement: ElementRef) {
  }

  @HostListener('mouseleave') OnMouseLeave(){
    this.htmlElement.nativeElement.style.border = 'none';
  }

  @HostListener('mouseenter') OnMouseEnter(){
    this.htmlElement.nativeElement.style.border = 'dotted';
  }

}
