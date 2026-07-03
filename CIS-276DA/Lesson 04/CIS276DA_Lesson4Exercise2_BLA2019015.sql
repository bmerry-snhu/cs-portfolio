SELECT
	v.vendor_name AS vendor_name,
    i.invoice_number AS invoice_number,
    i.invoice_date AS invoice_date,
    (i.invoice_total - i.payment_total - i.credit_total) AS balance_due
FROM
	ap.vendors AS v
INNER JOIN
	ap.invoices AS i
ON
	v.vendor_id = i.vendor_id
WHERE
	(i.invoice_total - i.payment_total - i.credit_total) > 0
ORDER BY
	v.vendor_name ASC;