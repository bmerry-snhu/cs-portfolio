USE
	my_guitar_shop;
    
SELECT
	c.last_name,
    c.first_name,
    o.order_date,
    p.product_name,
    oi.item_price,
    oi.discount_amount,
    oi.quantity
FROM
	customers AS c
JOIN
	orders AS o ON c.customer_id = o.customer_id
JOIN
	order_items AS oi ON o.order_id = oi.order_id
JOIN
	products AS p ON oi.product_id = p.product_id
ORDER BY
	c.last_name,
    o.order_date,
    p.product_name;