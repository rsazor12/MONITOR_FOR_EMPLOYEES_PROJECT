-- ROLES TABLE

INSERT INTO roles (role)
    VALUES ('Admin');
    
INSERT INTO roles (role)
    VALUES ('User');



-- ACTION_TYPES 

INSERT INTO action_types (name)
    VALUES ('StartWorking');
    
INSERT INTO action_types (name)
    VALUES ('EndWorking');
    
INSERT INTO action_types (name)
    VALUES ('LeftMouseClick');
    
INSERT INTO action_types (name)
    VALUES ('RightMouseClick');
    
INSERT INTO action_types (name)
    VALUES ('KeyboardPressed');
    
INSERT INTO action_types (name)
    VALUES ('LineAdded');
    
INSERT INTO action_types (name)
    VALUES ('LineRemoved');
    
INSERT INTO action_types (name)
    VALUES ('LineCalculating');

INSERT INTO action_types (name)
    VALUES ('Other');
	
INSERT INTO action_types (name)
    VALUES ('Scroll');


-- USERS

INSERT INTO users (name, surname, login, pass, id_role)
    VALUES ('Daria','Czajkowska','dar.czaj','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601', 1);

INSERT INTO users (name, surname, login, pass, id_role)
    VALUES ('Agata','Czerwi�ska','cze-aga','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601', 2);

INSERT INTO users (name, surname, login, pass, id_role)
    VALUES ('�ukasz','G�rski','GoLucas','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601', 2);

INSERT INTO users (name, surname, login, pass, id_role)
    VALUES ('Kamil','Bielski','rsazor12','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601', 2);

INSERT INTO users (name, surname, login, pass, id_role)
    VALUES ('Anna','Nowak','nowaq','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601', 1);

INSERT INTO users (name, surname, login, pass, id_role)
    VALUES ('Jan','Kowalski','kowal','008c70392e3abfbd0fa47bbc2ed96aa99bd49e159727fcba0f2e6abeb3a9d601', 1);
    


-- PROJECTS


INSERT INTO projects (name, id_supervisor, info)
    VALUES ('Zarz�dzanie w informatyce', 1, 'Projekt na zaj�cia.');


INSERT INTO projects (name, id_supervisor, info)
    VALUES ('Zarz�dzanie w informatyce', 1, 'Projekt na zaj�cia.');

INSERT INTO projects (name, id_supervisor, info)
    VALUES ('Alior Bank Service', 1, 'Aplikacja do zarz�dzania us�ugami bankowymi dla Alior Banku');

INSERT INTO projects (name, id_supervisor, info)
    VALUES ('Medica', 1, 'Serwis dla pacjent�w przychodni Medica');

INSERT INTO projects (name, id_supervisor, info)
    VALUES ('Smart Parking', 4, 'Program do odnajdywania miejsc parkingowych');

INSERT INTO projects (name, id_supervisor, info)
    VALUES ('Omada', 4, '');

INSERT INTO projects (name, id_supervisor, info)
    VALUES ('Universal Studio', 4, '');

-- PROJECTS_USERS

INSERT INTO projects_users (id_user, id_project)
    VALUES ('1','1');


INSERT INTO projects_users (id_user, id_project)
    VALUES ('4','7');

