create database HRMSDB;
use HRMSDB;
CREATE TABLE dep_tb (
    department_id INT AUTO_INCREMENT PRIMARY KEY,
    department_name varchar(50) unique,
    created_date dateTime
);
CREATE TABLE des_tb (
    designation_id INT AUTO_INCREMENT PRIMARY KEY,
    designation_name varchar(50) unique,
    created_date dateTime
);
CREATE TABLE emp_tb (
    employee_id INT AUTO_INCREMENT PRIMARY KEY,
    ename  varchar(50) ,
    email varchar(50) unique,
    created_date dateTime
    
);
ALTER TABLE emp_tb

ADD COLUMN department_id INT,
ADD COLUMN designation_id INT,
ADD COLUMN salary DECIMAL(18,2),
ADD COLUMN pass VARCHAR(50),
ADD COLUMN bankname VARCHAR(50),
ADD COLUMN bankno VARCHAR(50),
ADD COLUMN nationality VARCHAR(50),
ADD CONSTRAINT fk_dep_tb
    FOREIGN KEY (department_id) REFERENCES dep_tb(department_id) ON DELETE CASCADE,
ADD CONSTRAINT fk_des_tb
    FOREIGN KEY (designation_id) REFERENCES des_tb(designation_id) ON DELETE CASCADE;
    show tables;
    SHOW CREATE TABLE emp_tb;
DESCRIBE emp_tb;
CREATE TABLE leave_tb (
    Leaveid INT AUTO_INCREMENT PRIMARY KEY,
    Startleavedate DATE,
    Endleavedate DATE,
    Days INT,
    status VARCHAR(50),
    Reason VARCHAR(50),
    employee_id INT,
    CONSTRAINT fk_emp_tb FOREIGN KEY (employee_id) REFERENCES emp_tb(employee_id) ON DELETE CASCADE
);
describe leave_tb;
create table salaryslip
(
salaryslipid INT AUTO_INCREMENT PRIMARY KEY,
monthyear date,
 CONSTRAINT fk_sal_tb FOREIGN KEY (employee_id) REFERENCES emp_tb(employee_id) ON DELETE CASCADE,
 salary DECIMAL(18,2),
 Actualsalary DECIMAL(18,2),
employee_id INT,
 advancesalary DECIMAL(18,2),
 leaveded DECIMAL(18,2),
 foodallownce decimal(18,2),
 Medicalallownce decimal(18,2),
 travelallownce decimal(18,2),
 Bonus DECIMAL(18,2),
 createddate date
 );
 CREATE TABLE contact_tb (
    contact_id INT AUTO_INCREMENT PRIMARY KEY,
    cname  varchar(50) ,
    email varchar(50) unique,
    message varchar(1000),
    created_date dateTime
    
);
 DELIMITER $$

CREATE PROCEDURE ContactSp(
    IN action VARCHAR(15),
    IN contact_id INT ,
    IN cname VARCHAR(50) ,
    IN email VARCHAR(50) ,
    IN message VARCHAR(1000)
)
BEGIN
    IF action = 'INSERT' THEN
        INSERT INTO contact_tb (cname, email, message, createddate)
        VALUES (cname, email, message, NOW());
    END IF;

    IF action = 'SELECT' THEN
        SELECT * FROM contact_tb;
    END IF;

    IF action = 'DELETE' THEN
        DELETE FROM contact_tb WHERE contact_id = contactSp.contact_id;
    END IF;
END$$

DELIMITER ;
DELIMITER $$

CREATE PROCEDURE DepartmentSp(
    IN action VARCHAR(15),
    IN in_department_id INT,
    IN in_department_name VARCHAR(50)
)
BEGIN
    IF action = 'INSERT' THEN
        INSERT INTO dep_tb (department_name, createddate)
        VALUES (in_department_name, NOW());
    END IF;

    IF action = 'SELECT' THEN
        SELECT * FROM dep_tb;
    END IF;

    IF action = 'UPDATE' THEN
        UPDATE dep_tb
        SET department_name = in_department_name
        WHERE department_id = in_department_id;
    END IF;

    IF action = 'GETBYID' THEN
        SELECT * FROM dep_tb
        WHERE department_id = in_department_id;
    END IF;

    IF action = 'DELETE' THEN
        DELETE FROM dep_tb
        WHERE department_id = in_department_id;
    END IF;
END$$

DELIMITER ;
DELIMITER $$

