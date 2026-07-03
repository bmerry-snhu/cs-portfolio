SELECT
	v.vendor_name AS vendor_name,
    i.invoice_date AS invoice_date,
    i.invoice_number AS invoice_number,
    ili.invoice_sequence AS li_sequence,
    ili.line_item_amount AS li_amount
FROM
	ap.vendors AS v
INNER JOIN
	ap.invoices AS i
ON
	v.vendor_id = i.vendor_id
INNER JOIN
	ap.invoice_line_items AS ili
ON
	i.invoice_id = ili.invoice_id
ORDER BY
	v.vendor_name, i.invoice_date, i.invoice_number, ili.invoice_sequence;