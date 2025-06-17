--courier management system--
--creating a new database for couriermanagement system 
create database CourierManagementSystem
--creating the first table (User)
create table Users(
UserID INT PRIMARY KEY,
Name VARCHAR(255),
Email VARCHAR(255) UNIQUE,
Password VARCHAR(255),
ContactNumber VARCHAR(20),
Address TEXT)
--ALTER TABLE TO ADD UNIQUE CONSTRAINT
alter table Users
add constraint UK_Users_Email
unique(Email)
--creating second table (courier)
create table Couriers
(CourierID INT PRIMARY KEY,
SenderName VARCHAR(255),
SenderAddress TEXT,
ReceiverName VARCHAR(255),
ReceiverAddress TEXT,
Weight DECIMAL(5, 2),
Status VARCHAR(50),
TrackingNumber VARCHAR(20) UNIQUE,
DeliveryDate DATE);
--add unique key constraints
alter table Couriers
add constraint UK_Couriers_TrackingNumber
unique(TrackingNumber)

--creating the third table(Courier service)
create table CourierServices
(ServiceID  INT  PRIMARY KEY,
ServiceName VARCHAR(100),
Cost DECIMAL(8, 2))
--creating the fourth table(employee)
create table Employees
(EmployeeID INT PRIMARY KEY,
Name VARCHAR(255),
Email VARCHAR(255) ,
ContactNumber VARCHAR(20),
Role VARCHAR(50),
Salary DECIMAL(10, 2))
--adding unique constraints
alter table Employees
add constraint UK_Employees_Email
unique(Email)

--creating fifth table (location)
create table locations 
(LocationID INT PRIMARY KEY,
LocationName VARCHAR(100),
Address TEXT)
--creating sixth table (payment)
create table payments
(PaymentID INT PRIMARY KEY,
CourierID INT,
LocationId INT,
Amount DECIMAL(10, 2),
PaymentDate DATE,
FOREIGN KEY (CourierID) REFERENCES Couriers(CourierID),
FOREIGN KEY (LocationID) REFERENCES Locations(LocationID))
--Insert values 
Insert into Users Values
(1, 'Arjun R', 'arjun.r@example.com', 'arjun@123', '9876543210', '12, Avinashi Road, Coimbatore'),
(2, 'Divya M', 'divya.m@example.com', 'divya@456', '8765432190', '45, Anna Nagar, Chennai'),
(3, 'Rahul S', 'rahul.s@example.com', 'rahul@789', '9988776655', '78, MG Road, Bangalore'),
(4, 'Sneha K', 'sneha.k@example.com', 'sneha@321', '9123456780', '34, Adyar, Chennai')
select * from Users
Insert into Couriers values 
(101, 'Arjun R', '12, Avinashi Road, Coimbatore', 'Divya M', '45, Anna Nagar, Chennai', 2.50, 'In Transit', 'TRK123456', '2025-06-15'),
(102, 'Rahul S', '78, MG Road, Bangalore', 'Sneha K', '34, Adyar, Chennai', 1.20, 'Delivered', 'TRK654321', '2025-06-10'),
(103, 'Divya M', '45, Anna Nagar, Chennai', 'Arjun R', '12, Avinashi Road, Coimbatore', 0.80, 'Pending Pickup', 'TRK789456', NULL),
(104, 'Karthik V', '23, KK Nagar, Madurai', 'Nisha L', '98, Vepery, Chennai', 3.10, 'Dispatched', 'TRK112233', '2025-06-12'),
(105, 'Sneha K', '34, Adyar, Chennai', 'Rahul S', '78, MG Road, Bangalore', 2.00, 'Out for Delivery', 'TRK445566', '2025-06-13')
select * from Couriers
insert into CourierServices VALUES
(1, 'Standard Delivery', 150.00),
(2, 'Express Delivery', 250.00),
(3, 'Same Day Delivery', 400.00)
select*from CourierServices
insert into Employees VALUES
(1, 'Ravi Kumar', 'ravi.k@example.com', '9000011122', 'Delivery Executive', 18000.00),
(2, 'Meena Singh', 'meena.s@example.com', '9000022233', 'Operations Manager', 45000.00),
(3, 'Aravind V', 'aravind.v@example.com', '9000033344', 'Pickup Staff', 16000.00)
select*from Employees
insert into Locations VALUES
(1, 'Coimbatore Hub', 'Avinashi Road, Coimbatore'),
(2, 'Chennai Hub', 'T Nagar, Chennai'),
(3, 'Bangalore Hub', 'Indiranagar, Bangalore')
select*from Locations
insert into Payments VALUES
(501, 101,1, 250.00, '2025-06-11'),
(502, 101,2, 150.00, '2025-06-08'),
(503, 103,3, 1400.00, '2025-06-10')    --whether we need to enter the foreign keys column values also here since its mentioned already in table creation
 select*from payments
