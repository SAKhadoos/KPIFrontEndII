SET NOCOUNT ON
SET DATEFORMAT mdy

DECLARE @KPIUser NVARCHAR(200);
DECLARE @CoeusAdmin NVARCHAR(200);

SET @KPIUser='KSTNormalUser'; -- this is required and should be valid KPI Scorecard user
SET @CoeusAdmin='CoeusAdminUser'; -- this is required and should be valid admin user

DELETE [KST_AuditFinding_AuditFindingImpactValue]
DELETE [KST_AuditFinding]
DELETE [KST_AuditFindingImpactValue]
DELETE [KST_AuditFindingReportedToGORMValue]
DELETE [KST_AuditFindingRootCauseValue]
DELETE [KST_AuditFindingSourceValue]
DELETE [KST_AuditFindingStatusValue]
DELETE [KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]
DELETE [KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]
DELETE [KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]
DELETE [KST_BusinessUnitKPIScorecard_OperationPerformanceScore]
DELETE [KST_BusinessUnitKPIScorecard_SecurityScore]
DELETE [KST_BusinessUnitKPIScorecard]
DELETE [KST_KPIScore_LowPerformanceReason]
DELETE [KST_KPIVolumeScore]
DELETE [KST_KPIScore]
DELETE [KST_KPIScorecardItem]
DELETE [KST_DecimalOrPercentageValue]
DELETE [KST_LowPerformanceReason]
DELETE [KST_OperationalIncident_OperationalIncidentImpactValue]
DELETE [KST_OperationalIncident]
DELETE [KST_FinancialExposureValue]
DELETE [KST_OperationalIncidentImpactValue]
DELETE [KST_OperationalIncidentReportedToGORMValue]
DELETE [KST_OperationalIncidentRootCauseValue]
DELETE [KST_OperationalIncidentSourceValue]
DELETE [KST_OperationalIncidentStatusValue]
DELETE [KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]
DELETE [KST_PrivacyIncident]
DELETE [KST_BusinessUnit]
DELETE [KST_MonthValue]
DELETE [KST_PrivacyIncidentMitigationCodeValue]
DELETE [KST_PrivacyIncidentRootCauseValue]
DELETE [KST_PrivacyIncidentStatusValue]
DELETE [KST_PrivacyIncidentTypeValue]
DELETE [KST_StatusValue]
DELETE [KST_VolumeTypeValue]
DELETE [KST_YearValue]
DELETE [Token]
DELETE [UserMappingInfo]
DELETE [ActionPermission]

INSERT INTO [Token] ([Username], [TokenValue], [ExpirationDate])
VALUES
(@CoeusAdmin, N'e4d5ba3f-2459-4ea5-a30a-b0addf99e0f5', '12/12/9999'),
(@KPIUser, N'kpi-user-2459-4ea5-a30a-b0addf99e0f5', '12/12/9999')

INSERT INTO [UserMappingInfo] ([Username], [Role], [IsActive])
VALUES
(@CoeusAdmin, 4, 1),
(@KPIUser, 5, 1)

INSERT INTO [ActionPermission] ([Role], [Action])
VALUES
-- admin
(4, N'AuditFinding.Get'),
(4, N'AuditFinding.Search'),
(4, N'AuditFinding.Update'),
(4, N'AuditFinding.Create'),
(4, N'AuditFinding.GetLastTalliedNumber'),
(4, N'BusinessUnitKPIScorecard.Get'),
(4, N'BusinessUnitKPIScorecard.Search'),
(4, N'BusinessUnitKPIScorecard.Update'),
(4, N'BusinessUnitKPIScorecard.Create'),
(4, N'BusinessUnitKPIScorecard.GetInputAllowedDays'),
(4, N'KPIScorecardConfiguration.GetKPIScorecardConfiguration'),
(4, N'KPIScorecardConfiguration.SaveKPIScorecardConfiguration'),
(4, N'KPIScorecardConfiguration.GetBusinessUnitConfiguration'),
(4, N'KPIScorecardConfiguration.GetOperationalIncidentConfiguration'),
(4, N'KPIScorecardConfiguration.GetAuditFindingConfiguration'),
(4, N'KPIScorecardConfiguration.GetPrivacyIncidentConfiguration'),
(4, N'OperationalIncident.Get'),
(4, N'OperationalIncident.Search'),
(4, N'OperationalIncident.Update'),
(4, N'OperationalIncident.Create'),
(4, N'OperationalIncident.GetLastTalliedNumber'),
(4, N'PrivacyIncident.Get'),
(4, N'PrivacyIncident.Search'),
(4, N'PrivacyIncident.Update'),
(4, N'PrivacyIncident.Create'),
(4, N'PrivacyIncident.GetLastTalliedNumber'),
(4, N'KSTLookup.GetLookupEntities'),
(4, N'KSTLookup.GetValueEntities'),
(4, N'Summary.GetSummary'),
-- KPI user
(5, N'AuditFinding.Get'),
(5, N'AuditFinding.Search'),
(5, N'AuditFinding.Update'),
(5, N'AuditFinding.Create'),
(5, N'AuditFinding.GetLastTalliedNumber'),
(5, N'BusinessUnitKPIScorecard.Get'),
(5, N'BusinessUnitKPIScorecard.Search'),
(5, N'BusinessUnitKPIScorecard.Update'),
(5, N'BusinessUnitKPIScorecard.Create'),
(5, N'BusinessUnitKPIScorecard.GetInputAllowedDays'),
(5, N'KPIScorecardConfiguration.GetBusinessUnitConfiguration'),
(5, N'OperationalIncident.Get'),
(5, N'OperationalIncident.Search'),
(5, N'OperationalIncident.Update'),
(5, N'OperationalIncident.Create'),
(5, N'OperationalIncident.GetLastTalliedNumber'),
(5, N'PrivacyIncident.Get'),
(5, N'PrivacyIncident.Search'),
(5, N'PrivacyIncident.Update'),
(5, N'PrivacyIncident.Create'),
(5, N'PrivacyIncident.GetLastTalliedNumber'),
(5, N'KSTLookup.GetLookupEntities'),
(5, N'KSTLookup.GetValueEntities'),
(5, N'Summary.GetSummary'),
(5, N'Security.RevokeToken')

