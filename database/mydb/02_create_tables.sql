CREATE TABLE CreditCard (
    id SERIAL PRIMARY KEY,
    pan VARCHAR(32) NOT NULL,
    expiry_month INT NOT NULL,
    expiry_year INT NOT NULL
);

CREATE TABLE History (
    id SERIAL PRIMARY KEY,
    location VARCHAR(256) NOT NULL,
    date timestamp NOT NULL,
    amount NUMERIC(14,2) NOT NULL
);