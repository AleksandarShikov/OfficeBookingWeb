import { Component,OnInit } from '@angular/core';
import { OfficePresenceService } from '../shared/office-presence.service';
import { OfficePresenceView } from '../shared/office-presence-view.model';
import { OfficePresence } from '../shared/office-presence.model';

@Component({
  selector: 'app-office-presence',
  standalone: false,

  templateUrl: './office-presence.component.html',
  styleUrl: './office-presence.component.css'
})
export class OfficePresenceComponent implements OnInit {
  list: OfficePresenceView[] = []
  
  constructor(private officePresenceService: OfficePresenceService) {

  }

  ngOnInit(): void {
    this.refreshList();
  }

  refreshList(): void {
    this.officePresenceService.getOfficePresences().subscribe({
      next: (data) => {
        this.list = data;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
  deletePresence(presenceId: number): void {
    if (confirm('Are you sure you want to delete this record?')) {
      this.officePresenceService.deleteOfficePresence(presenceId).subscribe({
        next: () => {
          console.log('Presence deleted successfully');
          this.list = this.list.filter(p => p.presenceId !== presenceId);
          window.location.reload();
        },
        error: (err) => {
          console.error('Error deleting presence:', err);
          alert('Failed to delete the record. Please try again.');
        },
      });
    }
  }
}