SET IDENTITY_INSERT [KST_YearValue] ON
INSERT INTO [KST_YearValue] ([Id], [Value], [Enabled])
VALUES
(1, N'2017', 1),
(2, N'2018', 1),
(3, N'2019', 1),
(4, N'2020', 0),
(5, N'2021', 1),
(6, N'2011', 0),
(7, N'2012', 1),
(8, N'2013', 0),
(9, N'2016', 1)
SET IDENTITY_INSERT [KST_YearValue] OFF

SET IDENTITY_INSERT [KST_VolumeTypeValue] ON
INSERT INTO [KST_VolumeTypeValue] ([Id], [Value], [Enabled])
VALUES
(1, N'VolumeTypeValue1', 1),
(2, N'VolumeTypeValue2', 0),
(3, N'VolumeTypeValue3', 1),
(4, N'VolumeTypeValue4', 0),
(5, N'VolumeTypeValue5', 1),
(6, N'VolumeTypeValue6', 0),
(7, N'VolumeTypeValue7', 1),
(8, N'VolumeTypeValue8', 0),
(9, N'VolumeTypeValue9', 1)
SET IDENTITY_INSERT [KST_VolumeTypeValue] OFF

SET IDENTITY_INSERT [KST_StatusValue] ON
INSERT INTO [KST_StatusValue] ([Id], [Value], [Enabled])
VALUES
(1, N'StatusValue1', 1),
(2, N'StatusValue2', 0),
(3, N'StatusValue3', 1),
(4, N'StatusValue4', 0),
(5, N'StatusValue5', 1),
(6, N'StatusValue6', 0),
(7, N'StatusValue7', 1),
(8, N'StatusValue8', 0),
(9, N'StatusValue9', 1)
SET IDENTITY_INSERT [KST_StatusValue] OFF

SET IDENTITY_INSERT [KST_PrivacyIncidentTypeValue] ON
INSERT INTO [KST_PrivacyIncidentTypeValue] ([Id], [Value], [Enabled])
VALUES
(1, N'PrivacyIncidentTypeValue1', 1),
(2, N'PrivacyIncidentTypeValue2', 0),
(3, N'PrivacyIncidentTypeValue3', 1),
(4, N'PrivacyIncidentTypeValue4', 0),
(5, N'PrivacyIncidentTypeValue5', 1),
(6, N'PrivacyIncidentTypeValue6', 0),
(7, N'PrivacyIncidentTypeValue7', 1),
(8, N'PrivacyIncidentTypeValue8', 0),
(9, N'PrivacyIncidentTypeValue9', 1)
SET IDENTITY_INSERT [KST_PrivacyIncidentTypeValue] OFF

SET IDENTITY_INSERT [KST_PrivacyIncidentStatusValue] ON
INSERT INTO [KST_PrivacyIncidentStatusValue] ([Id], [Value], [Enabled])
VALUES
(1, N'PrivacyIncidentStatusValue1', 1),
(2, N'PrivacyIncidentStatusValue2', 0),
(3, N'PrivacyIncidentStatusValue3', 1),
(4, N'PrivacyIncidentStatusValue4', 0),
(5, N'PrivacyIncidentStatusValue5', 1),
(6, N'PrivacyIncidentStatusValue6', 0),
(7, N'PrivacyIncidentStatusValue7', 1),
(8, N'PrivacyIncidentStatusValue8', 0),
(9, N'PrivacyIncidentStatusValue9', 1)
SET IDENTITY_INSERT [KST_PrivacyIncidentStatusValue] OFF

