CREATE TABLE CreditCard (
    id SERIAL PRIMARY KEY,
    pan VARCHAR(32) NOT NULL,
    expiry_month INT NOT NULL,
    expiry_year INT NOT NULL
);
