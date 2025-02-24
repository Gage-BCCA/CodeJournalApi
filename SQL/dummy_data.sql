INSERT INTO projects (title, language, description, date_created, status, github_link)
VALUES 
    ('Project A', 'JavaScript', 'This is a sample JavaScript project focused on web development. It includes a variety of features and optimizations.', '2025-02-23 12:00:00', 'active', 'https://github.com/example/projectA'),
    ('Project B', 'Python', 'A Python project aimed at data analysis with various libraries like Pandas and Matplotlib.', '2025-02-22 12:00:00', 'inactive', 'https://github.com/example/projectB'),
    ('Project C', 'Java', 'A Java-based application that solves algorithmic problems efficiently.', '2025-02-21 12:00:00', 'active', 'https://github.com/example/projectC'),
    ('Project D', 'C++', 'C++ project focused on building optimized software for embedded systems.', '2025-02-20 12:00:00', 'active', 'https://github.com/example/projectD');

INSERT INTO posts (title, blurb, content, date_created, date_modified, slug, like_count, dislike_count, status, parent_project_id)
VALUES
    ('Introduction to Web Development', 'A comprehensive guide to getting started with web development using JavaScript.', '# Introduction\nIn the modern era of technology, web development has become one of the most exciting and essential fields. Whether you are a beginner or an experienced developer, understanding the fundamentals of web development is crucial. JavaScript is one of the key languages used to create dynamic and interactive websites.\n\n## Key Concepts\nWeb development consists of three main layers: HTML, CSS, and JavaScript. HTML structures the web page, CSS styles it, and JavaScript adds interactivity. The combination of these languages allows you to build sophisticated websites that users can interact with in real time.\n\n## Getting Started\nTo start, you should install a code editor like VS Code, which is widely used by developers. Once you have your editor set up, you can begin by creating simple HTML documents that include both JavaScript and CSS. The possibilities are endless!\n\n## Conclusion\nWeb development is a rewarding career choice with numerous job opportunities. If you are new to programming, learning JavaScript is a great way to begin your journey.', '2025-02-23 12:00:00', '2025-02-23 12:30:00', 'intro-to-web-development', 50, 3, 'active', 1),
    ('Efficient Algorithms in Java', 'An exploration of algorithmic techniques in Java to solve complex computational problems efficiently.', '# Introduction\nIn the field of computer science, algorithms are the backbone of almost every application. From sorting and searching to complex problems like pathfinding and dynamic programming, understanding algorithms is essential. Java is a great language to implement algorithms due to its efficiency and scalability.\n\n## Common Algorithms\nSome of the most common algorithms include sorting algorithms like QuickSort and MergeSort, and searching algorithms like Binary Search. These algorithms help in processing large datasets efficiently.\n\n## Conclusion\nMastering algorithms is key to becoming a proficient developer. Java, with its rich set of libraries and performance optimizations, is an excellent language for this purpose.', '2025-02-21 12:00:00', '2025-02-21 13:00:00', 'efficient-algorithms-java', 60, 2, 'active', 3),
    ('Optimizing Embedded Systems in C++', 'A deep dive into optimizing embedded systems using C++ and hardware-specific programming.', '# Introduction\nEmbedded systems are specialized computing systems that do not look like traditional computers. They are found in devices like smartphones, cars, medical equipment, and much more. C++ is often used in embedded systems development because it offers fine-grained control over hardware resources.\n\n## Optimization Techniques\nOne key aspect of embedded systems development is optimization. This involves writing code that makes the most efficient use of limited resources, such as memory and processing power. In C++, you can optimize your code by using techniques like direct memory access, bitwise operations, and writing low-level code.\n\n## Conclusion\nEmbedded systems are crucial to modern technology, and learning how to optimize them in C++ is a highly valuable skill. With experience, you can develop systems that are both powerful and efficient.', '2025-02-20 12:00:00', '2025-02-20 13:00:00', 'optimizing-embedded-systems-cpp', 70, 1, 'active', 4);


INSERT INTO tags (tag, parent_project_id)
VALUES 
    ('Web Development', 1),
    ('JavaScript', 1),
    ('Algorithms', 3),
    ('Java', 3),
    ('Embedded Systems', 4),
    ('C++', 4);
