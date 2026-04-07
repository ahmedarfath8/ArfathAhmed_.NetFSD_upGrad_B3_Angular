CREATE DATABASE triggerTransaction

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    stock_quantity INT,
    price DECIMAL(10,2)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATETIME
);

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    price DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TRIGGER trg_reduce_stock
ON order_items
AFTER INSERT
AS
BEGIN

    -- Check if stock is sufficient
    IF EXISTS (
        SELECT 1
        FROM products p
        JOIN inserted i
        ON p.product_id = i.product_id
        WHERE p.stock_quantity < i.quantity
    )
    BEGIN
        RAISERROR ('Insufficient stock for one or more products.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE p
    SET p.stock_quantity = p.stock_quantity - i.quantity
    FROM products p
    JOIN inserted i
    ON p.product_id = i.product_id;

END;

BEGIN TRANSACTION;

BEGIN TRY

-- Insert order
INSERT INTO orders(order_id, customer_id, order_date)
VALUES (101, 1, GETDATE());

-- Insert order items
INSERT INTO order_items(order_item_id, order_id, product_id, quantity, price)
VALUES
(1, 101, 1, 2, 50000),
(2, 101, 2, 1, 75000);

COMMIT TRANSACTION;

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Order failed due to insufficient stock';

END CATCH;