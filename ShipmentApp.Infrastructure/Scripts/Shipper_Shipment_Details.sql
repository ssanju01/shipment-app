
CREATE OR ALTER PROCEDURE [dbo].[Shipper_Shipment_Details]
	@shipper_id int
AS
BEGIN
	SELECT 
		s.shipment_id,
		sh.shipper_name,
		c.carrier_name,
		s.shipment_description,
		s.shipment_weight,
		sr.shipment_rate_description

	FROM
		SHIPMENT s
	LEFT JOIN
		SHIPPER sh ON sh.shipper_id = s.shipper_id
	LEFT JOIN
		CARRIER c ON c.carrier_id = s.carrier_id
	LEFT JOIN
		SHIPMENT_RATE sr ON sr.shipment_rate_id = s.shipment_rate_id
	WHERE 
		s.shipper_id = @shipper_id
END
GO


