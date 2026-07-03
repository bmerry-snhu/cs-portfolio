USE
	my_guitar_shop;

SELECT
	c.email_address,
    o.order_id,
    o.order_date
FROM
	customers AS c
JOIN
	orders AS o ON c.customer_id = o.customer_id
WHERE
	o.order_date = (
		SELECT
			MIN(o2.order_date)
		FROM
			orders AS o2
		WHERE
			o2.customer_id = c.customer_id
		)
ORDER BY
	o.order_date ASC,
    o.order_id ASC;