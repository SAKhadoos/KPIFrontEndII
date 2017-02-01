SET NOCOUNT ON
SET DATEFORMAT mdy

Declare @CoeusOwnerUser1 NVARCHAR(200);
Declare @BUFuncApprover1 NVARCHAR(200);
Declare @BUFuncApprover2 NVARCHAR(200);
Declare @BUFuncApprover3 NVARCHAR(200);
Declare @BURiskManApprover1 NVARCHAR(200);
Declare @BURiskManApprover2 NVARCHAR(200);
DECLARE @DivisionalManApprover1 NVARCHAR(200);
DECLARE @CoeusAdmin NVARCHAR(200);

SET @CoeusOwnerUser1='CoeusOwnerUser1'; -- this is required and should be valid user
SET @BUFuncApprover1='CoeusBUFuncApp1'; -- this is required and should be valid user
SET @BUFuncApprover2='CoeusBUFuncApp2';
SET @BUFuncApprover3='CoeusBUFuncApp3';
SET @BURiskManApprover1='CoeusRiskManager'; -- this is required and should be valid user
SET @BURiskManApprover2='CoeusRiskManager2';
SET @DivisionalManApprover1='CoeusDivManager'; -- this is required and should be valid user
SET @CoeusAdmin='CoeusAdminUser'; -- this is required and should be valid user

DELETE [ActionPermission]
DELETE [AuditRecord]
DELETE [User_BusinessUnit]
DELETE [UserMappingInfo]
DELETE [Assessment_Product]
DELETE [ControlAssessment_ControlDesign]
DELETE [ControlAssessment_ControlTrigger]
DELETE [ControlAssessment_TestingFrequency]
DELETE [ControlAssessment]
DELETE [ControlDesign]
DELETE [ControlFrequency]
DELETE [ControlTrigger]
DELETE [CoreProcess_ControlType]
DELETE [ProcessRisk_ControlType]
DELETE [ControlType]
DELETE [FunctionPerformedSite]
DELETE [FutureFunctionChanges]
DELETE [KeyControlsMaturity]
DELETE [KPISLAAssessment]
DELETE [Percentage]
DELETE [PriorFunctionChanges]
DELETE [FunctionChange]
DELETE [ChangeType]
DELETE [ProcessControlAssessment_RiskImpact]
DELETE [ProcessRiskAssessment]
DELETE [FunctionalAreaProcessAssessment]
DELETE [Assessment]
DELETE [AssessmentStatus]
DELETE [AssessmentType]
DELETE [Department]
DELETE [DepartmentHead]
DELETE [FunctionalAreaOwner]
DELETE [ProcessControlAssessment]
DELETE [LikelihoodOfOccurrence]
DELETE [SubProcessRisk]
DELETE [CoreProcess]
DELETE [ProcessRisk]
DELETE [Product]
DELETE [RiskExposure]
DELETE [RiskImpact]
DELETE [Site]
DELETE [SLA]
DELETE [KPI]
DELETE [KPICategory]
DELETE [TestingFrequency]
DELETE [FunctionalArea]
DELETE [BusinessUnit]
DELETE [RiskScoreRange]
DELETE [Category]
DELETE [Token]

INSERT INTO [Token] ([Username], [TokenValue], [ExpirationDate])
VALUES
(N'CoeusOwnerUser1', N'e0d5ba3f-2459-4ea5-a30a-b0addf99e0f5', '12/12/9999'),
(N'CoeusBUFuncApp1', N'e1d5ba3f-2459-4ea5-a30a-b0addf99e0f5', '12/12/9999'),
(N'CoeusRiskManager', N'e2d5ba3f-2459-4ea5-a30a-b0addf99e0f5', '12/12/9999'),
(N'CoeusDivManager', N'e3d5ba3f-2459-4ea5-a30a-b0addf99e0f5', '12/12/9999'),
(N'CoeusAdminUser', N'e4d5ba3f-2459-4ea5-a30a-b0addf99e0f5', '12/12/9999')

