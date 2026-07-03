SELECT
    i.account_number,
    SUM(i.line_item_amount) AS total_invoiced_amount
FROM
    ap.invoice_line_items AS i
GROUP BY
    i.account_number WITH ROLLUP;