SET IDENTITY_INSERT [KST_PrivacyIncidentRootCauseValue] ON
INSERT INTO [KST_PrivacyIncidentRootCauseValue] ([Id], [Value], [Enabled])
VALUES
(1, N'PrivacyIncidentStatusValue1', 1),
(2, N'PrivacyIncidentStatusValue2', 0),
(3, N'PrivacyIncidentStatusValue3', 1),
(4, N'PrivacyIncidentStatusValue4', 0),
(5, N'PrivacyIncidentStatusValue5', 1),
(6, N'PrivacyIncidentStatusValue6', 0),
(7, N'PrivacyIncidentStatusValue7', 1),
(8, N'PrivacyIncidentStatusValue8', 0),
(9, N'PrivacyIncidentStatusValue9', 1)
SET IDENTITY_INSERT [KST_PrivacyIncidentRootCauseValue] OFF

SET IDENTITY_INSERT [KST_PrivacyIncidentMitigationCodeValue] ON
INSERT INTO [KST_PrivacyIncidentMitigationCodeValue] ([Id], [Value], [Enabled])
VALUES
(1, N'PrivacyIncidentMitigationCodeValue1', 1),
(2, N'PrivacyIncidentMitigationCodeValue2', 0),
(3, N'PrivacyIncidentMitigationCodeValue3', 1),
(4, N'PrivacyIncidentMitigationCodeValue4', 0),
(5, N'PrivacyIncidentMitigationCodeValue5', 1),
(6, N'PrivacyIncidentMitigationCodeValue6', 0),
(7, N'PrivacyIncidentMitigationCodeValue7', 1),
(8, N'PrivacyIncidentMitigationCodeValue8', 0),
(9, N'PrivacyIncidentMitigationCodeValue9', 1)
SET IDENTITY_INSERT [KST_PrivacyIncidentMitigationCodeValue] OFF

SET IDENTITY_INSERT [KST_MonthValue] ON
INSERT INTO [KST_MonthValue] ([Id], [Value], [Enabled])
VALUES
(1, N'January', 1),
(2, N'February', 0),
(3, N'March', 1),
(4, N'April', 0),
(5, N'May', 1),
(6, N'June', 0),
(7, N'July', 1),
(8, N'August', 0),
(9, N'September', 1),
(10, N'October', 1),
(11, N'November', 1),
(12, N'December', 1)
SET IDENTITY_INSERT [KST_MonthValue] OFF

SET IDENTITY_INSERT [KST_BusinessUnit] ON
INSERT INTO [KST_BusinessUnit] ([Id], [Value], [Enabled])
VALUES
(1, N'KST_BusinessUnit1', 1),
(2, N'KST_BusinessUnit2', 1),
(3, N'KST_BusinessUnit3', 0),
(4, N'KST_BusinessUnit4', 1),
(5, N'KST_BusinessUnit5', 1),
(6, N'KST_BusinessUnit6', 0),
(7, N'KST_BusinessUnit7', 1),
(8, N'KST_BusinessUnit8', 0),
(9, N'KST_BusinessUnit9', 1)
SET IDENTITY_INSERT [KST_BusinessUnit] OFF

