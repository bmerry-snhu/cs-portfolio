CREATE USER IF NOT EXISTS
	ray@localhost
IDENTIFIED BY
	'temp'
PASSWORD HISTORY
	1
PASSWORD EXPIRE
	INTERVAL 90 DAY;
    
GRANT
	SELECT, INSERT, UPDATE
ON
	ap.vendors
TO
	ray@localhost;
    
GRANT
	SELECT, INSERT, UPDATE
ON
	ap.invoices
TO
	ray@localhost;
    
GRANT
	SELECT, INSERT
ON
	ap.invoice_line_items
TO
	ray@localhost;
    
GRANT
	USAGE
ON
	*.*
TO
	ray@localhost
WITH
	GRANT OPTION;