CREATE DATABASE ViewsIndexes;

USE ViewsIndexes;

CREATE TABLE brands (
brand_id INT PRIMARY KEY,
brand_name VARCHAR(50)
);

CREATE TABLE categories (
category_id INT PRIMARY KEY,
category_name VARCHAR(50)
);

CREATE TABLE products (
product_id INT PRIMARY KEY,
product_name VARCHAR(100),
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2),
FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
customer_id INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50)
);

CREATE TABLE stores (
store_id INT PRIMARY KEY,
store_name VARCHAR(100)
);

CREATE TABLE staffs (
staff_id INT PRIMARY KEY,
staff_name VARCHAR(100),
store_id INT,
FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE orders (
order_id INT PRIMARY KEY,
customer_id INT,
order_date DATE,
store_id INT,
staff_id INT,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
FOREIGN KEY (store_id) REFERENCES stores(store_id),
FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);

CREATE TABLE order_items (
item_id INT PRIMARY KEY,
order_id INT,
product_id INT,
quantity INT,
list_price DECIMAL(10,2),
FOREIGN KEY (order_id) REFERENCES orders(order_id),
FOREIGN KEY (product_id) REFERENCES products(product_id)
);

INSERT INTO brands VALUES
(1,'Trek'),
(2,'Giant'),
(3,'Specialized');

INSERT INTO categories VALUES
(1,'Mountain Bike'),
(2,'Road Bike'),
(3,'Electric Bike');

INSERT INTO products VALUES
(101,'X-Caliber 8',1,1,2023,1200),
(102,'Defy Advanced',2,2,2022,1800),
(103,'Turbo Vado',3,3,2024,3200);

INSERT INTO customers VALUES
(1,'Rahul','Sharma'),
(2,'Anita','Verma'),
(3,'David','John');

INSERT INTO stores VALUES
(1,'City Bike Store'),
(2,'Downtown Bikes');

INSERT INTO staffs VALUES
(1,'Arjun',1),
(2,'Meera',2);

INSERT INTO orders VALUES
(1001,1,'2025-02-01',1,1),
(1002,2,'2025-02-10',2,2);

INSERT INTO order_items VALUES
(1,1001,101,1,1200),
(2,1002,103,1,3200);


CREATE VIEW ViewForProducts AS
SELECT p.product_name,b.brand_name,c.category_name,p.model_year,p.list_price
FROM products p
JOIN brands b 
ON p.brand_id = b.brand_id
JOIN categories c 
ON p.category_id = c.category_id;

SELECT * FROM ViewForProducts;

CREATE VIEW ViewForOrders AS
SELECT c.first_name + ' ' + c.last_name AS customer_name, s.store_name,st.staff_name
FROM orders o
JOIN customers c 
ON o.customer_id = c.customer_id
JOIN stores s 
ON o.store_id = s.store_id
JOIN staffs st 
ON o.staff_id = st.staff_id;


SELECT * FROM ViewForOrders;

-- Index on products table foreign keys
CREATE INDEX idx_products_brand_id
ON products(brand_id);

CREATE INDEX idx_products_category_id
ON products(category_id);

-- Index on staffs table foreign key
CREATE INDEX idx_staffs_store_id
ON staffs(store_id);

-- Index on orders table foreign keys
CREATE INDEX idx_orders_customer_id
ON orders(customer_id);

CREATE INDEX idx_orders_store_id
ON orders(store_id);

CREATE INDEX idx_orders_staff_id
ON orders(staff_id);

-- Index on order_items table foreign keys
CREATE INDEX idx_order_items_order_id
ON order_items(order_id);

CREATE INDEX idx_order_items_product_id
ON order_items(product_id);