SET IDENTITY_INSERT [KST_PrivacyIncident] ON
INSERT INTO [KST_PrivacyIncident] ([Id], [IncidentNumber], [IncidentTitle], [RootCauseDetail], [NumberOfCustomersImpacted], [MitigationDetail], [CompletionType], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [BusinessUnit_Id], [IncidentMonth_Id], [IncidentType_Id], [IncidentYear_Id], [RemediationMonth_Id], [RemediationYear_Id], [ReportedToORMMonth_Id], [ReportedToORMYear_Id], [RootCause_Id], [Status_Id])
VALUES
(1, N'I160121', N'IncidentTitle11', N'RootCauseDetail1', 4, N'MitigationDetail21', 1, N'CreatedBy1', '12/20/2016', N'LastUpdatedBy1', '12/19/2016', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(2, N'I160102', N'IncidentTitle12', N'RootCauseDetail2', 7, N'MitigationDetail22', 0, N'CreatedBy2', '12/10/2016', N'LastUpdatedBy2', '12/09/2016', 2, 2, 2, 2, 2, 2, 2, 2, 2, 2),
(3, NULL, NULL, NULL, 1, NULL, 1, N'CreatedBy3', '11/30/2016', N'LastUpdatedBy23', '11/29/2016', 3, NULL, 3, NULL, NULL, NULL, NULL, NULL, 3, NULL),
(4, N'I16121', N'IncidentTitle4', N'RootCauseDetail4', 9, N'MitigationDetail4', 1, N'CreatedBy4', '11/20/2016', N'LastUpdatedBy4', '11/19/2016', 4, 4, 4, 4, 4, 4, 4, 4, 4, 4),
(5, N'I161226', N'IncidentTitle15', N'RootCauseDetail5', 4, N'MitigationDetail25', 1, N'CreatedBy5', '11/10/2016', N'LastUpdatedBy5', '11/09/2016', 5, 5, 5, 5, 5, 5, 5, 5, 5, 5),
(6, NULL, NULL, NULL, 6, NULL, 0, N'CreatedBy6', '10/31/2016', N'LastUpdatedBy6', '10/30/2016', 6, NULL, 6, NULL, NULL, NULL, NULL, NULL, 6, NULL),
(7, N'I161231', N'IncidentTitle7', N'RootCauseDetail7', 9, N'MitigationDetail7', 0, N'CreatedBy7', '10/21/2016', N'LastUpdatedBy7', '10/20/2016', 7, 7, 7, 7, 7, 7, 7, 7, 7, 7),
(8, N'I170221', N'IncidentTitle18', N'RootCauseDetail8', 4, N'MitigationDetail28', 1, N'CreatedBy8', '10/11/2016', N'LastUpdatedBy8', '10/10/2016', 1, 2, 3, 4, 5, 6, 7, 6, 5, 4),
(9, NULL, NULL, NULL, 4, NULL, 0, N'CreatedBy9', '10/01/2016', N'LastUpdatedBy29', '09/30/2016', 1, NULL, 2, NULL, NULL, NULL, NULL, NULL, 3, NULL)
SET IDENTITY_INSERT [KST_PrivacyIncident] OFF

INSERT INTO [KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue] ([PrivacyIncidentId], [PrivacyIncidentMitigationCodeValueId])
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 5),
(2, 6),
(2, 7),
(4, 8),
(4, 9)

SET IDENTITY_INSERT [KST_OperationalIncidentStatusValue] ON
INSERT INTO [KST_OperationalIncidentStatusValue] ([Id], [Value], [Enabled])
VALUES
(1, N'OperationalIncidentStatusValue1', 1),
(2, N'OperationalIncidentStatusValue2', 0),
(3, N'OperationalIncidentStatusValue3', 1),
(4, N'OperationalIncidentStatusValue4', 0),
(5, N'OperationalIncidentStatusValue5', 1),
(6, N'OperationalIncidentStatusValue6', 0),
(7, N'OperationalIncidentStatusValue7', 1),
(8, N'OperationalIncidentStatusValue8', 0),
(9, N'OperationalIncidentStatusValue9', 1)
SET IDENTITY_INSERT [KST_OperationalIncidentStatusValue] OFF

SET IDENTITY_INSERT [KST_OperationalIncidentSourceValue] ON
INSERT INTO [KST_OperationalIncidentSourceValue] ([Id], [Value], [Enabled])
VALUES
(1, N'OperationalIncidentSourceValue1', 1),
(2, N'OperationalIncidentSourceValue2', 0),
(3, N'OperationalIncidentSourceValue3', 1),
(4, N'OperationalIncidentSourceValue4', 0),
(5, N'OperationalIncidentSourceValue5', 1),
(6, N'OperationalIncidentSourceValue6', 0),
(7, N'OperationalIncidentSourceValue7', 1),
(8, N'OperationalIncidentSourceValue8', 0),
(9, N'OperationalIncidentSourceValue9', 1)
SET IDENTITY_INSERT [KST_OperationalIncidentSourceValue] OFF

SET IDENTITY_INSERT [KST_OperationalIncidentRootCauseValue] ON
INSERT INTO [KST_OperationalIncidentRootCauseValue] ([Id], [Value], [Enabled])
VALUES
(1, N'OperationalIncidentRootCauseValue1', 1),
(2, N'OperationalIncidentRootCauseValue2', 0),
(3, N'OperationalIncidentRootCauseValue3', 1),
(4, N'OperationalIncidentRootCauseValue4', 0),
(5, N'OperationalIncidentRootCauseValue5', 1),
(6, N'OperationalIncidentRootCauseValue6', 0),
(7, N'OperationalIncidentRootCauseValue7', 1),
(8, N'OperationalIncidentRootCauseValue8', 0),
(9, N'OperationalIncidentRootCauseValue9', 1)
SET IDENTITY_INSERT [KST_OperationalIncidentRootCauseValue] OFF

