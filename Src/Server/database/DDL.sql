/***************************************************************************
 * Architect: LOY, albertwang
 * Assembler: NightWolf, veshu, TCSASSEMBLER, TCSASSEMBLER
 * Version: 1.7
 * Copyright (c) 2016-2017, TopCoder, Inc. All rights reserved.
 *
 * Description:
 *     This file contains DDL for all required tables used by backend assembly.
 * Changes in 1.1:
 *		- changed ProcessRiskAssessment.ProcessRisk_Id to nullable
 *		- changed ProcessControlAssessment.LikelihoodOfOccurrence_Id to nullable
 *		- changed ProcessControlAssessment.RiskExposure_Id to nullable
 *		- changed ControlObjective, Tested,[ControlType_Id],[ControlFrequency_Id],[KeyControlsMaturity_Id] of ControlAssessment to nullable
 * Changes in 1.2
 *		- changed Assessment.Title to not nullable
 *		- Added 'OtherTestingFrequency' and 'OtherKeyControlMaturity' in controlAssessment table
 * Changes in 1.3 during 72H! JOHN HANCOCK - PROJECT COEUS USERS AND ROLES MANAGEMENT
 *      - Added new tables 'UserMappingInfo' and 'User_BusinessUnit'
 *
 * Changes in 1.4 during John Hancock - Project Coeus Admin Backend Assembly v1.0:
 * Changes in 1.5 during JOHN HANCOCK - PROJECT COEUS ADMIN FRONTEND ASSEMBLY PART 2
 * Changes in 1.6 during JOHN HANCOCK - PROJECT COEUS ADMIN RELEASE ASSEMBLY
 * Changes in 1.7 during JOHN HANCOCK - COEUS SECURITY UPDATES AND KPI SCORECARD FRONTEND INTEGRATION 1 ASSEMBLY
 *
 ***************************************************************************/
