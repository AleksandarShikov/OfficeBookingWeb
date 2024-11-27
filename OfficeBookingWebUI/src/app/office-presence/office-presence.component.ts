import { Component,OnInit } from '@angular/core';
import { OfficePresenceService } from '../shared/office-presence.service';

@Component({
  selector: 'app-office-presence',
  standalone: false,
  
  templateUrl: './office-presence.component.html',
  styleUrl: './office-presence.component.css'
})
export class OfficePresenceComponent implements OnInit {
  constructor(public service: OfficePresenceService) {

  }
  ngOnInit(): void {
    this.service.refreshList();
    }
}