SET IDENTITY_INSERT [KST_OperationalIncidentReportedToGORMValue] ON
INSERT INTO [KST_OperationalIncidentReportedToGORMValue] ([Id], [Value], [Enabled])
VALUES
(1, N'OperationalIncidentReportedToGORMValue1', 1),
(2, N'OperationalIncidentReportedToGORMValue2', 0),
(3, N'OperationalIncidentReportedToGORMValue3', 1),
(4, N'OperationalIncidentReportedToGORMValue4', 0),
(5, N'OperationalIncidentReportedToGORMValue5', 1),
(6, N'OperationalIncidentReportedToGORMValue6', 0),
(7, N'OperationalIncidentReportedToGORMValue7', 1),
(8, N'OperationalIncidentReportedToGORMValue8', 0),
(9, N'OperationalIncidentReportedToGORMValue9', 1)
SET IDENTITY_INSERT [KST_OperationalIncidentReportedToGORMValue] OFF

SET IDENTITY_INSERT [KST_OperationalIncidentImpactValue] ON
INSERT INTO [KST_OperationalIncidentImpactValue] ([Id], [Value], [Enabled])
VALUES
(1, N'OperationalIncidentImpactValue1', 1),
(2, N'OperationalIncidentImpactValue2', 0),
(3, N'OperationalIncidentImpactValue3', 1),
(4, N'OperationalIncidentImpactValue4', 0),
(5, N'OperationalIncidentImpactValue5', 1),
(6, N'OperationalIncidentImpactValue6', 0),
(7, N'OperationalIncidentImpactValue7', 1),
(8, N'OperationalIncidentImpactValue8', 0),
(9, N'OperationalIncidentImpactValue9', 1)
SET IDENTITY_INSERT [KST_OperationalIncidentImpactValue] OFF

SET IDENTITY_INSERT [KST_FinancialExposureValue] ON
INSERT INTO [KST_FinancialExposureValue] ([Id], [Amount], [Type])
VALUES
(1, 1.1, 1),
(2, 1.2, 2),
(3, 1.3, 0),
(4, 1.4, 1),
(5, 1.5, 2),
(6, 1.6, 1),
(7, 1.7, 0),
(8, 1.8, 1),
(9, 1.9, 2)
SET IDENTITY_INSERT [KST_FinancialExposureValue] OFF

