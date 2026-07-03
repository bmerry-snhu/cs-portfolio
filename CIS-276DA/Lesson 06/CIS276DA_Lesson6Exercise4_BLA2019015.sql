SELECT
    g.account_description,
    COUNT(i.invoice_sequence) AS line_item_count,
    SUM(i.line_item_amount) AS total_line_item_amount
FROM
    ap.general_ledger_accounts AS g
JOIN
    ap.invoice_line_items AS i 
    ON g.account_number = i.account_number
GROUP BY
    g.account_description
HAVING
    COUNT(i.invoice_sequence) > 1
ORDER BY
    total_line_item_amount DESC;