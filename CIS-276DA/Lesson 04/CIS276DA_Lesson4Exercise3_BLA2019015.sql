SELECT
	v.vendor_name AS vendor_name,
    v.default_account_number AS default_account,
    g.account_description AS description
FROM
	ap.vendors AS v
INNER JOIN
	ap.general_ledger_accounts AS g
ON
	v.default_account_number = g.account_number
ORDER BY
	g.account_description, v.vendor_name;