SET IDENTITY_INSERT [KST_OperationalIncident] ON
INSERT INTO [KST_OperationalIncident] ([Id], [IncidentNumber], [OperationalFinding], [RootCauseDetail], [MitigationStrategy], [CompletionType], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [BusinessUnit_Id], [FinancialExposure_Id], [IncidentMonth_Id], [IncidentYear_Id], [RemediationMonth_Id], [RemediationYear_Id], [ReportedToGORM_Id], [ReportedToORMMonth_Id], [ReportedToORMYear_Id], [RootCause_Id], [Source_Id], [Status_Id])
VALUES
(1, N'O16017', N'OperationalFinding11', N'RootCauseDetail1', N'MitigationStrategy1', 0, N'CreatedBy1', '12/20/2016', N'LastUpdatedBy1', '12/19/2016', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(2, N'O160121', N'OperationalFinding12', N'RootCauseDetail2', N'MitigationStrategy2', 1, N'CreatedBy2', '12/10/2016', N'LastUpdatedBy2', '12/09/2016', 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2),
(3, NULL, NULL, NULL, NULL, 0, N'CreatedBy3', '11/30/2016', N'LastUpdatedBy3', '11/29/2016', 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL),
(4, N'O160114', N'OperationalFinding4', N'RootCauseDetail4', N'MitigationStrategy4', 0, N'CreatedBy4', '11/20/2016', N'LastUpdatedBy4', '11/19/2016', 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4),
(5, N'O160111', N'OperationalFinding15', N'RootCauseDetail5', N'MitigationStrategy5', 1, N'CreatedBy5', '11/10/2016', N'LastUpdatedBy5', '11/09/2016', 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5),
(6, NULL, NULL, NULL, NULL, 1, N'CreatedBy6', '10/31/2016', N'LastUpdatedBy6', '10/30/2016', 6, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL),
(7, N'O16122', N'OperationalFinding17', N'RootCauseDetail7', N'MitigationStrategy7', 0, N'CreatedBy7', '10/21/2016', N'LastUpdatedBy7', '10/20/2016', 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7),
(8, N'O16121', N'OperationalFinding18', N'RootCauseDetail8', N'MitigationStrategy8', 1, N'CreatedBy8', '10/11/2016', N'LastUpdatedBy8', '10/10/2016', 1, 2, 3, 4, 5, 6, 7, 6, 5, 4, 3, 2),
(9, NULL, NULL, NULL, NULL, 1, N'CreatedBy19', '10/01/2016', N'LastUpdatedBy9', '09/30/2016', 1, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
SET IDENTITY_INSERT [KST_OperationalIncident] OFF

INSERT INTO [KST_OperationalIncident_OperationalIncidentImpactValue] ([OperationalIncidentId], [OperationalIncidentImpactValueId])
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 5),
(2, 6),
(2, 7),
(4, 8),
(4, 9)

SET IDENTITY_INSERT [KST_LowPerformanceReason] ON
INSERT INTO [KST_LowPerformanceReason] ([Id], [Name])
VALUES
(1, N'KST_LowPerformanceReason1'),
(2, N'KST_LowPerformanceReason2'),
(3, N'KST_LowPerformanceReason3'),
(4, N'KST_LowPerformanceReason4'),
(5, N'KST_LowPerformanceReason5'),
(6, N'KST_LowPerformanceReason6'),
(7, N'KST_LowPerformanceReason7'),
(8, N'KST_LowPerformanceReason8'),
(9, N'KST_LowPerformanceReason9')
SET IDENTITY_INSERT [KST_LowPerformanceReason] OFF

SET IDENTITY_INSERT [KST_DecimalOrPercentageValue] ON
INSERT INTO [KST_DecimalOrPercentageValue] ([Id], [Value], [Percentage], [AdditionalNote])
VALUES
(1, 1.2, 1, N'AdditionalNote1'),
(2, 2.1, 0, N'AdditionalNote2'),
(3, 1.3, 1, NULL),
(4, 2.4, 0, N'AdditionalNote4'),
(5, 1.9, 1, N'AdditionalNote5'),
(6, 1.3, 0, NULL),
(7, 1.7, 1, N'AdditionalNote7'),
(8, 4.3, 0, N'AdditionalNote8'),
(9, 2.3, 1, NULL)
SET IDENTITY_INSERT [KST_DecimalOrPercentageValue] OFF

SET IDENTITY_INSERT [KST_KPIScorecardItem] ON
INSERT INTO [KST_KPIScorecardItem] ([Id], [KeyPerformanceIndicator], [TargetHigh], [Enabled], [Type], [ServiceLevel_Id], [Threshold_Id])
VALUES
(1, N'KeyPerformanceIndicator1', 1, 1, 0, 1, 3),
(2, N'KeyPerformanceIndicator2', 0, 0, 1, 2, 5),
(3, NULL, 1, 1, 2, 3, 3),
(4, N'KeyPerformanceIndicator4', 0, 0, 3, 7, 4),
(5, N'KeyPerformanceIndicator5', 1, 1, 4, 6, 1),
(6, NULL, 0, 0, 0, 6, 6),
(7, N'KeyPerformanceIndicator7', 1, 1, 1, 4, 5),
(8, N'KeyPerformanceIndicator8', 0, 0, 2, 5, 2),
(9, NULL, 1, 1, 3, 3, 9)
SET IDENTITY_INSERT [KST_KPIScorecardItem] OFF

SET IDENTITY_INSERT [KST_KPIScore] ON
INSERT INTO [KST_KPIScore] ([Id], [Score], [ScorecardItem_Id])
VALUES
(1, 1.1, 1),
(2, 1.2, 2),
(3, 1.3, 3),
(4, 1.4, 4),
(5, 1.4, 5),
(6, 1.29, 6),
(7, 1.7, 7),
(8, 1.9, 8),
(9, 1.3, 9),
(11, 2.0, 1),
(12, 2.5, 2),
(13, 1.1, 3),
(14, 2.4, 4),
(15, 2.2, 5),
(16, 3.6, 6),
(17, 1.8, 7),
(18, 2.8, 8),
(19, 0.9, 9)
SET IDENTITY_INSERT [KST_KPIScore] OFF

INSERT INTO [KST_KPIVolumeScore] ([Id], [VolumeType_Id], [Volume])
VALUES
(11, 1, 3.1),
(12, 2, 3.2),
(13, NULL, 3.3),
(14, 4, 3.4),
(15, 5, 3.5),
(16, NULL, 3.6),
(17, 7, 3.7),
(18, 8, 3.8),
(19, NULL, 3.9)

INSERT INTO [KST_KPIScore_LowPerformanceReason] ([KPIScoreId], [LowPerformanceReasonId])
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 5),
(2, 6),
(2, 7),
(4, 8),
(4, 9),
(11, 9),
(11, 8),
(11, 7),
(11, 6),
(12, 5),
(12, 4),
(12, 3),
(14, 2),
(14, 1)

