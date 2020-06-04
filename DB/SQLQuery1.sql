insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('824e1ef5-0dd3-465c-95bb-38f9db54a203', '0', Null, Null, '��������', 'fa fa-calendar-check-o', Null, 'expand', 'False', 'True', 'False', 'False', 'False', 6, Null, 'True', Null, '2020/6/1 10:40:56', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null, Null, Null)
insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('7fdc2982-da5e-4bcf-acee-c8763a49057a', '824e1ef5-0dd3-465c-95bb-38f9db54a203', Null, Null, 'EDM����', Null, '/TeamTask/EdmTeam/Index', 'iframe', 'True', 'False', 'False', 'False', 'False', 2, Null, 'True', Null, '2020/6/1 10:42:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2020/6/1 10:44:17', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null)
insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('9ee4478e-dbb9-495f-8ed9-d32d0e88fd02', '824e1ef5-0dd3-465c-95bb-38f9db54a203', Null, Null, 'CNC����', Null, '/TeamTask/CNCTeam/Index', 'iframe', 'True', 'False', 'False', 'False', 'False', 1, Null, 'True', Null, '2020/6/1 12:40:39', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null, Null, Null)
insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('47f88ee5-e87d-4852-a1eb-84eb5de8f995', '824e1ef5-0dd3-465c-95bb-38f9db54a203', Null, Null, 'WE����', Null, '/TeamTask/WETeam/Index', 'iframe', 'True', 'False', 'False', 'False', 'False', 3, Null, 'True', Null, '2020/6/1 13:41:58', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null, Null, Null)

CREATE table Sys_TaskList  --�����嵥
(  
id int identity (1,1) primary key , 
Mold_No varchar(50)  NULL, --ģ�߱��
Part_Number  varchar(50)  NULL,--������
Planned_Equipment varchar(50)  NULL,--�ƻ��豸
Start_Time DATETIME, --��ʼʱ��
END_Time DATETIME, --����ʱ��
Latest_Start_Time DATETIME,--����ʼʱ��
Working_Hours varchar(50)  NULL,--��׼��ʱ
Customer  varchar(50)  NULL,--�ͻ�
Mold_Kernel_Material varchar(50)  NULL,--ģ�ʲ���
Category varchar(50)  NULL,--���
Team varchar(50)  NULL,  --����
Colour varchar(50)  NULL,  --�Ƶ���ɫ
IsEffective int DEFAULT 1 -- 0 ��Ч 1 ��Ч 1��ʾ
)  
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19001' ,'F01' ,'GF01' ,GETDATE() ,GETDATE() ,GETDATE() ,2 ,'INNER' ,8407 ,2 ,'EDM' ,'#006600')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19002' ,'S01' ,'GF03' ,GETDATE() ,GETDATE() ,GETDATE() ,5 ,'INNER' ,8407 ,2 ,'EDM' ,'#CCFF00')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19003' ,'X92' ,'GF04' ,GETDATE() ,GETDATE() ,GETDATE() ,4 ,'INNER' ,8407 ,2 ,'EDM' ,'#CCFF00')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19004' ,'M01' ,'GF02' ,GETDATE() ,GETDATE() ,GETDATE() ,2 ,'INNER' ,8407 ,2 ,'EDM' ,'#CC0000')

INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19001' ,'F01' ,'GF01' ,GETDATE() ,GETDATE() ,GETDATE() ,2 ,'INNER' ,8407 ,2 ,'CNC' ,'#006600')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19002' ,'S01' ,'GF03' ,GETDATE() ,GETDATE() ,GETDATE() ,5 ,'INNER' ,8407 ,2 ,'CNC' ,'#CCFF00')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19003' ,'X92' ,'GF04' ,GETDATE() ,GETDATE() ,GETDATE() ,4 ,'INNER' ,8407 ,2 ,'CNC' ,'#CCFF00')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19004' ,'M01' ,'GF02' ,GETDATE() ,GETDATE() ,GETDATE() ,2 ,'INNER' ,8407 ,2 ,'CNC' ,'#CC0000')

INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19001' ,'F01' ,'GF01' ,GETDATE() ,GETDATE() ,GETDATE() ,2 ,'INNER' ,8407 ,2 ,'WE' ,'#006600')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19002' ,'S01' ,'GF03' ,GETDATE() ,GETDATE() ,GETDATE() ,5 ,'INNER' ,8407 ,2 ,'WE' ,'#CCFF00')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19003' ,'X92' ,'GF04' ,GETDATE() ,GETDATE() ,GETDATE() ,4 ,'INNER' ,8407 ,2 ,'WE' ,'#CCFF00')
INSERT INTO [NFineBase].[dbo].[Sys_TaskList]([Mold_No] ,[Part_Number] ,[Planned_Equipment] ,[Start_Time] ,[END_Time] ,[Latest_Start_Time]
,[Working_Hours] ,[Customer] ,[Mold_Kernel_Material] ,[Category] ,[Team] ,[Colour])
VALUES ('IK19004' ,'M01' ,'GF02' ,GETDATE() ,GETDATE() ,GETDATE() ,2 ,'INNER' ,8407 ,2 ,'WE' ,'#CC0000')
CREATE table Sys_EquipmentList  --�豸�嵥
(  
id int identity (1,1) primary KEY,
Equipment_Name varchar(50)  NULL,--�豸��
Equipment_Url varchar(200)  NULL,--�豸Url
Workpieces_Url varchar(200)  NULL, --�ӹ���Url
Yield  varchar(10)  NULL, --���ղ���
Jiadong varchar(10)  NULL, --�ڶ���
Team varchar(50)  NULL,  --����
Colour varchar(50)  NULL,  --�Ƶ���ɫ
CreationTime DATETIME not null default getdate(),--����ʱ��
IsEffective int DEFAULT 1 -- 0 ��Ч 1 ��Ч 1��ʾ
)
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF01','/Content/img/product/edm/GF01a.png','/Content/img/product/edm/GF01a.png','6','83%','EDM' ,'#CC0000')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF02','/Content/img/product/edm/GF01a.png','/Content/img/product/edm/GF01b.png','3','90%','EDM' ,'#CCFF00')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF01','/Content/img/product/edm/GF01a.png','/Content/img/product/edm/GF01a.png','6','83%','EDM' ,'#00CC99')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF02','/Content/img/product/edm/GF01a.png','/Content/img/product/edm/GF01b.png','3','90%','EDM' ,'#00CC99')

INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF01','/Content/img/product/cnc/GF01a.png','/Content/img/product/cnc/GF01b.png','6','83%','CNC' ,'#00CC99')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF02','/Content/img/product/cnc/GF02a.png','/Content/img/product/cnc/GF02b.png','3','90%','CNC' ,'#00CC99')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF03','/Content/img/product/cnc/GF03a.png','/Content/img/product/cnc/GF03b.png','2','95%','CNC' ,'#00CC99')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF04','/Content/img/product/cnc/GF04a.png','/Content/img/product/cnc/GF04b.png','3','89%','CNC' ,'#C4C400')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF05','/Content/img/product/cnc/GF05a.png','/Content/img/product/cnc/GF05b.png','6','85%','CNC' ,'#C4C400')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF06','/Content/img/product/cnc/GF06a.png','/Content/img/product/cnc/GF06b.png','4','95%','CNC' ,'#FF5809')

INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF01','/Content/img/product/we/GF01a.png','/Content/img/product/we/GF01b.png','6','83%','WE' ,'#019858')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF02','/Content/img/product/we/GF02a.png','/Content/img/product/we/GF02b.png','3','90%','WE' ,'#019858')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF03','/Content/img/product/we/GF03a.png','/Content/img/product/we/GF03b.png','2','95%','WE' ,'#019858')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF04','/Content/img/product/we/GF04a.png','/Content/img/product/we/GF04b.png','3','89%','WE' ,'#C4C400')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF05','/Content/img/product/we/GF05a.png','/Content/img/product/we/GF05b.png','6','85%','WE' ,'#C4C400')
INSERT INTO [dbo].[Sys_EquipmentList]([Equipment_Name],[Equipment_Url],[Workpieces_Url],[Yield],[Jiadong],[Team],[Colour])
VALUES('GF06','/Content/img/product/we/GF06a.png','/Content/img/product/we/GF06b.png','4','95%','WE' ,'#FF5809')
CREATE TABLE Sys_CapacityLoad --����/����
(
	id int identity (1,1) primary KEY,
	Task_Type varchar(50)  NULL,--��𣺲���/����
	Device_Name varchar(50)  NULL,--�豸��(չʾ��ʱ�򣬲���/���ɵ��豸������һ��)
	Device_Number int,--�豸����
	Team varchar(50)  NULL,  --����
	Colour varchar(50)  NULL,  --��ɫ
	CreationTime DATETIME not null default getdate(),--����ʱ��
	IsEffective int DEFAULT 1 -- 0 ��Ч 1 ��Ч 1��ʾ
)
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF01',88,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF02',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF03',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF04',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF05',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF06',32,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF01',100,'EDM','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF02',120,'EDM','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF03',78,'EDM','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF04',325,'EDM','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF05',221,'EDM','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF06',23,'EDM','#F9F900')

INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF01',100,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF02',120,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF03',95,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF04',89,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF05',100,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF06',110,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF01',130,'CNC','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF02',140,'CNC','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF03',95,'CNC','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF04',150,'CNC','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF05',130,'CNC','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF06',50,'CNC','#F9F900')

INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF01',95,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF02',96,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF03',94,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF04',92,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF05',89,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF06',89,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF01',86,'WE','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF02',87,'WE','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF03',95,'WE','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF04',100,'WE','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF05',50,'WE','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('����','GF06',90,'WE','#F9F900')
CREATE TABLE Sys_Trend --�ڶ�������
(
	id int identity (1,1) primary KEY,
	Month_Day varchar(20)  NULL, --����
	Device_Name varchar(50)  NULL,--�豸��
	TrendRate FLOAT,--������
	Team varchar(50)  NULL,  --����
	CreationTime DATETIME not null default getdate(),--����ʱ��
	IsEffective int DEFAULT 1 -- 0 ��Ч 1 ��Ч 1��ʾ
)
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF01',95,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF02',86.5,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF03',24.1,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF04',55.2,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF01',95.8,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF02',92.1,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF03',67.2,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF04',67.1,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF01',94.2,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF02',85.7,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF03',79.5,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF04',69.2,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF01',93,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF02',83.1,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF03',84.6,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF04',72.4,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF01',92,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF02',73.1,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF03',65.2,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF04',53.9,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF01',91,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF02',55.1,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF03',82.5,'EDM')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF04',49.1,'EDM')

INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF01',88,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF02',95,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF03',86,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF04',93,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF01',89,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF02',96,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF03',92,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-29','GF04',92,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF01',85,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF02',94,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF03',84,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF04',91,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF01',86,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF02',85,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF03',88,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF04',85,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF01',87,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF02',88,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF03',89,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF04',84,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF01',89,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF02',89,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF03',85,'CNC')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF04',83,'CNC')

INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF01',86,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF02',85,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF03',88,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('2-28','GF04',85,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF01',87,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF02',88,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF03',88,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-1','GF04',84,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF01',89,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF02',89,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF03',89,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-2','GF04',83,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF01',96,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF02',89,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF03',85,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-3','GF04',93,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-4','GF01',94,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-4','GF02',85,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-4','GF03',87,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-4','GF04',92,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF01',84,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF02',91,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF03',89,'WE')
INSERT INTO [dbo].[Sys_Trend] ([Month_Day],[Device_Name],[TrendRate],[Team])VALUES ('3-5','GF04',91,'WE')
SELECT * FROM	[Sys_Trend]  ORDER BY Device_Name


CREATE table Sys_RunningState  --����״̬
(  
id int identity (1,1) primary key , 
Picture_Tip varchar(50)  NULL, --ͼƬ����������չʾ
Picture_Url varchar(50)  NULL, --ͼƬURL
Describe1 varchar(200)  NULL,--�ı�����1
DescribeColor1 varchar(10)  NULL,--�ı�������ɫ1
Describe2 varchar(200)  NULL,--�ı�����2
DescribeColor2 varchar(10)  NULL,--�ı�������ɫ2
Describe3 varchar(200)  NULL,--�ı�����3
DescribeColor3 varchar(10)  NULL,--�ı�������ɫ3
Describe4 varchar(200)  NULL,--�ı�����4
DescribeColor4 varchar(10)  NULL,--�ı�������ɫ4
Describe5 varchar(200)  NULL,--�ı�����5
DescribeColor5 varchar(10)  NULL,--�ı�������ɫ5
Describe6 varchar(200)  NULL,--�ı�����6
DescribeColor6 varchar(10)  NULL,--�ı�������ɫ6
CreationTime DATETIME not null default getdate(),--����ʱ��
IsEffective int DEFAULT 1 -- 0 ��Ч 1 ��Ч 1��ʾ
)  