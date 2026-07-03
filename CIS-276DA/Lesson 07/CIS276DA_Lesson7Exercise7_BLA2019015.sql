SELECT
	v.vendor_name,
    i.invoice_number,
    i.invoice_date,
    i.invoice_total
FROM
	ap.invoices AS i
JOIN
	ap.vendors AS v
ON
	i.vendor_id = v.vendor_id
WHERE
	i.invoice_date = (
		SELECT
			MIN(invoice_date)
		FROM
			ap.invoices AS i2
		WHERE
			i2.vendor_id = i.vendor_id
		)
ORDER BY
	v.vendor_name;