--------------- Drop Tables, if exist ---------------
use projectCoeus;
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_User_BusinessUnit_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[User_BusinessUnit]'))
ALTER TABLE [dbo].[User_BusinessUnit] DROP CONSTRAINT [fk_User_BusinessUnit_User1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_User_BusinessUnit_BusinessUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[User_BusinessUnit]'))
ALTER TABLE [dbo].[User_BusinessUnit] DROP CONSTRAINT [fk_User_BusinessUnit_BusinessUnit1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_SubProcessRisk_CoreProcess1]') AND parent_object_id = OBJECT_ID(N'[dbo].[SubProcessRisk]'))
ALTER TABLE [dbo].[SubProcessRisk] DROP CONSTRAINT [fk_SubProcessRisk_CoreProcess1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Product_BusinessUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product]'))
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessRiskAssessment_ProcessRisk1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRiskAssessment]'))
ALTER TABLE [dbo].[ProcessRiskAssessment] DROP CONSTRAINT [fk_ProcessRiskAssessment_ProcessRisk1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProcessRiskAssessment_ProcessControlAssessment]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRiskAssessment]'))
ALTER TABLE [dbo].[ProcessRiskAssessment] DROP CONSTRAINT [FK_ProcessRiskAssessment_ProcessControlAssessment]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessRiskAssessment_Assessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRiskAssessment]'))
ALTER TABLE [dbo].[ProcessRiskAssessment] DROP CONSTRAINT [fk_ProcessRiskAssessment_Assessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessRisk_ControlType_ProcessRisk1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRisk_ControlType]'))
ALTER TABLE [dbo].[ProcessRisk_ControlType] DROP CONSTRAINT [fk_ProcessRisk_ControlType_ProcessRisk1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessRisk_ControlType_ControlType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRisk_ControlType]'))
ALTER TABLE [dbo].[ProcessRisk_ControlType] DROP CONSTRAINT [fk_ProcessRisk_ControlType_ControlType1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessRisk_FunctionalArea1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRisk]'))
ALTER TABLE [dbo].[ProcessRisk] DROP CONSTRAINT [fk_ProcessRisk_FunctionalArea1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessRisk_Category1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRisk]'))
ALTER TABLE [dbo].[ProcessRisk] DROP CONSTRAINT [fk_ProcessRisk_Category1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessRisk_BusinessUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessRisk]'))
ALTER TABLE [dbo].[ProcessRisk] DROP CONSTRAINT [fk_ProcessRisk_BusinessUnit1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessControlAssessment_RiskImpact_RiskImpact1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessControlAssessment_RiskImpact]'))
ALTER TABLE [dbo].[ProcessControlAssessment_RiskImpact] DROP CONSTRAINT [fk_ProcessControlAssessment_RiskImpact_RiskImpact1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessControlAssessment_RiskImpact_ProcessControlAssessme1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessControlAssessment_RiskImpact]'))
ALTER TABLE [dbo].[ProcessControlAssessment_RiskImpact] DROP CONSTRAINT [fk_ProcessControlAssessment_RiskImpact_ProcessControlAssessme1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessControlAssessment_RiskExposure1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessControlAssessment]'))
ALTER TABLE [dbo].[ProcessControlAssessment] DROP CONSTRAINT [fk_ProcessControlAssessment_RiskExposure1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessControlAssessment_LikelihoodOfOccurrence1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessControlAssessment]'))
ALTER TABLE [dbo].[ProcessControlAssessment] DROP CONSTRAINT [fk_ProcessControlAssessment_LikelihoodOfOccurrence1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ProcessControlAssessment_Category1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProcessControlAssessment]'))
ALTER TABLE [dbo].[ProcessControlAssessment] DROP CONSTRAINT [fk_ProcessControlAssessment_Category1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_FunctionChange_FunctionChange1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PriorFunctionChanges]'))
ALTER TABLE [dbo].[PriorFunctionChanges] DROP CONSTRAINT [fk_Assessment_FunctionChange_FunctionChange1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_FunctionChange_Assessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[PriorFunctionChanges]'))
ALTER TABLE [dbo].[PriorFunctionChanges] DROP CONSTRAINT [fk_Assessment_FunctionChange_Assessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncidentMitigationCodeValue_PrivacyIncidentMitigati]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]'))
ALTER TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncidentMitigationCodeValue_PrivacyIncidentMitigati]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncident_PrivacyIncidentId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]'))
ALTER TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncident_PrivacyIncidentId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_ReportedToORMYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_ReportedToORMYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_RemediationYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_RemediationYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_IncidentYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_IncidentYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentTypeValue_IncidentType_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentTypeValue_IncidentType_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentStatusValue_Status_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentStatusValue_Status_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentRootCauseValue_RootCause_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentRootCauseValue_RootCause_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_RemediationMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_RemediationMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_IncidentMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_IncidentMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_PrivacyIncident_dbo.KST_BusinessUnit_BusinessUnit_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]'))
ALTER TABLE [dbo].[KST_PrivacyIncident] DROP CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncidentImpactValue_OperationalIncidentImpactVa]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]'))
ALTER TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncidentImpactValue_OperationalIncidentImpactVa]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncident_OperationalIncidentId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]'))
ALTER TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncident_OperationalIncidentId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_ReportedToORMYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_ReportedToORMYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_RemediationYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_RemediationYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_IncidentYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_IncidentYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentStatusValue_Status_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentStatusValue_Status_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentSourceValue_Source_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentSourceValue_Source_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentRootCauseValue_RootCause_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentRootCauseValue_RootCause_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentReportedToGORMValue_ReportedToGORM_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentReportedToGORMValue_ReportedToGORM_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_RemediationMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_RemediationMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_IncidentMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_IncidentMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_FinancialExposureValue_FinancialExposure_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_FinancialExposureValue_FinancialExposure_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_OperationalIncident_dbo.KST_BusinessUnit_BusinessUnit_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]'))
ALTER TABLE [dbo].[KST_OperationalIncident] DROP CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_KPIVolumeScore_dbo.KST_VolumeTypeValue_VolumeType_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_KPIVolumeScore]'))
ALTER TABLE [dbo].[KST_KPIVolumeScore] DROP CONSTRAINT [FK_dbo.KST_KPIVolumeScore_dbo.KST_VolumeTypeValue_VolumeType_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_KPIVolumeScore_dbo.KST_KPIScore_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_KPIVolumeScore]'))
ALTER TABLE [dbo].[KST_KPIVolumeScore] DROP CONSTRAINT [FK_dbo.KST_KPIVolumeScore_dbo.KST_KPIScore_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_Threshold_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_KPIScorecardItem]'))
ALTER TABLE [dbo].[KST_KPIScorecardItem] DROP CONSTRAINT [FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_Threshold_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_ServiceLevel_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_KPIScorecardItem]'))
ALTER TABLE [dbo].[KST_KPIScorecardItem] DROP CONSTRAINT [FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_ServiceLevel_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_LowPerformanceReason_LowPerformanceReasonId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_KPIScore_LowPerformanceReason]'))
ALTER TABLE [dbo].[KST_KPIScore_LowPerformanceReason] DROP CONSTRAINT [FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_LowPerformanceReason_LowPerformanceReasonId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_KPIScore_KPIScoreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_KPIScore_LowPerformanceReason]'))
ALTER TABLE [dbo].[KST_KPIScore_LowPerformanceReason] DROP CONSTRAINT [FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_KPIScore_KPIScoreId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_KPIScore_dbo.KST_KPIScorecardItem_ScorecardItem_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_KPIScore]'))
ALTER TABLE [dbo].[KST_KPIScore] DROP CONSTRAINT [FK_dbo.KST_KPIScore_dbo.KST_KPIScorecardItem_ScorecardItem_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_KPIScore_KPIScoreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_KPIScore_KPIScoreId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_KPIVolumeScore_KPIVolumeScoreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_KPIVolumeScore_KPIVolumeScoreId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_KPIScore_KPIScoreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_KPIScore_KPIScoreId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_KPIScore_KPIScoreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_KPIScore_KPIScoreId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_KPIScore_KPIScoreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_KPIScore_KPIScoreId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_YearValue_Year_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_YearValue_Year_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_StatusValue_Status_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_StatusValue_Status_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_MonthValue_Month_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_MonthValue_Month_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_BusinessUnit_BusinessUnit_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard]'))
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] DROP CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFindingImpactValue_AuditFindingImpactValueId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding_AuditFindingImpactValue]'))
ALTER TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFindingImpactValue_AuditFindingImpactValueId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFinding_AuditFindingId]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding_AuditFindingImpactValue]'))
ALTER TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFinding_AuditFindingId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_YearValue_ReportedToORMYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_ReportedToORMYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_YearValue_RemediationYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_RemediationYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_YearValue_AuditYear_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_AuditYear_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_ReportedToORMMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_ReportedToORMMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_RemediationMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_RemediationMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_AuditMonth_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_AuditMonth_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_BusinessUnit_BusinessUnit_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingStatusValue_Status_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingStatusValue_Status_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingSourceValue_Source_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingSourceValue_Source_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingRootCauseValue_RootCause_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingRootCauseValue_RootCause_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingReportedToGORMValue_ReportedToGORM_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]'))
ALTER TABLE [dbo].[KST_AuditFinding] DROP CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingReportedToGORMValue_ReportedToGORM_Id]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPISLAAssessment_SLA1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPISLAAssessment]'))
ALTER TABLE [dbo].[KPISLAAssessment] DROP CONSTRAINT [fk_KPISLAAssessment_SLA1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPISLAAssessment_KPICategory1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPISLAAssessment]'))
ALTER TABLE [dbo].[KPISLAAssessment] DROP CONSTRAINT [fk_KPISLAAssessment_KPICategory1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPISLAAssessment_KPI1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPISLAAssessment]'))
ALTER TABLE [dbo].[KPISLAAssessment] DROP CONSTRAINT [fk_KPISLAAssessment_KPI1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPISLAAssessment_Category1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPISLAAssessment]'))
ALTER TABLE [dbo].[KPISLAAssessment] DROP CONSTRAINT [fk_KPISLAAssessment_Category1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPISLAAssessment_Assessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPISLAAssessment]'))
ALTER TABLE [dbo].[KPISLAAssessment] DROP CONSTRAINT [fk_KPISLAAssessment_Assessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPICategory_SLA_SLA1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPICategory_SLA]'))
ALTER TABLE [dbo].[KPICategory_SLA] DROP CONSTRAINT [fk_KPICategory_SLA_SLA1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPICategory_SLA_KPICategoryId1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPICategory_SLA]'))
ALTER TABLE [dbo].[KPICategory_SLA] DROP CONSTRAINT [fk_KPICategory_SLA_KPICategoryId1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPICategory_FunctionalArea1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPICategory]'))
ALTER TABLE [dbo].[KPICategory] DROP CONSTRAINT [fk_KPICategory_FunctionalArea1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPICategory_BusinessUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPICategory]'))
ALTER TABLE [dbo].[KPICategory] DROP CONSTRAINT [fk_KPICategory_BusinessUnit1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_KPI_KPICategory1]') AND parent_object_id = OBJECT_ID(N'[dbo].[KPI]'))
ALTER TABLE [dbo].[KPI] DROP CONSTRAINT [fk_KPI_KPICategory1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_FunctionChange1_FunctionChange1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FutureFunctionChanges]'))
ALTER TABLE [dbo].[FutureFunctionChanges] DROP CONSTRAINT [fk_Assessment_FunctionChange1_FunctionChange1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_FunctionChange1_Assessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FutureFunctionChanges]'))
ALTER TABLE [dbo].[FutureFunctionChanges] DROP CONSTRAINT [fk_Assessment_FunctionChange1_Assessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionPerformedSite_Site]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionPerformedSite]'))
ALTER TABLE [dbo].[FunctionPerformedSite] DROP CONSTRAINT [fk_FunctionPerformedSite_Site]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionPerformedSite_Percentage1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionPerformedSite]'))
ALTER TABLE [dbo].[FunctionPerformedSite] DROP CONSTRAINT [fk_FunctionPerformedSite_Percentage1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionPerformedSite_Assessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionPerformedSite]'))
ALTER TABLE [dbo].[FunctionPerformedSite] DROP CONSTRAINT [fk_FunctionPerformedSite_Assessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionChange_ChangeType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionChange]'))
ALTER TABLE [dbo].[FunctionChange] DROP CONSTRAINT [fk_FunctionChange_ChangeType1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionalAreaProcessAssessment_SubProcessRisk1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionalAreaProcessAssessment]'))
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] DROP CONSTRAINT [fk_FunctionalAreaProcessAssessment_SubProcessRisk1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FunctionalAreaProcessAssessment_ProcessControlAssessment]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionalAreaProcessAssessment]'))
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] DROP CONSTRAINT [FK_FunctionalAreaProcessAssessment_ProcessControlAssessment]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionalAreaProcessAssessment_CoreProcess1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionalAreaProcessAssessment]'))
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] DROP CONSTRAINT [fk_FunctionalAreaProcessAssessment_CoreProcess1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionalAreaProcessAssessment_Assessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionalAreaProcessAssessment]'))
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] DROP CONSTRAINT [fk_FunctionalAreaProcessAssessment_Assessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FunctionalAreaOwner_BusinessUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionalAreaOwner]'))
ALTER TABLE [dbo].[FunctionalAreaOwner] DROP CONSTRAINT [FK_FunctionalAreaOwner_BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_FunctionalArea_Category1]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionalArea]'))
ALTER TABLE [dbo].[FunctionalArea] DROP CONSTRAINT [fk_FunctionalArea_Category1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FunctionalArea_BusinessUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[FunctionalArea]'))
ALTER TABLE [dbo].[FunctionalArea] DROP CONSTRAINT [FK_FunctionalArea_BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DepartmentHead_BusinessUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[DepartmentHead]'))
ALTER TABLE [dbo].[DepartmentHead] DROP CONSTRAINT [FK_DepartmentHead_BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Department_BusinessUnit]') AND parent_object_id = OBJECT_ID(N'[dbo].[Department]'))
ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_Department_BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_CoreProcess_ControlType_CoreProcess1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CoreProcess_ControlType]'))
ALTER TABLE [dbo].[CoreProcess_ControlType] DROP CONSTRAINT [fk_CoreProcess_ControlType_CoreProcess1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_CoreProcess_ControlType_ControlType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CoreProcess_ControlType]'))
ALTER TABLE [dbo].[CoreProcess_ControlType] DROP CONSTRAINT [fk_CoreProcess_ControlType_ControlType1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_CoreProcess_FunctionalArea1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CoreProcess]'))
ALTER TABLE [dbo].[CoreProcess] DROP CONSTRAINT [fk_CoreProcess_FunctionalArea1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_CoreProcess_Category1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CoreProcess]'))
ALTER TABLE [dbo].[CoreProcess] DROP CONSTRAINT [fk_CoreProcess_Category1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_CoreProcess_BusinessUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CoreProcess]'))
ALTER TABLE [dbo].[CoreProcess] DROP CONSTRAINT [fk_CoreProcess_BusinessUnit1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlType_Category1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlType]'))
ALTER TABLE [dbo].[ControlType] DROP CONSTRAINT [fk_ControlType_Category1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_TestingFrequency_TestingFrequency1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment_TestingFrequency]'))
ALTER TABLE [dbo].[ControlAssessment_TestingFrequency] DROP CONSTRAINT [fk_ControlAssessment_TestingFrequency_TestingFrequency1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_TestingFrequency_ControlAssessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment_TestingFrequency]'))
ALTER TABLE [dbo].[ControlAssessment_TestingFrequency] DROP CONSTRAINT [fk_ControlAssessment_TestingFrequency_ControlAssessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_ControlTrigger_ControlTrigger1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment_ControlTrigger]'))
ALTER TABLE [dbo].[ControlAssessment_ControlTrigger] DROP CONSTRAINT [fk_ControlAssessment_ControlTrigger_ControlTrigger1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_ControlTrigger_ControlAssessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment_ControlTrigger]'))
ALTER TABLE [dbo].[ControlAssessment_ControlTrigger] DROP CONSTRAINT [fk_ControlAssessment_ControlTrigger_ControlAssessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_ControlDesign_ControlDesign1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment_ControlDesign]'))
ALTER TABLE [dbo].[ControlAssessment_ControlDesign] DROP CONSTRAINT [fk_ControlAssessment_ControlDesign_ControlDesign1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_ControlDesign_ControlAssessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment_ControlDesign]'))
ALTER TABLE [dbo].[ControlAssessment_ControlDesign] DROP CONSTRAINT [fk_ControlAssessment_ControlDesign_ControlAssessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_ProcessControlAssessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment]'))
ALTER TABLE [dbo].[ControlAssessment] DROP CONSTRAINT [fk_ControlAssessment_ProcessControlAssessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_KeyControlsMaturity1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment]'))
ALTER TABLE [dbo].[ControlAssessment] DROP CONSTRAINT [fk_ControlAssessment_KeyControlsMaturity1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_ControlType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment]'))
ALTER TABLE [dbo].[ControlAssessment] DROP CONSTRAINT [fk_ControlAssessment_ControlType1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_ControlAssessment_ControlFrequency1]') AND parent_object_id = OBJECT_ID(N'[dbo].[ControlAssessment]'))
ALTER TABLE [dbo].[ControlAssessment] DROP CONSTRAINT [fk_ControlAssessment_ControlFrequency1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_BusinessUnit_Category1]') AND parent_object_id = OBJECT_ID(N'[dbo].[BusinessUnit]'))
ALTER TABLE [dbo].[BusinessUnit] DROP CONSTRAINT [fk_BusinessUnit_Category1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_Product_Product1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment_Product]'))
ALTER TABLE [dbo].[Assessment_Product] DROP CONSTRAINT [fk_Assessment_Product_Product1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_Product_Assessment1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment_Product]'))
ALTER TABLE [dbo].[Assessment_Product] DROP CONSTRAINT [fk_Assessment_Product_Assessment1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_FunctionalAreaOwner1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment]'))
ALTER TABLE [dbo].[Assessment] DROP CONSTRAINT [fk_Assessment_FunctionalAreaOwner1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_FunctionalArea1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment]'))
ALTER TABLE [dbo].[Assessment] DROP CONSTRAINT [fk_Assessment_FunctionalArea1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_DepartmentHead1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment]'))
ALTER TABLE [dbo].[Assessment] DROP CONSTRAINT [fk_Assessment_DepartmentHead1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_Department1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment]'))
ALTER TABLE [dbo].[Assessment] DROP CONSTRAINT [fk_Assessment_Department1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_BusinessUnit1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment]'))
ALTER TABLE [dbo].[Assessment] DROP CONSTRAINT [fk_Assessment_BusinessUnit1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_AssessmentType1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment]'))
ALTER TABLE [dbo].[Assessment] DROP CONSTRAINT [fk_Assessment_AssessmentType1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Assessment_AssessmentStatus1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assessment]'))
ALTER TABLE [dbo].[Assessment] DROP CONSTRAINT [fk_Assessment_AssessmentStatus1]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserMappingInfo]') AND type in (N'U'))
DROP TABLE [dbo].[UserMappingInfo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_BusinessUnit]') AND type in (N'U'))
DROP TABLE [dbo].[User_BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Token]') AND type in (N'U'))
DROP TABLE [dbo].[Token]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestingFrequency]') AND type in (N'U'))
DROP TABLE [dbo].[TestingFrequency]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SubProcessRisk]') AND type in (N'U'))
DROP TABLE [dbo].[SubProcessRisk]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SLA]') AND type in (N'U'))
DROP TABLE [dbo].[SLA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Site]') AND type in (N'U'))
DROP TABLE [dbo].[Site]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RiskScoreRange]') AND type in (N'U'))
DROP TABLE [dbo].[RiskScoreRange]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RiskImpact]') AND type in (N'U'))
DROP TABLE [dbo].[RiskImpact]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RiskExposure]') AND type in (N'U'))
DROP TABLE [dbo].[RiskExposure]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcessRiskAssessment]') AND type in (N'U'))
DROP TABLE [dbo].[ProcessRiskAssessment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcessRisk_ControlType]') AND type in (N'U'))
DROP TABLE [dbo].[ProcessRisk_ControlType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcessRisk]') AND type in (N'U'))
DROP TABLE [dbo].[ProcessRisk]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcessControlAssessment_RiskImpact]') AND type in (N'U'))
DROP TABLE [dbo].[ProcessControlAssessment_RiskImpact]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProcessControlAssessment]') AND type in (N'U'))
DROP TABLE [dbo].[ProcessControlAssessment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriorFunctionChanges]') AND type in (N'U'))
DROP TABLE [dbo].[PriorFunctionChanges]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Percentage]') AND type in (N'U'))
DROP TABLE [dbo].[Percentage]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LikelihoodOfOccurrence]') AND type in (N'U'))
DROP TABLE [dbo].[LikelihoodOfOccurrence]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_YearValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_YearValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_VolumeTypeValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_VolumeTypeValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_StatusValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_StatusValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncidentTypeValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_PrivacyIncidentTypeValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncidentStatusValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_PrivacyIncidentStatusValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncidentRootCauseValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_PrivacyIncidentRootCauseValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncidentMitigationCodeValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_PrivacyIncidentMitigationCodeValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_PrivacyIncident]') AND type in (N'U'))
DROP TABLE [dbo].[KST_PrivacyIncident]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncidentStatusValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_OperationalIncidentStatusValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncidentSourceValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_OperationalIncidentSourceValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncidentRootCauseValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_OperationalIncidentRootCauseValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncidentReportedToGORMValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_OperationalIncidentReportedToGORMValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncidentImpactValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_OperationalIncidentImpactValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_OperationalIncident]') AND type in (N'U'))
DROP TABLE [dbo].[KST_OperationalIncident]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_MonthValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_MonthValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_LowPerformanceReason]') AND type in (N'U'))
DROP TABLE [dbo].[KST_LowPerformanceReason]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_KPIVolumeScore]') AND type in (N'U'))
DROP TABLE [dbo].[KST_KPIVolumeScore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_KPIScorecardItem]') AND type in (N'U'))
DROP TABLE [dbo].[KST_KPIScorecardItem]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_KPIScore_LowPerformanceReason]') AND type in (N'U'))
DROP TABLE [dbo].[KST_KPIScore_LowPerformanceReason]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_KPIScore]') AND type in (N'U'))
DROP TABLE [dbo].[KST_KPIScore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_FinancialExposureValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_FinancialExposureValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_DecimalOrPercentageValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_DecimalOrPercentageValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]') AND type in (N'U'))
DROP TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]') AND type in (N'U'))
DROP TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]') AND type in (N'U'))
DROP TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]') AND type in (N'U'))
DROP TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]') AND type in (N'U'))
DROP TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnitKPIScorecard]') AND type in (N'U'))
DROP TABLE [dbo].[KST_BusinessUnitKPIScorecard]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_BusinessUnit]') AND type in (N'U'))
DROP TABLE [dbo].[KST_BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_AuditFindingStatusValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_AuditFindingStatusValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_AuditFindingSourceValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_AuditFindingSourceValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_AuditFindingRootCauseValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_AuditFindingRootCauseValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_AuditFindingReportedToGORMValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_AuditFindingReportedToGORMValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_AuditFindingImpactValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_AuditFindingImpactValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding_AuditFindingImpactValue]') AND type in (N'U'))
DROP TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KST_AuditFinding]') AND type in (N'U'))
DROP TABLE [dbo].[KST_AuditFinding]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KPISLAAssessment]') AND type in (N'U'))
DROP TABLE [dbo].[KPISLAAssessment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KPICategory_SLA]') AND type in (N'U'))
DROP TABLE [dbo].[KPICategory_SLA]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KPICategory]') AND type in (N'U'))
DROP TABLE [dbo].[KPICategory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KPI]') AND type in (N'U'))
DROP TABLE [dbo].[KPI]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KeyControlsMaturity]') AND type in (N'U'))
DROP TABLE [dbo].[KeyControlsMaturity]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FutureFunctionChanges]') AND type in (N'U'))
DROP TABLE [dbo].[FutureFunctionChanges]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FunctionPerformedSite]') AND type in (N'U'))
DROP TABLE [dbo].[FunctionPerformedSite]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FunctionChange]') AND type in (N'U'))
DROP TABLE [dbo].[FunctionChange]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalAreaProcessAssessment]') AND type in (N'U'))
DROP TABLE [dbo].[FunctionalAreaProcessAssessment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalAreaOwner]') AND type in (N'U'))
DROP TABLE [dbo].[FunctionalAreaOwner]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FunctionalArea]') AND type in (N'U'))
DROP TABLE [dbo].[FunctionalArea]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DepartmentHead]') AND type in (N'U'))
DROP TABLE [dbo].[DepartmentHead]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
DROP TABLE [dbo].[Department]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoreProcess_ControlType]') AND type in (N'U'))
DROP TABLE [dbo].[CoreProcess_ControlType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoreProcess]') AND type in (N'U'))
DROP TABLE [dbo].[CoreProcess]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlType]') AND type in (N'U'))
DROP TABLE [dbo].[ControlType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlTrigger]') AND type in (N'U'))
DROP TABLE [dbo].[ControlTrigger]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlFrequency]') AND type in (N'U'))
DROP TABLE [dbo].[ControlFrequency]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlDesign]') AND type in (N'U'))
DROP TABLE [dbo].[ControlDesign]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlAssessment_TestingFrequency]') AND type in (N'U'))
DROP TABLE [dbo].[ControlAssessment_TestingFrequency]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlAssessment_ControlTrigger]') AND type in (N'U'))
DROP TABLE [dbo].[ControlAssessment_ControlTrigger]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlAssessment_ControlDesign]') AND type in (N'U'))
DROP TABLE [dbo].[ControlAssessment_ControlDesign]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ControlAssessment]') AND type in (N'U'))
DROP TABLE [dbo].[ControlAssessment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChangeType]') AND type in (N'U'))
DROP TABLE [dbo].[ChangeType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BusinessUnit]') AND type in (N'U'))
DROP TABLE [dbo].[BusinessUnit]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AuditRecord]') AND type in (N'U'))
DROP TABLE [dbo].[AuditRecord]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssessmentType]') AND type in (N'U'))
DROP TABLE [dbo].[AssessmentType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssessmentStatus]') AND type in (N'U'))
DROP TABLE [dbo].[AssessmentStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Assessment_Product]') AND type in (N'U'))
DROP TABLE [dbo].[Assessment_Product]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Assessment]') AND type in (N'U'))
DROP TABLE [dbo].[Assessment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ActionPermission]') AND type in (N'U'))
DROP TABLE [dbo].[ActionPermission]
GO
--------------- Create Tables ---------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionPermission](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Role] [int] NOT NULL,
	[Action] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ActionPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FunctionalAreaDescription] [varchar](4000) NULL,
	[AssessmentDueDate] [datetime] NULL,
	[OverallRiskRatingCommentary] [varchar](4000) NULL,
	[ApprovalStatus] [int] NOT NULL,
	[BUFunctionalApproverUsername] [varchar](200) NULL,
	[BUFunctionalApproveTime] [datetime] NULL,
	[BURiskManagementApproverUsername] [varchar](200) NULL,
	[BURiskManagementApproveTime] [datetime] NULL,
	[DivisionalRiskManagementApproverUsername] [varchar](200) NULL,
	[DivisionalRiskManagementApproveTime] [datetime] NULL,
	[RejecterUsername] [varchar](200) NULL,
	[RejectTime] [datetime] NULL,
	[RejectionReason] [varchar](4000) NULL,
	[RejectPhase] [int] NULL,
	[SubmitterUsername] [varchar](200) NULL,
	[SubmitTime] [datetime] NULL,
	[Title] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[BusinessUnit_Id] [bigint] NULL,
	[DepartmentHead_Id] [bigint] NULL,
	[Department_Id] [bigint] NULL,
	[FunctionalAreaOwner_Id] [bigint] NULL,
	[FunctionalArea_Id] [bigint] NULL,
	[AssessmentType_Id] [bigint] NULL,
	[AssessmentStatus_Id] [bigint] NULL,
 CONSTRAINT [PK_Assessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment_Product](
	[AssessmentId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
 CONSTRAINT [PK_Assessment_Product] PRIMARY KEY CLUSTERED 
(
	[AssessmentId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentStatus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_AssessmentStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_AssessmentStatus_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_AssessmentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_AssessmentType_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditRecord](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](200) NOT NULL,
	[Action] [varchar](200) NOT NULL,
	[ItemType] [varchar](200) NOT NULL,
	[ItemId] [bigint] NOT NULL,
	[Field] [varchar](200) NOT NULL,
	[PreviousValue] [varchar](max) NULL,
	[NewValue] [varchar](max) NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_AuditReocrd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessUnit](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
	[Category_Id] [bigint] NULL,
 CONSTRAINT [PK_BusinessUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_BusinessUnit_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
	[Weight] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_Category_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_ChangeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_ChangeType_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlAssessment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OtherControlType] [varchar](200) NULL,
	[ControlObjective] [varchar](200) NULL,
	[ControlType_Id] [bigint] NULL,
	[ControlFrequency_Id] [bigint] NULL,
	[KeyControlsMaturity_Id] [bigint] NULL,
	[OtherTestingFrequency] [varchar](4000) NULL,
	[OtherKeyControlMaturity] [varchar](4000) NULL,
	[ProcessControlAssessment_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_ControlAssessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlAssessment_ControlDesign](
	[ControlAssessmentId] [bigint] NOT NULL,
	[ControlDesignId] [bigint] NOT NULL,
 CONSTRAINT [PK_ControlAssessment_ControlDesign] PRIMARY KEY CLUSTERED 
(
	[ControlAssessmentId] ASC,
	[ControlDesignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlAssessment_ControlTrigger](
	[ControlAssessmentId] [bigint] NOT NULL,
	[ControlTriggerId] [bigint] NOT NULL,
 CONSTRAINT [PK_ControlAssessment_ControlTrigger] PRIMARY KEY CLUSTERED 
(
	[ControlAssessmentId] ASC,
	[ControlTriggerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlAssessment_TestingFrequency](
	[ControlAssessmentId] [bigint] NOT NULL,
	[TestingFrequencyId] [bigint] NOT NULL,
 CONSTRAINT [PK_ControlAssessment_TestingFrequency] PRIMARY KEY CLUSTERED 
(
	[ControlAssessmentId] ASC,
	[TestingFrequencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlDesign](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_ControlDesign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_ControlDesign_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlFrequency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_ControlFrequency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_ControlFrequency_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlTrigger](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_ControlTrigger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_ControlTrigger_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Category_Id] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_ControlType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_ControlType_name] UNIQUE NONCLUSTERED 
(
	[Category_Id] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoreProcess](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](700) NOT NULL,
	[FunctionalAreaId] [bigint] NULL,
	[BusinessUnitId] [bigint] NULL,
	[Category_Id] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_CoreProcess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_CoreProcess_name] UNIQUE NONCLUSTERED 
(
	[Category_Id] ASC,
	[BusinessUnitId] ASC,
	[FunctionalAreaId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoreProcess_ControlType](
	[CoreProcessId] [bigint] NOT NULL,
	[ControlTypeId] [bigint] NOT NULL,
 CONSTRAINT [PK_CoreProcess_ControlType] PRIMARY KEY CLUSTERED 
(
	[CoreProcessId] ASC,
	[ControlTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[BusinessUnitId] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_Department_name] UNIQUE NONCLUSTERED 
(
	[BusinessUnitId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentHead](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[BusinessUnitId] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_DepartmentHead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_DepartmentHead_name] UNIQUE NONCLUSTERED 
(
	[BusinessUnitId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionalArea](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[BusinessUnitId] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
	[Category_Id] [bigint] NULL,
 CONSTRAINT [PK_FunctionalArea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_FunctionalArea_name] UNIQUE NONCLUSTERED 
(
	[BusinessUnitId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionalAreaOwner](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[BusinessUnitId] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_FunctionalAreaOwner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_FunctionalAreaOwner_name] UNIQUE NONCLUSTERED 
(
	[BusinessUnitId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionalAreaProcessAssessment](
	[Id] [bigint] NOT NULL,
	[AdditionalCoreProcess] [varchar](200) NULL,
	[AdditionalSubProcess] [varchar](200) NULL,
	[AdditionalRisk] [varchar](200) NULL,
	[SubProcessRisk_Id] [bigint] NULL,
	[CoreProcess_Id] [bigint] NULL,
	[Assessment_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_FunctionalAreaProcessAssessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionChange](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ChangeTime] [datetime] NOT NULL,
	[ChangeDescription] [varchar](4000) NOT NULL,
	[ChangeType_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_FunctionChange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionPerformedSite](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Site_Id] [bigint] NOT NULL,
	[Percentage_Id] [bigint] NOT NULL,
	[Assessment_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_FunctionPerformedSite] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FutureFunctionChanges](
	[AssessmentId] [bigint] NOT NULL,
	[FunctionChangeId] [bigint] NOT NULL,
 CONSTRAINT [PK_FutureFunctionChanges] PRIMARY KEY CLUSTERED 
(
	[AssessmentId] ASC,
	[FunctionChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeyControlsMaturity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
	[Value] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_KeyControlsMaturity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_KeyControlsMaturity_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KPI](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](800) NOT NULL,
	[KPICategory_Id] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_KPI] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_KPI_name] UNIQUE NONCLUSTERED 
(
	[KPICategory_Id] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KPICategory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](800) NOT NULL,
	[FunctionalAreaId] [bigint] NULL,
	[BusinessUnitId] [bigint] NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_KPICategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_KPICategory_name] UNIQUE NONCLUSTERED 
(
	[BusinessUnitId] ASC,
	[FunctionalAreaId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KPICategory_SLA](
	[KPICategoryId] [bigint] NOT NULL,
	[SLAId] [bigint] NOT NULL,
 CONSTRAINT [PK_KPICategory_SLA] PRIMARY KEY CLUSTERED 
(
	[KPICategoryId] ASC,
	[SLAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KPISLAAssessment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AdditionalKPICategory] [varchar](200) NULL,
	[AdditionalKPI] [varchar](200) NULL,
	[AdditionalSLA] [varchar](500) NULL,
	[KPI_Id] [bigint] NULL,
	[SelectedSLA_Id] [bigint] NULL,
	[KPICategory_Id] [bigint] NULL,
	[Category_Id] [bigint] NULL,
	[Assessment_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_KPISLAAssessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_AuditFinding](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AuditFindingNumber] [varchar](200) NULL,
	[AuditTitle] [varchar](200) NOT NULL,
	[RootCauseDetail] [varchar](2000) NULL,
	[MitigationStrategy] [varchar](2000) NULL,
	[CompletionType] [int] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[AuditMonth_Id] [bigint] NULL,
	[AuditYear_Id] [bigint] NULL,
	[BusinessUnit_Id] [bigint] NOT NULL,
	[RemediationMonth_Id] [bigint] NULL,
	[RemediationYear_Id] [bigint] NULL,
	[ReportedToGORM_Id] [bigint] NULL,
	[ReportedToORMMonth_Id] [bigint] NULL,
	[ReportedToORMYear_Id] [bigint] NULL,
	[RootCause_Id] [bigint] NOT NULL,
	[Source_Id] [bigint] NULL,
	[Status_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.KST_AuditFinding] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue](
	[AuditFindingId] [bigint] NOT NULL,
	[AuditFindingImpactValueId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_AuditFinding_AuditFindingImpactValue] PRIMARY KEY CLUSTERED 
(
	[AuditFindingId] ASC,
	[AuditFindingImpactValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_AuditFindingImpactValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_AuditFindingImpactValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_AuditFindingReportedToGORMValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_AuditFindingReportedToGORMValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_AuditFindingRootCauseValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_AuditFindingRootCauseValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_AuditFindingSourceValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_AuditFindingSourceValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_AuditFindingStatusValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_AuditFindingStatusValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_BusinessUnit](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_BusinessUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_BusinessUnitKPIScorecard](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[CompletionType] [int] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[BusinessUnit_Id] [bigint] NOT NULL,
	[Month_Id] [bigint] NOT NULL,
	[Status_Id] [bigint] NOT NULL,
	[Year_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_BusinessUnitKPIScorecard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore](
	[BusinessUnitKPIScorecardId] [bigint] NOT NULL,
	[KPIScoreId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore] PRIMARY KEY CLUSTERED 
(
	[BusinessUnitKPIScorecardId] ASC,
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore](
	[BusinessUnitKPIScorecardId] [bigint] NOT NULL,
	[KPIScoreId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore] PRIMARY KEY CLUSTERED 
(
	[BusinessUnitKPIScorecardId] ASC,
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore](
	[BusinessUnitKPIScorecardId] [bigint] NOT NULL,
	[KPIScoreId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore] PRIMARY KEY CLUSTERED 
(
	[BusinessUnitKPIScorecardId] ASC,
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore](
	[BusinessUnitKPIScorecardId] [bigint] NOT NULL,
	[KPIVolumeScoreId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore] PRIMARY KEY CLUSTERED 
(
	[BusinessUnitKPIScorecardId] ASC,
	[KPIVolumeScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore](
	[BusinessUnitKPIScorecardId] [bigint] NOT NULL,
	[KPIScoreId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore] PRIMARY KEY CLUSTERED 
(
	[BusinessUnitKPIScorecardId] ASC,
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_DecimalOrPercentageValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
	[Percentage] [bit] NOT NULL,
	[AdditionalNote] [varchar](200) NULL,
 CONSTRAINT [PK_dbo.KST_DecimalOrPercentageValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_FinancialExposureValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_dbo.KST_FinancialExposureValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_KPIScore](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Score] [decimal](18, 2) NOT NULL,
	[ScorecardItem_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_KPIScore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_KPIScore_LowPerformanceReason](
	[KPIScoreId] [bigint] NOT NULL,
	[LowPerformanceReasonId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_KPIScore_LowPerformanceReason] PRIMARY KEY CLUSTERED 
(
	[KPIScoreId] ASC,
	[LowPerformanceReasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_KPIScorecardItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[KeyPerformanceIndicator] [varchar](200) NULL,
	[TargetHigh] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Type] [int] NOT NULL,
	[ServiceLevel_Id] [bigint] NOT NULL,
	[Threshold_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_KPIScorecardItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_KPIVolumeScore](
	[Id] [bigint] NOT NULL,
	[VolumeType_Id] [bigint] NULL,
	[Volume] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.KST_KPIVolumeScore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_LowPerformanceReason](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_dbo.KST_LowPerformanceReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_MonthValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_MonthValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_OperationalIncident](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IncidentNumber] [varchar](200) NULL,
	[OperationalFinding] [varchar](2000) NULL,
	[RootCauseDetail] [varchar](2000) NULL,
	[MitigationStrategy] [varchar](2000) NULL,
	[CompletionType] [int] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[BusinessUnit_Id] [bigint] NOT NULL,
	[FinancialExposure_Id] [bigint] NOT NULL,
	[IncidentMonth_Id] [bigint] NULL,
	[IncidentYear_Id] [bigint] NULL,
	[RemediationMonth_Id] [bigint] NULL,
	[RemediationYear_Id] [bigint] NULL,
	[ReportedToGORM_Id] [bigint] NULL,
	[ReportedToORMMonth_Id] [bigint] NULL,
	[ReportedToORMYear_Id] [bigint] NULL,
	[RootCause_Id] [bigint] NOT NULL,
	[Source_Id] [bigint] NULL,
	[Status_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.KST_OperationalIncident] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue](
	[OperationalIncidentId] [bigint] NOT NULL,
	[OperationalIncidentImpactValueId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue] PRIMARY KEY CLUSTERED 
(
	[OperationalIncidentId] ASC,
	[OperationalIncidentImpactValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_OperationalIncidentImpactValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_OperationalIncidentImpactValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_OperationalIncidentReportedToGORMValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_OperationalIncidentReportedToGORMValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_OperationalIncidentRootCauseValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_OperationalIncidentRootCauseValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_OperationalIncidentSourceValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_OperationalIncidentSourceValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_OperationalIncidentStatusValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_OperationalIncidentStatusValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_PrivacyIncident](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IncidentNumber] [varchar](200) NULL,
	[IncidentTitle] [varchar](2000) NULL,
	[RootCauseDetail] [varchar](2000) NULL,
	[NumberOfCustomersImpacted] [int] NOT NULL,
	[MitigationDetail] [varchar](2000) NULL,
	[CompletionType] [int] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[BusinessUnit_Id] [bigint] NOT NULL,
	[IncidentMonth_Id] [bigint] NULL,
	[IncidentType_Id] [bigint] NOT NULL,
	[IncidentYear_Id] [bigint] NULL,
	[RemediationMonth_Id] [bigint] NULL,
	[RemediationYear_Id] [bigint] NULL,
	[ReportedToORMMonth_Id] [bigint] NULL,
	[ReportedToORMYear_Id] [bigint] NULL,
	[RootCause_Id] [bigint] NOT NULL,
	[Status_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.KST_PrivacyIncident] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue](
	[PrivacyIncidentId] [bigint] NOT NULL,
	[PrivacyIncidentMitigationCodeValueId] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue] PRIMARY KEY CLUSTERED 
(
	[PrivacyIncidentId] ASC,
	[PrivacyIncidentMitigationCodeValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_PrivacyIncidentMitigationCodeValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_PrivacyIncidentMitigationCodeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_PrivacyIncidentRootCauseValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_PrivacyIncidentRootCauseValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_PrivacyIncidentStatusValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_PrivacyIncidentStatusValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_PrivacyIncidentTypeValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_PrivacyIncidentTypeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_StatusValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_StatusValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_VolumeTypeValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_VolumeTypeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KST_YearValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.KST_YearValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikelihoodOfOccurrence](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_LikelihoodOfOccurrence] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_LikelihoodOfOccurrence_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Percentage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Value] [float] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_Percentage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_Percentage_value] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriorFunctionChanges](
	[AssessmentId] [bigint] NOT NULL,
	[FunctionChangeId] [bigint] NOT NULL,
 CONSTRAINT [PK_PriorFunctionChanges] PRIMARY KEY CLUSTERED 
(
	[AssessmentId] ASC,
	[FunctionChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessControlAssessment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LikelihoodOfOccurrence_Id] [bigint] NULL,
	[OtherLikelihoodOfOccurrence] [varchar](4000) NULL,
	[RiskExposure_Id] [bigint] NULL,
	[Category_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_ProcessControlAssessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessControlAssessment_RiskImpact](
	[ProcessControlAssessmentId] [bigint] NOT NULL,
	[RiskImpactId] [bigint] NOT NULL,
 CONSTRAINT [PK_ProcessControlAssessment_RiskImpact] PRIMARY KEY CLUSTERED 
(
	[ProcessControlAssessmentId] ASC,
	[RiskImpactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessRisk](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Risk] [varchar](200) NULL,
	[FunctionalAreaId] [bigint] NULL,
	[BusinessUnitId] [bigint] NULL,
	[Category_Id] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_ProcessRisk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_ProcessRisk_name] UNIQUE NONCLUSTERED 
(
	[Category_Id] ASC,
	[BusinessUnitId] ASC,
	[FunctionalAreaId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessRisk_ControlType](
	[ProcessRiskId] [bigint] NOT NULL,
	[ControlTypeId] [bigint] NOT NULL,
 CONSTRAINT [PK_ProcessRisk_ControlType] PRIMARY KEY CLUSTERED 
(
	[ProcessRiskId] ASC,
	[ControlTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessRiskAssessment](
	[Id] [bigint] NOT NULL,
	[AdditionalProcess] [varchar](200) NULL,
	[AdditionalRisk] [varchar](200) NULL,
	[ProcessRisk_Id] [bigint] NULL,
	[Assessment_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_ProcessRiskAssessment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[BusinessUnitId] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_Product_name] UNIQUE NONCLUSTERED 
(
	[BusinessUnitId] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RiskExposure](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
	[Value] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_RiskExposure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_RiskExposure_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RiskImpact](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_RiskImpact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_RiskImpact_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RiskScoreRange](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
	[UpperBound] [decimal](5, 2) NULL,
	[LowerBound] [decimal](5, 2) NULL,
	[Color] [varchar](20) NOT NULL,
 CONSTRAINT [PK_RiskScoreRange] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_RiskScoreRange_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_Site_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SLA](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_SLA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_SLA_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubProcessRisk](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](800) NOT NULL,
	[Risk] [varchar](1000) NULL,
	[CoreProcess_Id] [bigint] NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_SubProcessRisk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [unq_SubProcessRisk_name] UNIQUE NONCLUSTERED 
(
	[CoreProcess_Id] ASC,
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestingFrequency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedBy] [varchar](200) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [varchar](200) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[AddOnStatus] [int] NOT NULL,
 CONSTRAINT [PK_TestingFrequency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [un_TestingFrequency_name] UNIQUE NONCLUSTERED 
(
	[AddOnStatus] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](200) NOT NULL,
	[TokenValue] [varchar](256) NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_BusinessUnit](
	[UserId] [bigint] NOT NULL,
	[BusinessUnitId] [bigint] NOT NULL,
 CONSTRAINT [PK_User_BusinessUnit] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[BusinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMappingInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](200) NOT NULL,
	[Role] [int] NULL,
	[KPIRole] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__UserMapp__3214EC07AB469CA3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__UserMapp__536C85E4CCC8AE65] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX [fk_Assessment_AssessmentStatus1_idx] ON [dbo].[Assessment]
(
	[AssessmentStatus_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_AssessmentType1_idx] ON [dbo].[Assessment]
(
	[AssessmentType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_BusinessUnit1_idx] ON [dbo].[Assessment]
(
	[BusinessUnit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_Department1_idx] ON [dbo].[Assessment]
(
	[Department_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_DepartmentHead1_idx] ON [dbo].[Assessment]
(
	[DepartmentHead_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_FunctionalArea1_idx] ON [dbo].[Assessment]
(
	[FunctionalArea_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_FunctionalAreaOwner1_idx] ON [dbo].[Assessment]
(
	[FunctionalAreaOwner_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_Product_Assessment1_idx] ON [dbo].[Assessment_Product]
(
	[AssessmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_Product_Product1_idx] ON [dbo].[Assessment_Product]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_BusinessUnit_Category1_idx] ON [dbo].[BusinessUnit]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_ControlFrequency1_idx] ON [dbo].[ControlAssessment]
(
	[ControlFrequency_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_ControlType1_idx] ON [dbo].[ControlAssessment]
(
	[ControlType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_KeyControlsMaturity1_idx] ON [dbo].[ControlAssessment]
(
	[KeyControlsMaturity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_ProcessControlAssessment1_idx] ON [dbo].[ControlAssessment]
(
	[ProcessControlAssessment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_ControlDesign_ControlAssessment1_idx] ON [dbo].[ControlAssessment_ControlDesign]
(
	[ControlAssessmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_ControlDesign_ControlDesign1_idx] ON [dbo].[ControlAssessment_ControlDesign]
(
	[ControlDesignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_ControlTrigger_ControlAssessment1_idx] ON [dbo].[ControlAssessment_ControlTrigger]
(
	[ControlAssessmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_ControlTrigger_ControlTrigger1_idx] ON [dbo].[ControlAssessment_ControlTrigger]
(
	[ControlTriggerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_TestingFrequency_ControlAssessment1_idx] ON [dbo].[ControlAssessment_TestingFrequency]
(
	[ControlAssessmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ControlAssessment_TestingFrequency_TestingFrequency1_idx] ON [dbo].[ControlAssessment_TestingFrequency]
(
	[TestingFrequencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ontrolType_Category1_idx] ON [dbo].[ControlType]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_CoreProcess_BusinessUnit1_idx] ON [dbo].[CoreProcess]
(
	[BusinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_CoreProcess_Category1_idx] ON [dbo].[CoreProcess]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_CoreProcess_FunctionalArea1_idx] ON [dbo].[CoreProcess]
(
	[FunctionalAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_CoreProcess_ControlType_ControlType1_idx] ON [dbo].[CoreProcess_ControlType]
(
	[ControlTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_CoreProcess_ControlType_CoreProcess1_idx] ON [dbo].[CoreProcess_ControlType]
(
	[CoreProcessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionalArea_Category1_idx] ON [dbo].[FunctionalArea]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionalAreaProcessAssessment_Assessment1_idx] ON [dbo].[FunctionalAreaProcessAssessment]
(
	[Assessment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionalAreaProcessAssessment_CoreProcess1_idx] ON [dbo].[FunctionalAreaProcessAssessment]
(
	[CoreProcess_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionalAreaProcessAssessment_SubProcessRisk1_idx] ON [dbo].[FunctionalAreaProcessAssessment]
(
	[SubProcessRisk_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionChange_ChangeType1_idx] ON [dbo].[FunctionChange]
(
	[ChangeType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionPerformedSite_Assessment1_idx] ON [dbo].[FunctionPerformedSite]
(
	[Assessment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionPerformedSite_Percentage1_idx] ON [dbo].[FunctionPerformedSite]
(
	[Percentage_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_FunctionPerformedSite_Site_idx] ON [dbo].[FunctionPerformedSite]
(
	[Site_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_FunctionChange1_Assessment1_idx] ON [dbo].[FutureFunctionChanges]
(
	[AssessmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_FunctionChange1_FunctionChange1_idx] ON [dbo].[FutureFunctionChanges]
(
	[FunctionChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPI_KPICategory2_idx] ON [dbo].[KPI]
(
	[KPICategory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPICategory_BusinessUnit1_idx] ON [dbo].[KPICategory]
(
	[BusinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPICategory_FunctionalArea1_idx] ON [dbo].[KPICategory]
(
	[FunctionalAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPICategory_SLA_KPICategory1_idx] ON [dbo].[KPICategory_SLA]
(
	[KPICategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPICategory_SLA_SLA1_idx] ON [dbo].[KPICategory_SLA]
(
	[SLAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPISLAAssessment_Assessment1_idx] ON [dbo].[KPISLAAssessment]
(
	[Assessment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPISLAAssessment_Category1_idx] ON [dbo].[KPISLAAssessment]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPISLAAssessment_KPI1_idx] ON [dbo].[KPISLAAssessment]
(
	[KPI_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPISLAAssessment_KPICategory1_idx] ON [dbo].[KPISLAAssessment]
(
	[KPICategory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_KPISLAAssessment_SLA1_idx] ON [dbo].[KPISLAAssessment]
(
	[SelectedSLA_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AuditMonth_Id] ON [dbo].[KST_AuditFinding]
(
	[AuditMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AuditYear_Id] ON [dbo].[KST_AuditFinding]
(
	[AuditYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnit_Id] ON [dbo].[KST_AuditFinding]
(
	[BusinessUnit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RemediationMonth_Id] ON [dbo].[KST_AuditFinding]
(
	[RemediationMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RemediationYear_Id] ON [dbo].[KST_AuditFinding]
(
	[RemediationYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToGORM_Id] ON [dbo].[KST_AuditFinding]
(
	[ReportedToGORM_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToORMMonth_Id] ON [dbo].[KST_AuditFinding]
(
	[ReportedToORMMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToORMYear_Id] ON [dbo].[KST_AuditFinding]
(
	[ReportedToORMYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RootCause_Id] ON [dbo].[KST_AuditFinding]
(
	[RootCause_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Source_Id] ON [dbo].[KST_AuditFinding]
(
	[Source_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Status_Id] ON [dbo].[KST_AuditFinding]
(
	[Status_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AuditFindingId] ON [dbo].[KST_AuditFinding_AuditFindingImpactValue]
(
	[AuditFindingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AuditFindingImpactValueId] ON [dbo].[KST_AuditFinding_AuditFindingImpactValue]
(
	[AuditFindingImpactValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnit_Id] ON [dbo].[KST_BusinessUnitKPIScorecard]
(
	[BusinessUnit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Month_Id] ON [dbo].[KST_BusinessUnitKPIScorecard]
(
	[Month_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Status_Id] ON [dbo].[KST_BusinessUnitKPIScorecard]
(
	[Status_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Year_Id] ON [dbo].[KST_BusinessUnitKPIScorecard]
(
	[Year_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnitKPIScorecardId] ON [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]
(
	[BusinessUnitKPIScorecardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KPIScoreId] ON [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]
(
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnitKPIScorecardId] ON [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]
(
	[BusinessUnitKPIScorecardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KPIScoreId] ON [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]
(
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnitKPIScorecardId] ON [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]
(
	[BusinessUnitKPIScorecardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KPIScoreId] ON [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]
(
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnitKPIScorecardId] ON [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]
(
	[BusinessUnitKPIScorecardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KPIVolumeScoreId] ON [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]
(
	[KPIVolumeScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnitKPIScorecardId] ON [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]
(
	[BusinessUnitKPIScorecardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KPIScoreId] ON [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]
(
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ScorecardItem_Id] ON [dbo].[KST_KPIScore]
(
	[ScorecardItem_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KPIScoreId] ON [dbo].[KST_KPIScore_LowPerformanceReason]
(
	[KPIScoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_LowPerformanceReasonId] ON [dbo].[KST_KPIScore_LowPerformanceReason]
(
	[LowPerformanceReasonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ServiceLevel_Id] ON [dbo].[KST_KPIScorecardItem]
(
	[ServiceLevel_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Threshold_Id] ON [dbo].[KST_KPIScorecardItem]
(
	[Threshold_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[KST_KPIVolumeScore]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_VolumeType_Id] ON [dbo].[KST_KPIVolumeScore]
(
	[VolumeType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnit_Id] ON [dbo].[KST_OperationalIncident]
(
	[BusinessUnit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FinancialExposure_Id] ON [dbo].[KST_OperationalIncident]
(
	[FinancialExposure_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_IncidentMonth_Id] ON [dbo].[KST_OperationalIncident]
(
	[IncidentMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_IncidentYear_Id] ON [dbo].[KST_OperationalIncident]
(
	[IncidentYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RemediationMonth_Id] ON [dbo].[KST_OperationalIncident]
(
	[RemediationMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RemediationYear_Id] ON [dbo].[KST_OperationalIncident]
(
	[RemediationYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToGORM_Id] ON [dbo].[KST_OperationalIncident]
(
	[ReportedToGORM_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToORMMonth_Id] ON [dbo].[KST_OperationalIncident]
(
	[ReportedToORMMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToORMYear_Id] ON [dbo].[KST_OperationalIncident]
(
	[ReportedToORMYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RootCause_Id] ON [dbo].[KST_OperationalIncident]
(
	[RootCause_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Source_Id] ON [dbo].[KST_OperationalIncident]
(
	[Source_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Status_Id] ON [dbo].[KST_OperationalIncident]
(
	[Status_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OperationalIncidentId] ON [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]
(
	[OperationalIncidentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OperationalIncidentImpactValueId] ON [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]
(
	[OperationalIncidentImpactValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BusinessUnit_Id] ON [dbo].[KST_PrivacyIncident]
(
	[BusinessUnit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_IncidentMonth_Id] ON [dbo].[KST_PrivacyIncident]
(
	[IncidentMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_IncidentType_Id] ON [dbo].[KST_PrivacyIncident]
(
	[IncidentType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_IncidentYear_Id] ON [dbo].[KST_PrivacyIncident]
(
	[IncidentYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RemediationMonth_Id] ON [dbo].[KST_PrivacyIncident]
(
	[RemediationMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RemediationYear_Id] ON [dbo].[KST_PrivacyIncident]
(
	[RemediationYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToORMMonth_Id] ON [dbo].[KST_PrivacyIncident]
(
	[ReportedToORMMonth_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ReportedToORMYear_Id] ON [dbo].[KST_PrivacyIncident]
(
	[ReportedToORMYear_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RootCause_Id] ON [dbo].[KST_PrivacyIncident]
(
	[RootCause_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Status_Id] ON [dbo].[KST_PrivacyIncident]
(
	[Status_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PrivacyIncidentId] ON [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]
(
	[PrivacyIncidentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PrivacyIncidentMitigationCodeValueId] ON [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]
(
	[PrivacyIncidentMitigationCodeValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_FunctionChange_Assessment1_idx] ON [dbo].[PriorFunctionChanges]
(
	[AssessmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_Assessment_FunctionChange_FunctionChange1_idx] ON [dbo].[PriorFunctionChanges]
(
	[FunctionChangeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessControlAssessment_Category1_idx] ON [dbo].[ProcessControlAssessment]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessControlAssessment_LikelihoodOfOccurrence1_idx] ON [dbo].[ProcessControlAssessment]
(
	[LikelihoodOfOccurrence_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessControlAssessment_RiskExposure1_idx] ON [dbo].[ProcessControlAssessment]
(
	[RiskExposure_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessControlAssessment_RiskImpact_ProcessControlAssess_idx] ON [dbo].[ProcessControlAssessment_RiskImpact]
(
	[ProcessControlAssessmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessControlAssessment_RiskImpact_RiskImpact1_idx] ON [dbo].[ProcessControlAssessment_RiskImpact]
(
	[RiskImpactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessRisk_BusinessUnit1_idx] ON [dbo].[ProcessRisk]
(
	[BusinessUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessRisk_Category1_idx] ON [dbo].[ProcessRisk]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessRisk_FunctionalArea1_idx] ON [dbo].[ProcessRisk]
(
	[FunctionalAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessRisk_ControlType_ControlType1_idx] ON [dbo].[ProcessRisk_ControlType]
(
	[ControlTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessRisk_ControlType_ProcessRisk1_idx] ON [dbo].[ProcessRisk_ControlType]
(
	[ProcessRiskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessRiskAssessment_Assessment1_idx] ON [dbo].[ProcessRiskAssessment]
(
	[Assessment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_ProcessRiskAssessment_ProcessRisk1_idx] ON [dbo].[ProcessRiskAssessment]
(
	[ProcessRisk_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [fk_SubProcessRisk_CoreProcess1_idx] ON [dbo].[SubProcessRisk]
(
	[CoreProcess_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_AssessmentStatus1] FOREIGN KEY([AssessmentStatus_Id])
REFERENCES [dbo].[AssessmentStatus] ([Id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [fk_Assessment_AssessmentStatus1]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_AssessmentType1] FOREIGN KEY([AssessmentType_Id])
REFERENCES [dbo].[AssessmentType] ([Id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [fk_Assessment_AssessmentType1]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_BusinessUnit1] FOREIGN KEY([BusinessUnit_Id])
REFERENCES [dbo].[BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [fk_Assessment_BusinessUnit1]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_Department1] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [fk_Assessment_Department1]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_DepartmentHead1] FOREIGN KEY([DepartmentHead_Id])
REFERENCES [dbo].[DepartmentHead] ([Id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [fk_Assessment_DepartmentHead1]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_FunctionalArea1] FOREIGN KEY([FunctionalArea_Id])
REFERENCES [dbo].[FunctionalArea] ([Id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [fk_Assessment_FunctionalArea1]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_FunctionalAreaOwner1] FOREIGN KEY([FunctionalAreaOwner_Id])
REFERENCES [dbo].[FunctionalAreaOwner] ([Id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [fk_Assessment_FunctionalAreaOwner1]
GO
ALTER TABLE [dbo].[Assessment_Product]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_Product_Assessment1] FOREIGN KEY([AssessmentId])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[Assessment_Product] CHECK CONSTRAINT [fk_Assessment_Product_Assessment1]
GO
ALTER TABLE [dbo].[Assessment_Product]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_Product_Product1] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Assessment_Product] CHECK CONSTRAINT [fk_Assessment_Product_Product1]
GO
ALTER TABLE [dbo].[BusinessUnit]  WITH CHECK ADD  CONSTRAINT [fk_BusinessUnit_Category1] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[BusinessUnit] CHECK CONSTRAINT [fk_BusinessUnit_Category1]
GO
ALTER TABLE [dbo].[ControlAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_ControlFrequency1] FOREIGN KEY([ControlFrequency_Id])
REFERENCES [dbo].[ControlFrequency] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment] CHECK CONSTRAINT [fk_ControlAssessment_ControlFrequency1]
GO
ALTER TABLE [dbo].[ControlAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_ControlType1] FOREIGN KEY([ControlType_Id])
REFERENCES [dbo].[ControlType] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment] CHECK CONSTRAINT [fk_ControlAssessment_ControlType1]
GO
ALTER TABLE [dbo].[ControlAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_KeyControlsMaturity1] FOREIGN KEY([KeyControlsMaturity_Id])
REFERENCES [dbo].[KeyControlsMaturity] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment] CHECK CONSTRAINT [fk_ControlAssessment_KeyControlsMaturity1]
GO
ALTER TABLE [dbo].[ControlAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_ProcessControlAssessment1] FOREIGN KEY([ProcessControlAssessment_Id])
REFERENCES [dbo].[ProcessControlAssessment] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment] CHECK CONSTRAINT [fk_ControlAssessment_ProcessControlAssessment1]
GO
ALTER TABLE [dbo].[ControlAssessment_ControlDesign]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_ControlDesign_ControlAssessment1] FOREIGN KEY([ControlAssessmentId])
REFERENCES [dbo].[ControlAssessment] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment_ControlDesign] CHECK CONSTRAINT [fk_ControlAssessment_ControlDesign_ControlAssessment1]
GO
ALTER TABLE [dbo].[ControlAssessment_ControlDesign]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_ControlDesign_ControlDesign1] FOREIGN KEY([ControlDesignId])
REFERENCES [dbo].[ControlDesign] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment_ControlDesign] CHECK CONSTRAINT [fk_ControlAssessment_ControlDesign_ControlDesign1]
GO
ALTER TABLE [dbo].[ControlAssessment_ControlTrigger]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_ControlTrigger_ControlAssessment1] FOREIGN KEY([ControlAssessmentId])
REFERENCES [dbo].[ControlAssessment] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment_ControlTrigger] CHECK CONSTRAINT [fk_ControlAssessment_ControlTrigger_ControlAssessment1]
GO
ALTER TABLE [dbo].[ControlAssessment_ControlTrigger]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_ControlTrigger_ControlTrigger1] FOREIGN KEY([ControlTriggerId])
REFERENCES [dbo].[ControlTrigger] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment_ControlTrigger] CHECK CONSTRAINT [fk_ControlAssessment_ControlTrigger_ControlTrigger1]
GO
ALTER TABLE [dbo].[ControlAssessment_TestingFrequency]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_TestingFrequency_ControlAssessment1] FOREIGN KEY([ControlAssessmentId])
REFERENCES [dbo].[ControlAssessment] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment_TestingFrequency] CHECK CONSTRAINT [fk_ControlAssessment_TestingFrequency_ControlAssessment1]
GO
ALTER TABLE [dbo].[ControlAssessment_TestingFrequency]  WITH CHECK ADD  CONSTRAINT [fk_ControlAssessment_TestingFrequency_TestingFrequency1] FOREIGN KEY([TestingFrequencyId])
REFERENCES [dbo].[TestingFrequency] ([Id])
GO
ALTER TABLE [dbo].[ControlAssessment_TestingFrequency] CHECK CONSTRAINT [fk_ControlAssessment_TestingFrequency_TestingFrequency1]
GO
ALTER TABLE [dbo].[ControlType]  WITH CHECK ADD  CONSTRAINT [fk_ControlType_Category1] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ControlType] CHECK CONSTRAINT [fk_ControlType_Category1]
GO
ALTER TABLE [dbo].[CoreProcess]  WITH CHECK ADD  CONSTRAINT [fk_CoreProcess_BusinessUnit1] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[CoreProcess] CHECK CONSTRAINT [fk_CoreProcess_BusinessUnit1]
GO
ALTER TABLE [dbo].[CoreProcess]  WITH CHECK ADD  CONSTRAINT [fk_CoreProcess_Category1] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[CoreProcess] CHECK CONSTRAINT [fk_CoreProcess_Category1]
GO
ALTER TABLE [dbo].[CoreProcess]  WITH CHECK ADD  CONSTRAINT [fk_CoreProcess_FunctionalArea1] FOREIGN KEY([FunctionalAreaId])
REFERENCES [dbo].[FunctionalArea] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoreProcess] CHECK CONSTRAINT [fk_CoreProcess_FunctionalArea1]
GO
ALTER TABLE [dbo].[CoreProcess_ControlType]  WITH CHECK ADD  CONSTRAINT [fk_CoreProcess_ControlType_ControlType1] FOREIGN KEY([ControlTypeId])
REFERENCES [dbo].[ControlType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoreProcess_ControlType] CHECK CONSTRAINT [fk_CoreProcess_ControlType_ControlType1]
GO
ALTER TABLE [dbo].[CoreProcess_ControlType]  WITH CHECK ADD  CONSTRAINT [fk_CoreProcess_ControlType_CoreProcess1] FOREIGN KEY([CoreProcessId])
REFERENCES [dbo].[CoreProcess] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CoreProcess_ControlType] CHECK CONSTRAINT [fk_CoreProcess_ControlType_CoreProcess1]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_BusinessUnit] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_BusinessUnit]
GO
ALTER TABLE [dbo].[DepartmentHead]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentHead_BusinessUnit] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartmentHead] CHECK CONSTRAINT [FK_DepartmentHead_BusinessUnit]
GO
ALTER TABLE [dbo].[FunctionalArea]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalArea_BusinessUnit] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FunctionalArea] CHECK CONSTRAINT [FK_FunctionalArea_BusinessUnit]
GO
ALTER TABLE [dbo].[FunctionalArea]  WITH CHECK ADD  CONSTRAINT [fk_FunctionalArea_Category1] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[FunctionalArea] CHECK CONSTRAINT [fk_FunctionalArea_Category1]
GO
ALTER TABLE [dbo].[FunctionalAreaOwner]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalAreaOwner_BusinessUnit] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FunctionalAreaOwner] CHECK CONSTRAINT [FK_FunctionalAreaOwner_BusinessUnit]
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment]  WITH CHECK ADD  CONSTRAINT [fk_FunctionalAreaProcessAssessment_Assessment1] FOREIGN KEY([Assessment_Id])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] CHECK CONSTRAINT [fk_FunctionalAreaProcessAssessment_Assessment1]
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment]  WITH CHECK ADD  CONSTRAINT [fk_FunctionalAreaProcessAssessment_CoreProcess1] FOREIGN KEY([CoreProcess_Id])
REFERENCES [dbo].[CoreProcess] ([Id])
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] CHECK CONSTRAINT [fk_FunctionalAreaProcessAssessment_CoreProcess1]
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FunctionalAreaProcessAssessment_ProcessControlAssessment] FOREIGN KEY([Id])
REFERENCES [dbo].[ProcessControlAssessment] ([Id])
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] CHECK CONSTRAINT [FK_FunctionalAreaProcessAssessment_ProcessControlAssessment]
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment]  WITH CHECK ADD  CONSTRAINT [fk_FunctionalAreaProcessAssessment_SubProcessRisk1] FOREIGN KEY([SubProcessRisk_Id])
REFERENCES [dbo].[SubProcessRisk] ([Id])
GO
ALTER TABLE [dbo].[FunctionalAreaProcessAssessment] CHECK CONSTRAINT [fk_FunctionalAreaProcessAssessment_SubProcessRisk1]
GO
ALTER TABLE [dbo].[FunctionChange]  WITH CHECK ADD  CONSTRAINT [fk_FunctionChange_ChangeType1] FOREIGN KEY([ChangeType_Id])
REFERENCES [dbo].[ChangeType] ([Id])
GO
ALTER TABLE [dbo].[FunctionChange] CHECK CONSTRAINT [fk_FunctionChange_ChangeType1]
GO
ALTER TABLE [dbo].[FunctionPerformedSite]  WITH CHECK ADD  CONSTRAINT [fk_FunctionPerformedSite_Assessment1] FOREIGN KEY([Assessment_Id])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[FunctionPerformedSite] CHECK CONSTRAINT [fk_FunctionPerformedSite_Assessment1]
GO
ALTER TABLE [dbo].[FunctionPerformedSite]  WITH CHECK ADD  CONSTRAINT [fk_FunctionPerformedSite_Percentage1] FOREIGN KEY([Percentage_Id])
REFERENCES [dbo].[Percentage] ([Id])
GO
ALTER TABLE [dbo].[FunctionPerformedSite] CHECK CONSTRAINT [fk_FunctionPerformedSite_Percentage1]
GO
ALTER TABLE [dbo].[FunctionPerformedSite]  WITH CHECK ADD  CONSTRAINT [fk_FunctionPerformedSite_Site] FOREIGN KEY([Site_Id])
REFERENCES [dbo].[Site] ([Id])
GO
ALTER TABLE [dbo].[FunctionPerformedSite] CHECK CONSTRAINT [fk_FunctionPerformedSite_Site]
GO
ALTER TABLE [dbo].[FutureFunctionChanges]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_FunctionChange1_Assessment1] FOREIGN KEY([AssessmentId])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[FutureFunctionChanges] CHECK CONSTRAINT [fk_Assessment_FunctionChange1_Assessment1]
GO
ALTER TABLE [dbo].[FutureFunctionChanges]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_FunctionChange1_FunctionChange1] FOREIGN KEY([FunctionChangeId])
REFERENCES [dbo].[FunctionChange] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FutureFunctionChanges] CHECK CONSTRAINT [fk_Assessment_FunctionChange1_FunctionChange1]
GO
ALTER TABLE [dbo].[KPI]  WITH CHECK ADD  CONSTRAINT [fk_KPI_KPICategory1] FOREIGN KEY([KPICategory_Id])
REFERENCES [dbo].[KPICategory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KPI] CHECK CONSTRAINT [fk_KPI_KPICategory1]
GO
ALTER TABLE [dbo].[KPICategory]  WITH CHECK ADD  CONSTRAINT [fk_KPICategory_BusinessUnit1] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[KPICategory] CHECK CONSTRAINT [fk_KPICategory_BusinessUnit1]
GO
ALTER TABLE [dbo].[KPICategory]  WITH CHECK ADD  CONSTRAINT [fk_KPICategory_FunctionalArea1] FOREIGN KEY([FunctionalAreaId])
REFERENCES [dbo].[FunctionalArea] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KPICategory] CHECK CONSTRAINT [fk_KPICategory_FunctionalArea1]
GO
ALTER TABLE [dbo].[KPICategory_SLA]  WITH CHECK ADD  CONSTRAINT [fk_KPICategory_SLA_KPICategoryId1] FOREIGN KEY([KPICategoryId])
REFERENCES [dbo].[KPICategory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KPICategory_SLA] CHECK CONSTRAINT [fk_KPICategory_SLA_KPICategoryId1]
GO
ALTER TABLE [dbo].[KPICategory_SLA]  WITH CHECK ADD  CONSTRAINT [fk_KPICategory_SLA_SLA1] FOREIGN KEY([SLAId])
REFERENCES [dbo].[SLA] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KPICategory_SLA] CHECK CONSTRAINT [fk_KPICategory_SLA_SLA1]
GO
ALTER TABLE [dbo].[KPISLAAssessment]  WITH CHECK ADD  CONSTRAINT [fk_KPISLAAssessment_Assessment1] FOREIGN KEY([Assessment_Id])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[KPISLAAssessment] CHECK CONSTRAINT [fk_KPISLAAssessment_Assessment1]
GO
ALTER TABLE [dbo].[KPISLAAssessment]  WITH CHECK ADD  CONSTRAINT [fk_KPISLAAssessment_Category1] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[KPISLAAssessment] CHECK CONSTRAINT [fk_KPISLAAssessment_Category1]
GO
ALTER TABLE [dbo].[KPISLAAssessment]  WITH CHECK ADD  CONSTRAINT [fk_KPISLAAssessment_KPI1] FOREIGN KEY([KPI_Id])
REFERENCES [dbo].[KPI] ([Id])
GO
ALTER TABLE [dbo].[KPISLAAssessment] CHECK CONSTRAINT [fk_KPISLAAssessment_KPI1]
GO
ALTER TABLE [dbo].[KPISLAAssessment]  WITH CHECK ADD  CONSTRAINT [fk_KPISLAAssessment_KPICategory1] FOREIGN KEY([KPICategory_Id])
REFERENCES [dbo].[KPICategory] ([Id])
GO
ALTER TABLE [dbo].[KPISLAAssessment] CHECK CONSTRAINT [fk_KPISLAAssessment_KPICategory1]
GO
ALTER TABLE [dbo].[KPISLAAssessment]  WITH CHECK ADD  CONSTRAINT [fk_KPISLAAssessment_SLA1] FOREIGN KEY([SelectedSLA_Id])
REFERENCES [dbo].[SLA] ([Id])
GO
ALTER TABLE [dbo].[KPISLAAssessment] CHECK CONSTRAINT [fk_KPISLAAssessment_SLA1]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingReportedToGORMValue_ReportedToGORM_Id] FOREIGN KEY([ReportedToGORM_Id])
REFERENCES [dbo].[KST_AuditFindingReportedToGORMValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingReportedToGORMValue_ReportedToGORM_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingRootCauseValue_RootCause_Id] FOREIGN KEY([RootCause_Id])
REFERENCES [dbo].[KST_AuditFindingRootCauseValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingRootCauseValue_RootCause_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingSourceValue_Source_Id] FOREIGN KEY([Source_Id])
REFERENCES [dbo].[KST_AuditFindingSourceValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingSourceValue_Source_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingStatusValue_Status_Id] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[KST_AuditFindingStatusValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_AuditFindingStatusValue_Status_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_BusinessUnit_BusinessUnit_Id] FOREIGN KEY([BusinessUnit_Id])
REFERENCES [dbo].[KST_BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_AuditMonth_Id] FOREIGN KEY([AuditMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_AuditMonth_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_RemediationMonth_Id] FOREIGN KEY([RemediationMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_RemediationMonth_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_ReportedToORMMonth_Id] FOREIGN KEY([ReportedToORMMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_MonthValue_ReportedToORMMonth_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_AuditYear_Id] FOREIGN KEY([AuditYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_AuditYear_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_RemediationYear_Id] FOREIGN KEY([RemediationYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_RemediationYear_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_ReportedToORMYear_Id] FOREIGN KEY([ReportedToORMYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_AuditFinding] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_dbo.KST_YearValue_ReportedToORMYear_Id]
GO
ALTER TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFinding_AuditFindingId] FOREIGN KEY([AuditFindingId])
REFERENCES [dbo].[KST_AuditFinding] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFinding_AuditFindingId]
GO
ALTER TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFindingImpactValue_AuditFindingImpactValueId] FOREIGN KEY([AuditFindingImpactValueId])
REFERENCES [dbo].[KST_AuditFindingImpactValue] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_AuditFinding_AuditFindingImpactValue] CHECK CONSTRAINT [FK_dbo.KST_AuditFinding_AuditFindingImpactValue_dbo.KST_AuditFindingImpactValue_AuditFindingImpactValueId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_BusinessUnit_BusinessUnit_Id] FOREIGN KEY([BusinessUnit_Id])
REFERENCES [dbo].[KST_BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_MonthValue_Month_Id] FOREIGN KEY([Month_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_MonthValue_Month_Id]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_StatusValue_Status_Id] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[KST_StatusValue] ([Id])
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_StatusValue_Status_Id]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_YearValue_Year_Id] FOREIGN KEY([Year_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_dbo.KST_YearValue_Year_Id]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId] FOREIGN KEY([BusinessUnitKPIScorecardId])
REFERENCES [dbo].[KST_BusinessUnitKPIScorecard] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_KPIScore_KPIScoreId] FOREIGN KEY([KPIScoreId])
REFERENCES [dbo].[KST_KPIScore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_BusinessContinuityPlanningScore_dbo.KST_KPIScore_KPIScoreId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId] FOREIGN KEY([BusinessUnitKPIScorecardId])
REFERENCES [dbo].[KST_BusinessUnitKPIScorecard] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_KPIScore_KPIScoreId] FOREIGN KEY([KPIScoreId])
REFERENCES [dbo].[KST_KPIScore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_ConcentrationRiskScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_ConcentrationRiskScore_dbo.KST_KPIScore_KPIScoreId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId] FOREIGN KEY([BusinessUnitKPIScorecardId])
REFERENCES [dbo].[KST_BusinessUnitKPIScorecard] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_KPIScore_KPIScoreId] FOREIGN KEY([KPIScoreId])
REFERENCES [dbo].[KST_KPIScore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_FinancialIndicatorScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_FinancialIndicatorScore_dbo.KST_KPIScore_KPIScoreId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId] FOREIGN KEY([BusinessUnitKPIScorecardId])
REFERENCES [dbo].[KST_BusinessUnitKPIScorecard] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_KPIVolumeScore_KPIVolumeScoreId] FOREIGN KEY([KPIVolumeScoreId])
REFERENCES [dbo].[KST_KPIVolumeScore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_OperationPerformanceScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_OperationPerformanceScore_dbo.KST_KPIVolumeScore_KPIVolumeScoreId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId] FOREIGN KEY([BusinessUnitKPIScorecardId])
REFERENCES [dbo].[KST_BusinessUnitKPIScorecard] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_BusinessUnitKPIScorecard_BusinessUnitKPIScorecardId]
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_KPIScore_KPIScoreId] FOREIGN KEY([KPIScoreId])
REFERENCES [dbo].[KST_KPIScore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_BusinessUnitKPIScorecard_SecurityScore] CHECK CONSTRAINT [FK_dbo.KST_BusinessUnitKPIScorecard_SecurityScore_dbo.KST_KPIScore_KPIScoreId]
GO
ALTER TABLE [dbo].[KST_KPIScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_KPIScore_dbo.KST_KPIScorecardItem_ScorecardItem_Id] FOREIGN KEY([ScorecardItem_Id])
REFERENCES [dbo].[KST_KPIScorecardItem] ([Id])
GO
ALTER TABLE [dbo].[KST_KPIScore] CHECK CONSTRAINT [FK_dbo.KST_KPIScore_dbo.KST_KPIScorecardItem_ScorecardItem_Id]
GO
ALTER TABLE [dbo].[KST_KPIScore_LowPerformanceReason]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_KPIScore_KPIScoreId] FOREIGN KEY([KPIScoreId])
REFERENCES [dbo].[KST_KPIScore] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_KPIScore_LowPerformanceReason] CHECK CONSTRAINT [FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_KPIScore_KPIScoreId]
GO
ALTER TABLE [dbo].[KST_KPIScore_LowPerformanceReason]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_LowPerformanceReason_LowPerformanceReasonId] FOREIGN KEY([LowPerformanceReasonId])
REFERENCES [dbo].[KST_LowPerformanceReason] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_KPIScore_LowPerformanceReason] CHECK CONSTRAINT [FK_dbo.KST_KPIScore_LowPerformanceReason_dbo.KST_LowPerformanceReason_LowPerformanceReasonId]
GO
ALTER TABLE [dbo].[KST_KPIScorecardItem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_ServiceLevel_Id] FOREIGN KEY([ServiceLevel_Id])
REFERENCES [dbo].[KST_DecimalOrPercentageValue] ([Id])
GO
ALTER TABLE [dbo].[KST_KPIScorecardItem] CHECK CONSTRAINT [FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_ServiceLevel_Id]
GO
ALTER TABLE [dbo].[KST_KPIScorecardItem]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_Threshold_Id] FOREIGN KEY([Threshold_Id])
REFERENCES [dbo].[KST_DecimalOrPercentageValue] ([Id])
GO
ALTER TABLE [dbo].[KST_KPIScorecardItem] CHECK CONSTRAINT [FK_dbo.KST_KPIScorecardItem_dbo.KST_DecimalOrPercentageValue_Threshold_Id]
GO
ALTER TABLE [dbo].[KST_KPIVolumeScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_KPIVolumeScore_dbo.KST_KPIScore_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[KST_KPIScore] ([Id])
GO
ALTER TABLE [dbo].[KST_KPIVolumeScore] CHECK CONSTRAINT [FK_dbo.KST_KPIVolumeScore_dbo.KST_KPIScore_Id]
GO
ALTER TABLE [dbo].[KST_KPIVolumeScore]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_KPIVolumeScore_dbo.KST_VolumeTypeValue_VolumeType_Id] FOREIGN KEY([VolumeType_Id])
REFERENCES [dbo].[KST_VolumeTypeValue] ([Id])
GO
ALTER TABLE [dbo].[KST_KPIVolumeScore] CHECK CONSTRAINT [FK_dbo.KST_KPIVolumeScore_dbo.KST_VolumeTypeValue_VolumeType_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_BusinessUnit_BusinessUnit_Id] FOREIGN KEY([BusinessUnit_Id])
REFERENCES [dbo].[KST_BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_FinancialExposureValue_FinancialExposure_Id] FOREIGN KEY([FinancialExposure_Id])
REFERENCES [dbo].[KST_FinancialExposureValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_FinancialExposureValue_FinancialExposure_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_IncidentMonth_Id] FOREIGN KEY([IncidentMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_IncidentMonth_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_RemediationMonth_Id] FOREIGN KEY([RemediationMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_RemediationMonth_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id] FOREIGN KEY([ReportedToORMMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentReportedToGORMValue_ReportedToGORM_Id] FOREIGN KEY([ReportedToGORM_Id])
REFERENCES [dbo].[KST_OperationalIncidentReportedToGORMValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentReportedToGORMValue_ReportedToGORM_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentRootCauseValue_RootCause_Id] FOREIGN KEY([RootCause_Id])
REFERENCES [dbo].[KST_OperationalIncidentRootCauseValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentRootCauseValue_RootCause_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentSourceValue_Source_Id] FOREIGN KEY([Source_Id])
REFERENCES [dbo].[KST_OperationalIncidentSourceValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentSourceValue_Source_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentStatusValue_Status_Id] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[KST_OperationalIncidentStatusValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_OperationalIncidentStatusValue_Status_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_IncidentYear_Id] FOREIGN KEY([IncidentYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_IncidentYear_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_RemediationYear_Id] FOREIGN KEY([RemediationYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_RemediationYear_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_ReportedToORMYear_Id] FOREIGN KEY([ReportedToORMYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_OperationalIncident] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_dbo.KST_YearValue_ReportedToORMYear_Id]
GO
ALTER TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncident_OperationalIncidentId] FOREIGN KEY([OperationalIncidentId])
REFERENCES [dbo].[KST_OperationalIncident] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncident_OperationalIncidentId]
GO
ALTER TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncidentImpactValue_OperationalIncidentImpactVa] FOREIGN KEY([OperationalIncidentImpactValueId])
REFERENCES [dbo].[KST_OperationalIncidentImpactValue] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_OperationalIncident_OperationalIncidentImpactValue] CHECK CONSTRAINT [FK_dbo.KST_OperationalIncident_OperationalIncidentImpactValue_dbo.KST_OperationalIncidentImpactValue_OperationalIncidentImpactVa]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_BusinessUnit_BusinessUnit_Id] FOREIGN KEY([BusinessUnit_Id])
REFERENCES [dbo].[KST_BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_BusinessUnit_BusinessUnit_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_IncidentMonth_Id] FOREIGN KEY([IncidentMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_IncidentMonth_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_RemediationMonth_Id] FOREIGN KEY([RemediationMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_RemediationMonth_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id] FOREIGN KEY([ReportedToORMMonth_Id])
REFERENCES [dbo].[KST_MonthValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_MonthValue_ReportedToORMMonth_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentRootCauseValue_RootCause_Id] FOREIGN KEY([RootCause_Id])
REFERENCES [dbo].[KST_PrivacyIncidentRootCauseValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentRootCauseValue_RootCause_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentStatusValue_Status_Id] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[KST_PrivacyIncidentStatusValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentStatusValue_Status_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentTypeValue_IncidentType_Id] FOREIGN KEY([IncidentType_Id])
REFERENCES [dbo].[KST_PrivacyIncidentTypeValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_PrivacyIncidentTypeValue_IncidentType_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_IncidentYear_Id] FOREIGN KEY([IncidentYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_IncidentYear_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_RemediationYear_Id] FOREIGN KEY([RemediationYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_RemediationYear_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_ReportedToORMYear_Id] FOREIGN KEY([ReportedToORMYear_Id])
REFERENCES [dbo].[KST_YearValue] ([Id])
GO
ALTER TABLE [dbo].[KST_PrivacyIncident] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_dbo.KST_YearValue_ReportedToORMYear_Id]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncident_PrivacyIncidentId] FOREIGN KEY([PrivacyIncidentId])
REFERENCES [dbo].[KST_PrivacyIncident] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncident_PrivacyIncidentId]
GO
ALTER TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncidentMitigationCodeValue_PrivacyIncidentMitigati] FOREIGN KEY([PrivacyIncidentMitigationCodeValueId])
REFERENCES [dbo].[KST_PrivacyIncidentMitigationCodeValue] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue] CHECK CONSTRAINT [FK_dbo.KST_PrivacyIncident_PrivacyIncidentMitigationCodeValue_dbo.KST_PrivacyIncidentMitigationCodeValue_PrivacyIncidentMitigati]
GO
ALTER TABLE [dbo].[PriorFunctionChanges]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_FunctionChange_Assessment1] FOREIGN KEY([AssessmentId])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[PriorFunctionChanges] CHECK CONSTRAINT [fk_Assessment_FunctionChange_Assessment1]
GO
ALTER TABLE [dbo].[PriorFunctionChanges]  WITH CHECK ADD  CONSTRAINT [fk_Assessment_FunctionChange_FunctionChange1] FOREIGN KEY([FunctionChangeId])
REFERENCES [dbo].[FunctionChange] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PriorFunctionChanges] CHECK CONSTRAINT [fk_Assessment_FunctionChange_FunctionChange1]
GO
ALTER TABLE [dbo].[ProcessControlAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ProcessControlAssessment_Category1] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProcessControlAssessment] CHECK CONSTRAINT [fk_ProcessControlAssessment_Category1]
GO
ALTER TABLE [dbo].[ProcessControlAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ProcessControlAssessment_LikelihoodOfOccurrence1] FOREIGN KEY([LikelihoodOfOccurrence_Id])
REFERENCES [dbo].[LikelihoodOfOccurrence] ([Id])
GO
ALTER TABLE [dbo].[ProcessControlAssessment] CHECK CONSTRAINT [fk_ProcessControlAssessment_LikelihoodOfOccurrence1]
GO
ALTER TABLE [dbo].[ProcessControlAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ProcessControlAssessment_RiskExposure1] FOREIGN KEY([RiskExposure_Id])
REFERENCES [dbo].[RiskExposure] ([Id])
GO
ALTER TABLE [dbo].[ProcessControlAssessment] CHECK CONSTRAINT [fk_ProcessControlAssessment_RiskExposure1]
GO
ALTER TABLE [dbo].[ProcessControlAssessment_RiskImpact]  WITH CHECK ADD  CONSTRAINT [fk_ProcessControlAssessment_RiskImpact_ProcessControlAssessme1] FOREIGN KEY([ProcessControlAssessmentId])
REFERENCES [dbo].[ProcessControlAssessment] ([Id])
GO
ALTER TABLE [dbo].[ProcessControlAssessment_RiskImpact] CHECK CONSTRAINT [fk_ProcessControlAssessment_RiskImpact_ProcessControlAssessme1]
GO
ALTER TABLE [dbo].[ProcessControlAssessment_RiskImpact]  WITH CHECK ADD  CONSTRAINT [fk_ProcessControlAssessment_RiskImpact_RiskImpact1] FOREIGN KEY([RiskImpactId])
REFERENCES [dbo].[RiskImpact] ([Id])
GO
ALTER TABLE [dbo].[ProcessControlAssessment_RiskImpact] CHECK CONSTRAINT [fk_ProcessControlAssessment_RiskImpact_RiskImpact1]
GO
ALTER TABLE [dbo].[ProcessRisk]  WITH CHECK ADD  CONSTRAINT [fk_ProcessRisk_BusinessUnit1] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
GO
ALTER TABLE [dbo].[ProcessRisk] CHECK CONSTRAINT [fk_ProcessRisk_BusinessUnit1]
GO
ALTER TABLE [dbo].[ProcessRisk]  WITH CHECK ADD  CONSTRAINT [fk_ProcessRisk_Category1] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProcessRisk] CHECK CONSTRAINT [fk_ProcessRisk_Category1]
GO
ALTER TABLE [dbo].[ProcessRisk]  WITH CHECK ADD  CONSTRAINT [fk_ProcessRisk_FunctionalArea1] FOREIGN KEY([FunctionalAreaId])
REFERENCES [dbo].[FunctionalArea] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProcessRisk] CHECK CONSTRAINT [fk_ProcessRisk_FunctionalArea1]
GO
ALTER TABLE [dbo].[ProcessRisk_ControlType]  WITH CHECK ADD  CONSTRAINT [fk_ProcessRisk_ControlType_ControlType1] FOREIGN KEY([ControlTypeId])
REFERENCES [dbo].[ControlType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProcessRisk_ControlType] CHECK CONSTRAINT [fk_ProcessRisk_ControlType_ControlType1]
GO
ALTER TABLE [dbo].[ProcessRisk_ControlType]  WITH CHECK ADD  CONSTRAINT [fk_ProcessRisk_ControlType_ProcessRisk1] FOREIGN KEY([ProcessRiskId])
REFERENCES [dbo].[ProcessRisk] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProcessRisk_ControlType] CHECK CONSTRAINT [fk_ProcessRisk_ControlType_ProcessRisk1]
GO
ALTER TABLE [dbo].[ProcessRiskAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ProcessRiskAssessment_Assessment1] FOREIGN KEY([Assessment_Id])
REFERENCES [dbo].[Assessment] ([Id])
GO
ALTER TABLE [dbo].[ProcessRiskAssessment] CHECK CONSTRAINT [fk_ProcessRiskAssessment_Assessment1]
GO
ALTER TABLE [dbo].[ProcessRiskAssessment]  WITH CHECK ADD  CONSTRAINT [FK_ProcessRiskAssessment_ProcessControlAssessment] FOREIGN KEY([Id])
REFERENCES [dbo].[ProcessControlAssessment] ([Id])
GO
ALTER TABLE [dbo].[ProcessRiskAssessment] CHECK CONSTRAINT [FK_ProcessRiskAssessment_ProcessControlAssessment]
GO
ALTER TABLE [dbo].[ProcessRiskAssessment]  WITH CHECK ADD  CONSTRAINT [fk_ProcessRiskAssessment_ProcessRisk1] FOREIGN KEY([ProcessRisk_Id])
REFERENCES [dbo].[ProcessRisk] ([Id])
GO
ALTER TABLE [dbo].[ProcessRiskAssessment] CHECK CONSTRAINT [fk_ProcessRiskAssessment_ProcessRisk1]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_BusinessUnit] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_BusinessUnit]
GO
ALTER TABLE [dbo].[SubProcessRisk]  WITH CHECK ADD  CONSTRAINT [fk_SubProcessRisk_CoreProcess1] FOREIGN KEY([CoreProcess_Id])
REFERENCES [dbo].[CoreProcess] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubProcessRisk] CHECK CONSTRAINT [fk_SubProcessRisk_CoreProcess1]
GO
ALTER TABLE [dbo].[User_BusinessUnit]  WITH CHECK ADD  CONSTRAINT [fk_User_BusinessUnit_BusinessUnit1] FOREIGN KEY([BusinessUnitId])
REFERENCES [dbo].[BusinessUnit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_BusinessUnit] CHECK CONSTRAINT [fk_User_BusinessUnit_BusinessUnit1]
GO
ALTER TABLE [dbo].[User_BusinessUnit]  WITH CHECK ADD  CONSTRAINT [fk_User_BusinessUnit_User1] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMappingInfo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User_BusinessUnit] CHECK CONSTRAINT [fk_User_BusinessUnit_User1]
GO
