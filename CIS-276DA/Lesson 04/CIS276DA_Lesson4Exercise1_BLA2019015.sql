SELECT
	*
FROM
	ap.vendors AS v
INNER JOIN
	ap.invoices AS i
ON
	v.vendor_id = i.vendor_id;