SET IDENTITY_INSERT [RIskScoreRange] ON 
INSERT INTO  [RiskScoreRange]([Id], [Name], [Color], [LowerBound], [UpperBound], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, 'Low', '#00ff00', 0, 5.4, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, 'Minor', '#ffff00', 5.5, 16.2,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, 'Moderate', '#ffbf00', 16.3, 32.4, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, 'High', '#ff0000', 32.5, null,  1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, 'High', '#ff0000', 32.5, null,  1, 4, 0, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [RIskScoreRange] OFF

SET IDENTITY_INSERT [Category] ON
INSERT INTO [Category] ([Id], [Name], [Weight], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'KPI''s / SLA''s',  0, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Functional Area Processes',65, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Corporate & Divisional Training', 5, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Business Continuity & Disaster Recovery',  5, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Records Management', 5, 1,5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Information Security', 10, 1,6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Data Privacy & Protection', 10, 1,7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, N'Data Privacy & Protection', 10, 1,7, 0, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [Category] OFF

SET IDENTITY_INSERT [KeyControlsMaturity] ON
INSERT INTO [KeyControlsMaturity] ([Id], [Name], [Value], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, 'Well Developed', '0.1', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, 'Partially Developed/Requires Improvement', '0.6',1 , 2, 1,@CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, 'Under Developed/Weak', '1',1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, 'Under Developed/Weak', '1',1, 3, 0, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [KeyControlsMaturity] OFF

SET IDENTITY_INSERT [BusinessUnit] ON
INSERT INTO [BusinessUnit] ([Id], [Name], [Category_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Annuities',null,  1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Insurance',null,  1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Investments/JHSS',null, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'RPS',null,  1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Shared Services',null,  1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [BusinessUnit] OFF

SET IDENTITY_INSERT [UserMappingInfo] ON
INSERT INTO [UserMappingInfo] ([Id], [Username], [Role], [IsActive])
VALUES
(1, @CoeusOwnerUser1, 0,1),
(2, @BUFuncApprover1, 1,1),
(3, @BUFuncApprover2, 1,1),
(4, @BUFuncApprover3, 1,1),
(5, @BURiskManApprover1, 2,1),
(6, @BURiskManApprover2, 2,1),
(7, @DivisionalManApprover1, 3,1),
(8, @CoeusAdmin, 4,1);
SET IDENTITY_INSERT [UserMappingInfo] OFF

INSERT INTO [User_BusinessUnit](UserId, BusinessUnitId)
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(2,1),
(2,2),
(2,3),
(2,4),
(2,5),
(3,1),
(3,2),
(3,3),
(3,4),
(3,5),
(4,1),
(4,2),
(4,3),
(4,4),
(4,5),
(5,1),
(5,2),
(5,3),
(5,4),
(5,5),
(6,1),
(6,2),
(6,3),
(6,4),
(6,5),
(7,1),
(7,2),
(7,3),
(7,4),
(7,5),
(8,1),
(8,2),
(8,3),
(8,4),
(8,5);

SET IDENTITY_INSERT [Product] ON
INSERT INTO [Product] ([Id], [Name], [BusinessUnitId], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Fixed Annuity', 1, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'PAR', 1, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Structured Settlements', 1, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Variable Annuity', 1, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),

(5, N'Life', 2, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'LTC', 2, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Life w/LTC rider', 2, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),

(8, N'Mutual Funds', 3, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9, N'Signature', 4, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, N'TRS/Enterprise', 4, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),

(11, N'Annuities', 5, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, N'Insurance', 5, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(13, N'Signator', 5, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(14, N'Safe Access Account', 5, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [Product] OFF

SET IDENTITY_INSERT [Department] ON
INSERT INTO [Department] ([Id], [Name], [BusinessUnitId],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Annuities Administration', 1 , 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Client Output Services, eDelivery & Vendor Management', 1, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Dealer & Institutional Services', 1, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Institutional Contract Services', 1, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Intake Operatioins & Business Solutions', 1, 1,5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),

(6, N'Financial Control', 2, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Claims', 2, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, N'New Business Operations', 2, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9, N'Policy Holder Services', 2, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, N'Operational Risk Management', 2, 1,5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),

(11, N'Compliance (Cmpl)', 3, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, N'Product Support (PdSp)', 3, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(13, N'Adjustments (Adj)', 3, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(14, N'Service Operations (SvOp)', 3, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(15, N'Correspondence (Corr)', 3, 1,5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(16, N'Dealer & Institutional Services (DlSv)', 3, 1,6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(17, N'Client Output Services (COS)', 3, 1,7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(18, N'Control (Cntl)', 3, 1,8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(19, N'Business Support Services (BSS)', 3, 1,9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(20, N'Finance (Fin)', 3, 1,10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(21, N'Vendor Management (VdMg)', 3, 1,11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),

(22, N'Business Administration Group', 4, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(23, N'Defined Benefit Operations, Trading Operations, Technical Support and Ops Mgmt Information', 4, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(24, N'Implementations and Enterprise/TRS Client Services', 4, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(25, N'Operations Risk Management', 4, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(26, N'Process Improvement', 4, 1,5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(27, N'Signature Client Services, Participant Services and Ops Learning & Comm', 4, 1,6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(28, N'Strategic Planning & Projects', 4, 1,7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),

(29, N'Intake Operatioins & Business Solutions', 5, 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(30, N'Shared Services Administration', 5, 1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(31, N'Shared Services Contact Center', 5, 1,3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(32, N'Signator Shared Services', 5, 1,4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [Department] OFF

SET IDENTITY_INSERT [DepartmentHead] ON
INSERT INTO [DepartmentHead] ([Id], [Name], [BusinessUnitId], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1,  @BUFuncApprover1, 1 ,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2,  @BUFuncApprover2, 1 ,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3,  @BUFuncApprover3, 1 ,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4,  @BUFuncApprover1, 2 ,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5,  @BUFuncApprover2, 2 ,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6,  @BUFuncApprover3, 2 ,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7,  @BUFuncApprover1, 3 ,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8,  @BUFuncApprover2, 3 ,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9,  @BUFuncApprover3, 3 ,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, @BUFuncApprover1, 4, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(11, @BUFuncApprover2, 4, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, @BUFuncApprover3, 5, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [DepartmentHead] OFF

SET IDENTITY_INSERT [FunctionalArea] ON
INSERT INTO [FunctionalArea] ([Id], [Name], [BusinessUnitId] ,[Category_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Account Maintenance', 1, null, 1,  1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Annuitizations', 1, null, 1,  2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Annuity Business Automation', 1, null, 1,  3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Benefits', 1, null, 1,  4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Client Output Services', 1, null, 1,  5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Commissions', 1, null, 1,  6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Contract Administration', 1, null, 1,  7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, N'Contract Financial Reporting', 1, null, 1,  8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9, N'Contract Research & Accounting', 1, null, 1,  9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, N'Death Benefit Administration (Fixed)', 1, null, 1,  10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(11, N'Death Benefit Administration (Retail)', 1, null, 1, 	11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, N'Disbursements', 1, null, 1,  12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(13, N'Inforce', 1, null, 1,  13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(14, N'Licensing', 1, null, 1,  14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(15, N'Reclaim & Cash Control', 1, null, 1,  15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(16, N'Reconciliation', 1, null, 1,  16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(17, N'Structured Settlements', 1, null, 1,  17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(18, N'Tax & Adjustment', 1, null, 1,  18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(19, N'Accounts Payable  and Control, Debt Management', 2, null, 1,  1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(20, N'Case Management', 2, null, 1,  2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(21, N'Collections - Life Renewal & Group LTC', 2, null, 1,  3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(22, N'Collections - Retail LTC', 2, null, 1,  4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(23, N'Complex LTC', 2, null, 1,  5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(24, N'Control', 2, null, 1,  6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(25, N'Core LTC', 2, null, 1,  7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(26, N'Disbursements & Distribution', 2, null, 1, 8 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(27, N'Front End', 2, null, 1,  9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(28, N'GLTC Account', 2, null, 1,  10,1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(29, N'Group Trust Admin', 2, null, 1,  11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(30, N'Illustrations', 2, null, 1,  12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(31, N'Initial Payments', 2, null, 1,  13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(32, N'Issue', 2, null, 1,  14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(33, N'Licensing', 2, null, 1,  15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(34, N'Life Claims', 2, null, 1,  16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(35, N'Life Special Billing', 2, null, 1,  17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(36, N'LTC Claims - Adjudication', 2, null, 1, 18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999' ),
(37, N'LTC Claims - Appeals', 2, null, 1,  19, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(38, N'LTC Claims - Benefit Eligibility', 2, null, 1,  20, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(39, N'LTC Claims - Benefit Eligibility QA', 2, null, 1,  21, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(40, N'LTC Claims - Boston Payment', 2, null, 1,  22, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(41, N'LTC Claims - Business Integrity Unit', 2, null, 1,  23, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(42, N'LTC Claims - Claim Initiation Unit', 2, null, 1,  24, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(43, N'LTC Claims - Clinical Thought Leadership', 2, null, 1,  25, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(44, N'LTC Claims - Complaints, Internal Audit, Market Conduct', 2, null, 1,  26, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(45, N'LTC Claims - Payment Quality Assurance', 2, null, 1,  27, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(46, N'LTC Claims - Policy Oversight', 2, null, 1,  28, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(47, N'LTC Claims - Provider Eligibility', 2, null, 1,  29, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(48, N'LTC Claims - Service Process Improvement', 2, null, 1,  30, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(49, N'LTC Claims - Training & Change Readiness', 2, null, 1,  31, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(50, N'NBCC', 2, null, 1,  32, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(51, N'Policy Change', 2, null, 1,  33, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(52, N'Product Consultation', 2, null, 1,  34, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(53, N'Registry', 2, null, 1,  35, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(54, N'Replacements', 2, null, 1,  36, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(55, N'Re-Rate Program', 2, null, 1,  37, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(56, N'Risk Management', 2, null, 1,  38, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(57, N'Specialty Products & Distribution', 2, null, 1,  39, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(58, N'System Consultation', 2, null, 1,  40, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(59, N'Tax Production', 2, null, 1,  41, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(60, N'Titles', 2, null, 1,  42, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(61, N'Cmpl - Administrative Matters', 3, null, 1,  1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(62, N'Cmpl - AML/ATF', 3, null, 1,  2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(63, N'Cmpl - Fingerprinting', 3, null, 1,  3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(64, N'Cmpl - Fraud', 3, null, 1,  4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(65, N'Cmpl - Frequent Trading', 3, null, 1,  5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(66, N'Cmpl - ID Administration', 3, null, 1,  6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(67, N'Cmpl - Lost Shareholder Searches', 3, null, 1,  7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(68, N'Cmpl - Escheatment', 3, null, 1,  8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(69, N'Cmpl - Withholding Filings', 3, null, 1,  9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(70, N'Cmpl - Retirement Plan Documents', 3, null, 1,  10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(71, N'Cmpl - Information Reporting', 3, null, 1,  11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(72, N'Cntl - Blue Sky', 3, null, 1,  12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(73, N'Cntl - Dividend Processing', 3, null, 1,  13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(74, N'Cntl - Half Penny Breakage', 3, null, 1,  14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(75, N'Cntl - Commission', 3, null, 1,  15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(76, N'Cntl - Trail Commission', 3, null, 1,  16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(77, N'Cntl - Withholding Remittance', 3, null, 1,  16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(78, N'Cntl - Pricing', 3, null, 1,  18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(79, N'Cntl - Cap Stock', 3, null, 1,  19, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(80, N'Cntl - Wires and Manual Checks', 3, null, 1,  20, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(81, N'Cntl - DDA Reconciliation', 3, null, 1,  21, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(82, N'DlSv - Financial Transactions', 3, null, 1,  22, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(83, N'DlSv - Non-Financial Transactions', 3, null, 1,  23, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(84, N'DlSv - DTCC Cusip Setup', 3, null, 1,  24, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(85, N'DlSv - MF Profile II', 3, null, 1,  25, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(86, N'DlSv - UFID Settings', 3, null, 1,  26, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(87, N'DlSv - Omnibus Firms', 3, null, 1,  27, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(88, N'DlSv - CIP', 3, null, 1,  28, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(89, N'DlSv - Late Trading', 3, null, 1, 29, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999' ),
(90, N'DlSv - Social Code Review', 3, null, 1,  30, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(91, N'SvOp - Financial & Non-Financial Transactions', 3, null, 1,  31, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(92, N'SvOps - Contact Center', 3, null, 1,  32, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(93, N'COS - Prospectus Refresh', 3, null, 1,  33, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(94, N'COS - Prospectus PSI', 3, null, 1,  34, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(95, N'COS - Confirms/Statements/Checks', 3, null, 1,  35, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(96, N'COS - Regulatory Mailings', 3, null, 1,  36, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(97, N'PdSp - System Updates', 3, null, 1,  37, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(98, N'Fin - Invoice Processing', 3, null, 1, 38 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(99, N'Fin - TA Monthly Invoice', 3, null, 1,  39, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(100, N'Fin - Expense Accrual', 3, null, 1, 40 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(101, N'Adj - Financial Transactions', 3, null, 1,  41, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(102, N'Adj - Non-Financial Transactions', 3, null, 1,  42, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(103, N'Adj - Adtrans', 3, null, 1,  43, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(104, N'Adj - LOI Recalculations', 3, null, 1,  44, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(105, N'Adj - B to A Roll Kickers', 3, null, 1,  45, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(106, N'Adj - Bad Price Processing', 3, null, 1, 46, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999' ),
(107, N'Adj - Tax Lot Maintenance', 3, null, 1,  47, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(108, N'BSS - ID Administration', 3, null, 1,  48, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(109, N'BSS - FI Data Match', 3, null, 1,  49, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(110, N'New Business/New Contract Set-up', 4, null, 1,  1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(111, N'Contract Data Changes Managed by Operations', 4, null, 1, 2 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(112, N'Broker Set-up and Maintenance', 4, null, 1, 3 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(113, N'RIA Set-up and Maintenance', 4, null, 1,  4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(114, N'Contract Data Changes - Managed by Pricing', 4, null, 1,  5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(115, N'Cash Receipts', 4, null, 1,  6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(116, N'Participant Account Set-up and Maintenance', 4, null, 1,  7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(117, N'Disbursements', 4, null, 1,  8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(118, N'PERA administration', 4, null, 1,  9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(119, N'Participant Services', 4, null, 1,  10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(120, N'Corrections', 4, null, 1, 11 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(131, N'Valuation of Sub-account units', 4, null, 1, 12 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(132, N'Purchases and Sales of Investments', 4, null, 1,  13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(133, N'Contract Reporting - Error Handling', 4, null, 1,  14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(134, N'Participant Reporting - Production ', 4, null, 1,  15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(135, N'Loans', 4, null, 1,  16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(136, N'Trustee Fees', 4, null, 1,  17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(137, N'Contact Management', 4, null, 1,  18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(138, N'Allocation Processing', 4, null, 1,  19, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(139, N'Contract Discontinuance/Termination', 4, null, 1,  20, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(140, N'Operations Compliance', 4, null, 1,  21, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(141, N'Plan Data', 4, null, 1,  22, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(142, N'Participant Census Data', 4, null, 1,  23, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(143, N'US WA Business Procedures', 4, null, 1, 24 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(144, N'Tax form production (1099R, etc)', 4, null, 1,  25, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(145, N'Payroll Services', 4, null, 1,  26, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(146, N'Abandoned Property', 5, null, 1, 1 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(147, N'Annuities & Fixed Products Contact Center', 5, null, 1,  2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(148, N'BD Operations & MBPS Governance', 5, null, 1,  3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(149, N'Data Integrity', 5, null, 1,  4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(150, N'Death Match', 5, null, 1, 5 , 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(151, N'Indexing', 5, null, 1,  6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(152, N'Licensing, Contracting & Compensation', 5, null, 1,  7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(153, N'Life Insurance Contact Center', 5, null, 1,  8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(154, N'LTC Contact Center', 5, null, 1,  9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(155, N'Metrics Reporting & Risk Management', 5, null, 1,  10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(156, N'Records Management & Imaging Services', 5, null, 1,  11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(157, N'Returned Mail (RPO)', 5, null, 1,  12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(158, N'JH Commitment', 5, null, 1,  13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(159, N'Safe Access Account', 5, null, 1,  14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(160, N'Shared Services Control', 5, null, 1,  15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(161, N'Thorough Search', 5, null, 1,  16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(162, N'TIN Match', 5, null, 1,  17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(163, N'Unclaimed Property Remittance', 5, null, 1, 18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [FunctionalArea] OFF

SET IDENTITY_INSERT [TestingFrequency] ON
INSERT INTO [TestingFrequency] ([Id], [Name],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, 'Business Area - Ad Hoc', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, 'Business Area - Daily', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, 'Business Area - Weekly', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, 'Business Area - Monthly', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, 'Business Area - Quarterly', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, 'Business Area - Semi-Annual', 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, 'Business Area - Annual or Greater', 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, 'Compliance - Monthly', 1, 8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9, 'Compliance - Quarterly', 1, 9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, 'Compliance - Semi-Annual', 1, 10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(11, 'Compliance - Annual or Greater', 1, 11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, 'Internal Audit - Annual or Greater', 1, 12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(13, 'External - Monthly', 1, 13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(14, 'External - Quarterly', 1, 14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(15, 'External - Semi-Annual', 1, 15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(16, 'External - Annual or Greater', 1, 16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(17, 'Not Tested', 1, 17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [TestingFrequency] OFF

SET IDENTITY_INSERT [KPICategory] ON
INSERT INTO [KPICategory] ([Id], [Name],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Telephony', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Transactional Timeliness', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Utilization', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Quality', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Customer Centricity', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [KPICategory] OFF

SET IDENTITY_INSERT [KPI] ON
INSERT INTO [KPI] ([Id], [Name],[KPICategory_Id],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Answer Rate', 1, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Abandoned Rate',1, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'IVR Containment Rate',1, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Occupancy Rate',1, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Individual Productivity',3, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Individual Accuracy', 4, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Call Surveys (CSAT)', 5, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [KPI] OFF

SET IDENTITY_INSERT [SLA] ON
INSERT INTO [SLA] ([Id], [Name],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1,  N'XX% Satisfied', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2,  N'Same day', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3,  N'Phone/emails every 15 days', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5,  N'Net Promoter Score of X', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6,  N'Letters every 30 days', 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7,  N'Customer Effort Score of X', 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8 , N'90% in 60 minutes', 1, 8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9 , N'90% in 6 hours', 1, 9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, N'90% in 5 days', 1, 10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(11, N'3-5 days', 1, 11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, N'30 days', 1, 12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(13, N'180 plans to one representative', 1, 13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(14, N'1-2 days', 1, 14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(15, N'<3%', 1, 28, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(16, N'% of payments in inventory by days (15/30 days)', 1, 16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(17, N'100%', 1, 17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(18, N'99%', 1, 18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(19, N'98%', 1, 19, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(20, N'95%', 1, 20, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(21, N'90%', 1, 21, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(22, N'85%', 1, 22, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(24, N'80%', 1, 23, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(25, N'30%', 1, 24, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(26, N'29', 1, 26, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(27, N'30', 1, 27, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4,  N'Not applicable', 1, 50, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999');
SET IDENTITY_INSERT [SLA] OFF
INSERT INTO KPICategory_SLA(KPICategoryId, SLAId)
VALUES
(1,21),
(1,22),
(1,24),
(1,25),
(1,15),
(1,4),
(2,2),
(2,14),
(2,11),
(2,12),
(2,10),
(2,9),
(2,16),
(2,6),
(2,3),
(2,4),
(3,20),
(3,21),
(3,13),
(3,4),
(4,18),
(4,19),
(4,20),
(4,21),
(4,4),
(5,1),
(5,5),
(5,7),
(5,4);

SET IDENTITY_INSERT [Site] ON
INSERT INTO [Site] ([Id], [Name],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Boston', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Cebu', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Manila', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Parsippany', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Portsmouth', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Toronto', 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Westwood', 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [Site] OFF

SET IDENTITY_INSERT [RiskImpact] ON
INSERT INTO [RiskImpact] ([Id], [Name],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Financial', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Operational', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Regulatory', 1, 1, 3, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Reputational', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Not applicable', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [RiskImpact] OFF

SET IDENTITY_INSERT [RiskExposure] ON
INSERT INTO [RiskExposure] ([Id], [Name], [Value] ,[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Low',		1,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Medium',	3,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'High',	9,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [RiskExposure] OFF


SET IDENTITY_INSERT [CoreProcess] ON
INSERT INTO [CoreProcess] ([Id], [Name], [FunctionalAreaId], [Category_Id],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Policies and procedures', 1, 2, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Death notification and validation', 1, 2, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'BU notification of death', 1, 2, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Death logic verification', 1, 2, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Additional',1, 2, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(371, N'Validated', 37, 2, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(372, N'Not Validated', 37, 2, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(373, N'Provider Eligibility (PE) Determination', 37, 2, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(374, N'Benefit Eligibility (BE) Determination', 37, 2, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(375, N'Independent Third Party (ITP) Review', 37, 2, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(376, N'State Reporting', 37, 2, 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(378, N'Additional',37, 2, 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(221, N'Manage Transactions in Workflow Systems',22, 2, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(222, N'Payment Validation',22, 2, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(223, N'Process Payment',22, 2, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(224, N'Daily Reconciliation',22, 2, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(225, N'Process an eTreasury  Entry (Payment Processing, Rejected Payment, Check Stop / Reissue)',22, 2, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(226, N'Suspense / Clearing Maintenance',22, 2, 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(227, N'Bank Draft Add / Change',22, 2, 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(228, N'Check Stop Pay',22, 2, 1, 8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(229, N'List Bill Add / Change',22, 2, 1, 9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2210, N'Create Manual Bill',22, 2, 1, 10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2211, N'Bank Account Maintenance',22, 2, 1, 11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2212, N'Billing Maintenance',22, 2, 1, 12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2213, N'Rejected Payments',22, 2, 1, 13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2214, N'Automated Feeds (EFT, Auto Lockbox/ERS)',22, 2, 1, 14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2215, N'List Bill Payments',22, 2, 1, 15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2216, N'Refunds',22, 2, 1, 16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2217, N'Additional',22, 2, 1, 17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(911, N'Authentication',91, 2, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(912, N'Financial Transaction Processing',91, 2, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(913, N'Non-Financial Transaction Processing',91, 2, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(914, N'Customer Correspondence',91, 2, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(915, N'Additional',91, 2, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(111, N'Death notification',150, 2, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(112, N'Death record validation',150, 2, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(113, N'BU Confirmed Death Matches (Eligible for Thorough Search)',150, 2, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(114, N'BU Confirmed Death Matches (Ineligible for Thorough Search)',150, 2, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(115, N'Additional',150, 2, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(1611, N'Perform beneficiary outreach',161, 2, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(1612, N'BU notification of outreach results',161, 2, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(1613, N'State Reporting Requirements',161, 2, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(1614, N'Additional',161, 2, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999');
SET IDENTITY_INSERT [CoreProcess] OFF

SET IDENTITY_INSERT [SubProcessRisk] ON
INSERT INTO [SubProcessRisk] ([Id], [Name], [Risk], [CoreProcess_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Document policies and procedures', N'Out of date or lack of policies and procedures', 1,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Verification of internal UCI and Lexis Nexis death files prior to AWD RIP job for processing', N'Old or inaccurate files in the workflow', 2,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Scrub internal UCI and Lexis Nexis death files and create AWD RIP job for processing', N'Previously reported deaths added to the workflow causing confusion and unnecessary work', 2,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Check admin system and AWD to confirm if the deceased is a JH client, has inactive account, and if there is a pending or completed claim', N'Wrongful terminations, customer service issues and financial impacts to company', 2,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Perfom 2nd validation of death using an external resource', N'Increase in false positive death matches', 2,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'If death is confirmed, suspend systematic payments in admin systems and place contracts in a non-paying status', N'Client could still be receiving payments after death', 3,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Update the AWD work item status based on reasearch and work is forwarded to Operations for processing', N'Work routed to the wrong workflow queue', 3,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, N'Test the accuracy of Lexis Nexis death match logic', N'Incarease in false positives death matches', 4,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [SubProcessRisk] OFF

--Business Unit:  Insurance	Functional Area:  LTC Appeals
INSERT INTO [SubProcessRisk] ([Name], [Risk], [CoreProcess_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(N'Appeal documentation received from insured/ responsibility party and scanned into Promise work queue', N'Appeal documentation scanned incorrectly impacting timeliness and customer experience', 371,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal validated and acknowledgment letter triggered', N'May not meet compliance requirements, customer experience impacted', 371,1,2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal validated for provider eligibility and triggered to Provider Eligibility team for determination', N'Use of email as work queue and communication vehicle', 371,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Enter claim data (BE / PE) in appeal database (Access)', N'Incorrect data entered misrepresenting claim results. Not meeting state reporting requirement', 371,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal documentation received from insured/ responsibility party and scanned into Promise work queue', N'Appeal documentation scanned incorrectly impacting timeliness and customer experience', 372,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal reviewed, not validated', N'Incorrect determination impacting customer experience', 372,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Create task for new claim in Promise or Beacon system, triggering work item to Escalation team', N'For Promise system claims, there needs to be coordination with the Beacon system for routing to Escalation team', 372,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal Coordinator review based on appeal information, request add''l info if needed', N'Untimely delays in reviewing and obtaining additional information', 373,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal Coordinator renders decision and communicates to BE Coordinator', N'Untimely determination, determination not reviewed by appropriate committee', 373,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal Coordinator review based on appeal information, request add''l info if needed', N'Untimely delays in reviewing and obtaining additional information', 374,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Check policy provisions to determine if an individual or committee review is required', N'Policy provisions not satisfied', 374,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Appeal Coordinator renders decision or forwards for committee review', N'Untimely determination, determination not reviewed by appropriate committee', 374,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Committee Modified Review - email summary and voting by committee (uphold / overturn / add''l information / request Committee review)', N'Untimely determination leading to a customer complaint or policy provisions not met', 374,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Committee Review – appeal data presented and committee determination made (uphold / overturn / add''l information)', N'Untimely determination leading to a customer complaint or policy provisions not met', 374,1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Enter BE/PE determination data in appeal database (Access)', N'Incorrect data entered misrepresenting claim results. Not meeting state reporting requirement', 374,1,6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Policyholder communication, including independent third party review information, if applicable', N'Wrong template (upheld / overturned), Risk of privacy breach, Untimely determination, ITP language not included', 374,1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Update notes in system', N'Current status/information is not available in system', 374,1, 8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Customer initiates ITP review, Appeals Coordinator uploads claim file to ITP website', N'Non-compliance with state guidelines', 375,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Send customer acknowledgment letter that ITP has been triggered', N'Customer experience impacted', 375,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'ITP communicates decision to company (uphold / overturn)', N'Non-compliance with state guidelines', 375,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Email communication to care management, payment, and provider teams to approve claim in system', N'Use of email as work queue and communication vehicle', 375,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Annual reporting of the # of independent 3rd party reviews done for the State of Colorado', N'Non-compliance with state guidelines', 376,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
--Business Unit: Insurance	Functional Area: Retail LTC Collections
INSERT INTO [SubProcessRisk] ([Name], [Risk], [CoreProcess_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(N'Create/access work items', N'Check that exists in AWD but not in CSC will never be processed, Delay > Unintended lapse, AWD / CSC Out of sync, Indexing errors, Potential data integrity, indexing, & imaging issues, Workflow systems (AWD, CSC) out of sync', 221,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Leave notes in appropriate systems and close work item', N'Customer service may not be able to explain transaction if it is not documented via processor notes, Off-workflow processes have no other record, Not closed, closed with incorrect status, Cannot be closed due to system issue', 221,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Evaluate check (If NIGO check (Signature, date, legal/numeric, payee) or unidentifiable, return to payor)', N'NIGO instrument, Unaffiliated remitter, AML/ATF, List bill issues, Make wrong decision', 222,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Evaluate payment (If IGO payment amount, apply to pay premium in admin system; If NIGO payment amount, apply to suspense, send balance due; If misdirected, inform BFDS to rescan to correct department; If unidentified, create letter and inform BFDS to return to sender)', N'Policy status decisions, Unable to identify correct policy, Not processed in a timely manner, Misidentify department, Processing delays, BFDS rescan error, Check could have been identified, was not, Error on return letter, Returned check to wrong address', 222,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Input check amount in AWD and mark for deposit', N'Wrong amount input, resulting in wrong amount being withdrawn from client account', 223,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Apply payment in LifePro/PNO', N'Funds applied incorrectly, refunded in error, misallocated between spouses, Retention of funds in error, Wrong amount input, Payment applied 0x or 2x, Funds applied to suspense but not to pay premium, Funds applied to wrong suspense account', 223,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Reallocate funds if applicable', N'Refund / partial refund in error, Funds transferred to wrong policy, Transfer reversal error, resulting in presence of erroneous balance, Incorrect mode/frequency is applied in error', 223,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Maintain check log in shared drive', N'Incorrect or missing items will add time to reconciliation', 224,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Import admin system payment detail', N'Data may not be accessible', 224,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Compare adjusted totals (admin system vs. check log) less any adjustments', N'Error in adjustments will compromise result', 224,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Correct errors in admin system and/or on check log', N'Accounting variances, Incorrect amount applied to customer policy, Write-offs', 224,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Select template, input required information, submit cash accounting entry', N'Wrong account, accounting variances, write-offs. Wrong business unit. Wrong transaction type. Will not show up for approval if not in correct status, leading to delays or complaints', 225,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Select template, input required information, submit entry (check / wire)', N'Wrong account, accounting variances, write-offs. Wrong business unit. Wrong transaction type. Funds disbursed to wrong customer. Will not show up for approval if not in correct status, leading to delays or complaints', 225,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Identify open item from admin report, Trecs, Control database and correct / apply / refund', N'Reports occasionally unavailable or delayed, so an entire batch of new suspense items can go un-reviewed. Import process is semi-manual, possible to lose existing commentary (not a system of record). Off workflow process. Wrong decision could lead to complaint or expense. Delayed processing could lead to complaint', 226,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Send balance due letter if applicable', N'Wrong amount on balance due letter. Policy will not be paid', 226,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Determine IGO / NIGO for ACH form (If NIGO, send letter to client)', N'Form could be submitted without voided check. Account could be of unsupported type. Account provided may not be owned by insured. Wrong info in policy number or account # fields can results in unauthorized drafts from unrelated 3rd parties', 227,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Add/update bank information in LifePro', N'Typo in account # / routing #. Mode/frequency change error. Change made to wrong policy', 227,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Locate check in eTreasury, determine status', N'Insufficient info to locate check. Misidentification of unrelated check for same amount. Check may predate existing archive range. Check may be cashed, stopped, or stale dated. Check may have already been reissued, request could actually pertain to replacement check rather than imaged check', 228,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If check is stale dated, close CSCS work item and route to Shared Services Abandoned Property via email', N'Email not sent. Not traceable after being closed in CSC', 228,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If check is not stale dated, or is stale dated but needs to be reapplied to the policy, stop the check', N'Wrong clearing account. Stop request is declined b/c payee cashes it during process. Check reissued before stop is confirmed', 228,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Update policy in LifePro', N'Processing error could result in incorrect billing, leading to complaint or expense', 229,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Send notification letter', N'Policy may lapse without client''s knowledge since bills don''t go out when billing is suspended', 229,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Determine correct premium amount based on data in admin system', N'Manual process leads to miscalculation of bills (Processor doesn''t subtract suspense, doesn''t take future rerate into account, miscalculates pro-rated amount, etc.)', 2210,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Send manual bill in CSC or collections letters database', N'Bad/non-current address, particularly if processed before accompanying address change request. Typo / error in name, address, date, amount, etc. Use of non-standard correspondence. Provides wrong return address. Wrong amount (suspense not included)', 2210,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Obtain bank account (Citibank, JPM Chase) open item lists from Treasury', N'Potentially many different bank accounts have activity for a single functional area. Most analysts are at MBPS so distribution can be delayed by holiday asymmetry, service outage', 2211,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Review open items and take action on items greater than 7 days', N'Failure to identify variances in a timely manner can lead to profit/loss exposure. Client payments not applied in a timely manner. Misidentification of transaction; accounts can have activity for multiple functional areas. Variances highlight processing errors that need to be corrected in a timely manner. Maintenance can be relatively complex and require an experienced staff member', 2211,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Retrieve / parse source reports', N'Report requires substantial modification via pre-existing logic. If assumptions change and the logic does not, policies requiring review could be missed', 2212,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Notify other areas of suspended / overdue policies', N'Users might not reactive billing promptly, or at all', 2212,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Review out-of-standard items', N'If items are not reviewed at all, billing can remain suspended indefinitely. If items are not reviewed promptly, restoring billing to standard is a manual process. Suspended items do not lapse, leading to Claims exposure, Financial reporting errors, and customer service issues. Criteria is arbitrary (90 days for list bills, 70 days for individual policies). Policies can appear to be years overdue while being actively worked on. List bill policies will never lapse without manual intervention. Customer service risk when billing policy far in arrears. Gain/loss exposure when trying to recover premium in arrears', 2212,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Send required correspondence', N'Increased risk of bad/non-current address on policies that haven''t been billed recently. Increased potential for error as all billings are manual', 2212,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'After evaluation, make determination and activate billings', N'Policy will lapse in error. Multiple EFT withdrawals. Policy can continue to suspend due to validation errors', 2212,1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Monitor source reports', N'Notifications must be actively sought. Some transactions do not include notifications. Off workflow process', 2213,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Reverse payment in admin system', N'Reverse wrong payment. Accounting variances. Reverse payment twice or not at all. Reverse only part of multi-policy payment', 2213,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Change mode and lock premium if necessary', N'Duplicate drafts due to incorrect mode. Draft/bill incorrect amount', 2213,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Send correspondence', N'Correspondence is manual; possible typos / miscalculations', 2213,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Review and validate automated feeds', N'File can be out of balance, not sent at all. Duplicate feed', 2214,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Correct any errors identified in the feed', N'Delay in applying funds to client accounts while correction is in process', 2214,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Evaluate check (If NIGO check (Signature, date, legal/numeric, payee) or unidentifiable, return to payor) ', N'NIGO instrument. Unaffiliated remitter. Anti-Money Laundering/Anti-Terrorist Financing', 2215,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Evaluate payment (If IGO payment amount, apply to pay premium in admin system; If NIGO payment amount, seek guidance from payor contact; If misdirected, inform BFDS to rescan to correct department; If unidentified, create letter and inform BFDS to return to sender; Locate list bill Billing Control Number (BCN) in admin system, If BCN does not exist, process payment via batch interface', N'Make wrong IGO/NIGO decision. Group may not have current BCN, so the payments will have to be applied manually. Some payments could be applied to suspense, will require additional manual processing. Unable to identify payment as list bill. Unable to identify correct list bill group. Policy status decisions', 2215,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If it is not possible to determine how to apply the payment, seek guidance from payor contact', N'No contact is known. Payment / bill is irreconcilable', 2215,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Update individual policy amounts to match amount of check received and process payment', N'If the amount paid doesn''t match the amount billed, it may be impossible to complete this step accurately. If payment is applied incorrectly, it may be impossible to trace in the future', 2215,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Verify that funds should be refunded', N'Wrong determination could anger customer or result in erroneous lapse', 2216,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If this is a reissue, cancel original refund or verify prior cancellation', N'Could be a duplicate reissue, Original check might not have been stopped', 2216,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Determine correct payee', N'Wrong payee leads to expense, Delays for correct payee, Bad address', 2216,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Process refund', N'Wrong amount input (treasury), Wrong refund type (check / wire / direct deposit), Wrong clearing account used', 2216,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
--Business Unit:  Investments/JHSS	Functional Area:  Service Operations
INSERT INTO [SubProcessRisk] ([Name], [Risk], [CoreProcess_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(N'Ensure the caller is authorized to act on the account', N'Unauthorized access could lead to fraudulent transactions. Money Laundering signs missed due to employee oversight. Vulnerable adult exploitation', 911,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Ensure the requestor/signer is authorized to submit written requests', N'Unauthorized access could lead to fraudulent transactions. Fraudulent documents provided. Money Laundering signs missed due to employee oversight', 911,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Non-Retirement Financial Transactions:  Ensure the correct fund, fund class/account, amount and trade date are used', N'Inaccurate processing will lead to financial gain/loss and customer complaints. Items indexed to the incorrect worktype/queue. Transaction processed with fraudulent intent. Processing without satisfying internal policies, procedures and guidelines. Transactions received after 4 pm processed using current trade date. Money laundering red flags not detected', 912,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Retirement Financial Transactions:  Ensure the correct fund, fund class/account, amount, trade date, contribution year, type of contribution/rollover/ transfer, type of distribution, withholding, tax/premature disclosures, admin fee are used', N'Inaccurate processing will lead to financial gain/loss and customer complaints. Items indexed to the incorrect worktype/queue. Transaction processed with fraudulent intent. Processing without satisfying internal policies, procedures and guidelines. Transactions received after 4 pm processed using current trade date. Money laundering red flags not detected', 912,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Ensure the correct fund, fund class and/or account, and transaction type is selected for processing and completed accurately (i.e. Transfer of Ownership, Beneficiary Change, Address Change, etc.)', N'Inaccurate processing will lead to customer complaints. Transaction processed with fraudulent intent. Processing without satisfying internal policies, procedures and guidelines. Money laundering red flags not detected', 913,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Generate letters to customers', N'Correspondence/checks being mailed, emailed or faxed to wrong customer or address', 914,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Lost Certificates', N'Lost Certificates not reported to the SIC timely', 914,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
--Business Unit:  Shared Services	Functional Area:  Death Match
INSERT INTO [SubProcessRisk] ([Name], [Risk], [CoreProcess_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(N'Verification of internal UCI and Lexis Nexis death files prior to AWD RIP and notification to Business Unit of pre-scrubbed death volumes', N'Improper filtering by roles, statuses, etc. Not identifying major outliers/volume discrepancies. Lack of Business Unit notification. Duplicate work types being ripped into AWD workflow. Key man risk', 111,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Validate the scrub and AWD RIP job performed by IT', N'Improperly scrubbed files can lead to duplicate requests. Not all files or too many are ripped into AWD impacting ability to meet regulatory settlement requirements', 111,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Check admin system and AWD  to confirm if the deceased is a JH client, has an inactive account, and if there is a pending or completed claim', N'Confirming death match that is not in fact deceased. Incorrect processing preventing record from going through Thorough Search process. Incorrect data in admin system (status, name, SSN, date of birth, etc.) impacting validation. Inaccurate vendor and DMF data/match logic', 112,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Perform 2nd validation of death using an external resource (Obituary, Legacy, Accurint)', N'Unable to validate death from a secondary source and record still goes through Thorough Search. Not following order of validation check leading to increase costs', 112,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Confirmed death matches are sent to Thorough Search via AWD', N'Work routed to the wrong workflow queue', 113,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Confirmed LTC death matches are sent to LTC Operations for processing', N'Inaccurate processing. Not reporting deaths in a timely manner', 114,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Confirmed Fixed Products death matches (PAR & Structured Settlements) are sent to Fixed - Death Benefit Administration for processing', N'Inaccurate processing. Not reporting deaths in a timely manner', 114,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')

INSERT INTO [SubProcessRisk] ([Name], [Risk], [CoreProcess_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(N'Check documentation and admin system to validate beneficiaries and if there is a benefit due', N'Privacy concerns if letters are  mailed to wrong beneficiary or address. Misidentification of benefit due or beneficiaries could lead to reputational risk', 1611,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Mail three letters (30 days apart) addressed to each beneficiary within admin system', N'Not satisfying Regulatory Settlement Agreement, 1st letter is not mailed within 90 days of notification, Privacy concerns if letters are  mailed to wrong beneficiary or address. Items indexed to the incorrect worktype/queue', 1611,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If no response after 2nd letter, research Accurint to obtain a phone number and better address.  If phone # is found, attempt three phone calls to the beneficiary 15 days apart.', N'Not satisfying Regulatory Settlement Agreement', 1611,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If neither a phone # or better address is found, then send an email to the beneficiary at the email address within JH records', N'Not satisfying Regulatory Settlement Agreement. Privacy concerns if email is sent to the wrong  person. Items indexed to the incorrect worktype/queue', 1611,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If returned mail is received, perform an Accurint search to obtain an updated address and begin Thorough Search process again', N'Not satisfying Regulatory Settlement Agreement. Not meeting the 30 day requirement to perform research and send letter to better address. Items indexed to the incorrect worktype/queue', 1611,1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If contact is made with beneficiary via phone callout, call is transferred to Call Center for Claims settlement', N'Unauthorized access could lead to fraudulent activity, Items indexed to the incorrect worktype/queue', 1612,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If contact is made with beneficiary via letter or email, update AWD work item status and work is forwarded to Operations  Claims settlement', N'Items indexed to the incorrect worktype/queue', 1612,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'If you''re unable to contact beneficiary, update AWD work item to dormancy status and work is forwarded to Operations for escheatment', N'Not satisfying Regulatory Settlement Agreement. Items indexed to the incorrect worktype/queue', 1612,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(N'Quarterly reporting for  the state of Minnesota based on determined business requirements and database logic', N'Manual reporting and multiple admin system feeds leads to inaccurate reporting. Not meeting reporting deadlines leading to potential regulatory risks', 1613,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')

SET IDENTITY_INSERT [ProcessRisk] ON
INSERT INTO [ProcessRisk] ([Id], [Name], [Risk], [Category_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Documented policies, procedures, manuals, job-aids and training materials', N'Procedures not followed according to current documentation. Documentation is not current', 3,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Corporate Training, Anti-Money Laundering & Fraud, Privacy & Information Security, Code of Conduct & Business Ethics, Employee Harrassment, Conflict of Interest', N'Incomplete training or knowledge of material', 3,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Divisional Training, U.S. Operations Risk Management, Records Management, Health Insurance Portability and Accountability Act (HIPAA)', N'Incomplete training or knowledge of material', 3,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'FINRA Training, Annual FINRA Firm Element Training, Continuing Education', N'', 3,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Business Continuity Plan administration', N'Business continuity plans are insufficient or not current', 4,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Maintain a current Business Unit Records, Mangement inventory (Identify records, description, retention, location, security classification and disposition) for both paper and electronic records', N'Loss of critical Company Records; Retention Requirements not understood or adhered to; improper disposal of expired records; disorganization of company records',5,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Maintain and communicate Business Unit Records Management Procedures Manual and Records Retention and Destruction Guidelines', N'Appropriate RM Procedures are unknown to employees resulting in ineffective handling of records Not satisfying regulatory/ Legal and Operational  requirements',5,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, N'Quality of Image as Official Record (IAOR) Policy', N'Electronic copies of records do not comply with regulatory and company record keeping standards, leaving the company open to litigation and regulatory repercusions',5,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9, N'Manage critical and often time-sensitive information requests for document holds or preservation as directed by Legal/Compliance/Tax', N'Legal/ Regulatory / Tax liabilities',5,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, N'Manage employee status (i.e. active/inactive, roles & responsibilities) within Workday and change system access  (i.e. Administration Systems) within Service Now', N'Inappropriate or insufficient system access',6,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(11, N'Manage access to current Business Records inventory (i.e. Structured/Unstructured Critical Data on SharePoint, Shared Drives)', N'Inappropriate access to company records',6,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, N'External electronic distribution or transmission of data (i.e. emails, faxes, data in motion, data at rest)', N'Electronic files/emails are not protected',6,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(13, N'Report Privacy incidents (complete Privacy Incident Reporting Form)', N'Incidents involving PII/PHI going undetected',7,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(14, N'Handling and destruction of privacy data including information with PII/PHI data', N'PII/PHI is easily accessible',7,1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(15, N'Customer Identification/Authentication (i.e. Inbound/Outbound callers and correspondence)', N'Inappropriate dissemination of information',7,1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(16, N'Handling of Privacy (Do Not Solicit/Do Not Contact) opt-out requests', N'Customers continue to receive unwanted marketing information or materials from the Company', 7,1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [ProcessRisk] OFF

SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(1, N'Annual review of policies & procedures',1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(2, N'Resides in centralized location with employee access',1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(3, N'Change in policies & procedures are communicated',1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(4, N'Master Production Calendar/Document Log Review',1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(5, N'Porject Management - Change Control',1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(6, N'Compass Reporting',1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(7, N'Employee Email Notification',1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(8, N'Manager Email Notification',1, 8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(9, N'No controls are in place',1, 9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 3),
(21, N'Annual review of BCP',1, 11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(22, N'Achieve of onshore/offshore staffing targets',1, 12, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(23, N'Achieve Workplace Flexibility targets',1, 13, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(24, N'Annual Alternate Site tests',1, 14, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(26, N'Perform Periodic Table Top Exercises (i.e. Disaster Scenario and stress testing)',1, 15, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(27, N'Quarterly NotiFind Call Tree tests',1, 16, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(28, N'Quarterly review of staffing (names/phone #''s) in BCP',1, 17, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(29, N'No controls are in place',1, 18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 4),
(30, N'Annual Divisional Risk Management Training',1, 18, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(31, N'BURC Records Inventory Worksheet',1, 19, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(32, N'BURC Records Destruction Approval Forms',1, 20, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(33, N'BURC Coordination',1, 21, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(34, N'BURC Comunication at Staff Meetings',1, 22, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(35, N'Divisional Attestation (Divisional RM Coordinator & Chief Compliance Officer)',1, 23, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(36, N'Global RM Self Assessment',1, 24, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(37, N'Image Completeness Controls (batch and document counts)',1, 25, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(39, N'Image Replica Controls (Original paper record compared to image record)',1, 26, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(40, N'Regular review of physical and electronic records',1, 27, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(41, N'Review of BU Records Management Inventory',1, 28, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(42, N'No controls are in place',1, 29, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 5),
(44, N'Access Control Lists (ACL) via Service Now',1, 29, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(45, N'BURC Records Inventory Worksheet',1, 30, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(47, N'Email Encryption',1, 31, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(48, N'Employee Badge Access',1, 32, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(49, N'Password Protected Files',1, 33, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(51, N'Review Role & Permission Profiles',1, 34, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(52, N'Secure File Transfer Protocol (SFTP)/Managed Transfer Protocol (MTP)',1, 35, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(53, N'System Access Reviews',1, 36, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(54, N'System Access Reviews using Identity IQ',1, 37, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(55, N'No controls are in place',1, 38, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 6),
(57, N'Call Monitoring/Recording',1, 38, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 7),
(58, N'Email Encryption',1, 39, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 7),
(59, N'Database Tracking (Enternal Gryphon site/Internal Opt Out Database)',1, 40, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 7),
(60, N'Notify Privacy Coordinator',1, 41, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 7),
(61, N'Perform Clean Desk Audit Reviews',1, 42, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 7),
(62, N'No controls are in place',1, 43, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 7);

SET IDENTITY_INSERT [ControlType] OFF

INSERT INTO [ProcessRisk_ControlType]([ProcessRiskId], [ControlTypeId])
VALUES
(1,1),
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(1,7),
(1,8),
(1,9),
(2,1),
(2,2),
(2,3),
(2,4),
(2,5),
(2,6),
(2,7),
(2,8),
(2,9),
(3,1),
(3,2),
(3,3),
(3,4),
(3,5),
(3,6),
(3,7),
(3,8),
(3,9),
(4,1),
(4,2),
(4,3),
(4,4),
(4,5),
(4,6),
(4,7),
(4,8),
(4,9),
(5,21),
(5,22),
(5,23),
(5,24),
(5,9),
(5,26),
(5,27),
(5,28),
(6,30),
(6,31),
(6,32),
(6,33),
(6,34),
(6,35),
(6,36),
(6,37),
(6,39),
(6,40),
(6,41),
(6,9),
(7,30),
(7,31),
(7,32),
(7,33),
(7,34),
(7,35),
(7,36),
(7,37),
(7,39),
(7,40),
(7,41),
(7,9),
(8,30),
(8,31),
(8,32),
(8,33),
(8,34),
(8,35),
(8,36),
(8,37),
(8,39),
(8,40),
(8,41),
(8,9),
(9,30),
(9,31),
(9,32),
(9,33),
(9,34),
(9,35),
(9,36),
(9,37),
(9,39),
(9,40),
(9,41),
(9,9),
(10,44),
(10,45),
(10,47),
(10,48),
(10,49),
(10,51),
(10,52),
(10,53),
(10,54),
(10,9),
(11,44),
(11,45),
(11,47),
(11,48),
(11,49),
(11,51),
(11,52),
(11,53),
(11,54),
(11,9),
(12,44),
(12,45),
(12,47),
(12,48),
(12,49),
(12,51),
(12,52),
(12,53),
(12,54),
(12,9),
(13,57 ),
(13,58 ),
(13,59 ),
(13,60 ),
(13,61 ),
(13,9 ),
(14,57 ),
(14,58 ),
(14,59 ),
(14,60 ),
(14,61 ),
(14,9 ),
(15,57 ),
(15,58 ),
(15,59 ),
(15,60 ),
(15,61 ),
(15,9 ),
(16,57 ),
(16,58 ),
(16,59 ),
(16,60 ),
(16,61 ),
(16,9 );
SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(201, N'Quality Review',1, 43, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(202, N'Manager Approval',1, 44, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(204, N'Legal/Compliance Review',1, 45, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(205, N'AWD/Workflow Reporting',1, 46, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(206, N'Document Imaging',1, 47, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(207, N'Call Recording',1, 48, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(208, N'Daily Reconciliation',1, 49, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2);
SET IDENTITY_INSERT [ControlType] OFF

INSERT INTO [CoreProcess_ControlType]([CoreProcessId], [ControlTypeId])
VALUES
(1,201),
(1,202),
(2,204),
(2,205),
(3,206),
(4,207),
(4,208);
SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(401, N'All reviews performed by LHCP as defined by HIPAA',1, 50, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(403, N'Call Monitoring/Recording',1, 52, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(404, N'Claim file is encrypted',1, 53, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(405, N'Control report to track aging of appeals and trigger delay letter',1, 54, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(406, N'Control report to track ITP reviews',1, 55, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(408, N'Determination within 60 days after all necessary information is received',1, 57, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2)
SET IDENTITY_INSERT [ControlType] OFF
INSERT INTO [CoreProcess_ControlType]([CoreProcessId], [ControlTypeId])
VALUES
(371,405),
(371,201),
(371,9),
(372,201),
(372,9),
(373,405),
(373,201),
(373,9),
(374,401),
(374,405),
(374,408),
(374,201),
(374,9),
(375,404),
(375,201),
(375,9),
(376,406),
(376,201),
(376,9);

SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(501, N'Admin Status Reports',1, 62, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(502, N'Admin Trend Analysis & Reporting',1, 63, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(504, N'AML verification',1, 64, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(505, N'Anti-Money Laundering Verification',1, 65, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(506, N'AWD Deposit Report',1, 66, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(508, N'BFDS Unprocessed Check Report',1, 68, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(510, N'Control Reporting',1, 70, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(511, N'CSC Trend Reporting and Analysis',1, 71, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(514, N'Global Disbursement Approval Policy',1, 74, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(515, N'JPM Chase Import Logic',1, 75, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(517, N'Lock premium report',1, 77, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(520, N'Partial review of bills before mailing (Corporate Solutions)',1, 79, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(522, N'Quality review (Post)',1, 81, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(523, N'Refund report',1, 82, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(524, N'Suspended Billing Report',1, 83, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(525, N'Suspense Reporting',1, 84, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(526, N'Suspense/Clearing Maintenance',1, 85, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(527, N'Time Stamp',1, 86, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(528, N'Treasury Dept Control Reporting',1, 87, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(529, N'Treasury Email Notification',1, 88, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(530, N'Working Group (CSC Integration',1, 89, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2)
SET IDENTITY_INSERT [ControlType] OFF

INSERT INTO [CoreProcess_ControlType]([CoreProcessId], [ControlTypeId])
VALUES
(221,508),
(221,527),
(221,511),
(221,530),
(221,9),
(222,522),
(222,527),
(222,505),
(222,9),
(223,522),
(223,208),
(223,510),
(223,9),
(224,506),
(224,510),
(224,526),
(224,9),
(225,202),
(225,510),
(225,526),
(225,528),
(225,529),
(225,514),
(225,9),
(226,510),
(226,525),
(226,529),
(227,9),
(227,529),
(228,202),
(228,510),
(228,529),
(228,9),
(229,520),
(229,9),
(2210,522),
(2210,9),
(2211,528),
(2211,529),
(2211,9),
(2212,524),
(2212,501),
(2212,502),
(2212,9),
(2213,522),
(2213,208),
(2213,517),
(2213,528),
(2213,9),
(2214,528),
(2214,515),
(2214,9),
(2215,522),
(2215,504),
(2215,527),
(2215,510),
(2215,526),
(2215,9),
(2216,522),
(2216,202),
(2216,510),
(2216,523),
(2216,9);

SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(602, N'$50k+ Report Review', 1, 91, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(604, N'38a-1 Reporting (B02B: Time/Date Stamp Policy, B02C: As of Transactions Policy, B02E: Trade Date Policy - Pricing of Share Transactions Policy)', 1, 92, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(605, N'38a-1 Reporting (Non-End Queue & E-delivery, B07A: Lost Certificate Reporting Policy)', 1, 93, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(606, N'38a-1 Testing', 1, 94, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(607, N'AML Suspicious Activity Check', 1, 95, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(608, N'AWD Work Item Priority Settings', 1, 96, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(611, N'Compliance Monitoring Reporting Testing', 1, 99, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(612, N'Critical Error Report', 1, 110, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(613, N'Daily Queue Monitoring Report', 1, 111, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(615, N'Day 2 Late Trading Review', 1, 113, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(619, N'National Quality Review (NQR)', 1, 117, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(621, N'OFAC Check via Bridger', 1, 118, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(622, N'PwC SOC1 Testing', 1, 119, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(624, N'Quality review (Day 1 -100%  High dollar trades)', 1, 121, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(625, N'Security Check', 1, 122, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(626, N'System Time Stamp (AWD, RightFax, etc.)', 1, 123, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(627, N'System Trade Date Generation (next day after 4 pm)', 1, 125, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2);
SET IDENTITY_INSERT [ControlType] OFF
INSERT INTO [CoreProcess_ControlType]([CoreProcessId], [ControlTypeId])
VALUES
(911,403),
(911,625),
(911,201),
(911,619),
(911,611),
(911,622),
(911,9),
(912,403),
(912,624),
(912,608),
(912,613),
(912,626),
(912,627),
(912,604),
(912,611),
(912,602),
(912,612),
(912,621),
(912,607),
(912,615),
(912,9),
(913,403),
(913,201),
(913,608),
(913,613),
(913,606),
(913,611),
(913,621),
(913,607),
(913,9),
(914,201),
(914,613),
(914,605),
(914,611),
(914,9);

SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(701, N'AWD Auto Generated Work Items', 1, 126, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(702, N'Death Match Results Congo''s report', 1, 127, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(704, N'Extract Reconciliation', 1, 128, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(705, N'Internal review of Vendor Death Match Logic', 1, 129, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(706, N'Manager Sign-off/Email notification triggering next step', 1, 130, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(707, N'Monthly Death File Validation (AWD BI - Outstanding Inventory Report)', 1, 131, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),

(709, N'Quality review (User Experience)', 1, 132, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(710, N'Shared Service functions (Data Integrity, Returned Mail, TIN Matching)', 1, 133, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(711, N'Unconfirmed Death Letters', 1, 134, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2);
SET IDENTITY_INSERT [ControlType] OFF
INSERT INTO [CoreProcess_ControlType]([CoreProcessId], [ControlTypeId])
VALUES
(111,704),
(111,706),
(111,707),
(111,9),
(112,709),
(112,711),
(112,710),
(112,705),
(112,9),
(113,709),
(113,9),
(114,709),
(114,702),
(114,701),
(114,9);

SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(801, N'38a-1 Reporting (09A- Lost Beneficiaries)', 1, 135, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(802, N'Auto Generated Letters (AWD/RR Donnelley)', 1, 136, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(805, N'AWD Workflow Routing', 1, 138, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(809, N'Return mail indicators', 1, 141, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2),
(810, N'Validation of Data', 1, 142, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 2);

SET IDENTITY_INSERT [ControlType] OFF
INSERT INTO [CoreProcess_ControlType]([CoreProcessId], [ControlTypeId])
VALUES
(1611,709),
(1611,801),
(1611,805),
(1611,802),
(1611,809),
(1611,9),
(1612,709),
(1612,403),
(1612,805),
(1612,701),
(1612,9),
(1613,701),
(1613,9);

-- common additional
INSERT INTO [CoreProcess_ControlType]([CoreProcessId], [ControlTypeId])
VALUES
(5,205),
(5,403),
(5,208),
(5,206),
(5,204),
(5,202),
(5,9),
(5,201),
(378,205),
(378,403),
(378,208),
(378,206),
(378,204),
(378,202),
(378,9),
(378,201),
(2217,205),
(2217,403),
(2217,208),
(2217,206),
(2217,204),
(2217,202),
(2217,9),
(2217,201),
(915,205),
(915,403),
(915,208),
(915,206),
(915,204),
(915,202),
(915,9),
(915,201),
(115,205),
(115,403),
(115,208),
(115,206),
(115,204),
(115,202),
(115,9),
(115,201),
(1614,205),
(1614,403),
(1614,208),
(1614,206),
(1614,204),
(1614,202),
(1614,9),
(1614,201);

SET IDENTITY_INSERT [LikelihoodOfOccurrence] ON
INSERT INTO [LikelihoodOfOccurrence] ([Id], [Name],[Value], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Daily', 6, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Weekly', 5, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Monthly', 4, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Quarterly', 3, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Semi-Annual', 2, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Annual', 1, 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Process is no longer applicable', 1, 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [LikelihoodOfOccurrence] OFF

SET IDENTITY_INSERT [FunctionalAreaOwner] ON
INSERT INTO [FunctionalAreaOwner] ([Id], [Name], [BusinessUnitId], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, @BUFuncApprover1, 1, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, @BUFuncApprover2, 1, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, @BUFuncApprover3, 1, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, @BUFuncApprover1, 2, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, @BUFuncApprover2, 2, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, @BUFuncApprover3, 2, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, @BUFuncApprover1, 3, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, @BUFuncApprover2, 3, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9, @BUFuncApprover3, 3, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10, @BUFuncApprover1, 4, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(11, @BUFuncApprover2, 4, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(12, @BUFuncApprover3, 5, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [FunctionalAreaOwner] OFF

SET IDENTITY_INSERT [AssessmentType] ON
INSERT INTO [AssessmentType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Annual Analysis', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'New Function Analysis', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'New Policy/Process Analysis', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Management Change Review', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [AssessmentType] OFF

SET IDENTITY_INSERT [AssessmentStatus] ON
INSERT INTO [AssessmentStatus] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Not Started', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'In Progress', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Complete', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [AssessmentStatus] OFF

SET IDENTITY_INSERT [ChangeType] ON
INSERT INTO [ChangeType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Process', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Compliance Requirements', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Controls', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Systems', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Outsourcing', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Organizational Structure', 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Roles & Responsibilities', 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [ChangeType] OFF

SET IDENTITY_INSERT [Percentage] ON
INSERT INTO [Percentage] ([Id], [Name], [Value], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'10%', 10, 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2  , N'20%', 20, 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3  , N'30%', 30, 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4  , N'40%', 40, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5  , N'50%', 50, 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6  , N'60%', 60, 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7  , N'70%', 70, 1, 8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8  , N'80%', 80, 1, 9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9  , N'90%', 90, 1, 10, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(10 , N'100%', 100, 1, 11, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [Percentage] OFF

SET IDENTITY_INSERT [ControlTrigger] ON
INSERT INTO [ControlTrigger] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Performance', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Process', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Product', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Regulatory/Compliance', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'SOC 1', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'SOC 2', 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'SOX/MAR', 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(8, N'38a-1', 1, 8, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(9, N'Other', 1, 9, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [ControlTrigger] OFF

SET IDENTITY_INSERT [ControlFrequency] ON
INSERT INTO [ControlFrequency] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Ad Hoc', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'Daily', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Weekly', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Monthly', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(5, N'Quarterly', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(6, N'Semi-Annual', 1, 6, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(7, N'Annual', 1, 7, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [ControlFrequency] OFF

SET IDENTITY_INSERT [ControlDesign] ON
INSERT INTO [ControlDesign] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1, N'Automated', 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(2, N'IT Dependent', 1, 2, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(3, N'Manual Prevention (Same Day)', 1, 3, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(4, N'Manual Detect (Day 2 plus)', 1, 4, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [ControlDesign] OFF

-- 0: Owner
-- 1: BUFunctionalApprover
-- 2: BURiskManagementApprover
-- 3: DivisionalRiskManagementApprover
-- 4: Admin
-- security permission
INSERT INTO [ActionPermission] ([Role], [Action])
VALUES
(0, N'Security.Login'),
(0, N'Security.RevokeToken'),
(1, N'Security.Login'),
(1, N'Security.RevokeToken'),
(2, N'Security.Login'),
(2, N'Security.RevokeToken'),
(3, N'Security.Login'),
(3, N'Security.RevokeToken'),
(4, N'Security.Login'),
(4, N'Security.RevokeToken');

-- assessment permission
INSERT INTO [ActionPermission] ([Role], [Action])
VALUES
(0, N'Assessment.CreateAsDraft'),-- only allowed to owner
(0, N'Assessment.Update'),
(0, N'Assessment.GetDraftCount'),-- only allowed to owner
(0, N'Assessment.Submit'),-- only allowed to owner
(0, N'Assessment.GetDraftAssessments'), -- only allowed to owner
(0, N'Assessment.Get'),
(0, N'Assessment.Search'),
(0, N'Assessment.ExportAssessment'),
(0, N'Assessment.GetOverallRiskRatingReport'),
(0, N'Assessment.GetAwaitingApprovalCount'),
(0, N'Assessment.GetApprovedCount'),
(0, N'Assessment.GetRejectedCount'),
(0, N'Assessment.GetAwaitingApprovalAssessments'),
(0, N'Assessment.GetApprovedAssessments'),
(0, N'Assessment.GetRejectedAssessments'),
(0, N'Assessment.GetRiskScore'),
-- for approvers
(1, N'Assessment.Get'),
(1, N'Assessment.Update'),
(1, N'Assessment.Search'),
(1, N'Assessment.ExportAssessment'),
(1, N'Assessment.Approve'),-- only allowed to approver
(1, N'Assessment.Reject'),-- only allowed to approver
(1, N'Assessment.GetOverallRiskRatingReport'),
(1, N'Assessment.GetAwaitingApprovalCount'),
(1, N'Assessment.GetApprovedCount'),
(1, N'Assessment.GetRejectedCount'),
(1, N'Assessment.GetAwaitingApprovalAssessments'),
(1, N'Assessment.GetApprovedAssessments'),
(1, N'Assessment.GetRejectedAssessments'),
(1, N'Assessment.GetRiskScore'),

(2, N'Assessment.Get'),
(2, N'Assessment.Update'),
(2, N'Assessment.Search'),
(2, N'Assessment.ExportAssessment'),
(2, N'Assessment.Approve'),
(2, N'Assessment.Reject'),
(2, N'Assessment.GetOverallRiskRatingReport'),
(2, N'Assessment.GetAwaitingApprovalCount'),
(2, N'Assessment.GetApprovedCount'),
(2, N'Assessment.GetRejectedCount'),
(2, N'Assessment.GetAwaitingApprovalAssessments'),
(2, N'Assessment.GetApprovedAssessments'),
(2, N'Assessment.GetRejectedAssessments'),
(2, N'Assessment.GetRiskScore'),

(3, N'Assessment.Get'),
(3, N'Assessment.Update'),
(3, N'Assessment.Search'),
(3, N'Assessment.ExportAssessment'),
(3, N'Assessment.Approve'),
(3, N'Assessment.Reject'),
(3, N'Assessment.GetOverallRiskRatingReport'),
(3, N'Assessment.GetAwaitingApprovalCount'),
(3, N'Assessment.GetApprovedCount'),
(3, N'Assessment.GetRejectedCount'),
(3, N'Assessment.GetAwaitingApprovalAssessments'),
(3, N'Assessment.GetApprovedAssessments'),
(3, N'Assessment.GetRejectedAssessments'),
(3, N'Assessment.GetRiskScore'),

(4, N'Assessment.Update'),-- only allowed to owner and admin
(4, N'Assessment.Get'),
(4, N'Assessment.Search'),
(4, N'Assessment.ExportAssessment'),
(4, N'Assessment.Reject'),
(4, N'Assessment.GetOverallRiskRatingReport'),
(4, N'Assessment.GetAwaitingApprovalCount'),
(4, N'Assessment.GetApprovedCount'),
(4, N'Assessment.GetRejectedCount'),
(4, N'Assessment.GetAwaitingApprovalAssessments'),
(4, N'Assessment.GetApprovedAssessments'),
(4, N'Assessment.GetRejectedAssessments'),
(4, N'Assessment.GetRiskScore');
-- lookup permission 
-- only required by owner add for other if needed
INSERT INTO [ActionPermission] ([Role], [Action])
VALUES
(0, N'Lookup.GetAllBusinessUnits'),
(0, N'Lookup.GetAllDepartmentHeads'),
(0, N'Lookup.GetAllProducts'),
(0, N'Lookup.GetAllDepartments'),
(0, N'Lookup.GetAllAssessmentTypes'),
(0, N'Lookup.GetAllRiskExposures'),
(0, N'Lookup.GetAllCategories'),
(0, N'Lookup.GetAllLikelihoodOfOccurrences'),
(0, N'Lookup.GetAllRiskImpacts'),
(0, N'Lookup.GetKPICategories'),
(0, N'Lookup.GetAllProcessRisks'),
(0, N'Lookup.GetAllControlFrequencies'),
(0, N'Lookup.GetAllControlTriggers'),
(0, N'Lookup.GetAllKeyControlsMaturities'),
(0, N'Lookup.GetAllControlDesigns'),
(0, N'Lookup.GetAllTestingFrequencies'),
(0, N'Lookup.GetAllPercentages'),
(0, N'Lookup.GetFunctionalAreaOwners'),
(0, N'Lookup.GetFunctionalAreas'),
(0, N'Lookup.GetControlTypes'),
(0, N'Lookup.GetAllAssessmentStatuses'),
(0, N'Lookup.GetAllChangeTypes'),
(0, N'Lookup.GetAllSites'),
(0, N'Lookup.GetCoreProcesses'),

(1, N'Lookup.GetAllBusinessUnits'),
(1, N'Lookup.GetAllDepartmentHeads'),
(1, N'Lookup.GetAllProducts'),
(1, N'Lookup.GetAllDepartments'),
(1, N'Lookup.GetAllAssessmentTypes'),
(1, N'Lookup.GetAllRiskExposures'),
(1, N'Lookup.GetAllCategories'),
(1, N'Lookup.GetAllLikelihoodOfOccurrences'),
(1, N'Lookup.GetAllRiskImpacts'),
(1, N'Lookup.GetKPICategories'),
(1, N'Lookup.GetAllProcessRisks'),
(1, N'Lookup.GetAllControlFrequencies'),
(1, N'Lookup.GetAllControlTriggers'),
(1, N'Lookup.GetAllKeyControlsMaturities'),
(1, N'Lookup.GetAllControlDesigns'),
(1, N'Lookup.GetAllTestingFrequencies'),
(1, N'Lookup.GetAllPercentages'),
(1, N'Lookup.GetFunctionalAreaOwners'),
(1, N'Lookup.GetFunctionalAreas'),
(1, N'Lookup.GetControlTypes'),
(1, N'Lookup.GetAllAssessmentStatuses'),
(1, N'Lookup.GetAllChangeTypes'),
(1, N'Lookup.GetAllSites'),
(1, N'Lookup.GetCoreProcesses'),

(2, N'Lookup.GetAllBusinessUnits'),
(2, N'Lookup.GetAllDepartmentHeads'),
(2, N'Lookup.GetAllProducts'),
(2, N'Lookup.GetAllDepartments'),
(2, N'Lookup.GetAllAssessmentTypes'),
(2, N'Lookup.GetAllRiskExposures'),
(2, N'Lookup.GetAllCategories'),
(2, N'Lookup.GetAllLikelihoodOfOccurrences'),
(2, N'Lookup.GetAllRiskImpacts'),
(2, N'Lookup.GetKPICategories'),
(2, N'Lookup.GetAllProcessRisks'),
(2, N'Lookup.GetAllControlFrequencies'),
(2, N'Lookup.GetAllControlTriggers'),
(2, N'Lookup.GetAllKeyControlsMaturities'),
(2, N'Lookup.GetAllControlDesigns'),
(2, N'Lookup.GetAllTestingFrequencies'),
(2, N'Lookup.GetAllPercentages'),
(2, N'Lookup.GetFunctionalAreaOwners'),
(2, N'Lookup.GetFunctionalAreas'),
(2, N'Lookup.GetControlTypes'),
(2, N'Lookup.GetAllAssessmentStatuses'),
(2, N'Lookup.GetAllChangeTypes'),
(2, N'Lookup.GetAllSites'),
(2, N'Lookup.GetCoreProcesses'),

(3, N'Lookup.GetAllBusinessUnits'),
(3, N'Lookup.GetAllDepartmentHeads'),
(3, N'Lookup.GetAllProducts'),
(3, N'Lookup.GetAllDepartments'),
(3, N'Lookup.GetAllAssessmentTypes'),
(3, N'Lookup.GetAllRiskExposures'),
(3, N'Lookup.GetAllCategories'),
(3, N'Lookup.GetAllLikelihoodOfOccurrences'),
(3, N'Lookup.GetAllRiskImpacts'),
(3, N'Lookup.GetKPICategories'),
(3, N'Lookup.GetAllProcessRisks'),
(3, N'Lookup.GetAllControlFrequencies'),
(3, N'Lookup.GetAllControlTriggers'),
(3, N'Lookup.GetAllKeyControlsMaturities'),
(3, N'Lookup.GetAllControlDesigns'),
(3, N'Lookup.GetAllTestingFrequencies'),
(3, N'Lookup.GetAllPercentages'),
(3, N'Lookup.GetFunctionalAreaOwners'),
(3, N'Lookup.GetFunctionalAreas'),
(3, N'Lookup.GetControlTypes'),
(3, N'Lookup.GetAllAssessmentStatuses'),
(3, N'Lookup.GetAllChangeTypes'),
(3, N'Lookup.GetAllSites'),
(3, N'Lookup.GetCoreProcesses'),

(4, N'Lookup.GetAllBusinessUnits'),
(4, N'Lookup.GetAllDepartmentHeads'),
(4, N'Lookup.GetAllProducts'),
(4, N'Lookup.GetAllDepartments'),
(4, N'Lookup.GetAllAssessmentTypes'),
(4, N'Lookup.GetAllRiskExposures'),
(4, N'Lookup.GetAllCategories'),
(4, N'Lookup.GetAllLikelihoodOfOccurrences'),
(4, N'Lookup.GetAllRiskImpacts'),
(4, N'Lookup.GetKPICategories'),
(4, N'Lookup.GetAllProcessRisks'),
(4, N'Lookup.GetAllControlFrequencies'),
(4, N'Lookup.GetAllControlTriggers'),
(4, N'Lookup.GetAllKeyControlsMaturities'),
(4, N'Lookup.GetAllControlDesigns'),
(4, N'Lookup.GetAllTestingFrequencies'),
(4, N'Lookup.GetAllPercentages'),
(4, N'Lookup.GetFunctionalAreaOwners'),
(4, N'Lookup.GetFunctionalAreas'),
(4, N'Lookup.GetControlTypes'),
(4, N'Lookup.GetAllAssessmentStatuses'),
(4, N'Lookup.GetAllChangeTypes'),
(4, N'Lookup.GetAllSites'),
(4, N'Lookup.GetCoreProcesses');
-- user management permission
-- only allow for admin
INSERT INTO [ActionPermission] ([Role], [Action])
VALUES
(4, N'User.Update'),
(4, N'User.Get'),
(4, N'User.Delete'),
(4, N'User.Search');
-- admin related CRUD operations
INSERT INTO [ActionPermission] ([Role], [Action])
VALUES
(4, N'Lookup.CreateAssessmentStatus'),
(4, N'Lookup.UpdateAssessmentStatus'),
(4, N'Lookup.DeleteAssessmentStatus'),
(4, N'Lookup.ReorderAssessmentStatuses'),
(4, N'Lookup.CreateAssessmentType'),
(4, N'Lookup.UpdateAssessmentType'),
(4, N'Lookup.DeleteAssessmentType'),
(4, N'Lookup.ReorderAssessmentTypes'),
(4, N'Lookup.CreateBusinessUnit'),
(4, N'Lookup.UpdateBusinessUnit'),
(4, N'Lookup.DeleteBusinessUnit'),
(4, N'Lookup.ReorderBusinessUnits'),
(4, N'Lookup.CreateDepartment'),
(4, N'Lookup.UpdateDepartment'),
(4, N'Lookup.DeleteDepartment'),
(4, N'Lookup.ReorderDepartments'),
(4, N'Lookup.CreateDepartmentHead'),
(4, N'Lookup.UpdateDepartmentHead'),
(4, N'Lookup.DeleteDepartmentHead'),
(4, N'Lookup.ReorderDepartmentHeads'),
(4, N'Lookup.CreateFunctionalArea'),
(4, N'Lookup.UpdateFunctionalArea'),
(4, N'Lookup.DeleteFunctionalArea'),
(4, N'Lookup.ReorderFunctionalAreas'),
(4, N'Lookup.CreateFunctionalAreaOwner'),
(4, N'Lookup.UpdateFunctionalAreaOwner'),
(4, N'Lookup.DeleteFunctionalAreaOwner'),
(4, N'Lookup.ReorderFunctionalAreaOwners'),
(4,  N'Lookup.CreateProduct'),
(4,  N'Lookup.UpdateProduct'),
(4,  N'Lookup.DeleteProduct'),
(4, N'Lookup.ReorderProducts'),
(4,  N'Lookup.CreateCategory'),
(4,  N'Lookup.UpdateCategory'),
(4,  N'Lookup.DeleteCategory'),
(4, N'Lookup.ReorderCategories'),
(4,  N'Lookup.CreateChangeType'),
(4,  N'Lookup.UpdateChangeType'),
(4,  N'Lookup.DeleteChangeType'),
(4, N'Lookup.ReorderChangeTypes'),
(4,  N'Lookup.CreateControlDesign'),
(4,  N'Lookup.UpdateControlDesign'),
(4,  N'Lookup.DeleteControlDesign'),
(4, N'Lookup.ReorderControlDesigns'),
(4,  N'Lookup.CreateControlFrequency'),
(4,  N'Lookup.UpdateControlFrequency'),
(4,  N'Lookup.DeleteControlFrequency'),
(4, N'Lookup.ReorderControlFrequencies'),
(4,  N'Lookup.CreateControlTrigger'),
(4,  N'Lookup.UpdateControlTrigger'),
(4,  N'Lookup.DeleteControlTrigger'),
(4, N'Lookup.ReorderControlTriggers'),
(4,  N'Lookup.CreateControlType'),
(4,  N'Lookup.UpdateControlType'),
(4,  N'Lookup.DeleteControlType'),
(4, N'Lookup.ReorderControlTypes'),
(4, N'Lookup.GetAllControlTypes'),
(4,  N'Lookup.CreateCoreProcess'),
(4,  N'Lookup.UpdateCoreProcess'),
(4,  N'Lookup.DeleteCoreProcess'),
(4, N'Lookup.ReorderCoreProcesses'),
(4,  N'Lookup.CreateKeyControlsMaturity'),
(4,  N'Lookup.UpdateKeyControlsMaturity'),
(4,  N'Lookup.DeleteKeyControlsMaturity'),
(4, N'Lookup.ReorderKeyControlsMaturities'),
(4,  N'Lookup.CreateKPICategory'),
(4,  N'Lookup.UpdateKPICategory'),
(4,  N'Lookup.DeleteKPICategory'),
(4, N'Lookup.ReorderKPICategories'),
(4,  N'Lookup.CreateLikelihoodOfOccurrence'),
(4,  N'Lookup.UpdateLikelihoodOfOccurrence'),
(4,  N'Lookup.DeleteLikelihoodOfOccurrence'),
(4, N'Lookup.ReorderLikelihoodOfOccurrences'),
(4,  N'Lookup.CreatePercentage'),
(4,  N'Lookup.UpdatePercentage'),
(4,  N'Lookup.DeletePercentage'),
(4, N'Lookup.ReorderPercentages'),
(4,  N'Lookup.CreateProcessRisk'),
(4,  N'Lookup.UpdateProcessRisk'),
(4,  N'Lookup.DeleteProcessRisk'),
(4, N'Lookup.ReorderProcessRisks'),
(4,  N'Lookup.CreateSubProcessRisk'),
(4,  N'Lookup.UpdateSubProcessRisk'),
(4,  N'Lookup.DeleteSubProcessRisk'),
(4, N'Lookup.ReorderSubProcessRisks'),
(4,  N'Lookup.CreateRiskExposure'),
(4,  N'Lookup.UpdateRiskExposure'),
(4,  N'Lookup.DeleteRiskExposure'),
(4, N'Lookup.ReorderRiskExposures'),
(4,  N'Lookup.CreateRiskImpact'),
(4,  N'Lookup.UpdateRiskImpact'),
(4,  N'Lookup.DeleteRiskImpact'),
(4, N'Lookup.ReorderRiskImpacts'),
(4,  N'Lookup.CreateSite'),
(4,  N'Lookup.UpdateSite'),
(4,  N'Lookup.DeleteSite'),
(4, N'Lookup.ReorderSites'),
(4,  N'Lookup.CreateKPI'),
(4,  N'Lookup.UpdateKPI'),
(4,  N'Lookup.DeleteKPI'),
(4, N'Lookup.ReorderKPIs'),
(4,  N'Lookup.CreateSLA'),
(4,  N'Lookup.UpdateSLA'),
(4,  N'Lookup.DeleteSLA'),
(4, N'Lookup.ReorderSLAs'),
(4, N'Lookup.GetAllSLAs'),
(4,  N'Lookup.CreateTestingFrequency'),
(4,  N'Lookup.UpdateTestingFrequency'),
(4,  N'Lookup.DeleteTestingFrequency'),
(4, N'Lookup.ReorderTestingFrequencies'),
(4, N'Lookup.CreateRiskScoreRange'),
(4, N'Lookup.UpdateRiskScoreRange'),
(4, N'Lookup.DeleteRiskScoreRange'),
(4, N'Lookup.GetAllRiskScoreRanges'),
(4,  N'Lookup.GetPendingAddOns'),
(4,  N'Lookup.CountPendingAddOns'),
(4,  N'Lookup.Import');
SET NOCOUNT OFF

SET IDENTITY_INSERT [Assessment] ON
INSERT INTO [Assessment] ([Id], [FunctionalAreaDescription], [AssessmentDueDate], [OverallRiskRatingCommentary], [ApprovalStatus], [BUFunctionalApproverUsername], [BUFunctionalApproveTime], [BURiskManagementApproverUsername], [BURiskManagementApproveTime], [DivisionalRiskManagementApproverUsername], [DivisionalRiskManagementApproveTime], [RejecterUsername], [RejectTime], [RejectionReason], [RejectPhase], [SubmitterUsername], [SubmitTime], [Title], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [BusinessUnit_Id], [DepartmentHead_Id], [Department_Id], [FunctionalAreaOwner_Id], [FunctionalArea_Id], [AssessmentType_Id], [AssessmentStatus_Id])
VALUES
(1, N'FunctionalAreaDescription1', '04/20/2016', N'OverallRiskRatingCommentary1', 0, N'CoeusBUFuncApp1', '04/19/2016', N'CoeusRiskManager', '04/18/2016', N'CoeusDivManager', '04/17/2016', NULL, NULL, NULL, 0, N'CoeusOwnerUser1', '04/15/2016', N'Title1', N'CreatedBy1', '04/14/2016', N'LastUpdatedBy1', '04/13/2016', 1, 1, 1, 1, 1, 1, 1),
(2, N'FunctionalAreaDescription1', '04/10/2016', N'OverallRiskRatingCommentary2', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, N'CoeusOwnerUser1', '04/05/2016', N'Title2', N'CreatedBy2', '04/04/2016', N'LastUpdatedBy2', '04/03/2016', 1, 1, 2, 2, 2, 2, 2),
(4, N'FunctionalAreaDescription2', '03/21/2016', N'OverallRiskRatingCommentary1', 2, N'CoeusBUFuncApp1', '03/20/2016', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'CoeusOwnerUser1', '03/16/2016', N'Title14', N'CreatedBy4', '03/15/2016', N'LastUpdatedBy4', '03/14/2016', 1, 2,  2, 4, 4, 2, 1),
(5, N'FunctionalAreaDescription2', '03/11/2016', N'OverallRiskRatingCommentary2', 3, N'CoeusBUFuncApp1', '03/10/2016', N'CoeusRiskManager', '03/09/2016', NULL, NULL, NULL, NULL, NULL, 0, N'CoeusOwnerUser1', '03/06/2016', N'Title15', N'CreatedBy5', '03/05/2016', N'LastUpdatedBy5', '03/04/2016', 2, 1,  3, 2, 3, 1, 1),
(7, N'FunctionalAreaDescription1', '02/20/2016', N'OverallRiskRatingCommentary3', 5, N'CoeusBUFuncApp1', '02/19/2016', N'CoeusRiskManager', '02/18/2016', N'CoeusDivManager', '02/17/2016', N'CoeusAdminUser', '02/16/2016', N'RejectionReason7', 1, N'CoeusOwnerUser1', '02/15/2016', N'Title17', N'CreatedBy7', '02/14/2016', N'LastUpdatedBy7', '02/13/2016', 2, 2, 3, 4, 3, 1, 3),
(8, N'FunctionalAreaDescription1', '02/10/2016', N'OverallRiskRatingCommentary2', 5, N'CoeusBUFuncApp1', '02/09/2016', N'CoeusRiskManager', '02/08/2016', N'CoeusDivManager', '02/07/2016', N'CoeusDivManager', '02/06/2016', N'RejectionReason8', 2, N'CoeusAdminUser', '02/05/2016', N'Title8', N'CreatedBy8', '02/04/2016', N'LastUpdatedBy8', '02/03/2016', 3, 1,  2, 4, 3, 4, 2),
(10, N'FunctionalAreaDescription2', '01/21/2016', N'OverallRiskRatingCommentary1', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, N'CoeusOwnerUser1', '01/16/2016', N'Title10', N'CreatedBy10', '01/15/2016', N'LastUpdatedBy10', '01/14/2016', 4, 3, 2, 2, 1, 1, 3),
(3, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Title2', N'CreatedBy3', '03/31/2016', N'LastUpdatedBy3', '03/30/2016', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(6, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Title6', N'CreatedBy6', '03/01/2016', N'LastUpdatedBy6', '02/29/2016', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(9, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Title9', N'CreatedBy9', '01/31/2016', N'LastUpdatedBy9', '01/30/2016', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [Assessment] OFF

INSERT INTO [Assessment_Product]([AssessmentId], [ProductId]) VALUES(1,1);
INSERT INTO [Assessment_Product]([AssessmentId], [ProductId]) VALUES(2,2);
INSERT INTO [Assessment_Product]([AssessmentId], [ProductId]) VALUES(4,3);
INSERT INTO [Assessment_Product]([AssessmentId], [ProductId]) VALUES(5,1);
INSERT INTO [Assessment_Product]([AssessmentId], [ProductId]) VALUES(7,1);
INSERT INTO [Assessment_Product]([AssessmentId], [ProductId]) VALUES(8,1);
INSERT INTO [Assessment_Product]([AssessmentId], [ProductId]) VALUES(10,1);

SET IDENTITY_INSERT [ProcessControlAssessment] ON
INSERT INTO [ProcessControlAssessment] ([Id], [LikelihoodOfOccurrence_Id], [RiskExposure_Id], [Category_Id])
VALUES
(1, 1, 1, 3),
(2, 1, 1, 4),
(3, 1, 1, 5),
(4, 1, 1, 6),
(5, 1, 1, 2),
(6, 1, 2, 3),
(7, 2, 2, 3),
(8, 2, 2, 4),
(9, 2, 3, 4),
(10, 2, 3, 5),
(11, 1, 1, 2),
(12, 2, 2, 2),
(13, 3, 3, 2),
(14, 4, 2, 2),
(15, 1, 1, 2),
(16, 1, 2, 2),
(17, 2, 2, 2),
(18, 2, 2, 4),
(19, 2, 3, 4),
(20, 2, 3, 5)
SET IDENTITY_INSERT [ProcessControlAssessment] OFF

INSERT INTO [ProcessRiskAssessment] ([Id], [AdditionalProcess], [AdditionalRisk], [ProcessRisk_Id], [Assessment_Id])
VALUES
(1, N'AdditionalProcess1', N'AdditionalRisk1', 1, 1),
(2, N'AdditionalProcess2', N'AdditionalRisk2', 2, 1),
(3, NULL, NULL, 3, 1),
(4, N'AdditionalProcess4', N'AdditionalRisk4', 4, 1),
(5, N'AdditionalProcess5', N'AdditionalRisk5', 5, 2),
(6, NULL, NULL, 6, 2),
(7, N'AdditionalProcess7', N'AdditionalRisk7', 7, 2),
(8, N'AdditionalProcess8', N'AdditionalRisk8', 8, 3),
(9, NULL, NULL, 9, 3),
(10, N'AdditionalProcess10', N'AdditionalRisk10', 10, 4)

INSERT INTO [FunctionalAreaProcessAssessment] ([Id], [AdditionalCoreProcess], [AdditionalSubProcess], [AdditionalRisk], [SubProcessRisk_Id],[CoreProcess_Id], [Assessment_Id])
VALUES
(11, N'AdditionalCoreProcess1',N'AdditionalSubProcess1', N'AdditionalRisk1', null, null, 1),
(12, null, N'AdditonalCoreSubProcess1', N'AdditionalRisk2', null, 2, 1),
(13, NULL, NULL,NULL,2, 3, 1),
(14, N'AdditionalCoreProcess4',N'AdditionalSubProcess4', N'AdditionalRisk4', null, null, 1),
(15, null,N'AdditionalSubProcess5', N'AdditionalRisk5',null, null, 2),
(16, NULL, NULL,null,3, 2, 2),
(17, N'AdditionalCoreProcess7',N'AdditionalSubProcess7', N'AdditionalCoreRisk7',null,null, 3)

INSERT INTO [ProcessControlAssessment_RiskImpact] ([ProcessControlAssessmentId], [RiskImpactId])
VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(11, 1),
(11, 2),
(13, 3),
(14, 4),
(15, 5)

SET IDENTITY_INSERT [FunctionChange] ON
INSERT INTO [FunctionChange] ([Id], [ChangeTime], [ChangeDescription], [ChangeType_Id])
VALUES
(1, '04/20/2016', N'ChangeDescription1', 1),
(2, '04/10/2016', N'ChangeDescription2', 2),
(3, '03/31/2016', N'ChangeDescription3', 3),
(4, '03/21/2016', N'ChangeDescription4', 4),
(5, '03/11/2016', N'ChangeDescription5', 5),
(6, '03/01/2016', N'ChangeDescription6', 6),
(7, '02/20/2016', N'ChangeDescription7', 7),
(8, '02/10/2016', N'ChangeDescription8', 3),
(9, '01/31/2016', N'ChangeDescription9', 4),
(10, '01/21/2016', N'ChangeDescription10', 5)
SET IDENTITY_INSERT [FunctionChange] OFF

INSERT INTO [PriorFunctionChanges] ([AssessmentId], [FunctionChangeId])
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 5),
(2, 6),
(2, 7),
(3, 8),
(3, 9),
(4, 10)

INSERT INTO [FutureFunctionChanges] ([AssessmentId], [FunctionChangeId])
VALUES
(1, 10),
(1, 9),
(1, 8),
(1, 7),
(2, 6),
(2, 5),
(2, 4),
(3, 3),
(3, 2),
(4, 1)

SET IDENTITY_INSERT [KPISLAAssessment] ON
INSERT INTO [KPISLAAssessment] ([Id], [AdditionalKPI], [AdditionalSLA], [KPI_Id], [SelectedSLA_Id], [Assessment_Id], [Category_Id], [KPICategory_Id])
VALUES
(11, N'AdditionalKPI1', N'AdditionalSLA1', 1, 1, 1,1,1),
(12, N'AdditionalKPI2', N'AdditionalSLA2', 2, 2, 1,1,1),
(13, NULL, NULL, NULL, NULL, 1,1,1),
(14, N'AdditionalKPI4', N'AdditionalSLA4', 4, 4, 1,1,2),
(15, N'AdditionalKPI5', N'AdditionalSLA5', 5, 5, 2,1,2),
(16, NULL, NULL, NULL, NULL, 2,1,1),
(17, N'AdditionalKPI7', N'AdditionalSLA7', 7, 7, 2,1,3),
(18, N'AdditionalKPI8', N'AdditionalSLA8', 4, 8, 3,1,1),
(19, NULL, NULL, NULL, NULL, 3,1,1),
(20, N'AdditionalKPI10', N'AdditionalSLA10', 5, 10, 4,1,3)
SET IDENTITY_INSERT [KPISLAAssessment] OFF

SET IDENTITY_INSERT [FunctionPerformedSite] ON
INSERT INTO [FunctionPerformedSite] ([Id], [Site_Id], [Percentage_Id], [Assessment_Id])
VALUES
(1, 1, 1, 1),
(2, 2, 2, 1),
(3, 3, 3, 1),
(4, 4, 4, 1),
(5, 5, 5, 2),
(6, 6, 6, 2),
(7, 7, 7, 2),
(8, 3, 8, 3),
(9, 4, 9, 3),
(10, 5, 10, 4)
SET IDENTITY_INSERT [FunctionPerformedSite] OFF

SET IDENTITY_INSERT [ControlAssessment] ON
INSERT INTO [ControlAssessment] ([Id], [OtherControlType], [ControlObjective], [ControlType_Id], [ControlFrequency_Id], [KeyControlsMaturity_Id], [ProcessControlAssessment_Id])
VALUES
(1, N'OtherControlType1', N'ControlObjective1', 1, 1, 1, 1),
(2, N'OtherControlType2', N'ControlObjective2', 2, 2, 2, 1),
(3, NULL, N'ControlObjective3', 3, 3, 3, 2),
(4, N'OtherControlType4', N'ControlObjective4', 4, 4, 1, 3),
(5, N'OtherControlType5', N'ControlObjective5', 5, 5, 2, 4),
(6, NULL, N'ControlObjective6',6, 6, 3, 11),
(7, N'OtherControlType7', N'ControlObjective7',  7, 7, 2, 11),
(8, N'OtherControlType8', N'ControlObjective8',  8, 1, 3, 11),
(9, NULL, N'ControlObjective9', 9, 2, 2, 13),
(10, N'OtherControlType10', N'ControlObjective10', 2, 3, 1, 14)
SET IDENTITY_INSERT [ControlAssessment] OFF

INSERT INTO [ControlAssessment_TestingFrequency] ([ControlAssessmentId], [TestingFrequencyId])
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10)

INSERT INTO [ControlAssessment_ControlTrigger] ([ControlAssessmentId], [ControlTriggerId])
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 2)

INSERT INTO [ControlAssessment_ControlDesign] ([ControlAssessmentId], [ControlDesignId])
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 1),
(6, 2),
(7, 3),
(8, 4),
(9, 2),
(10, 3)

SET IDENTITY_INSERT [Category] ON
INSERT INTO [Category] ([Id], [Name], [Weight], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'KPI''s / SLA''s1',  0, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999');
SET IDENTITY_INSERT [Category] OFF

SET IDENTITY_INSERT [BusinessUnit] ON
INSERT INTO [BusinessUnit] ([Id], [Name], [Category_Id],  [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Shared Services1',1111, 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [BusinessUnit] OFF

SET IDENTITY_INSERT [FunctionalArea] ON
INSERT INTO [FunctionalArea] ([Id], [Name], [BusinessUnitId] ,[Category_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Account Maintenance1', 1111, 1111, 1,  1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(1112, N'Account Maintenance2', 1, 1111, 1,  1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [FunctionalArea] OFF

SET IDENTITY_INSERT [CoreProcess] ON
INSERT INTO [CoreProcess] ([Id], [Name], [FunctionalAreaId], [Category_Id],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Policies and procedures1', 1111, 1111, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [CoreProcess] OFF

SET IDENTITY_INSERT [SubProcessRisk] ON
INSERT INTO [SubProcessRisk] ([Id], [Name], [Risk], [CoreProcess_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Test1', N'te', 1111,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [SubProcessRisk] OFF

SET IDENTITY_INSERT [ProcessRisk] ON
INSERT INTO [ProcessRisk] ([Id], [Name], [Risk], [Category_Id], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Documented', N'Procedures not followed', 1111,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999');
SET IDENTITY_INSERT [ProcessRisk] OFF

SET IDENTITY_INSERT [ControlType] ON
INSERT INTO [ControlType] ([Id], [Name], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime], [Category_id])
VALUES
(1111, N'for process Risk',1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 1111),
(1112, N'for Core process Risk',1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999', 1111);
SET IDENTITY_INSERT [ControlType] OFF

INSERT INTO CoreProcess_ControlType(CoreProcessId, ControlTypeId) VALUES(1111,1112);
INSERT INTO ProcessRIsk_ControlType(ProcessRIskId, ControlTypeId) VALUES(1111,1111);

SET IDENTITY_INSERT [Product] ON
INSERT INTO [Product] ([Id], [Name], [BusinessUnitId], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Product', 1111, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [Product] OFF

SET IDENTITY_INSERT [Department] ON
INSERT INTO [Department] ([Id], [Name], [BusinessUnitId],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Department ', 1111 , 1,1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [Department] OFF

SET IDENTITY_INSERT [DepartmentHead] ON
INSERT INTO [DepartmentHead] ([Id], [Name], [BusinessUnitId], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111,  @CoeusAdmin, 1111 ,1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [DepartmentHead] OFF

SET IDENTITY_INSERT [FunctionalAreaOwner] ON
INSERT INTO [FunctionalAreaOwner] ([Id], [Name], [BusinessUnitId], [Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, @CoeusAdmin, 1111, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [FunctionalAreaOwner] OFF

-- for testing KPIs 
SET IDENTITY_INSERT [KPICategory] ON
INSERT INTO [KPICategory] ([Id], [Name],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Customer Centricity2', 1, 5, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [KPICategory] OFF

SET IDENTITY_INSERT [KPI] ON
INSERT INTO [KPI] ([Id], [Name],[KPICategory_Id],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111, N'Answer Rate3', 1111, 1, 1, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999')
SET IDENTITY_INSERT [KPI] OFF

SET IDENTITY_INSERT [SLA] ON
INSERT INTO [SLA] ([Id], [Name],[Enabled], [DisplayOrder], [AddOnStatus], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime])
VALUES
(1111,  N'Not applicable1', 1, 50, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999'),
(1112,  N'Not applicable3', 1, 50, 1, @CoeusAdmin, '12/12/9999', @CoeusAdmin, '12/12/9999');
SET IDENTITY_INSERT [SLA] OFF
INSERT INTO KPICategory_SLA(KPICategoryId, SLAId)
VALUES
(1111,1111),
(1111,1112);