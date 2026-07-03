SELECT
	invoice_number,
    invoice_total,
    (payment_total + credit_total) AS 'payment_credit_total',
    (invoice_total - (payment_total + credit_total)) AS 'balance_due'
FROM
	ap.invoices
WHERE
	(invoice_total - (payment_total + credit_total)) > 50
ORDER BY
	(invoice_total - (payment_total + credit_total)) DESC
LIMIT 5;