SELECT
	v1.vendor_id AS vendor_id,
    v1.vendor_name AS vendor_name,
    concat(v1.vendor_contact_first_name,' ',v1.vendor_contact_last_name) AS contact_name
FROM
	ap.vendors AS v1
INNER JOIN
	ap.vendors AS v2
ON
	v1.vendor_id <> v2.vendor_id
AND
	v1.vendor_contact_last_name = v2.vendor_contact_last_name
ORDER BY
	v1.vendor_contact_last_name;