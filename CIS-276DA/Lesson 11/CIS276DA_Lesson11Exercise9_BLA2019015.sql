CREATE USER
	dorothy@localhost
IDENTIFIED BY
	'sesame';
    
CREATE ROLE
	ap_user;
    
GRANT
	SELECT, INSERT, UPDATE
ON
	ap.*
TO
	ap_user;
    
GRANT
	ap_user
TO
	dorothy@localhost;