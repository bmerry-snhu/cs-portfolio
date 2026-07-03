SELECT
	invoice_due_date AS 'Due Date',
    invoice_total AS 'Invoice Total',
    invoice_total * 0.10 AS '10%',
    invoice_total * 1.10 AS 'Plus 10%'
FROM
	ap.invoices
WHERE
	invoice_total >= 500 AND invoice_total <= 1000
ORDER BY
	invoice_due_date DESC;