namespace ShipmentApp.Domain.Dtos.Shipment
{
    public class ShipperShipmentDetailDto
    {
        public int shipment_id { get; set; }
        public string shipper_name { get; set; }
        public string carrier_name { get; set; }
        public string shipment_description { get; set; }
        public double shipment_weight { get; set; }
        public string shipment_rate_description { get; set; }
    }
}
