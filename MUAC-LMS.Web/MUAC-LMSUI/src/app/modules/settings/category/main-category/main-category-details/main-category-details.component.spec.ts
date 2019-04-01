import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainCategoryDetailsComponent } from './main-category-details.component';

describe('MainCategoryDetailsComponent', () => {
  let component: MainCategoryDetailsComponent;
  let fixture: ComponentFixture<MainCategoryDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainCategoryDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainCategoryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
