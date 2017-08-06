CREATE TABLE ROLES (
    Id_Role serial PRIMARY KEY,
    Role varchar (50) NOT NULL
    );

CREATE TABLE USERS (
    ID_USER serial PRIMARY KEY,
    Name varchar (30) NOT NULL,
    Surname varchar (50) NOT NULL,
    Login varchar (50) UNIQUE NOT NULL,
    Pass varchar (100) NOT NULL,
    Id_Role int NOT NULL,
    CONSTRAINT user_id_role_fk FOREIGN KEY (id_role)
    	REFERENCES ROLES (id_role) match simple
    	ON UPDATE NO ACTION ON DELETE NO ACTION
);


CREATE TABLE USERS (
    ID_USER serial PRIMARY KEY,
    Name varchar (30) NOT NULL,
    Surname varchar (50) NOT NULL,
    Login varchar (50) UNIQUE NOT NULL,
    Pass varchar (100) NOT NULL,
    Id_Role int NOT NULL,
    CONSTRAINT user_id_role_fk FOREIGN KEY (id_role)
    	REFERENCES ROLES (id_role) match simple
    	ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE PROJECTS_USERS (
    ID_USER int,
    ID_PROJECT int,
    PRIMARY KEY (ID_USER , ID_PROJECT),
    CONSTRAINT id_user_fk FOREIGN KEY (id_user)
    	REFERENCES USERS (id_user) match simple
    	ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT id_project_fk FOREIGN KEY (id_project)
    	REFERENCES PROJECTS (id_project) match simple
    	ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE ROLES (
    Id_Role serial PRIMARY KEY,
    Role varchar (50) NOT NULL
    );

CREATE TABLE USER_ACTIONS (
    ID_ACTION serial PRIMARY KEY,
    ID_USER int NOT NULL,
    ID_PROJECT INT NOT NULL,
    ID_ACTION_TYPE int NOT NULL,
    ACTION_DATE TIMESTAMP NOT NULL DEFAULT current_timestamp,
    INFO varchar (100),
    CONSTRAINT user_action_id_user_fk FOREIGN KEY (id_user)
    	REFERENCES users (id_user) match simple
    	ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT user_action_id_project_fk FOREIGN KEY (id_project)
    	REFERENCES projects (id_project) match simple
    	ON UPDATE NO ACTION ON DELETE NO ACTION,
    CONSTRAINT user_action_id_action_type_fk FOREIGN KEY (id_action_type)
    	REFERENCES Action_types (id_action_type) match simple
    	ON UPDATE NO ACTION ON DELETE NO ACTION    
);


