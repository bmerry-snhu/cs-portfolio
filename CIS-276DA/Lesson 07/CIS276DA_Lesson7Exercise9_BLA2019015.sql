WITH
	LargestUnpaidInvoices AS (
		SELECT
			vendor_id,
            MAX(invoice_total - payment_total - credit_total) AS largest_unpaid_invoice
		FROM
			ap.invoices
		WHERE
			invoice_total - payment_total - credit_total > 0
		GROUP BY
			vendor_id
		)
SELECT
	SUM(largest_unpaid_invoice) AS total_largest_unpaid
FROM
	LargestUnpaidInvoices;