CREATE SEQUENCE ID_SEQ 
  START WITH 1 
  INCREMENT BY 1;

CREATE TABLE tollStation (
	 id integer NOT NULL,
	 name varchar(30) NOT NULL,
     isDeleted integer DEFAULT 0 NOT NULL,
	 CONSTRAINT tollStation_PK PRIMARY KEY (id),
     CONSTRAINT tollStationDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);

CREATE OR REPLACE TRIGGER TOLLSTATIONID
BEFORE INSERT ON tollStation
FOR EACH ROW
  WHEN (new.ID IS NULL)
BEGIN
  :new.ID := ID_SEQ.NEXTVAL;
END;
/
  
CREATE TABLE tollBooth(
	 stationId integer NOT NULL,
	 ordinalNumber integer NOT NULL,
     isDeleted integer DEFAULT 0 NOT NULL,
	 CONSTRAINT tollBooth_PK PRIMARY KEY (stationId, ordinalNumber),
	 CONSTRAINT tollBooth_FK FOREIGN KEY (stationId) REFERENCES tollStation (id),
     CONSTRAINT tollBoothDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)     
);

create table DEVICE (
    id integer NOT NULL,
    isDamaged integer DEFAULT 0,
    deviceType varchar(10) not null,
    tollBoothNumber integer NOT NULL,
    stationId integer NOT NULL,
    isDeleted integer DEFAULT 0 NOT NULL,
    CONSTRAINT device_pk PRIMARY KEY(id),
    CONSTRAINT device_fk FOREIGN KEY (stationId, tollBoothNumber) REFERENCES TollBooth(stationId,ordinalNumber),
    CONSTRAINT damaged_c CHECK(isDamaged = 0 or isDamaged = 1),
    CONSTRAINT device_type_c CHECK(deviceType=ANY('PRINTER', 'SEMAPHORE', 'RAMP', 'SCANNER')),
    CONSTRAINT deviceDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);

create table SCANNER (
    id integer NOT NULL,
    scannerType varchar(10) not null,
    isDeleted integer DEFAULT 0 NOT NULL,
    CONSTRAINT scanner_pk PRIMARY KEY(id),
    CONSTRAINT scanner_fk FOREIGN KEY (id) REFERENCES DEVICE(id),
    CONSTRAINT scanner_type_c CHECK(scannerType=ANY('LICENCE_PLATE', 'TAG')),
    CONSTRAINT scannerDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);

CREATE OR REPLACE TRIGGER DEVICE_id
BEFORE INSERT ON DEVICE
FOR EACH ROW
  WHEN (new.id IS NULL)
BEGIN
  :new.id := ID_SEQ.NEXTVAL;
END;
/

CREATE TABLE section(
	 id integer NOT NULL,
	 length integer NOT NULL,
	 tollStation1Id integer NOT NULL,
     tollStation2Id integer NOT NULL,
     isDeleted integer DEFAULT 0 NOT NULL,
	 CONSTRAINT section_PK PRIMARY KEY (id),
	 CONSTRAINT section_FK1 FOREIGN KEY (tollStation1Id) REFERENCES tollStation (id),
     CONSTRAINT section_FK2 FOREIGN KEY (tollStation2Id) REFERENCES tollStation (id),
     CONSTRAINT sectionDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);

CREATE OR REPLACE TRIGGER SECTIONID
BEFORE INSERT ON section
FOR EACH ROW
  WHEN (new.ID IS NULL)
BEGIN
  :new.ID := ID_SEQ.NEXTVAL;
END;
/

create table staff (
    userId integer not null,
    username varchar(15) not null,
    password varchar(15) not null,
    firstName varchar(20) not null,
    lastName varchar(20) not null,
    salary integer not null,
    validFrom date not null,
    validTo date,
    role varchar(15) not null check (role in ('REFERENT', 'STATIONMASTER', 'MANAGER', 'ADMINISTRATOR')), 
    stationId integer,
    isDeleted integer DEFAULT 0 NOT NULL,
    CONSTRAINT staff_PK PRIMARY KEY (userId),
    CONSTRAINT staff_FK FOREIGN KEY (stationId) REFERENCES tollStation (id),
    CONSTRAINT staffDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);

CREATE OR REPLACE TRIGGER STAFFID
BEFORE INSERT ON staff
FOR EACH ROW
  WHEN (new.userId IS NULL)
BEGIN
  :new.userId := ID_SEQ.NEXTVAL;
END;
/

CREATE TABLE pricelist (
    id integer NOT NULL,
    validFrom date NOT NULL,
    validTo date,
    isActive integer DEFAULT 0,
    isDeleted integer DEFAULT 0 NOT NULL,
    CONSTRAINT pricelist_id_pk PRIMARY KEY (id),
    CONSTRAINT pricelist_date_ch CHECK (validTo >= validFrom),
    CONSTRAINT pricelist_isActive_ch CHECK (isActive = 1 or isActive = 0),
    CONSTRAINT pricelistDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);

CREATE OR REPLACE TRIGGER pricelistId
BEFORE INSERT ON pricelist
FOR EACH ROW
  WHEN (new.id IS NULL)
BEGIN
  :new.id := ID_SEQ.NEXTVAL;
END;
/

CREATE TABLE salesplace (
    id integer NOT NULL,
    name varchar(30) NOT NULL,
    username varchar(30) NOT NULL,
    password varchar(30) NOT NULL,
    availableTags integer DEFAULT 0,
    isDeleted integer DEFAULT 0 NOT NULL,
    CONSTRAINT salesplace_id_pk PRIMARY KEY (id),
    CONSTRAINT salesplace_availableTags_ch CHECK (availableTags >= 0),
    CONSTRAINT salesplaceDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);

CREATE OR REPLACE TRIGGER salesplaceId
BEFORE INSERT ON salesplace
FOR EACH ROW
  WHEN (new.id IS NULL)
BEGIN
  :new.id := ID_SEQ.NEXTVAL;
END;
/

CREATE TABLE damage (
    deviceId integer NOT NULL,
    description varchar(30) NOT NULL,
    isDeleted integer DEFAULT 0 NOT NULL,
    CONSTRAINT damage_deviceId_pk PRIMARY KEY (deviceId),
    CONSTRAINT damage_deviceId_fk FOREIGN KEY (deviceId) REFERENCES device(id),
    CONSTRAINT damageDeleted_c CHECK(isDeleted = 0 or isDeleted = 1)
);