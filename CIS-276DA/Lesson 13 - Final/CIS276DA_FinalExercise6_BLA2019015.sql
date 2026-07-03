USE
	my_guitar_shop;
    
SELECT
	c.email_address,
    order_counts.number_of_orders,
    SUM(oi.quantity * (oi.item_price - oi.discount_amount)) AS total_order_amount
FROM
	customers AS c
JOIN (
	SELECT
		customer_id,
        COUNT(order_id) AS number_of_orders
	FROM
		orders
	GROUP BY
		customer_id
	HAVING
		COUNT(order_id) > 1
	) AS order_counts ON c.customer_id = order_counts.customer_id
JOIN
	orders AS o ON o.customer_id = c.customer_id
JOIN
	order_items AS oi ON oi.order_id = o.order_id
GROUP BY
	c.email_address
ORDER BY
	total_order_amount DESC;