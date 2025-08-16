import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-sample-card',
  templateUrl: './sample-card.component.html',
  styleUrls: ['./sample-card.component.scss'],
})
export class SampleCardComponent {
  @Input() title = 'Card Title';
  @Input() subtitle = 'Card Subtitle';
  @Input() content = 'This is some sample content inside the card.';
}