SET IDENTITY_INSERT [KST_BusinessUnitKPIScorecard] ON
INSERT INTO [KST_BusinessUnitKPIScorecard] ([Id], [DueDate], [CompletionType], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [BusinessUnit_Id], [Month_Id], [Status_Id], [Year_Id])
VALUES
(1, '12/20/2016', 1, N'CreatedBy1', '12/19/2016', N'LastUpdatedBy1', '12/18/2016', 1, 1, 1, 1),
(2, '12/31/2016', 1, N'CreatedBy2', '12/09/2016', N'LastUpdatedBy2', '12/08/2016', 2, 2, 2, 2),
(3, '11/30/2016', 0, N'CreatedBy3', '11/29/2016', N'LastUpdatedBy3', '11/28/2016', 3, 3, 3, 3),
(4, '11/20/2016', 1, N'CreatedBy4', '11/19/2016', N'LastUpdatedBy4', '11/18/2016', 2, 4, 4, 2),
(5, '11/10/2016', 1, N'CreatedBy5', '11/09/2016', N'LastUpdatedBy5', '11/08/2016', 5, 5, 5, 5),
(6, '10/31/2016', 0, N'CreatedBy6', '10/30/2016', N'LastUpdatedBy6', '10/29/2016', 6, 6, 6, 6),
(7, '12/31/2016', 0, N'CreatedBy7', '10/20/2016', N'LastUpdatedBy7', '10/19/2016', 7, 7, 7, 7),
(8, '10/11/2016', 1, N'CreatedBy8', '10/10/2016', N'LastUpdatedBy8', '10/09/2016', 2, 5, 3, 2),
(9, '12/31/2016', 1, N'CreatedBy9', '09/30/2016', N'LastUpdatedBy9', '09/29/2016', 4, 7, 6, 2)
SET IDENTITY_INSERT [KST_BusinessUnitKPIScorecard] OFF

INSERT INTO [KST_BusinessUnitKPIScorecard_SecurityScore] ([BusinessUnitKPIScorecardId], [KPIScoreId])
VALUES
(1, 3),
(1, 1),
(1, 6),
(1, 7),
(2, 9),
(2, 8),
(2, 5),
(4, 4),
(4, 2)

INSERT INTO [KST_BusinessUnitKPIScorecard_OperationPerformanceScore] ([BusinessUnitKPIScorecardId], [KPIVolumeScoreId])
VALUES
(1, 11),
(2, 12),
(1, 13),
(1, 14),
(2, 15),
(2, 16),
(2, 17),
(4, 18),
(4, 19)

INSERT INTO [KST_BusinessUnitKPIScorecard_FinancialIndicatorScore] ([BusinessUnitKPIScorecardId], [KPIScoreId])
VALUES
(1, 5),
(1, 7),
(1, 9),
(1, 1),
(3, 2),
(2, 3),
(2, 4),
(4, 6),
(4, 8)

INSERT INTO [KST_BusinessUnitKPIScorecard_ConcentrationRiskScore] ([BusinessUnitKPIScorecardId], [KPIScoreId])
VALUES
(1, 8),
(1, 7),
(1, 6),
(2, 5),
(2, 4),
(2, 2),
(2, 3),
(4, 9),
(4, 1)

INSERT INTO [KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore] ([BusinessUnitKPIScorecardId], [KPIScoreId])
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 5),
(2, 6),
(2, 7),
(4, 8),
(4, 9)

SET IDENTITY_INSERT [KST_AuditFindingStatusValue] ON
INSERT INTO [KST_AuditFindingStatusValue] ([Id], [Value], [Enabled])
VALUES
(1, N'AuditFindingStatusValue1', 1),
(2, N'AuditFindingStatusValue2', 0),
(3, N'AuditFindingStatusValue3', 1),
(4, N'AuditFindingStatusValue4', 0),
(5, N'AuditFindingStatusValue5', 1),
(6, N'AuditFindingStatusValue6', 0),
(7, N'AuditFindingStatusValue7', 1),
(8, N'AuditFindingStatusValue8', 0),
(9, N'AuditFindingStatusValue9', 1)
SET IDENTITY_INSERT [KST_AuditFindingStatusValue] OFF

SET IDENTITY_INSERT [KST_AuditFindingSourceValue] ON
INSERT INTO [KST_AuditFindingSourceValue] ([Id], [Value], [Enabled])
VALUES
(1, N'AuditFindingSourceValue1', 1),
(2, N'AuditFindingSourceValue2', 0),
(3, N'AuditFindingSourceValue3', 1),
(4, N'AuditFindingSourceValue4', 0),
(5, N'AuditFindingSourceValue5', 1),
(6, N'AuditFindingSourceValue6', 0),
(7, N'AuditFindingSourceValue7', 1),
(8, N'AuditFindingSourceValue8', 0),
(9, N'AuditFindingSourceValue9', 1)
SET IDENTITY_INSERT [KST_AuditFindingSourceValue] OFF

SET IDENTITY_INSERT [KST_AuditFindingRootCauseValue] ON
INSERT INTO [KST_AuditFindingRootCauseValue] ([Id], [Value], [Enabled])
VALUES
(1, N'AuditFindingSourceValue1', 1),
(2, N'AuditFindingSourceValue2', 0),
(3, N'AuditFindingSourceValue3', 1),
(4, N'AuditFindingSourceValue4', 0),
(5, N'AuditFindingSourceValue5', 1),
(6, N'AuditFindingSourceValue6', 0),
(7, N'AuditFindingSourceValue7', 1),
(8, N'AuditFindingSourceValue8', 0),
(9, N'AuditFindingSourceValue9', 1)
SET IDENTITY_INSERT [KST_AuditFindingRootCauseValue] OFF

