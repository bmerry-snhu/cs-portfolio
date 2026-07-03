// Using the mysql2 module instead of mysql for authentication reasons.
const mysql = require('mysql2');

// Connection Arguments (don't steal my plain-text password!)
const connection = mysql.createConnection({
  host: "merryserv.home.arpa",
  user: "root",
  password: "Iamover30!",
  database: "lesson10"
});

// Connect to the database
connection.connect(function(err) {
  if (err) throw err;
  console.log("Connected to MySQL server!");

  // Query Arguments
  const table = 'employees';

  const employeeName = 'Jane Doe';
  const jobTitle = 'Senior Developer';
  const newJobTitle = 'Lead Developer';

  // INSERT Query Statement
  const insertQuery = `INSERT INTO ${table} (name, job_title) VALUES ('${employeeName}', '${jobTitle}')`;
  connection.query(insertQuery, function (err, result) {
    if (err) throw err;
    console.log(`New employee ${employeeName} added.`);
  });

  // SELECT Query Statement
  const selectQuery = `SELECT name FROM ${table}`;
  connection.query(selectQuery, function (err, result) {
    if (err) throw err;
    console.log("Employee names:", result);
  });

  // UPDATE Query Statement
  const updateQuery = `UPDATE ${table} SET job_title = '${newJobTitle}' WHERE name = '${employeeName}'`;
  connection.query(updateQuery, function (err, result) {
    if (err) throw err;
    console.log(`Employee '${employeeName}' job title updated to '${newJobTitle}'.`);
  });

  // DELETE Query Statement
  const deleteQuery = `DELETE FROM ${table} WHERE name = '${employeeName}'`;
  connection.query(deleteQuery, function (err, result) {
    if (err) throw err;
    console.log(`Employee '${employeeName}' deleted.`);
  });

  // Close the connection
  connection.end(function(err) {
    if (err) throw err;
    console.log("Connection closed.");
  });
});