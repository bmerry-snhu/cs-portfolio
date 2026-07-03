USE ap;

CREATE VIEW
	open_items_summary AS
SELECT
	v.vendor_name,
    COUNT(i.invoice_number) AS open_item_count,
    SUM(i.invoice_total - i.payment_total - i.credit_total) AS open_item_total
FROM
	invoices AS i
JOIN
	vendors AS v
ON
	i.vendor_id = v.vendor_id
WHERE
	(i.invoice_total - i.payment_total - i.credit_total) > 0
GROUP BY
	v.vendor_name;