CREATE PROCEDURE DesignationSp(
    IN action VARCHAR(15),
    IN in_designation_id INT,
    IN in_designation_name VARCHAR(50)
)
BEGIN
    IF action = 'INSERT' THEN
        INSERT INTO des_tb (designation_name, createddate)
        VALUES (in_designation_name, NOW());
    END IF;

    IF action = 'SELECT' THEN
        SELECT * FROM des_tb;
    END IF;

    IF action = 'UPDATE' THEN
        UPDATE des_tb
        SET designation_name = in_designation_name
        WHERE designation_id = in_designation_id;
    END IF;

    IF action = 'GETBYID' THEN
        SELECT * FROM des_tb
        WHERE designation_id = in_designation_id;
    END IF;

    IF action = 'DELETE' THEN
        DELETE FROM des_tb
        WHERE designation_id = in_designation_id;
    END IF;
END$$

DELIMITER ;
DELIMITER $$

CREATE PROCEDURE EmployeeSp(
    IN action VARCHAR(15),
    IN in_employee_id INT,
    IN in_ename VARCHAR(50),
    IN in_email VARCHAR(50),
    IN in_department_id INT,
    IN in_designation_id INT,
    IN in_salary DECIMAL(18,2),
    IN in_pass VARCHAR(50),
    IN in_bankname VARCHAR(50),
    IN in_bankno VARCHAR(50),
    IN in_nationality VARCHAR(50)
)
BEGIN
    -- INSERT action
    IF action = 'INSERT' THEN
        INSERT INTO emp_tb (
            ename, email, department_id, designation_id, salary, pass, bankname, bankno, nationality, created_date
        )
        VALUES (
            in_ename, in_email, in_department_id, in_designation_id, in_salary, in_pass, in_bankname, in_bankno, in_nationality, NOW()
        );
    END IF;

    -- SELECT action
    IF action = 'SELECT' THEN
        SELECT * FROM emp_tb;
    END IF;

    -- UPDATE action
    IF action = 'UPDATE' THEN
        UPDATE emp_tb
        SET 
            ename = in_ename,
            email = in_email,
            department_id = in_department_id,
            designation_id = in_designation_id,
            salary = in_salary,
            pass = in_pass,
            bankname = in_bankname,
            bankno = in_bankno,
            nationality = in_nationality
        WHERE employee_id = in_employee_id;
    END IF;

    -- GETBYID action
    IF action = 'GETBYID' THEN
        SELECT * FROM emp_tb WHERE employee_id = in_employee_id;
    END IF;

    -- DELETE action
    IF action = 'DELETE' THEN
        DELETE FROM emp_tb WHERE employee_id = in_employee_id;
    END IF;

END$$

DELIMITER ;
DROP PROCEDURE IF EXISTS EmployeeSp;

DELIMITER $$

CREATE PROCEDURE EmployeeSp(
    IN action VARCHAR(15),
    IN in_employee_id INT,
    IN in_ename VARCHAR(50),
    IN in_email VARCHAR(50),
    IN in_department_id INT,
    IN in_designation_id INT,
    IN in_salary DECIMAL(18,2),
    IN in_pass VARCHAR(50),
    IN in_bankname VARCHAR(50),
    IN in_bankno VARCHAR(50),
    IN in_nationality VARCHAR(50)
)
BEGIN
    -- ✅ Declare variables at the beginning
    DECLARE user_exists INT DEFAULT 0;

    -- Insert
    IF action = 'INSERT' THEN
        INSERT INTO emp_tb (
            ename, email, department_id, designation_id, salary, pass, bankname, bankno, nationality, created_date
        )
        VALUES (
            in_ename, in_email, in_department_id, in_designation_id, in_salary, in_pass, in_bankname, in_bankno, in_nationality, NOW()
        );
    END IF;

    -- Select All with JOIN
    IF action = 'SELECT' THEN
        SELECT 
            e.employee_id,
            e.ename,
            e.email,
            e.salary,
            e.created_date,
            d.department_name,
            des.designation_name
        FROM emp_tb e
        JOIN dep_tb d ON e.department_id = d.department_id
        JOIN des_tb des ON e.designation_id = des.designation_id;
    END IF;

    -- Update
    IF action = 'UPDATE' THEN
        UPDATE emp_tb
        SET 
            ename = in_ename,
            email = in_email,
            department_id = in_department_id,
            designation_id = in_designation_id,
            salary = in_salary,
            pass = in_pass,
            bankname = in_bankname,
            bankno = in_bankno,
            nationality = in_nationality
        WHERE employee_id = in_employee_id;
    END IF;

    -- Get by ID
    IF action = 'GETBYID' THEN
        SELECT 
            e.employee_id,
            e.ename,
            e.email,
            e.salary,
            e.created_date,
            d.department_name,
            des.designation_name
        FROM emp_tb e
        JOIN dep_tb d ON e.department_id = d.department_id
        JOIN des_tb des ON e.designation_id = des.designation_id
        WHERE e.employee_id = in_employee_id;
    END IF;

    -- Delete
    IF action = 'DELETE' THEN
        DELETE FROM emp_tb WHERE employee_id = in_employee_id;
    END IF;

    -- Login
    IF action = 'LOGIN' THEN
        SELECT COUNT(*) INTO user_exists
        FROM emp_tb
        WHERE email = in_email AND pass = in_pass;

        IF user_exists > 0 THEN
            SELECT 'Login successful' AS message;
        ELSE
            SELECT 'Invalid email or password' AS message;
        END IF;
    END IF;

