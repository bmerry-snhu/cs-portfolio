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
JOIN (
	SELECT
		vendor_id,
        MIN(invoice_date) AS earliest_invoice_date
	FROM
		ap.invoices
	GROUP BY
		vendor_id
	) AS earliest_invoices
ON
	i.vendor_id = earliest_invoices.vendor_id
AND
	i.invoice_date = earliest_invoices.earliest_invoice_date
ORDER BY
	v.vendor_name;