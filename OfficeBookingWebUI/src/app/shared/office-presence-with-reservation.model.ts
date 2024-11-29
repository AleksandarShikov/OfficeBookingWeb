export class OfficePresenceWithReservation {
  presenceDate: Date = new Date
  employeeId: number = 0
  roomId: number = 0
  notes: string = ""

  parkingSpotId: number = 0
  arrivalTime: Date = new Date
  departureTime: Date = new Date

  isReservationRequired: boolean = false;
}
