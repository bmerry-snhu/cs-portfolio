SELECT
    IF(GROUPING(i.terms_id) = 1, 'Summary for Terms', i.terms_id) AS terms_id,
    IF(GROUPING(i.vendor_id) = 1, 'Summary for Vendor', i.vendor_id) AS vendor_id,
    MAX(i.payment_date) AS last_payment_date,
    SUM(i.invoice_total - i.payment_total - i.credit_total) AS total_balance_due
FROM
    ap.invoices AS i
GROUP BY
    i.terms_id, i.vendor_id WITH ROLLUP;