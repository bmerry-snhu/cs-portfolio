USE ex;

ALTER TABLE
	committees
ADD CONSTRAINT 
	committee_name_uq UNIQUE (committee_name);
    
INSERT INTO
	committees (committee_name)
VALUES
	('Commitee 1');
    
INSERT INTO
	committees (committee_name)
VALUES
	('Commitee 1');