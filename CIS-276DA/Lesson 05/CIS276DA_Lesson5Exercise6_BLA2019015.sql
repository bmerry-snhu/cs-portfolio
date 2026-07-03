UPDATE
	ap.invoices
SET
	credit_total = invoice_total * 0.10,
    payment_total = invoice_total - (invoice_total * 0.10)
WHERE
	invoice_id = 115;