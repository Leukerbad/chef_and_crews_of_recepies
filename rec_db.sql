USE master;
GO

IF DB_ID(N'food') IS NULL
	CREATE DATABASE food;
GO

USE food;
GO 

IF OBJECT_ID('x_chef_crew') IS NOT NULL
	DROP TABLE x_chef_crew;
GO

IF OBJECT_ID('x_recipe_crew') IS NOT NULL
	DROP TABLE x_recipe_crew;
GO

IF OBJECT_ID('x_chef_recipe') IS NOT NULL
	DROP TABLE x_chef_recipe;
GO

IF OBJECT_ID('x_recipe_ingrediant') IS NOT NULL
	DROP TABLE x_recipe_ingrediant;
GO

IF OBJECT_ID('x_chef_ingrediant') IS NOT NULL
	DROP TABLE x_chef_ingrediant;
GO

IF OBJECT_ID('chef') IS NOT NULL
	DROP TABLE chef;
GO

IF OBJECT_ID('crew') IS NOT NULL
	DROP TABLE crew;
GO

IF OBJECT_ID('recipe') IS NOT NULL
	DROP TABLE recipe;
GO

IF OBJECT_ID('ingrediant') IS NOT NULL
	DROP TABLE ingrediant;
GO

CREATE TABLE chef (
	id_chef INT IDENTITY PRIMARY KEY, 
	name_chef nvarchar(50),
	email_chef nvarchar(50),
	password_chef nvarchar(50)
);

CREATE TABLE crew (
	id_crew INT IDENTITY PRIMARY KEY, 
	name_crew nvarchar(50)
);

CREATE TABLE recipe (
	id_recipe INT IDENTITY PRIMARY KEY, 
	name_recipe nvarchar(50),
	image_recipe varbinary(8000)
);

CREATE TABLE ingrediant (
	id_ingrediant INT IDENTITY PRIMARY KEY, 
	name_ingrediant nvarchar(50)
);

CREATE TABLE x_chef_crew (
  id_chef INT, 
  id_crew INT,
  CONSTRAINT pk_chef_crew PRIMARY KEY (id_chef,id_crew) ,
  constraint fk_chef_crew_chef 
  foreign key (id_chef)
  references chef (id_chef)
  on delete no action,
  constraint fk_chef_crew_crew 
  foreign key (id_crew)
  references crew (id_crew)
  on delete no action
);

CREATE TABLE x_recipe_crew (
  id_recipe INT, 
  id_crew INT,
  state_of_recipe nvarchar(10),
  CONSTRAINT pk_recipe_crew PRIMARY KEY (id_recipe,id_crew),
  constraint fk_recipe_crew_recipe
  foreign key (id_recipe)
  references recipe (id_recipe)
  on delete no action,
  constraint fk_recipe_crew_crew 
  foreign key (id_crew)
  references crew (id_crew)
  on delete no action
);

CREATE TABLE x_chef_recipe (
  id_chef INT,
  id_recipe INT, 
  CONSTRAINT pk_chef_recipe PRIMARY KEY (id_chef,id_recipe),
  constraint fk_chef_recipe_chef
  foreign key (id_chef)
  references chef (id_chef)
  on delete no action,
  constraint fk_chef_recipe_recipe 
  foreign key (id_recipe)
  references recipe (id_recipe)
  on delete no action
);

CREATE TABLE x_recipe_ingrediant (
  id_recipe INT,
  id_ingrediant INT, 
  quantity int,
  CONSTRAINT pk_recipe_ingrediant PRIMARY KEY (id_recipe,id_ingrediant),
  constraint fk_recipe_ingrediant_recipe
  foreign key (id_recipe)
  references recipe (id_recipe)
  on delete no action,
  constraint fk_recipe_ingrediant_ingrediant 
  foreign key (id_ingrediant)
  references ingrediant (id_ingrediant)
  on delete no action
);

CREATE TABLE x_chef_ingrediant (
  id_chef INT,
  id_ingrediant INT, 
  CONSTRAINT pk_chef_ingrediant PRIMARY KEY (id_chef,id_ingrediant),
  constraint fk_chef_ingrediant_chef
  foreign key (id_chef)
  references chef (id_chef)
  on delete no action,
  constraint fk_chef_ingrediant_ingrediant 
  foreign key (id_ingrediant)
  references ingrediant (id_ingrediant)
  on delete no action
);