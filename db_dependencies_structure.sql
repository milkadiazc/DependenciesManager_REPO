create table configuration_items (
name_ci varchar(30) primary key,
description_ci varchar(50),
version_ci varchar(25)

);


create table dependencies_ci (
id_dependency int primary key,
name_ci_father varchar(30),
name_ci_child varchar(30),
constraint fk_ci_father_config_item foreign key (name_ci_father) references configuration_items(name_ci),
constraint fk_ci_child_config_item foreign key (name_ci_child) references configuration_items(name_ci)

);
