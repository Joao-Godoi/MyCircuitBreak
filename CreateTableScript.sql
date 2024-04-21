CREATE TABLE timeout_history (
     id INT AUTO_INCREMENT PRIMARY KEY,
     response_time INT NOT NULL,
     num_a DOUBLE NOT NULL,
     num_b DOUBLE NOT NULL,
     operation_type CHAR(255) NOT NULL
);