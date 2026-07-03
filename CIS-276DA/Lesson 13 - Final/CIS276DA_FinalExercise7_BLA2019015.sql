USE
	my_guitar_shop;
    
WITH order_item_totals AS (
	SELECT
		item_id,
        order_id,
        quantity,
        item_price,
        discount_amount,
        (quantity * (item_price - discount_amount)) AS item_total
    FROM
		order_items
	)
SELECT
	oit.order_id,
    oit.item_id,
    oit.item_total,
    SUM(oit.item_total) OVER order_window AS total_order_amount,
    ROUND(AVG(oit.item_total) OVER order_window, 2) AS average_item_amount
FROM
	order_item_totals AS oit
WINDOW
	order_window AS (PARTITION BY oit.order_id)
ORDER BY
	oit.order_id ASC;