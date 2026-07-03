SELECT
	g.account_number AS account_number,
    g.account_description AS account_description
FROM
	ap.general_ledger_accounts AS g
LEFT JOIN
	ap.invoice_line_items AS ili
ON
	g.account_number = ili.account_number
WHERE
	ili.invoice_id IS NULL
ORDER BY
	g.account_number;