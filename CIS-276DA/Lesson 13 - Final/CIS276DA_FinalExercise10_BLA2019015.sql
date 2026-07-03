USE
	my_guitar_shop;
    
ALTER TABLE
	products
ADD COLUMN
	date_added DATETIME;

ALTER TABLE
	products
ADD COLUMN
	supplier_name VARCHAR(255);
    
ALTER TABLE
	products
ADD COLUMN
	markup_percentage DECIMAL(5, 2) DEFAULT 50.00;