--normalising the schema by creating another parcel table to add multiple packages to a courier
create table Parcel( ParcelID INT PRIMARY KEY,
    CourierID int,
    Description text,
    Weight decimal(5,2),
    FOREIGN KEY (CourierID) references Couriers(CourierID))
--added sent_date to find the differences between sent and delivered date to find average in 10th query
alter table Couriers
add sentdate Date
select*from couriers
-- to find no of couriers handled by employees 
alter table Couriers
add HandledBy int
alter table Couriers
add constraint FK_Courier_Employee
Foreign key (HandledBy) references Employees(EmployeeID)
select*from Couriers

--     task 2  ----
--.1. List all customers:  
select* from Users

--2. List all orders for a specific customer: 
select * 
from Couriers 
where ReceiverName = 'Divya M' -- here we can keep receiver as a customer ,or sender as a customer or both sender and receiver as a customer

--3. List all couriers:  
select*from Couriers

--4. List all packages for a specific order: 
select* from Couriers
where CourierID='101'

--5. List all deliveries for a specific courier:  
select * 
from Couriers
where TrackingNumber = 'TRK123456' -- showing the deliveries of a specific courier

--6. List all undelivered packages:  
select * from Couriers 
Where Status!= 'Delivered'

--7. List all packages that are scheduled for delivery today:  
select getdate()
select* from Couriers 
where DeliveryDate = cast(GETDATE() as date)  --- why we use cast ,giving error for getDate()

--8. List all packages with a specific status:  
select* from Couriers 
where Status='dispatched'

--9. Calculate the total number of packages for each courier.  -- we can create a parcel table to show multiple parcels for a courier so normalising the schema
Select CourierID, count(*) as TotalPackages
from Parcel
group by CourierID; 

--10. Find the average delivery time for each courier  --for this we added a new column sent date to find the date diff bw sent and delivery time
select  CourierID,
    avg(DATEDIFF(DAY, sentdate, DeliveryDate)) AS avgtime
from Couriers
where sentdate IS NOT NULL AND DeliveryDate IS NOT NULL
group by CourierID

--11. List all packages with a specific weight range:  
select * from Couriers 
where weight='2'

--12. Retrieve employees whose names contain 'John' 
select* from employees
where name='john'

--13. Retrieve all courier records with payments greater than $50. 
select * from payments
where amount>50

--- task 3 -----
--14. Find the total number of couriers handled by each employee.  here we need to link courier to the employee so link it by foreign key as handledby
select count(*) from Couriers
where HandledBy is not null -- handledby is constrained with foreign key employeeid 
group by HandledBy

--15. Calculate the total revenue generated by each location  
select sum(amount) from payments
where amount is not null
group by locationId

--16. Find the total number of couriers delivered to each location.  
select count(CourierId) from Payments
where courierid is not null
group by locationId

--17. Find the courier with the highest average delivery time:
select  CourierID,
    avg(datediff(day, sentdate, DeliveryDate)) AS avgtime
from Couriers
where sentdate IS NOT NULL AND DeliveryDate IS NOT NULL
group by CourierID

--18. Find Locations with Total Payments Less Than a Certain Amount  
select locationId from Payments
where Amount<250

--19. Calculate Total Payments per Location  
select sum(amount) from Payments
where amount is not null
group by LocationId

--20. Retrieve couriers who have received payments totaling more than $1000 in a specific location  -- here having can be used only after group by
--(LocationID = X):  
select locationId from payments
where locationId='1'
group by LocationId
having sum(amount)>1000

--21. Retrieve couriers who have received payments totaling more than $1000 after a certain date 
--(PaymentDate > 'YYYY-MM-DD'):  
select CourierID from payments
where paymentDate>'2025-06-09'
group by CourierId
having sum(amount)>1000

