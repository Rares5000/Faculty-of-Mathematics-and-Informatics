import { ElementRef } from '@angular/core';
import { MouseEnterDirective } from './mouse-enter.directive';

describe('MouseEnterDirective', () => {
  it('should create an instance', () => {
    const elementRefMock: ElementRef = { nativeElement: document.createElement('div') };
    const directive = new MouseEnterDirective(elementRefMock);
    expect(directive).toBeTruthy();
  });
});
