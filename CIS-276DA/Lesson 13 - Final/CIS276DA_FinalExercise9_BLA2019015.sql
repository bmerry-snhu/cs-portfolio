USE
	my_guitar_shop;

WITH product_sales AS (
	SELECT
		p.category_id,
        p.product_name,
		SUM(oi.quantity * (oi.item_price - oi.discount_amount)) AS total_sales
    FROM
		products AS p
	JOIN
		order_items AS oi ON p.product_id = oi.product_id
	GROUP BY
		p.category_id,
        p.product_name
	)
SELECT
	c.category_name,
    ps.product_name,
    ps.total_sales,
    FIRST_VALUE(ps.product_name) OVER category_sales_window AS highest_sales,
    LAST_VALUE(ps.product_name) OVER category_sales_window AS lowest_sales
FROM
	categories AS c
JOIN
	product_sales AS ps ON c.category_id = ps.category_id
WINDOW
	category_sales_window AS (PARTITION BY ps.category_id ORDER BY ps.total_sales DESC ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING)
ORDER BY
	c.category_name,
    ps.total_sales DESC;