--22. Retrieve locations where the total amount received is more than $5000 before a certain date 
--(PaymentDate > 'YYYY-MM-DD'):  
select CourierID from payments
where paymentDate >'2025-06-09'
group by CourierId
having sum(amount)>5000

---casting question in own to do 
select cast(paymentDate as varchar) from payments

--- task 4 ---
--23. Retrieve Payments with Courier Information  
select p.PaymentId,p.Amount,
p.CourierId As CourierId,
p.PaymentDate,
c.SenderName,
c.SenderAddress,
c.ReceiverName,
c.Weight,c.Status
from payments p
join Couriers c
on c.CourierId=p.CourierId


--24. Retrieve Payments with Location Information  
select p.PaymentId,p.PaymentDate,
p.Amount,l.LocationId as LocationId
from payments p
join locations l
on l.locationId=p.locationId

--25. Retrieve Payments with Courier and Location Information  
select p.paymentId,
p.courierId,p.locationId,
p.amount,p.paymentDate,
c.CourierId,c.senderName,c.SenderAddress,
c.ReceiverName,c.ReceiverAddress,
c.TrackingNumber,
l.LocationId,l.LocationName,
l.Address
from payments p
join Couriers c on  p.CourierId=c.CourierId
join Locations l on p.LocationId=l.locationId

--26. List all payments with courier details  
select p.PaymentId,
p.PaymentDate,p.Amount,
p.CourierId as CourierId
from Payments p
join Couriers c on p.courierId=c.CourierId

--27. Total payments received for each courier  
select courierId,
sum(Amount) as total
from Payments
group by courierId

--28. List payments made on a specific date  
select paymentId
from Payments
where paymentDate='2025-06-08'

--29. Get Courier Information for Each Payment  --here we can select them individually to make only the payment id visible from the payment table
select c.CourierId as CourierId,
c.SenderName,c.SenderAddress,
c.ReceiverName,c.ReceiverName,
c.Weight,c.Status,c.TrackingNumber,c.deliveryDate,
c.SentDate,c.HandledBy,
p.PaymentId
from couriers c 
  join Payments p
on c.CourierId =p.CourierId 


--30. Get Payment Details with Location  
select p.PaymentId,p.PaymentDate,
p.Amount,l.LocationId as locationId 
from Payments p
 join Locations l
on p.LocationId=l.LocationId

--31. Calculating Total Payments for Each Courier
 select courierId,
 sum(Amount) as total
from payments
group by courierId

--32. List Payments Within a Date Range 
select PaymentId,Amount,PaymentDate
from payments
where PaymentDate between '2025-06-09' and '2025-06-14'

--33. Retrieve a list of all users and their corresponding courier records, including cases where there are no matches on either side 
  -- users with  no couriers or no matching users also should be printed
  -- first we need to make relationship bw users table and couriers table
  alter table Users
  add CourierId int
  Foreign Key (Courierid) references Couriers(CourierId)
  -- we need to create userid as a foreign key as 
  alter table Couriers
  add UserId int 
  Foreign key (Userid) references Users(UserId)
  -- now writing query
  select u.UserId,u.Name,c.CourierId as courierid,
  c.SenderName,c.SenderAddress,
  c.ReceiverName,c.ReceiverAddress,
  c.Weight,c.Status,
  c.TrackingNumber,c.DeliveryDate,
  c.SentDate,c.HandledBy
  from Couriers c
  full outer join users u
 on c.UserId=u.UserId
 --select* from couriers
-- select*from Users

--34. Retrieve a list of all couriers and their corresponding services, including cases where there are no matches on either side  
-- here we need to add foreign key serviceId to the couriers table
alter table Couriers 
add ServiceID int
alter table Couriers
add constraint FK_Courier_Service foreign key (ServiceID) references CourierServices(ServiceID)
--now the query writing
select c.CourierId,s.ServiceId as ServiceId,
s.ServiceName,s.Cost
from Couriers c
full outer join CourierServices s
on c.ServiceId=s.ServiceID

--35. Retrieve a list of all employees and their corresponding payments, including cases where there are no matches on either side 
--first here we need to add Payment id as foreign key in Employee table
alter table Employees
add PaymentId int
alter table Employees
add constraint FK_Payments foreign key (Payment_Id) references Payments(PaymentId)
--now write the query
select e.employeeId,
p.PaymentId as Payment_Id,
p.paymentDate,p.Amount
from Employees e
full outer join Payments p
on p.PaymentId=e.Payment_Id

