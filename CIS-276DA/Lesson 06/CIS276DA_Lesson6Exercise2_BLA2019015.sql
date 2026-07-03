SELECT 
    v.vendor_name, 
    SUM(i.payment_total) AS total_payment
FROM 
	ap.vendors AS v
JOIN 
	ap.invoices AS i 
	ON v.vendor_id = i.vendor_id
GROUP BY 
	v.vendor_name
ORDER BY 
	total_payment DESC;
