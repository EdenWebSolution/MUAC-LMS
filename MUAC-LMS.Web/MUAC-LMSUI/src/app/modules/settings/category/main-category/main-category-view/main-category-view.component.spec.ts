import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainCategoryViewComponent } from './main-category-view.component';

describe('MainCategoryViewComponent', () => {
  let component: MainCategoryViewComponent;
  let fixture: ComponentFixture<MainCategoryViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainCategoryViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainCategoryViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
