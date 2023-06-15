CREATE TABLE members (
	member_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	first_name VARCHAR(30) NOT NULL,
	last_name VARCHAR(30) NOT NULL,
	address VARCHAR(200) NOT NULL,
	phone VARCHAR(13) NOT NULL,
	email VARCHAR(100) NULL
)

CREATE TABLE roles (
	role_id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(20) NOT NULL,
	has_access BIT NOT NULL
)

CREATE TABLE users (
	user_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	role_id INT,
	member_id UNIQUEIDENTIFIER,
	username VARCHAR(20) NOT NULL,
    password_hash VARCHAR(500) NOT NULL,
	profile_picture VARCHAR(500) NOT NULL,
	FOREIGN KEY (role_id) REFERENCES roles(role_id) ON DELETE CASCADE,
	FOREIGN KEY (member_id) REFERENCES members(member_id) ON DELETE CASCADE
)

CREATE TABLE announcements (
	announcement_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	user_id UNIQUEIDENTIFIER,
	announcement_header VARCHAR(1000) NOT NULL,
	announcement_body NVARCHAR(MAX) NOT NULL,
	announcement_due DATETIME2 NOT NULL,
	announcement_timestamp DATETIME2 NOT NULL,
	is_priority BIT NOT NULL,
	announcement_cover VARCHAR(1000) NULL,
	FOREIGN KEY (user_id) REFERENCES users(user_id),
);

CREATE TABLE announcement_roles (
    announcement_id UNIQUEIDENTIFIER,
    role_id INT,
    PRIMARY KEY (announcement_id, role_id),
    FOREIGN KEY (announcement_id) REFERENCES announcements(announcement_id) ON DELETE CASCADE,
    FOREIGN KEY (role_id) REFERENCES roles(role_id) ON DELETE CASCADE
);

CREATE TABLE statuses (
	status_id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(20) NOT NULL,
	description VARCHAR(200) NOT NULL,
	is_available BIT NOT NULL
)

CREATE TABLE genres (
	genre_id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(50) NOT NULL,
	description VARCHAR(500) NOT NULL
)

CREATE TABLE books (
	book_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	genre_id INT,
	title VARCHAR(100) NOT NULL,
	sypnosis VARCHAR(1500) NOT NULL,
	author VARCHAR(40) NOT NULL,
	cover VARCHAR(500) NOT NULL,
	publisher VARCHAR(40) NOT NULL,
	publication_date DATETIME2 NOT NULL,
	isbn VARCHAR(100) NOT NULL,
	FOREIGN KEY (genre_id) REFERENCES genres(genre_id),
)

CREATE TABLE copies (
	copy_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	book_id UNIQUEIDENTIFIER,
	status_id INT,
	FOREIGN KEY (book_id) REFERENCES books(book_id) ON DELETE CASCADE,
	FOREIGN KEY (status_id) REFERENCES statuses(status_id) ON DELETE CASCADE
)

CREATE TABLE loans (
	loan_id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	user_id UNIQUEIDENTIFIER,
	copy_id UNIQUEIDENTIFIER,
	date_borrowed DATETIME2 NOT NULL,
	due_date DATETIME2 NOT NULL,
	is_returned BIT NOT NULL,
	timestamp DATETIME2 NOT NULL,
	FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
	FOREIGN KEY (copy_id) REFERENCES copies(copy_id) ON DELETE CASCADE,
)

/* INSERTS DATA */

INSERT INTO roles (name, has_access) VALUES 
('ADMINISTRATOR', 1),
('USER', 0),
('LIBRARIAN', 1);

INSERT INTO statuses (name, description, is_available) VALUES 
('AVAILABLE', 'The book is currently available', 1),
('NOT AVAILABLE', 'The book is not available', 0),
('ON HOLD', 'The book is currently on hold', 0);

INSERT INTO genres (name, description) VALUES 
('Romance', 'Love stories exploring themes of attraction and intimacy.'),
('Fantasy', 'Transport readers to magical worlds filled with mythical creatures and supernatural powers.'),
('Paranormal', 'Books featuring ghosts, vampires, werewolves, and other paranormal elements.'),
('Horror', 'Scary stories designed to frighten readers with supernatural or psychological elements.'),
('Historical Fiction', 'Set in a specific period of history and often revolve around real-life events, people, or places.'),
('Fiction', 'Imaginative stories not based on true events or real people.'),
('Short Story', 'Collections of shorter works of fiction, often stand-alone pieces or part of a larger narrative.'),
('Spiritual', 'Explore themes of faith, religion, and spirituality from various perspectives.'),
('Classics', 'Timeless works of literature that have endured the test of time.'),
('Science Fiction', 'Set in the future or alternate realities and explore themes of technology and space exploration.'),
('Humor', 'Designed to make readers laugh through witty observations and silly situations.'),
('Mystery / Thriller', 'Designed to keep readers on the edge of their seats with suspenseful plots and surprise twists.'),
('Action / Adventure', 'Exciting stories filled with epic battles, daring escapes, and thrilling chases.'),
('Teen Fiction', 'Stories exploring themes of growing up, identity, and social issues.'),
('Poetry', 'Works of verse that use language in unique and creative ways.'),
('Non-Fiction', 'Factual writing exploring a specific topic or theme.');

/* DEFAULT ADMIN */

DECLARE @member_id UNIQUEIDENTIFIER; SET @member_id = NEWID();

INSERT INTO members (
	first_name,
	last_name,
	email,
	phone,
	address,
	member_id
) VALUES (
	'John',
	'Doe',
	'johndoe@mail.co.uk',
	'+639100813695',
	'211 Baker St.',
	@member_id
);

INSERT INTO users (username, password_hash, profile_picture, role_id, member_id) VALUES (
	'admin',
	'$argon2id$v=19$m=65536,t=3,p=1$3wKJEyw8CQjpQHN2DjH7qg$uRD8wwKE4DTmjFVgunfEcH+zbdJOzi7n1/03Le70lRo',
	'',
	1,
	@member_id
);