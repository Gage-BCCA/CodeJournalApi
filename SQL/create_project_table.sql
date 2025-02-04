CREATE TABLE Projects (
    ProjectId INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Language VARCHAR(100) NOT NULL,
    Description TEXT NOT NULL,
    DateCreated DATETIME NOT NULL,
    Status VARCHAR(50),
    GithubLink VARCHAR(255)
);
