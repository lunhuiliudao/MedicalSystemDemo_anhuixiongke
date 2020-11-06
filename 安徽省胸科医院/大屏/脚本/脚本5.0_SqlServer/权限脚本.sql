create view med_user_permissions as
select DISTINCT a.user_id,  b.role_id ,c.permission_id, c.app_id,c.name,c.sort_id,c.permission_key,c.description ,d.Login_Name
FROM MED_USERS_ROLES a , MED_ROLES_PERMISSIONS b ,MED_PERMISSIONS c ,MED_USERS d
where a.role_id=b.role_id and b.permission_id =c.permission_id and  a.user_id=d.user_id and (c.is_valid='T' or c.is_valid='t');

DELETE MED_PERMISSIONS
 WHERE PERMISSION_ID IN
       (SELECT MPA.PERMISSION_ID
          FROM MED_PERMISSIONS_ANES MPA
         WHERE MPA.PARENT_ID = 'DoCareΧ���ڹ������ƽ̨');


DELETE MED_PERMISSIONS_ANES WHERE PARENT_ID = 'DoCareΧ���ڹ������ƽ̨';
DELETE med_permissions WHERE PERMISSION_ID = 'DoCareΧ���ڹ������ƽ̨';


insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('DoCareΧ���ڹ������ƽ̨', 'ANESPERSONAL', 'DoCareΧ���ڹ������ƽ̨', 'DoCareΧ���ڹ������ƽ̨', null, 't', 'DoCareΧ���ڹ������ƽ̨');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10001','ANESPERSONAL','������ͳ��-����ҽ��������','AnesWorkLoadQuery',10001,'t','������ͳ��');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10001','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10002','ANESPERSONAL','������ͳ��-��ʿ������','NurseWorkLoad',10002,'t','������ͳ��');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10002','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10003','ANESPERSONAL','������ͳ��-�ٴ�����������(�ȼ�)','OperReport',10003,'t','������ͳ��');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10003','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10004','ANESPERSONAL','������ͳ��-�ٴ�����������(��)','OperReportMonthly',10004,'t','������ͳ��');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10004','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10005','ANESPERSONAL','���ұ���-ASA�ּ�ͳ��','AsaQueryDept',10005,'t','���ұ���');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10005','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10006','ANESPERSONAL','���ұ���-����ʽͳ��','AnesMethod',10006,'t','���ұ���');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10006','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10007','ANESPERSONAL','���ұ���-�ٴ�����������(�ȼ�)','OperReportDept',10007,'t','���ұ���');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10007','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10010','ANESPERSONAL','�ȼ�����-�ۺ�ͳ��','AnesAAAQCQuery',10010,'t','�ȼ�����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10010','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10011','ANESPERSONAL','�ȼ�����-ʵʩ��������ͳ��','AnesCaseNumQuery',10011,'t','�ȼ�����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10011','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10012','ANESPERSONAL','�ȼ�����-��ʹ����ͳ��','PumpPainQuery',10012,'t','�ȼ�����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10012','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10013','ANESPERSONAL','�ȼ�����-�ķθ���','CardioRescueQuery',10013,'t','�ȼ�����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10013','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10014','ANESPERSONAL','�ȼ�����-������','AnesPACUQuery',10014,'t','�ȼ�����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10014','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10015','ANESPERSONAL','�ȼ�����-��Ԥ���¼�','NotExpectedEventsQuery',10015,'t','�ȼ�����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10015','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10016','ANESPERSONAL','�ȼ�����-����ּ�����','AsaQueryGrade',10016,'t','�ȼ�����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10016','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10017','ANESPERSONAL','�����ʿ�2015-�����ʿ��ۺϲ�ѯ','ucAnesQC17',10017,'t','�����ʿ�2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10017','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10018','ANESPERSONAL','�����ʿ�2015-ASA�ּ�ͳ��','AsaQueryQC',10018,'t','�����ʿ�2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10018','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10019','ANESPERSONAL','�����ʿ�2015-����ʽ','AnesMethodQC',10019,'t','�����ʿ�2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10019','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10020','ANESPERSONAL','�����ʿ�2015-����/����','OperEindicator',10020,'t','�����ʿ�2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10020','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10021','ANESPERSONAL','ϵͳ����-����ͬ��������','DataSyncView',10021,'t','ϵͳ����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10021','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10022','ANESPERSONAL','ϵͳ����-����������','AnesMethodSyncView',10022,'t','ϵͳ����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10022','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10023','ANESPERSONAL','ҵ���ѯ-������ϸ��ѯ','OperCompxInfoQuery',10023,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10023','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10024','ANESPERSONAL','ҵ���ѯ-������Ϣ��ѯ','OperAnesInfoQuery',10024,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10024','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10025','ANESPERSONAL','ҵ���ѯ-ȡ��������ѯ','CancelOperQuery',10025,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10025','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10026','ANESPERSONAL','ҵ���ѯ-��PACU��ѯ','PacuOperQuery',10026,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10026','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10027','ANESPERSONAL','ҵ���ѯ-������ʹ������ѯ','AfterOperPumpQuery',10027,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10027','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10028','ANESPERSONAL','ҵ���ѯ-ÿ����̨������ѯ','FirstOperation',10028,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10028','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10029','ANESPERSONAL','ҵ���ѯ-���������ѯ','ReturnOperation',10029,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10029','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10030','ANESPERSONAL','ҵ���ѯ-������Ѫ��ѯ','OperatingBlood',10030,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10030','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10033','ANESPERSONAL','ҵ���ѯ-�����¼���ѯ','AdverseEventQuery',10033,'t','ҵ���ѯ');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10033','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10031','ANESPERSONAL','ϵͳ����-�����������','ReportConfig',10031,'T','ϵͳ����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10031','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10032','ANESPERSONAL','ϵͳ����-�±�������','fmReportConfig',10032,'T','ϵͳ����');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10032','L','','','','','','','DoCareΧ���ڹ������ƽ̨','');

insert into med_roles (ROLE_ID, APP_ID, NAME, DESCRIPTION,CREATE_DATE)
values ('2ac3aba4-a746-4ff7-b4d0-20161116ae5a', 'ANESPERSONAL', 'DoCareΧ���ڹ������ƽ̨', 'DoCareΧ���ڹ������ƽ̨Ȩ�޹���',getdate());