SET IDENTITY_INSERT [KST_AuditFindingReportedToGORMValue] ON
INSERT INTO [KST_AuditFindingReportedToGORMValue] ([Id], [Value], [Enabled])
VALUES
(1, N'AuditFindingReportedToGORMValue1', 1),
(2, N'AuditFindingReportedToGORMValue2', 0),
(3, N'AuditFindingReportedToGORMValue3', 1),
(4, N'AuditFindingReportedToGORMValue4', 0),
(5, N'AuditFindingReportedToGORMValue5', 1),
(6, N'AuditFindingReportedToGORMValue6', 0),
(7, N'AuditFindingReportedToGORMValue7', 1),
(8, N'AuditFindingReportedToGORMValue8', 0),
(9, N'AuditFindingReportedToGORMValue9', 1)
SET IDENTITY_INSERT [KST_AuditFindingReportedToGORMValue] OFF

SET IDENTITY_INSERT [KST_AuditFindingImpactValue] ON
INSERT INTO [KST_AuditFindingImpactValue] ([Id], [Value], [Enabled])
VALUES
(1, N'AuditFindingImpactValue1', 1),
(2, N'AuditFindingImpactValue2', 0),
(3, N'AuditFindingImpactValue3', 1),
(4, N'AuditFindingImpactValue4', 0),
(5, N'AuditFindingImpactValue5', 1),
(6, N'AuditFindingImpactValue6', 0),
(7, N'AuditFindingImpactValue7', 1),
(8, N'AuditFindingImpactValue8', 0),
(9, N'AuditFindingImpactValue9', 1)
SET IDENTITY_INSERT [KST_AuditFindingImpactValue] OFF

SET IDENTITY_INSERT [KST_AuditFinding] ON
INSERT INTO [KST_AuditFinding] ([Id], [AuditFindingNumber], [AuditTitle], [RootCauseDetail], [MitigationStrategy], [CompletionType], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [AuditMonth_Id], [AuditYear_Id], [BusinessUnit_Id], [RemediationMonth_Id], [RemediationYear_Id], [ReportedToGORM_Id], [ReportedToORMMonth_Id], [ReportedToORMYear_Id], [RootCause_Id], [Source_Id], [Status_Id])
VALUES
(1, N'A160121', N'AuditTitle1', N'RootCauseDetail1', N'MitigationStrategy1', 0, N'CreatedBy1', '12/20/2016', N'LastUpdatedBy1', '12/19/2016', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1),
(2, N'A16015', N'AuditTitle2', N'RootCauseDetail2', N'MitigationStrategy2', 1, N'CreatedBy2', '12/10/2016', N'LastUpdatedBy2', '12/09/2016', 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2),
(3, NULL, N'AuditTitle3', NULL, NULL, 1, N'CreatedBy3', '11/30/2016', N'LastUpdatedBy3', '11/29/2016', NULL, NULL, 3, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL),
(4, N'A160113', N'AuditTitile4', N'RootCauseDetail4', N'MitigationStrategy4', 0, N'CreatedBy4', '11/20/2016', N'LastUpdatedBy4', '11/19/2016', 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4),
(5, N'A1612001', N'AuditTitle5', N'RootCauseDetail5', N'MitigationStrategy5', 0, N'CreatedBy5', '11/10/2016', N'LastUpdatedBy5', '11/09/2016', 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5),
(6, NULL, N'AuditTitle6', NULL, NULL, 1, N'CreatedBy6', '10/31/2016', N'LastUpdatedBy6', '10/30/2016', NULL, NULL, 6, NULL, NULL, NULL, NULL, NULL, 6, NULL, NULL),
(7, N'A1612015', N'AuditTitile7', N'RootCauseDetail7', N'MitigationStrategy7', 1, N'CreatedBy7', '10/21/2016', N'LastUpdatedBy7', '10/20/2016', 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7),
(8, N'A1612003', N'AuditTitle8', N'RootCauseDetail8', N'MitigationStrategy8', 0, N'CreatedBy8', '10/11/2016', N'LastUpdatedBy8', '10/10/2016', 1, 2, 3, 4, 5, 6, 7, 6, 5, 4, 3),
(9, NULL, N'AuditTitle9', NULL, NULL, 0, N'CreatedBy9', '10/01/2016', N'LastUpdatedBy9', '09/30/2016', NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
SET IDENTITY_INSERT [KST_AuditFinding] OFF

INSERT INTO [KST_AuditFinding_AuditFindingImpactValue] ([AuditFindingId], [AuditFindingImpactValueId])
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 5),
(2, 6),
(2, 7),
(4, 8),
(4, 9)

SET NOCOUNT OFF
