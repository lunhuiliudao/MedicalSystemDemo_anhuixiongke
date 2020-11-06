/****** Object:  Table [dbo].[MED_ANESTHESIA_INPUT_DATA]    Script Date: 09/28/2015 20:23:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MED_ANESTHESIA_INPUT_DATA](
	[PATIENT_ID] [varchar](20) NOT NULL,
	[VISIT_ID] [numeric](2, 0) NOT NULL,
	[OPER_ID] [numeric](2, 0) NOT NULL,
	[CANCELED_TYPE] [varchar](20) NULL,
    [PACU_TEMPERATURE] [numeric](2, 0) NULL,
    [IN_ICU] [numeric](2, 0) NULL,
    [TRACHEA_6H] [numeric](2, 0) NULL,
    [TRACHEA_REMOVE] [numeric](2, 0) NULL,
    [ANES_START_24H_DEATH] [numeric](2, 0) NULL,
    [ANES_START_24H_STOP] [numeric](2, 0) NULL,
    [ANES_ANAPHYLAXIS] [numeric](2, 0) NULL,
    [SPINAL_ANES_COMP] [numeric](2, 0) NULL,
    [CENTRAL_VENOUS] [numeric](2, 0) NULL,
    [SPINAL_ANES] [numeric](2, 0) NULL,
    [TRACHEA_HOARSE] [numeric](2, 0) NULL,
    [AFTER_ANES_COMA] [numeric](2, 0) NULL,
    [GEN_ANES_TRACHEA] [numeric](2, 0) NULL,
    [PACU_SITUATION] [varchar](200) NULL,
    [PACU_STEWARD] [numeric](2, 0) NULL,
    [PACU_DOCTOR] [varchar](8) NULL,
    [PACU_NURSE] [varchar](8) NULL,
    [ANALGESIA_PUMP] [varchar](20) NULL,
    [ANALGESIA_METHOD] [varchar](20) NULL,
    [ANALGESIA_DRUGS] [varchar](200) NULL,
    [ANALGESIA_EFFECT] [varchar](20) NULL,
    [EXTRA_CIRCULATION] [numeric](2, 0) NULL,
    [ANALGESIA_THERAPY] [numeric](2, 0) NULL,
    [AFTER_ANALGESIA] [numeric](2, 0) NULL,
    [MONARY_RES] [numeric](2, 0) NULL,
    [MONARY_RES_OK] [numeric](2, 0) NULL,
    [CONS_DISTURBANCE] [numeric](2, 0) NULL,
    [OXYGEN_SATURATION] [numeric](2, 0) NULL,
    [USE_REMINDERS] [numeric](2, 0) NULL,
    [RES_TRACT_OBSTRUCE] [numeric](2, 0) NULL,
    [ANES_DEATH] [numeric](2, 0) NULL,
    [OTHER_NOT_EXP] [numeric](2, 0) NULL,
    [DEATH_AFTER_OPER] [numeric](2, 0) NULL,
    [NO_PLAN_IN_ICU] [numeric](2, 0) NULL,
	[PAT_DIRECTION] [varchar](20) NULL,
 CONSTRAINT [PK_MED_ANESTHESIA_INPUT_DATA] PRIMARY KEY CLUSTERED 
(
	[PATIENT_ID] ASC,
	[VISIT_ID] ASC,
	[OPER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


