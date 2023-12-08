DECLARE @book_id UNIQUEIDENTIFIER;
DECLARE @metadata_id UNIQUEIDENTIFIER;
DECLARE @counter INT; 
SET @counter = 0;

-- BOOK 1 --
SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 1, 'The Millionaire Mind', 'A motivational business-minded book.', 'Thomas J. Stanley', 'Copyright 2023', '../../../resources/assets/defaults/books/The Millionaires Mind.jpg', 'Open Road Integrated Media', '2010-12-03', '2023-06-16', '9780795314834', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

SET @counter = 0;
WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 10.99);
    SET @counter = @counter + 1;
END

-- BOOK 2 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 2, 'The Hobbit', 'A fantasy tale in which a hobbit sets out to regain a stolen treasure called the rings.', 'J.R.R. Tolkien', 'Copyright 2002', '../../../resources/assets/defaults/books/The Hobbit.jpg', 'HMH Books for Young Readers', '2002-02-28', '2023-06-16', '9780618260300', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 6.00);
    SET @counter = @counter + 1;
END

-- BOOK 3 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 3, 'The Lord of the Rings', 'One Ring to rule them all, One Ring to find them, One Ring to bring them all and in the darkness bind them', 'J.R.R. Tolkien', 'Copyright 2005', '../../../resources/assets/defaults/books/The Lord of the Rings.jpg', 'Mariner Books', '2005-06-25', '2023-06-16', '9780618640157', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 11.00);
    SET @counter = @counter + 1;
END

-- BOOK 4 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 4, 'The Call of Cthulhu and Other Weird Stories', 'The most merciful thing in the world, I think, is the inability of the human mind to correlate all its contents.', 'H. P. Lovecraft', 'Copyright 1999', '../../../resources/assets/defaults/books/The Call of Cthulhu and Other Weird Stories.jpg', 'Penguin Classics', '1999-03-09', '2023-06-16', '9780141182346', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 10.00);
    SET @counter = @counter + 1;
END

-- BOOK 5 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 5, 'The Adventures of Sherlock Holmes', 'Matching of the wits of a clever man against the dumb resistance of the secrecy of inanimate things, which results in the triumph of human intelligence.', 'Arthur Conan Doyle', 'Copyright 1998', '../../../resources/assets/defaults/books/The Adventures of Sherlock Holmes.jpg', 'Oxford University Press', '1998-10-22', '2023-06-16', '9780192835086', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 12.00);
    SET @counter = @counter + 1;
END

-- BOOK 6 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 6, 'The Chronicles of Narnia', 'A series of fantasy novels set in the magical land of Narnia.', 'C.S. Lewis', 'Copyright 2002', '../../../resources/assets/defaults/books/The Chronicles of Narnia.jpg', 'HarperCollins', '2002-10-01', '2023-06-16', '9780064471190', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 11.00);
    SET @counter = @counter + 1;
END

-- BOOK 7 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 7, 'The Count of Monte Cristo', 'An adventure novel about a man seeking revenge against those who wronged him.', 'Alexandre Dumas', 'Copyright 2003', '../../../resources/assets/defaults/books/The Count of Monte Cristo.jpg', 'Penguin Classics', '2003-08-28', '2023-06-16', '9780140449266', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 15.00);
    SET @counter = @counter + 1;
END

-- BOOK 8 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 8, 'The Mysterious Island', 'The book tells the adventures of five American prisoners of war on an uncharted island in the South Pacific.', 'Jules Verne', 'Copyright 2004', '../../../resources/assets/defaults/books/The Mysterious Island.jpg', 'Modern Library', '2004-08-28', '2023-06-16', '9780812972122', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 13.00);
    SET @counter = @counter + 1;
END

-- BOOK 9 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 9, 'The Strange Case of Dr. Jekyll and Mr. Hyde', 'The gripping novel of a London lawyer who investigates strange occurrences surrounding his old friend, Dr. Henry Jekyll, and the misanthropic Mr. Edward Hyde.', 'Robert Louis Stevenson', 'Copyright 2004', '../../../resources/assets/defaults/books/The Strange Case of Dr. Jekyll and Mr. Hyde.jpg', 'Modern Library', '2004-08-28', '2023-06-16', '9780812972122', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 8.00);
    SET @counter = @counter + 1;
END

-- BOOK 10 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 10, 'The Story of My Life', 'This is the autobiography written by the amazing deafblind woman Helen Keller at the early age of 22.', 'Helen Keller', 'Copyright 2001', '../../../resources/assets/defaults/books/The Story of My Life.jpg', 'Penguin Classics', '2001-05-01', '2023-06-16', '9780140439151', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 5.00);
    SET @counter = @counter + 1;
END

-- BOOK 11 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 11, 'The Adventures of Huckleberry Finn', 'The drifting journey of Huck and his friend Jim, a runaway slave, down the Mississippi River on their raft may be one of the most enduring images of escape and freedom in all of American literature.', 'Mark Twain', 'Copyright 2002', '../../../resources/assets/defaults/books/The Adventures of Huckleberry Finn.jpg', 'Penguin Classics', '2002-12-31', '2023-06-16', '9780140439151', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 12.00);
    SET @counter = @counter + 1;
END

-- BOOK 12 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 12, 'Frankenstein', 'A Gothic novel about a scientist who creates a monster.', 'Mary Shelley', 'Copyright 1818', '../../../resources/assets/defaults/books/Frankenstein.jpg', 'Dover Publications', '1818-01-01', '2023-06-16', '9780486282114', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 14.00);
    SET @counter = @counter + 1;
END

-- BOOK 13 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 13, 'Hunger Games', 'A dystopian novel about a young girl fighting for survival in a televised competition.', 'Suzanne Collins', 'Copyright 2008', '../../../resources/assets/defaults/books/Hunger Games.jpg', 'Scholastic Press', '2008-09-14', '2023-06-16', '9780439023481', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 14.00);
    SET @counter = @counter + 1;
END

-- BOOK 14 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 14, 'The Book Thief', 'A story about a girl who steals books during World War II.', 'Markus Zusak', 'Copyright 2007', '../../../resources/assets/defaults/books/The Book Thief.jpg', 'Knopf Books for Young Readers', '2007-03-14', '2023-06-16', '9780375842207', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 11.00);
    SET @counter = @counter + 1;
END

-- BOOK 15 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 15, 'The Da Vinci Code', 'A thriller involving a symbologist and a conspiracy involving the Holy Grail.', 'Dan Brown', 'Copyright 2018', '../../../resources/assets/defaults/books/The Da Vinci Code.jpg', 'Corgi', '2018-04-01', '2023-06-16', '9780307474278', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 9.99);
    SET @counter = @counter + 1;
END

-- BOOK 16 --
SET @counter = 0;

SET @book_id = NEWID();
SET @metadata_id = NEWID();
INSERT INTO book_metadata (metadata_id, genre_id, title, sypnosis, author, copyright, cover, publisher, publication_date, added_on, isbn, edition_str, edition_num) VALUES (@metadata_id, 16, 'The Odyssey', 'An epic poem about the hero Odysseus and his journey home.', 'Homer', 'Copyright 2008', '../../../resources/assets/defaults/books/The Odyssey.jpg', 'Oxford University Press', '2008-09-10', '2023-06-16', '9780199536788', 'First Edition', 1);
INSERT INTO books (metadata_id, book_id) VALUES (@metadata_id, @book_id);

WHILE @counter < CAST(RAND() * 6 AS INT)
BEGIN
    INSERT INTO copies (book_id, source_id, status_id, price) VALUES (@book_id, 1, 1, 10.00);
    SET @counter = @counter + 1;
END