SELECT
	account_number,
    account_description
FROM
	ap.general_ledger_accounts
WHERE NOT EXISTS (
	SELECT
		1
	FROM
		ap.invoice_line_items
	WHERE
		ap.invoice_line_items.account_number = ap.general_ledger_accounts.account_number
	)
ORDER BY
	account_number;