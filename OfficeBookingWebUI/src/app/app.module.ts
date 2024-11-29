import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OfficePresenceComponent } from './office-presence/office-presence.component';
import { OfficePresenceFormComponent } from './office-presence/office-presence-form/OfficePresenceFormComponent';
import { HttpClientModule } from '@angular/common/http';
import { ParkingReservationFormComponent } from './office-presence/parking-reservation-form/parking-reservation-form.component';

@NgModule({
  declarations: [
    AppComponent,
    OfficePresenceComponent,
    OfficePresenceFormComponent,
    ParkingReservationFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
