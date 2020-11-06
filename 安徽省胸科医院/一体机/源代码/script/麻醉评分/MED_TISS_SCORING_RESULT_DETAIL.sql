-- Create table
create table MED_TISS_SCORING_RESULT_DETAIL
(
  patient_id        VARCHAR2(20) not null,
  visit_id          NUMBER(2) not null,
  dep_id            NUMBER(2) not null,
  scoring_date_time DATE not null,
  t41               NUMBER(1),
  t42               NUMBER(1),
  t43               NUMBER(1),
  t44               NUMBER(1),
  t45               NUMBER(1),
  t46               NUMBER(1),
  t47               NUMBER(1),
  t48               NUMBER(1),
  t49               NUMBER(1),
  t410              NUMBER(1),
  t411              NUMBER(1),
  t412              NUMBER(1),
  t413              NUMBER(1),
  t414              NUMBER(1),
  t415              NUMBER(1),
  t416              NUMBER(1),
  t417              NUMBER(1),
  t418              NUMBER(1),
  t419              NUMBER(1),
  t31               NUMBER(1),
  t32               NUMBER(1),
  t33               NUMBER(1),
  t34               NUMBER(1),
  t35               NUMBER(1),
  t36               NUMBER(1),
  t37               NUMBER(1),
  t38               NUMBER(1),
  t39               NUMBER(1),
  t310              NUMBER(1),
  t311              NUMBER(1),
  t312              NUMBER(1),
  t313              NUMBER(1),
  t314              NUMBER(1),
  t315              NUMBER(1),
  t316              NUMBER(1),
  t317              NUMBER(1),
  t318              NUMBER(1),
  t319              NUMBER(1),
  t320              NUMBER(1),
  t321              NUMBER(1),
  t322              NUMBER(1),
  t323              NUMBER(1),
  t324              NUMBER(1),
  t325              NUMBER(1),
  t326              NUMBER(1),
  t327              NUMBER(1),
  t328              NUMBER(1),
  t21               NUMBER(1),
  t22               NUMBER(1),
  t23               NUMBER(1),
  t24               NUMBER(1),
  t25               NUMBER(1),
  t26               NUMBER(1),
  t27               NUMBER(1),
  t28               NUMBER(1),
  t29               NUMBER(1),
  t210              NUMBER(1),
  t211              NUMBER(1),
  t11               NUMBER(1),
  t12               NUMBER(1),
  t13               NUMBER(1),
  t14               NUMBER(1),
  t15               NUMBER(1),
  t16               NUMBER(1),
  t17               NUMBER(1),
  t18               NUMBER(1),
  t19               NUMBER(1),
  t110              NUMBER(1),
  t111              NUMBER(1),
  t112              NUMBER(1),
  t113              NUMBER(1),
  t114              NUMBER(1),
  t115              NUMBER(1),
  t116              NUMBER(1),
  t117              NUMBER(1),
  t118              NUMBER(1),
  memo              VARCHAR2(100)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_TISS_SCORING_RESULT_DETAIL
  add constraint PK_TISS_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_TISS_SCORING_RESULT_DETAIL to ROLE_DOCARE;
