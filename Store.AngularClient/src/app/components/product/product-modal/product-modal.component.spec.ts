import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductModalComponent } from './ProductModalComponent';

describe('ProductModalComponent', () => {
  let component: ProductModalComponent;
  let fixture: ComponentFixture<ProductModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductModalComponent]
    });
    fixture = TestBed.createComponent(ProductModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
