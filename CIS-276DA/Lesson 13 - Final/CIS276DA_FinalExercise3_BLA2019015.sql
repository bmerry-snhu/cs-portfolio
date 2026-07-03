USE
	my_guitar_shop;
    
SELECT
	CONCAT(last_name ,', ', first_name) AS customer_name
FROM
	customers
WHERE
	SUBSTR(last_name, 1, 1) >= 'M' AND SUBSTR(last_name, 1, 1) <= 'Z'
ORDER BY
	last_name;