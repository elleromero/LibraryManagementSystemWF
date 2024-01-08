DECLARE @member_id UNIQUEIDENTIFIER;

SET @member_id = NEWID();

INSERT INTO members (
	first_name,
	last_name,
	school_no,
	email,
	phone,
	address,
	member_id,
	program_id
) VALUES (
	'Shello Luis',
	'Roxas',
	'100813695',
	'SheRoxas@gmail.com',
	'09113456780',
	'1049 Malhacan St.',
	@member_id,
	2
);

INSERT INTO users (username, password_hash, profile_picture, role_id, member_id) VALUES (
	'admin2',
	'$argon2id$v=19$m=65536,t=3,p=1$3wKJEyw8CQjpQHN2DjH7qg$uRD8wwKE4DTmjFVgunfEcH+zbdJOzi7n1/03Le70lRo',
	'../../../resources/assets/defaults/users/Admin.png',
	1,
	@member_id
);

SET @member_id = NEWID();

INSERT INTO members (
	first_name,
	last_name,
	school_no,
	email,
	phone,
	address,
	member_id,
	program_id
) VALUES (
	'Juan',
	'Dela Cruz',
	'10091',
	'juandc@mail.co.uk',
	'09123456789',
	'102 Melbourne St.',
	@member_id,
	2
);

INSERT INTO users (username, password_hash, profile_picture, role_id, member_id) VALUES (
	'librarian',
	'$argon2id$v=19$m=65536,t=3,p=1$3wKJEyw8CQjpQHN2DjH7qg$uRD8wwKE4DTmjFVgunfEcH+zbdJOzi7n1/03Le70lRo',
	'../../../resources/assets/defaults/users/librarian.png',
	3,
	@member_id
);

SET @member_id = NEWID();

INSERT INTO members (
	first_name,
	last_name,
	school_no,
	email,
	phone,
	address,
	member_id,
	program_id,
	course_year
) VALUES (
	'Jameson',
	'Teodore',
	'102901',
	'jTeodore@gmail.com',
	'09987654321',
	'1023 Santolan St.',
	@member_id,
	1,
	3
);

INSERT INTO users (username, password_hash, profile_picture, role_id, member_id) VALUES (
	'User1',
	'$argon2id$v=19$m=65536,t=3,p=1$3wKJEyw8CQjpQHN2DjH7qg$uRD8wwKE4DTmjFVgunfEcH+zbdJOzi7n1/03Le70lRo',
	'../../../resources/assets/defaults/users/user1.jpg',
	2,
	@member_id
);

SET @member_id = NEWID();

INSERT INTO members (
	first_name,
	last_name,
	school_no,
	email,
	phone,
	address,
	member_id,
	program_id,
	course_year
) VALUES (
	'Jamesmar',
	'Martin',
	'21612',
	'jmartin@gmail.com',
	'09192365102',
	'0018 Payatas St.',
	@member_id,
	1,
	3
);

INSERT INTO users (username, password_hash, profile_picture, role_id, member_id) VALUES (
	'User2',
	'$argon2id$v=19$m=65536,t=3,p=1$3wKJEyw8CQjpQHN2DjH7qg$uRD8wwKE4DTmjFVgunfEcH+zbdJOzi7n1/03Le70lRo',
	'../../../resources/assets/defaults/users/User3.jpeg',
	2,
	@member_id
);


SET @member_id = NEWID();

INSERT INTO members (
	first_name,
	last_name,
	school_no,
	email,
	phone,
	address,
	member_id,
	program_id,
	course_year
) VALUES (
	'Shello',
	'Roxas',
	'21613',
	'Sheshe@gmail.com',
	'09987654312',
	'1023 Santolan St.',
	@member_id,
	1,
	3
);

INSERT INTO users (username, password_hash, profile_picture, role_id, member_id) VALUES (
	'User3',
	'$argon2id$v=19$m=65536,t=3,p=1$3wKJEyw8CQjpQHN2DjH7qg$uRD8wwKE4DTmjFVgunfEcH+zbdJOzi7n1/03Le70lRo',
	'../../../resources/assets/defaults/users/Admin.png',
	2,
	@member_id
);

SET @member_id = NEWID();

INSERT INTO members (
	first_name,
	last_name,
	school_no,
	email,
	phone,
	address,
	member_id,
	program_id,
	course_year
) VALUES (
	'Eleazar',
	'Romero',
	'202902',
	'Elromero@gmail.com',
	'09987654322',
	'1023 Santolan St.',
	@member_id,
	1,
	3
);

INSERT INTO users (username, password_hash, profile_picture, role_id, member_id) VALUES (
	'User4',
	'$argon2id$v=19$m=65536,t=3,p=1$3wKJEyw8CQjpQHN2DjH7qg$uRD8wwKE4DTmjFVgunfEcH+zbdJOzi7n1/03Le70lRo',
	'../../../resources/assets/defaults/users/babboon.JPG',
	2,
	@member_id
);
