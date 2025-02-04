CREATE TABLE Posts (
    PostId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Blurb VARCHAR(500) NULL,
    Content TEXT NOT NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
    DateModified DATETIME NULL,
    Slug VARCHAR(255) UNIQUE NOT NULL,
    LikeCount INT NOT NULL DEFAULT 0,
    DislikeCount INT NOT NULL DEFAULT 0,
    Status VARCHAR(50) NULL,
    ParentProjectId INT NULL,
    FOREIGN KEY (ParentProjectId) REFERENCES Projects(ProjectId)
);
