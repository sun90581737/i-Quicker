insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('824e1ef5-0dd3-465c-95bb-38f9db54a203', '0', Null, Null, '班组任务', 'fa fa-calendar-check-o', Null, 'expand', 'False', 'True', 'False', 'False', 'False', 6, Null, 'True', Null, '2020/6/1 10:40:56', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null, Null, Null)
insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('7fdc2982-da5e-4bcf-acee-c8763a49057a', '824e1ef5-0dd3-465c-95bb-38f9db54a203', Null, Null, 'EDM班组', Null, '/TeamTask/EdmTeam/Index', 'iframe', 'True', 'False', 'False', 'False', 'False', 2, Null, 'True', Null, '2020/6/1 10:42:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2020/6/1 10:44:17', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null)
insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('9ee4478e-dbb9-495f-8ed9-d32d0e88fd02', '824e1ef5-0dd3-465c-95bb-38f9db54a203', Null, Null, 'CNC班组', Null, '/TeamTask/CNCTeam/Index', 'iframe', 'True', 'False', 'False', 'False', 'False', 1, Null, 'True', Null, '2020/6/1 12:40:39', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null, Null, Null)
insert into Sys_Module(F_Id, F_ParentId, F_Layers, F_EnCode, F_FullName, F_Icon, F_UrlAddress, F_Target, F_IsMenu, F_IsExpand, F_IsPublic, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId, F_LastModifyTime, F_LastModifyUserId, F_DeleteTime, F_DeleteUserId) values ('47f88ee5-e87d-4852-a1eb-84eb5de8f995', '824e1ef5-0dd3-465c-95bb-38f9db54a203', Null, Null, 'WE班组', Null, '/TeamTask/WETeam/Index', 'iframe', 'True', 'False', 'False', 'False', 'False', 3, Null, 'True', Null, '2020/6/1 13:41:58', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', Null, Null, Null, Null)

CREATE table Sys_TaskList  --任务清单
(  
id int identity (1,1) primary key , 
Mold_No varchar(50)  NULL, --模具编号
Part_Number  varchar(50)  NULL,--零件编号
Planned_Equipment varchar(50)  NULL,--计划设备
Start_Time DATETIME, --开始时间
END_Time DATETIME, --结束时间
Latest_Start_Time DATETIME,--最晚开始时间
Working_Hours varchar(50)  NULL,--标准工时
Customer  varchar(50)  NULL,--客户
Mold_Kernel_Material varchar(50)  NULL,--模仁材质
Category varchar(50)  NULL,--类别
Team varchar(50)  NULL,  --班组
Colour varchar(50)  NULL,  --灯的颜色
IsEffective int DEFAULT 1 -- 0 无效 1 有效 1显示
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
CREATE table Sys_EquipmentList  --设备清单
(  
id int identity (1,1) primary KEY,
Equipment_Name varchar(50)  NULL,--设备名
Equipment_Url varchar(200)  NULL,--设备Url
Workpieces_Url varchar(200)  NULL, --加工件Url
Yield  varchar(10)  NULL, --今日产量
Jiadong varchar(10)  NULL, --稼动率
Team varchar(50)  NULL,  --班组
Colour varchar(50)  NULL,  --灯的颜色
CreationTime DATETIME not null default getdate(),--创建时间
IsEffective int DEFAULT 1 -- 0 无效 1 有效 1显示
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
CREATE TABLE Sys_CapacityLoad --产能/负荷
(
	id int identity (1,1) primary KEY,
	Task_Type varchar(50)  NULL,--类别：产能/负荷
	Device_Name varchar(50)  NULL,--设备名(展示的时候，产能/负荷的设备名保持一致)
	Device_Number int,--设备数量
	Team varchar(50)  NULL,  --班组
	Colour varchar(50)  NULL,  --颜色
	CreationTime DATETIME not null default getdate(),--创建时间
	IsEffective int DEFAULT 1 -- 0 无效 1 有效 1显示
)
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF01',88,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF02',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF03',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF04',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF05',66,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF06',32,'EDM','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF01',100,'EDM','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF02',120,'EDM','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF03',78,'EDM','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF04',325,'EDM','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF05',221,'EDM','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF06',23,'EDM','#F9F900')

INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF01',100,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF02',120,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF03',95,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF04',89,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF05',100,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF06',110,'CNC','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF01',130,'CNC','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF02',140,'CNC','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF03',95,'CNC','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF04',150,'CNC','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF05',130,'CNC','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF06',50,'CNC','#F9F900')

INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF01',95,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF02',96,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF03',94,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF04',92,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF05',89,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('产能','GF06',89,'WE','#01B468')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF01',86,'WE','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF02',87,'WE','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF03',95,'WE','#F9F900')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF04',100,'WE','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF05',50,'WE','#FF2D2D')
INSERT INTO [dbo].[Sys_CapacityLoad] ([Task_Type] ,[Device_Name] ,[Device_Number] ,[Team] ,[Colour])VALUES ('负荷','GF06',90,'WE','#F9F900')
CREATE TABLE Sys_Trend --稼动率趋势
(
	id int identity (1,1) primary KEY,
	Month_Day varchar(20)  NULL, --日期
	Device_Name varchar(50)  NULL,--设备名
	TrendRate FLOAT,--趋势数
	Team varchar(50)  NULL,  --班组
	CreationTime DATETIME not null default getdate(),--创建时间
	IsEffective int DEFAULT 1 -- 0 无效 1 有效 1显示
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


CREATE table Sys_RunningState  --运行状态
(  
id int identity (1,1) primary key , 
Picture_Tip varchar(50)  NULL, --图片内容描述不展示
Picture_Url varchar(50)  NULL, --图片URL
Describe1 varchar(200)  NULL,--文本描述1
DescribeColor1 varchar(10)  NULL,--文本描述颜色1
Describe2 varchar(200)  NULL,--文本描述2
DescribeColor2 varchar(10)  NULL,--文本描述颜色2
Describe3 varchar(200)  NULL,--文本描述3
DescribeColor3 varchar(10)  NULL,--文本描述颜色3
Describe4 varchar(200)  NULL,--文本描述4
DescribeColor4 varchar(10)  NULL,--文本描述颜色4
Describe5 varchar(200)  NULL,--文本描述5
DescribeColor5 varchar(10)  NULL,--文本描述颜色5
Describe6 varchar(200)  NULL,--文本描述6
DescribeColor6 varchar(10)  NULL,--文本描述颜色6
CreationTime DATETIME not null default getdate(),--创建时间
IsEffective int DEFAULT 1 -- 0 无效 1 有效 1显示
)  