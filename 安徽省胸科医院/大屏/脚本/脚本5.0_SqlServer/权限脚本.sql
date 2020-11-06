create view med_user_permissions as
select DISTINCT a.user_id,  b.role_id ,c.permission_id, c.app_id,c.name,c.sort_id,c.permission_key,c.description ,d.Login_Name
FROM MED_USERS_ROLES a , MED_ROLES_PERMISSIONS b ,MED_PERMISSIONS c ,MED_USERS d
where a.role_id=b.role_id and b.permission_id =c.permission_id and  a.user_id=d.user_id and (c.is_valid='T' or c.is_valid='t');

DELETE MED_PERMISSIONS
 WHERE PERMISSION_ID IN
       (SELECT MPA.PERMISSION_ID
          FROM MED_PERMISSIONS_ANES MPA
         WHERE MPA.PARENT_ID = 'DoCare围术期管理决策平台');


DELETE MED_PERMISSIONS_ANES WHERE PARENT_ID = 'DoCare围术期管理决策平台';
DELETE med_permissions WHERE PERMISSION_ID = 'DoCare围术期管理决策平台';


insert into med_permissions (PERMISSION_ID, APP_ID, NAME, PERMISSION_KEY, SORT_ID, IS_VALID, DESCRIPTION)
values ('DoCare围术期管理决策平台', 'ANESPERSONAL', 'DoCare围术期管理决策平台', 'DoCare围术期管理决策平台', null, 't', 'DoCare围术期管理决策平台');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10001','ANESPERSONAL','工作量统计-麻醉医生工作量','AnesWorkLoadQuery',10001,'t','工作量统计');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10001','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10002','ANESPERSONAL','工作量统计-护士工作量','NurseWorkLoad',10002,'t','工作量统计');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10002','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10003','ANESPERSONAL','工作量统计-临床科室手术量(等级)','OperReport',10003,'t','工作量统计');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10003','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10004','ANESPERSONAL','工作量统计-临床科室手术量(月)','OperReportMonthly',10004,'t','工作量统计');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10004','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10005','ANESPERSONAL','科室报表-ASA分级统计','AsaQueryDept',10005,'t','科室报表');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10005','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10006','ANESPERSONAL','科室报表-麻醉方式统计','AnesMethod',10006,'t','科室报表');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10006','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10007','ANESPERSONAL','科室报表-临床科室手术量(等级)','OperReportDept',10007,'t','科室报表');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10007','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10010','ANESPERSONAL','等级评审-综合统计','AnesAAAQCQuery',10010,'t','等级评审');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10010','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10011','ANESPERSONAL','等级评审-实施麻醉例数统计','AnesCaseNumQuery',10011,'t','等级评审');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10011','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10012','ANESPERSONAL','等级评审-镇痛例数统计','PumpPainQuery',10012,'t','等级评审');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10012','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10013','ANESPERSONAL','等级评审-心肺复苏','CardioRescueQuery',10013,'t','等级评审');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10013','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10014','ANESPERSONAL','等级评审-麻醉复苏','AnesPACUQuery',10014,'t','等级评审');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10014','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10015','ANESPERSONAL','等级评审-非预期事件','NotExpectedEventsQuery',10015,'t','等级评审');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10015','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10016','ANESPERSONAL','等级评审-麻醉分级管理','AsaQueryGrade',10016,'t','等级评审');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10016','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10017','ANESPERSONAL','麻醉质控2015-麻醉质控综合查询','ucAnesQC17',10017,'t','麻醉质控2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10017','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10018','ANESPERSONAL','麻醉质控2015-ASA分级统计','AsaQueryQC',10018,'t','麻醉质控2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10018','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10019','ANESPERSONAL','麻醉质控2015-麻醉方式','AnesMethodQC',10019,'t','麻醉质控2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10019','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10020','ANESPERSONAL','麻醉质控2015-急诊/择期','OperEindicator',10020,'t','麻醉质控2015');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10020','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10021','ANESPERSONAL','系统配置-数据同步及参数','DataSyncView',10021,'t','系统配置');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10021','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10022','ANESPERSONAL','系统配置-麻醉方法归类','AnesMethodSyncView',10022,'t','系统配置');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10022','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10023','ANESPERSONAL','业务查询-手术明细查询','OperCompxInfoQuery',10023,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10023','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10024','ANESPERSONAL','业务查询-麻醉信息查询','OperAnesInfoQuery',10024,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10024','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10025','ANESPERSONAL','业务查询-取消手术查询','CancelOperQuery',10025,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10025','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10026','ANESPERSONAL','业务查询-入PACU查询','PacuOperQuery',10026,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10026','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10027','ANESPERSONAL','业务查询-术后镇痛手术查询','AfterOperPumpQuery',10027,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10027','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10028','ANESPERSONAL','业务查询-每日首台手术查询','FirstOperation',10028,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10028','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10029','ANESPERSONAL','业务查询-多次手术查询','ReturnOperation',10029,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10029','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10030','ANESPERSONAL','业务查询-术中用血查询','OperatingBlood',10030,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10030','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10033','ANESPERSONAL','业务查询-不良事件查询','AdverseEventQuery',10033,'t','业务查询');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10033','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10031','ANESPERSONAL','系统配置-报表参数配置','ReportConfig',10031,'T','系统配置');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10031','L','','','','','','','DoCare围术期管理决策平台','');

INSERT INTO med_permissions(Permission_ID,App_Id,name,permission_key,sort_id,is_valid,description) 
VALUES ('ANESPERSONAL-AutoAdd-10032','ANESPERSONAL','系统配置-新报表配置','fmReportConfig',10032,'T','系统配置');
INSERT INTO med_permissions_anes VALUES ('ANESPERSONAL-AutoAdd-10032','L','','','','','','','DoCare围术期管理决策平台','');

insert into med_roles (ROLE_ID, APP_ID, NAME, DESCRIPTION,CREATE_DATE)
values ('2ac3aba4-a746-4ff7-b4d0-20161116ae5a', 'ANESPERSONAL', 'DoCare围术期管理决策平台', 'DoCare围术期管理决策平台权限管理',getdate());