END$$

DELIMITER ;
DELIMITER $$

CREATE PROCEDURE LeaveSp(
    IN action VARCHAR(15),
    IN in_Leaveid INT,
    IN in_Startleavedate date,
    IN in_Endleavedate date,
    IN in_Days INT,
  
    IN in_status VARCHAR(50),
    IN in_Reason VARCHAR(500),
    IN in_employee_id int
  
)
BEGIN
   

    -- Insert
    IF action = 'INSERT' THEN
        INSERT INTO leave_tb (
            Startleavedate, Endleavedate,Days,status,Reason,employee_id
        )
        VALUES (
            in_Startleavedate, in_Endleavedate, in_Days, in_status, in_Reason, in_employee_id
        );
    END IF;

  
    IF action = 'SELECT' THEN
        SELECT * from leave_tb where employee_id=in_employee_id;
    END IF;

    -- Update
    IF action = 'UPDATE' THEN
        UPDATE leave_tb
        SET 
            Startleavedate = in_Startleavedate,
            Endleavedate = in_Endleavedate,
            Days = in_Days,
            
            Reason = in_Reason,
          
            employee_id = in_employee_id
           
        WHERE Leaveid = in_Leaveid;
    END IF;
    IF action = 'UPDATE STATUS' THEN
        UPDATE leave_tb
        SET 
    status = in_status
    WHERE Leaveid = in_Leaveid;
    END IF;

    -- Get by ID
    IF action = 'GETBYID' THEN
        SELECT 
           * from leave_tb
        WHERE Leaveid = in_Leaveid;
    END IF;

    -- Delete
    IF action = 'DELETE' THEN
        DELETE FROM leave_tb WHERE Leaveid = in_Leaveid;
    END IF;


END$$

DELIMITER ;
DELIMITER $$

CREATE PROCEDURE SalarySlipSp(
    IN action VARCHAR(20),
    IN in_salaryslipid INT,
    IN in_monthyear DATE,
    IN in_employee_id INT,
    IN in_salary DECIMAL(18,2),
    IN in_Actualsalary DECIMAL(18,2),
    IN in_advancesalary DECIMAL(18,2),
    IN in_leaveded DECIMAL(18,2),
    IN in_foodallownce DECIMAL(18,2),
    IN in_Medicalallownce DECIMAL(18,2),
    IN in_travelallownce DECIMAL(18,2),
    IN in_Bonus DECIMAL(18,2)
)
BEGIN
    -- Insert
    IF action = 'INSERT' THEN
        INSERT INTO salaryslip (
            monthyear, employee_id, salary, Actualsalary, advancesalary, leaveded,
            foodallownce, Medicalallownce, travelallownce, Bonus, createddate
        )
        VALUES (
            in_monthyear, in_employee_id, in_salary, in_Actualsalary, in_advancesalary, in_leaveded,
            in_foodallownce, in_Medicalallownce, in_travelallownce, in_Bonus, NOW()
        );
    END IF;

    -- Update
    IF action = 'UPDATE' THEN
        UPDATE salaryslip
        SET
            monthyear = in_monthyear,
            employee_id = in_employee_id,
            salary = in_salary,
            Actualsalary = in_Actualsalary,
            advancesalary = in_advancesalary,
            leaveded = in_leaveded,
            foodallownce = in_foodallownce,
            Medicalallownce = in_Medicalallownce,
            travelallownce = in_travelallownce,
            Bonus = in_Bonus
        WHERE salaryslipid = in_salaryslipid;
    END IF;

    -- Select All
    IF action = 'SELECT' THEN
        SELECT * FROM salaryslip;
    END IF;

    -- Get by Employee ID
    IF action = 'GETBYEMP' THEN
        SELECT * FROM salaryslip WHERE employee_id = in_employee_id;
    END IF;

    -- Yearly Report (fetch all slips for the year of given monthyear)
    IF action = 'YEARLY' THEN
        SELECT * FROM salaryslip
        WHERE YEAR(monthyear) = YEAR(in_monthyear)
          AND employee_id = in_employee_id;
    END IF;

    -- Delete
    IF action = 'DELETE' THEN
        DELETE FROM salaryslip WHERE salaryslipid = in_salaryslipid;
    END IF;

END$$

DELIMITER ;
describe emp_tb;



