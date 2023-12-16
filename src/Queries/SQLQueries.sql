-- Create Database
CREATE DATABASE CustomerFeedbackSystemDB;
USE CustomerFeedbackSystemDB;

-- Drop Table
DROP TABLE Feedbacks
-- Create Feedback Table
CREATE TABLE Feedbacks (
    FeedbackId INT  IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    ProductId INT,
    Rating INT,
    Comment NVARCHAR(1000),
    Timestamp DATETIME
);

-- Seed Feedback
INSERT INTO Feedbacks (UserId, ProductId, Rating, Comment, Timestamp) VALUES
(1, 1, 4, 'Great product!', '2023-01-01 12:00:00'),
(2, 1, 5, 'Excellent service!', '2023-01-02 14:30:00'),
(3, 2, 3, 'Could be improved', '2023-01-03 10:45:00'),
(1, 2, 4, 'Satisfied with the purchase', '2023-01-05 08:15:00'),
(2, 3, 2, 'Not happy with the delivery', '2023-01-07 16:20:00'),
(3, 1, 5, 'Fantastic experience!', '2023-01-09 11:30:00'),
(1, 3, 3, 'Average product', '2023-01-11 13:45:00'),
(2, 2, 4, 'Quick response from customer support', '2023-01-13 09:00:00'),
(3, 1, 2, 'Disappointed with the quality', '2023-01-15 17:00:00'),
( 1, 2, 5, 'Highly recommended!', '2023-01-17 14:10:00');


-- Get Feedbacks
SELECT * FROM Feedbacks;

-- Rename Table
EXEC sp_rename 'Feedback', 'Feedbacks';

sp_help Feedbacks

ALTER TABLE Feedbacks
ALTER COLUMN FeedbackId INT IDENTITY(1,1);