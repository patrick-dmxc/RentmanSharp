﻿using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// With this endpoint you can retrieve information about subrental equipment.
    /// </summary>
    public class SubrentalEquipment : AbstractEndpoint<SubrentalEquipmentItem>
    {
        public override string Path { get => "subrentalequipment"; }
    }
}