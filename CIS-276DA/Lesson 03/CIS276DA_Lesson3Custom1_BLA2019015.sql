SELECT
	concat(last_name,', ',first_name) as 'full_name'
FROM
	ap.vendor_contacts
WHERE
	last_name LIKE 'A%';