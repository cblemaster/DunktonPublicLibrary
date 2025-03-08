-- DELETE FROM Account WHERE 1=1;
--
SELECT * FROM Account a;
--
SELECT * FROM Role r;
--
SELECT *
FROM Account a
LEFT JOIN Role r ON a.RoleId = r.Id;
--