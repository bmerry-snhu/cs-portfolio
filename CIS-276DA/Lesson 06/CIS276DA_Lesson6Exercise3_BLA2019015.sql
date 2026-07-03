SELECT 
    v.vendor_name, 
    COUNT(i.invoice_id) AS invoice_count, 
    SUM(i.invoice_total) AS total_invoice_amount
FROM 
	ap.vendors AS v
JOIN 
	ap.invoices AS i 
    ON v.vendor_id = i.vendor_id
GROUP BY 
	v.vendor_name
ORDER BY
	invoice_count DESC;
