SELECT
	invoice_number,
    invoice_due_date
FROM
	ap.invoices
ORDER BY
	invoice_due_date
LIMIT 20;