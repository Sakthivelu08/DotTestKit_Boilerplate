import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SampleCardComponent } from './sample-card.component';

describe('SampleCardComponent', () => {
  let component: SampleCardComponent;
  let fixture: ComponentFixture<SampleCardComponent>;
  let compiled: HTMLElement;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SampleCardComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(SampleCardComponent);
    component = fixture.componentInstance;
    compiled = fixture.nativeElement;
  });

  it('should create the card component', () => {
    expect(component).toBeTruthy();
  });

  it('should render default title, subtitle and content', () => {
    fixture.detectChanges();
    expect(compiled.querySelector('h2')?.textContent).toContain('Card Title');
    expect(compiled.querySelector('h4')?.textContent).toContain(
      'Card Subtitle'
    );
    expect(compiled.querySelector('p')?.textContent).toContain(
      'This is some sample content inside the card.'
    );
  });

  it('should render custom inputs', () => {
    component.title = 'Custom Title';
    component.subtitle = 'Custom Subtitle';
    component.content = 'Custom Content';
    fixture.detectChanges();

    expect(compiled.querySelector('h2')?.textContent).toContain('Custom Title');
    expect(compiled.querySelector('h4')?.textContent).toContain(
      'Custom Subtitle'
    );
    expect(compiled.querySelector('p')?.textContent).toContain(
      'Custom Content'
    );
  });
});
