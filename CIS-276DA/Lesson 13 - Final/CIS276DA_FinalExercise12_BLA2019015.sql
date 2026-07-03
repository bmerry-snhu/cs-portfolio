CREATE USER
	'newuser'@'%' IDENTIFIED BY 'newpassword';
    
GRANT SELECT, INSERT, UPDATE, DELETE ON my_guitar_shop.customers TO 'newuser'@'%';
GRANT SELECT, INSERT, UPDATE, DELETE ON my_guitar_shop.addresses TO 'newuser'@'%';
GRANT SELECT, INSERT, UPDATE, DELETE ON my_guitar_shop.orders TO 'newuser'@'%';
GRANT SELECT, INSERT, UPDATE, DELETE ON my_guitar_shop.order_items TO 'newuser'@'%';
GRANT SELECT ON my_guitar_shop.products TO 'newuser'@'%';
GRANT SELECT ON my_guitar_shop.categories TO 'newuser'@'%';

REVOKE GRANT OPTION ON *.* FROM 'newuser'@'%';
    
SHOW GRANTS FOR 'newuser'@'%';