--36. List all users and all courier services, showing all possible combinations.  
select u.userId,u.name,
c.ServiceId,c.serviceName
from Users u
cross join CourierServices c 

--37. List all employees and all locations, showing all possible combinations:  
select e.employeeId,e.name,
l.locationId,l.locationName 
from Employees e
cross join Locations l

--38. Retrieve a list of couriers and their corresponding sender information (if available)  
select courierId,
senderName,senderAddress 
from Couriers

--39. Retrieve a list of couriers and their corresponding receiver information (if available):  
select courierId,
ReceiverName,receiverAddress
from Couriers

--40. Retrieve a list of couriers along with the courier service details (if available):  
select courierId,
ServiceID  
from Couriers

--41. Retrieve a list of employees and the number of couriers assigned to each employee:  

select HandledBy,
count(courierId) numberofcouriers
from Couriers
group by HandledBy
--42. Retrieve a list of locations and the total payment amount received at each location:  
select locationId,
sum(Amount) as total
from Payments
group by LocationId

--43. Retrieve all couriers sent by the same sender (based on SenderName). --we can also use subquery here 
select SenderName, COUNT(*) as Couriers
from Couriers
group by SenderName
having COUNT(*) > 1

--44. List all employees who share the same role. we can also use subqueries here 
--using self join
select distinct e1.*
from Employees e1
join Employees e2
on e1.Role = e2.Role
and e1.EmployeeID <> e2.EmployeeID

-- Using self join 2nd method
  select  e1.employeeId,e2.employeeId,e1.role
  from Employees e1 , employees e2
  where e1.EmployeeId<>e2.employeeId
  and e1.role = e2.role 
  order by e1.role

--45. Retrieve all payments made for couriers sent from the same location.  
-- join couriers +payments + location tables  
--here first sender address is of text type so we cant compare or equal it so casting the type
SELECT p.paymentId,p.CourierId,
p.LocationId,p.Amount
FROM Payments p
join Couriers c1 ON p.CourierID = c1.CourierID
join Couriers c2 ON cast(c1.SenderAddress as varchar(400)) =cast( c2.SenderAddress as varchar(400))
  AND c1.CourierID <> c2.CourierID

--46. Retrieve all couriers sent from the same location (based on SenderAddress).  we cannot compare or sort the datatype text****
SELECT c1.courierId,c2.CourierId,c1.senderAddress
FROM Couriers c1
JOIN Couriers c2 
  ON CAST(c1.SenderAddress AS VARCHAR(400)) = CAST(c2.SenderAddress AS VARCHAR(400))
  AND c1.CourierID <> c2.CourierID

--47. List employees and the number of couriers they have delivered: 
select Handledby,count(CourierId) as numberofcouriers
from Couriers
where status='delivered'
group by HandledBy

--48. Find couriers that were paid an amount greater than the cost of their respective courier services 
select c.CourierID, c.TrackingNumber, p.Amount AS PaidAmount, cs.Cost AS ServiceCost
from Couriers c
join Payments p ON c.CourierID = p.CourierID
join CourierServices cs ON c.ServiceID = cs.ServiceID
Where p.Amount > cs.Cost

--49. Find couriers that have a weight greater than the average weight of all couriers  
select CourierId
from Couriers
where Weight > (
    select AVG(Weight)
    from Couriers)


--50. Find the names of all employees who have a salary greater than the average salary:  
select EmployeeId
from Employees
where salary >(select avg(salary)
from Employees)

--51. Find the total cost of all courier services where the cost is less than the maximum cost  
select sum(Cost) as TotalCost
from CourierServices
where Cost < (
    select max(Cost)
    from CourierServices
)
--52. Find all couriers that have been paid for  
select c.CourierId 
from Couriers c
join Payments  p ON c.CourierID = p.CourierID

--53. Find the locations where the maximum payment amount was made  
select locationId
from Payments
where Amount =(select max(Amount) 
from Payments)

--54. Find all couriers whose weight is greater than the weight of all couriers sent by a specific sender (e.g., 'SenderName'):
select CourierId
from Couriers
where Weight >All (    ---here without all operator also it works
    select sum(Weight)
    from Couriers
    where SenderName = 'Sneha K')
    

   

