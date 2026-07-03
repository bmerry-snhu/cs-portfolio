SELECT DISTINCT
	vendor_name
FROM
	ap.vendors
WHERE
	vendor_id IN (
		SELECT
			vendor_id
		FROM
			ap.invoices
		)
ORDER BY
	vendor_name;