--To insert user mapping info in database please use below template
--where 
--	- username must be the samAccountName of user
--	- role is integer value of enum 'Role'
--	- status_flag is bit representing active/inactive by 1/0

INSERT INTO [UserMappingInfo] ([Username], [Role], [Status])
VALUES('<username>', <role>,<status_flag>)

-- Now, based on need please insert the mapping of user and business unit with below query
-- you need to insert into multiple record for multiple business unit
INSERT INTO [User_BusinessUnit]([UserId], [BusinessUnitId])
VALUES(<user_id>, <business_unit_id>)

-- Where above <user_id> and <business_unit_id> can be identified as :
-- To get the user id from 'UserMappingInfo' table by executing
SELECT Id FROM UserMappingInfo WHERE username='<username>' --
-- and to get business unit ids, see the 'BusinessUnit' lookup table
SELECT * FROM BusinessUnit;

-- Note: Only one admin must be inserted mannually, other can be inserted using the admin account through the app.
