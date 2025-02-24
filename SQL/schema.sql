CREATE TABLE projects (
    id SERIAL PRIMARY KEY,
    title TEXT NOT NULL,
    language TEXT NOT NULL,
    description TEXT NOT NULL,
    date_created TIMESTAMP NOT NULL,
    status TEXT,
    github_link VARCHAR(255)
);

CREATE TABLE posts (
    id SERIAL PRIMARY KEY,
    title TEXT NOT NULL,
    blurb TEXT NULL,
    content TEXT NOT NULL,
    date_created TIMESTAMP NOT NULL DEFAULT NOW(),
    date_modified TIMESTAMP NULL DEFAULT NOW(),
    slug VARCHAR(255) UNIQUE NOT NULL,
    like_count INT NOT NULL DEFAULT 0,
    dislike_count INT NOT NULL DEFAULT 0,
    status TEXT NULL,
    parent_project_id INT NOT NULL REFERENCES projects (id) ON DELETE CASCADE
);

CREATE TABLE tags (
    id SERIAL PRIMARY KEY,
    tag VARCHAR(25) NOT NULL,
    parent_project_id INT NOT NULL REFERENCES projects (id) ON DELETE CASCADE
);
