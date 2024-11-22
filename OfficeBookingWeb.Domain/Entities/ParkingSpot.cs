﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OfficeBookingWeb.Domain.Common;

namespace OfficeBookingWeb.Domain.Entities;

public partial class ParkingSpot : AuditableEntity
{
    public int ParkingSpotId { get; set; }

    public int SpotNumber { get; set; }

    public bool IsReserved { get; set; }

    public virtual ICollection<ParkingReservation> ParkingReservations { get; set; } = new List<ParkingReservation>();
}