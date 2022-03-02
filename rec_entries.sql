use food;
go

insert into chef(name_chef, email_chef, password_chef)
	values	('Jule','test@mail.de','123456'),
			('Plo','test@mail.de','123456'),
			('Mace','test@mail.de','123456'),
			('Grogu','test@mail.de','123456')

insert into crew(name_crew)
	values	('Jedi-Master'),
			('Younglings'),
			('Humanoid')

insert into recipe (name_recipe)
	values	('Bulgur-Burger'),	('Ice'),
			('Cheese-Burger'),	('Kebab'),
			('Hanf-Burger'),	('Bolognese'),
			('Bulgur-Plate'),	('Pizza'),
			('Carrot-Bread'),	('Falaffel'),
			('Ratatouille'),	('Chilli'),
			('Soup'),			('Kakao-Cake'),
			('Lasagne'),		('Nutella-Crepe'),
			('Backed-Noodles')

insert into ingrediant (name_ingrediant)
	values	('a'), ('f'), ('k'), ('p'),
			('b'), ('g'), ('l'), ('q'),
			('c'), ('h'), ('m'), ('r'),
			('d'), ('i'), ('n'), ('s'),
			('e'), ('j'), ('o'), ('t')

insert into x_chef_crew(id_chef, id_crew)
	values	(2,1), (3,1),
			(1,2), (4,1),
			(1,3), (2,3), (3,3)

insert into x_recipe_ingrediant(id_recipe, id_ingrediant)
	values	(1,3), (1,4), (1,12), (1,18), (1,19),
			(2,1), (2,5), (2,15), (2,16), (2,19),
			(3,20), (3,4), (3,5), (3,18), (3,11),
			(4,3), (4,14), (4,12), (4,8), (4,16),
			(5,13), (5,4), (5,12), (5,18), (5,19),
			(6,6), (6,4), (6,12), (6,18), (6,19),
			(7,8), (7,6), (7,12), (7,18), (7,19),
			(8,8), (8,9), (8,12), (8,18), (8,19),
			(9,4), (9,14), (9,12), (9,18), (9,19),
			(10,3), (10,4), (10,12), (10,18), (10,19),
			(11,1), (11,6), (11,12), (11,18), (11,19),
			(12,2), (12,5), (12,12), (12,18), (12,19),
			(13,2), (13,1), (13,12), (13,18), (13,19),
			(14,6), (14,12), (14,17), (14,18), (14,19),
			(15,9), (15,17), (15,12), (15,18), (15,19),
			(16,10), (16,8), (16,12), (16,18), (16,19),
			(17,11), (17,5), (17,12), (17,18), (17,19)

			
