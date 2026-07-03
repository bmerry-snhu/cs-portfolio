USE ex;

DROP TABLE IF EXISTS
	member_committees;
DROP TABLE IF EXISTS
	members;
DROP TABLE IF EXISTS
	committees;
    
CREATE TABLE members (
	member_id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    address VARCHAR(255),
    city VARCHAR(100),
    state CHAR(2),
    phone VARCHAR(15) NOT NULL
);

CREATE TABLE committees (
	committee_id INT AUTO_INCREMENT PRIMARY KEY,
    committee_name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE members_committees (
	member_id INT,
    committee_id INT,
    PRIMARY KEY (member_id, committee_id),
    FOREIGN KEY (member_id) REFERENCES members(member_id),
    FOREIGN KEY (committee_id) REFERENCES committees(committee_id)
);