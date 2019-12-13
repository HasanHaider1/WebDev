CREATE TABLE School (
  idSchool INTEGER   NOT NULL IDENTITY(1,1) ,
  nameSchool VARCHAR(255)    ,
  contactPersonName VARCHAR(255)    ,
  contactPersonNumber BIGINT      ,
PRIMARY KEY(idSchool));




CREATE TABLE StudentPersonal (
  idStudent INTEGER   NOT NULL IDENTTY(1,1) ,
  School_idSchool INTEGER   NOT NULL ,
  name VARCHAR(255)    ,
  class INTEGER    ,
  age INTEGER    ,
  contact BIGINT    ,
  prevSchool VARCHAR(255)    ,
  currentlyStudying BOOL    ,
  nextSchool VARCHAR(255)      ,
PRIMARY KEY(idStudent)  ,
  FOREIGN KEY(School_idSchool)
    REFERENCES School(idSchool));


CREATE INDEX StudentPersonal_FKIndex1 ON StudentPersonal (School_idSchool);


CREATE INDEX IFK_Rel_05 ON StudentPersonal (School_idSchool);


CREATE TABLE StudentSchool (
  StudentPersonal_idStudent INTEGER   NOT NULL ,
  month_2 VARCHAR(255)    ,
  reading decoding INTEGER    ,
  reading comprehension INTEGER    ,
  reading rate/fluency INTEGER    ,
  spelling accuracy INTEGER    ,
  mathematics computation INTEGER    ,
  mathematics concepts INTEGER    ,
  handwriting INTEGER    ,
  writing rate INTEGER    ,
  punctuation/grammer INTEGER    ,
  ability to express thoughts through writing INTEGER    ,
  gross motor skills INTEGER    ,
  fine motor skills INTEGER      ,
PRIMARY KEY(StudentPersonal_idStudent)  ,
  FOREIGN KEY(StudentPersonal_idStudent)
    REFERENCES StudentPersonal(idStudent));


CREATE INDEX Table_04_FKIndex1 ON StudentSchool (StudentPersonal_idStudent);


CREATE INDEX IFK_Rel_02 ON StudentSchool (StudentPersonal_idStudent);


CREATE TABLE StudentClassroom (
  StudentPersonal_idStudent INTEGER   NOT NULL ,
  month_2 VARCHAR(255)    ,
  understanding verbal instruction INTEGER    ,
  classroom assignment completion INTEGER    ,
  organizational skills INTEGER    ,
  getting hw to and from school INTEGER    ,
  hw completion INTEGER    ,
  relationship with peers INTEGER    ,
  following directions INTEGER    ,
  disrupting class INTEGER    ,
  verbal participation in class INTEGER      ,
PRIMARY KEY(StudentPersonal_idStudent)  ,
  FOREIGN KEY(StudentPersonal_idStudent)
    REFERENCES StudentPersonal(idStudent));


CREATE INDEX StudentClassroom_FKIndex1 ON StudentClassroom (StudentPersonal_idStudent);


CREATE INDEX IFK_Rel_01 ON StudentClassroom (StudentPersonal_idStudent);


CREATE TABLE Teacher (
  idTeacher INTEGER   NOT NULL IDENTITY(1,1) ,
  School_idSchool INTEGER   NOT NULL ,
  name INTEGER    ,
  subject VARCHAR(255)    ,
  contact BIGINT    ,
  salary BIGINT      ,
PRIMARY KEY(idTeacher)  ,
  FOREIGN KEY(School_idSchool)
    REFERENCES School(idSchool));


CREATE INDEX Teacher_FKIndex1 ON Teacher (School_idSchool);


CREATE INDEX IFK_Rel_06 ON Teacher (School_idSchool);


CREATE TABLE StudentHistory (
  StudentPersonal_idStudent INTEGER   NOT NULL ,
  Teacher_idTeacher INTEGER   NOT NULL ,
  trouble learning new material INTEGER    ,
  little desire to master new skills INTEGER    ,
  unable to tell time INTEGER    ,
  cannot repeat info INTEGER    ,
  trouble multithinking INTEGER    ,
  trouble following multistep directions INTEGER    ,
  difficulty copying INTEGER    ,
  difficulty orienting self INTEGER    ,
  poor spatial judgement INTEGER    ,
  confuses directions INTEGER    ,
  mixes up lower and upper cases INTEGER    ,
  reverses letters and numbers INTEGER    ,
  trouble ordering words and events INTEGER    ,
  mispronounciation INTEGER    ,
  trouble verbally expressing thoughts INTEGER    ,
  little to no connection to what others are discussing INTEGER    ,
  teacherComments VARCHAR(500)      ,
PRIMARY KEY(StudentPersonal_idStudent)    ,
  FOREIGN KEY(StudentPersonal_idStudent)
    REFERENCES StudentPersonal(idStudent),
  FOREIGN KEY(Teacher_idTeacher)
    REFERENCES Teacher(idTeacher));


CREATE INDEX Table_05_FKIndex1 ON StudentHistory (StudentPersonal_idStudent);
CREATE INDEX StudentHistory_FKIndex2 ON StudentHistory (Teacher_idTeacher);


CREATE INDEX IFK_Rel_03 ON StudentHistory (StudentPersonal_idStudent);
CREATE INDEX IFK_Rel_04 ON StudentHistory (Teacher_idTeacher);



