using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MedAnesthesiaPlan
    {
        private string patient_id;
        private decimal visit_id;
        private decimal oper_id;
        private string  height;
        private string  weight;
        private string blood_press;
        private decimal cardiotach;
        private decimal plus;
        private decimal breath;
        private string tempeture;
        private string consciousness;
        private string mr_abstract;
        private decimal anes_history_indicator;
        private string anes_history;
        private string alergy_drugs_indicator;
        private string alergy_drugs;
        private string cervix;
        private string tooth_exam;
        private string mouth_open_width;
        private string sound_of_heart_and_lung;
        private decimal limb_indicator;
        private string limb_feel;
        private string down_limb_feel;
        private string vein;
        private string spine_status;
        private string spine_status_of_mis;
        private string heart_grade;
        private string ecg_exam;
        private string lung;
        private string exam_x;
        private decimal liver_indicator;
        private string liver;
        private decimal kidney_indicator;
        private string kidney;
        private string hemoglobin;
        private string lab_a;
        private string blood_corpuscle;
        private string lab_c;
        private string bleeding_time;
        private string cruor_time;
        private string cruor_zymogen_time;
        private string lab_k;
        private string lab_na;
        private string lab_cl;
        private string lab_giu;
        private string other_labs;
        private string asa_grade;
        private string anes_summary;
        private string operation_class;
        private string anesthesia_drugs;
        private string drug_in_operation;
        private System.DateTime anes_start_time;
        private System.DateTime anes_end_time;
        private System.DateTime enter_date_time;
        private string entered_by;
        private string pre_anes_pham;
        private string pre_anes_pham_result;
        private string anesthesia_method;
        private string anesthesia_position;
        private decimal end_indicator;
        private string bed_no;
        private decimal order_transfer;
        private decimal charge_transfer;
        private string operation_name;
        private string allens;
        private string alimentation_status;
        private string lab_w;
        private string lab_alt;
        private string lab_ast;
        private string lab_cr;
        private string lab_bun;
        private string lab_hbcab;
        private string lab_hbeab;
        private string lab_hbbag;
        private string lab_hbsab;
        private string lab_hbsag;
        private string lab_anti_hcv;
        private string lab_ca;
        private string psychosis;
        private string sound_of_heart;
        private string sound_of_lung;
        private string heart_color_ultrasonic;
        private string anesthesia_operation;
        private string thoracic_cage;
        private string investigate_suggestion;
        private string fluid_path1;
        private string fluid_path2;
        private string fluid_path3;
        private decimal fasting;
        private decimal oper_history_indicator;
        private decimal smoke_drink_indicator;
        private decimal blood_transfer_history;
        private decimal sleeping_pill_indicator;
        private decimal intub_dificult;
        private string mallampatti;
        private decimal tonsil_tumescent_indicator;
        private string tonsil_tumescent_level;
        private string abdomen;
        private string artery_vein_puncture_pos;
        private string operation_position;
        private string in_room_status;
        private string heart_fun;
        private string rbc_plot;
        private string urine_conventional;
        private string urine_giu;
        private string urea_n;
        private string albumin;
        private string wbc_ball;
        private string liver_function;
        private string ecg;
        private string heart_catheterization;
        private string echocardiography;
        private string x_ray_examination;
        private decimal easepain_transfer;
        private string pre_spec_anes_pham;
        private string urine_rbc;
        private string urine_globin;
        private string kidney_antigen;
        private string lab_kzero;
        private string erp_sift;
        private string lab_bgkt;
        private string lab_bilirubin;
        private string lab_cholesterol;
        private string anes_history_indicator_text;
        private string retake_pipe;
        private string bed_label;
        private string anes_keep;
        private string visit_nurse;
        private System.DateTime visit_date;
        private string operation_doc;
        private string body_status;
        private string skin_status;
        private string active_status;
        private string psych_status;
        private string psych_memo;
        private string degree_status;
        private string economy_status;
        private string pay_way;
        private string comm_memo;
        private string bp_status;
        private string operation_history;
        private string i_bp;
        private string i_p;
        private string i_giu;
        private string v_bp;
        private string v_p;
        private string v_giu;
        private string syphils;
        private string hiv_info;
        private string alt;
        private string tp;
        private string alb;
        private string glb;
        private string cr;
        private string bun;
        private string ua;
        private string glu;
        private string tg;
        private string cho;
        private string hbsag;
        private string pt;
        private string aptt;
        private string fbg;
        private string tt;
        private string co2cp;
        private string ag;
        private string tbil;
        private string dbil;
        private string nfky;
        private string qms;
        private string blood_type;
        private string proportion;
        private string ph;
        private string allen;
        private string state;
        private System.DateTime plandate;
        private string body_area;
        private string secuname;
        private string secuname_1;
        private string statespec;
        private string p_history1;
        private string p_history2;
        private string c_history1;
        private string c_history2;
        private string p_worry1;
        private string p_worry2;
        private string p_worry3;
        private string p_worry4;
        private string p_worry5;
        private string p_worry6;
        private string anes_history_family;
        private string cardiac;
        private string respiratory;
        private string endocrine;
        private string gl_gu;
        private string neur_hema;
        private string muscular_skeletal;
        private string heart_desc;
        private string mallampatti_desc;
        private string medications;
        private string npo_since;
        private string psce;
        private string p_m1;
        private string p_m2;
        private string p_m3;
        private string p_t1;
        private string p_t2;
        private string p_t3;
        private string p_t4;
        private string p_t5;
        private string p_n1;
        private string p_n2;
        private string p_n3;
        private string p_n4;
        private string p_h1;
        private string p_h2;
        private string p_h3;
        private string p_h4;
        private string p_h5;
        private string p_h6;
        private string p_hl1;
        private string p_hl2;
        private string p_hl3;
        private string p_hl4;
        private string p_anes_m1;
        private string p_anes_m2;
        private string p_action;

        public string PATIENT_ID
        {
            get { return patient_id; }
            set { patient_id = value; }
        }
        public decimal VISIT_ID
        {
            get { return visit_id; }
            set { visit_id = value; }
        }
        public decimal OPER_ID
        {
            get { return oper_id; }
            set { oper_id = value; }
        }
        public string  HEIGHT
        {
            get { return height; }
            set { height = value; }
        }
        public string  WEIGHT
        {
            get { return weight; }
            set { weight = value; }
        }
        public string BLOOD_PRESS
        {
            get { return blood_press; }
            set { blood_press = value; }
        }
        public decimal CARDIOTACH
        {
            get { return cardiotach; }
            set { cardiotach = value; }
        }
        public decimal PLUS
        {
            get { return plus; }
            set { plus = value; }
        }
        public decimal BREATH
        {
            get { return breath; }
            set { breath = value; }
        }
        public string TEMPETURE
        {
            get { return tempeture; }
            set { tempeture = value; }
        }
        public string CONSCIOUSNESS
        {
            get { return consciousness; }
            set { consciousness = value; }
        }
        public string MR_ABSTRACT
        {
            get { return mr_abstract; }
            set { mr_abstract = value; }
        }
        public decimal ANES_HISTORY_INDICATOR
        {
            get { return anes_history_indicator; }
            set { anes_history_indicator = value; }
        }
        public string ANES_HISTORY
        {
            get { return anes_history; }
            set { anes_history = value; }
        }
        public string ALERGY_DRUGS_INDICATOR
        {
            get { return alergy_drugs_indicator; }
            set { alergy_drugs_indicator = value; }
        }
        public string ALERGY_DRUGS
        {
            get { return alergy_drugs; }
            set { alergy_drugs = value; }
        }
        public string CERVIX
        {
            get { return cervix; }
            set { cervix = value; }
        }
        public string TOOTH_EXAM
        {
            get { return tooth_exam; }
            set { tooth_exam = value; }
        }
        public string MOUTH_OPEN_WIDTH
        {
            get { return mouth_open_width; }
            set { mouth_open_width = value; }
        }
        public string SOUND_OF_HEART_AND_LUNG
        {
            get { return sound_of_heart_and_lung; }
            set { sound_of_heart_and_lung = value; }
        }
        public decimal LIMB_INDICATOR
        {
            get { return limb_indicator; }
            set { limb_indicator = value; }
        }
        public string LIMB_FEEL
        {
            get { return limb_feel; }
            set { limb_feel = value; }
        }
        public string DOWN_LIMB_FEEL
        {
            get { return down_limb_feel; }
            set { down_limb_feel = value; }
        }
        public string VEIN
        {
            get { return vein; }
            set { vein = value; }
        }
        public string SPINE_STATUS
        {
            get { return spine_status; }
            set { spine_status = value; }
        }
        public string SPINE_STATUS_OF_MIS
        {
            get { return spine_status_of_mis; }
            set { spine_status_of_mis = value; }
        }
        public string HEART_GRADE
        {
            get { return heart_grade; }
            set { heart_grade = value; }
        }
        public string ECG_EXAM
        {
            get { return ecg_exam; }
            set { ecg_exam = value; }
        }
        public string LUNG
        {
            get { return lung; }
            set { lung = value; }
        }
        public string EXAM_X
        {
            get { return exam_x; }
            set { exam_x = value; }
        }
        public decimal LIVER_INDICATOR
        {
            get { return liver_indicator; }
            set { liver_indicator = value; }
        }
        public string LIVER
        {
            get { return liver; }
            set { liver = value; }
        }
        public decimal KIDNEY_INDICATOR
        {
            get { return kidney_indicator; }
            set { kidney_indicator = value; }
        }
        public string KIDNEY
        {
            get { return kidney; }
            set { kidney = value; }
        }
        public string HEMOGLOBIN
        {
            get { return hemoglobin; }
            set { hemoglobin = value; }
        }
        public string LAB_A
        {
            get { return lab_a; }
            set { lab_a = value; }
        }
        public string BLOOD_CORPUSCLE
        {
            get { return blood_corpuscle; }
            set { blood_corpuscle = value; }
        }
        public string LAB_C
        {
            get { return lab_c; }
            set { lab_c = value; }
        }
        public string BLEEDING_TIME
        {
            get { return bleeding_time; }
            set { bleeding_time = value; }
        }
        public string CRUOR_TIME
        {
            get { return cruor_time; }
            set { cruor_time = value; }
        }
        public string CRUOR_ZYMOGEN_TIME
        {
            get { return cruor_zymogen_time; }
            set { cruor_zymogen_time = value; }
        }
        public string LAB_K
        {
            get { return lab_k; }
            set { lab_k = value; }
        }
        public string LAB_NA
        {
            get { return lab_na; }
            set { lab_na = value; }
        }
        public string LAB_CL
        {
            get { return lab_cl; }
            set { lab_cl = value; }
        }
        public string LAB_GIU
        {
            get { return lab_giu; }
            set { lab_giu = value; }
        }
        public string OTHER_LABS
        {
            get { return other_labs; }
            set { other_labs = value; }
        }
        public string ASA_GRADE
        {
            get { return asa_grade; }
            set { asa_grade = value; }
        }
        public string ANES_SUMMARY
        {
            get { return anes_summary; }
            set { anes_summary = value; }
        }
        public string OPERATION_CLASS
        {
            get { return operation_class; }
            set { operation_class = value; }
        }
        public string ANESTHESIA_DRUGS
        {
            get { return anesthesia_drugs; }
            set { anesthesia_drugs = value; }
        }
        public string DRUG_IN_OPERATION
        {
            get { return drug_in_operation; }
            set { drug_in_operation = value; }
        }
        public System.DateTime ANES_START_TIME
        {
            get { return anes_start_time; }
            set { anes_start_time = value; }
        }
        public System.DateTime ANES_END_TIME
        {
            get { return anes_end_time; }
            set { anes_end_time = value; }
        }
        public System.DateTime ENTER_DATE_TIME
        {
            get { return enter_date_time; }
            set { enter_date_time = value; }
        }
        public string ENTERED_BY
        {
            get { return entered_by; }
            set { entered_by = value; }
        }
        public string PRE_ANES_PHAM
        {
            get { return pre_anes_pham; }
            set { pre_anes_pham = value; }
        }
        public string PRE_ANES_PHAM_RESULT
        {
            get { return pre_anes_pham_result; }
            set { pre_anes_pham_result = value; }
        }
        public string ANESTHESIA_METHOD
        {
            get { return anesthesia_method; }
            set { anesthesia_method = value; }
        }
        public string ANESTHESIA_POSITION
        {
            get { return anesthesia_position; }
            set { anesthesia_position = value; }
        }
        public decimal END_INDICATOR
        {
            get { return end_indicator; }
            set { end_indicator = value; }
        }
        public string BED_NO
        {
            get { return bed_no; }
            set { bed_no = value; }
        }
        public decimal ORDER_TRANSFER
        {
            get { return order_transfer; }
            set { order_transfer = value; }
        }
        public decimal CHARGE_TRANSFER
        {
            get { return charge_transfer; }
            set { charge_transfer = value; }
        }
        public string OPERATION_NAME
        {
            get { return operation_name; }
            set { operation_name = value; }
        }
        public string ALLENS
        {
            get { return allens; }
            set { allens = value; }
        }
        public string ALIMENTATION_STATUS
        {
            get { return alimentation_status; }
            set { alimentation_status = value; }
        }
        public string LAB_W
        {
            get { return lab_w; }
            set { lab_w = value; }
        }
        public string LAB_ALT
        {
            get { return lab_alt; }
            set { lab_alt = value; }
        }
        public string LAB_AST
        {
            get { return lab_ast; }
            set { lab_ast = value; }
        }
        public string LAB_CR
        {
            get { return lab_cr; }
            set { lab_cr = value; }
        }
        public string LAB_BUN
        {
            get { return lab_bun; }
            set { lab_bun = value; }
        }
        public string LAB_HBCAB
        {
            get { return lab_hbcab; }
            set { lab_hbcab = value; }
        }
        public string LAB_HBEAB
        {
            get { return lab_hbeab; }
            set { lab_hbeab = value; }
        }
        public string LAB_HBBAG
        {
            get { return lab_hbbag; }
            set { lab_hbbag = value; }
        }
        public string LAB_HBSAB
        {
            get { return lab_hbsab; }
            set { lab_hbsab = value; }
        }
        public string LAB_HBSAG
        {
            get { return lab_hbsag; }
            set { lab_hbsag = value; }
        }
        public string LAB_ANTI_HCV
        {
            get { return lab_anti_hcv; }
            set { lab_anti_hcv = value; }
        }
        public string LAB_CA
        {
            get { return lab_ca; }
            set { lab_ca = value; }
        }
        public string PSYCHOSIS
        {
            get { return psychosis; }
            set { psychosis = value; }
        }
        public string SOUND_OF_HEART
        {
            get { return sound_of_heart; }
            set { sound_of_heart = value; }
        }
        public string SOUND_OF_LUNG
        {
            get { return sound_of_lung; }
            set { sound_of_lung = value; }
        }
        public string HEART_COLOR_ULTRASONIC
        {
            get { return heart_color_ultrasonic; }
            set { heart_color_ultrasonic = value; }
        }
        public string ANESTHESIA_OPERATION
        {
            get { return anesthesia_operation; }
            set { anesthesia_operation = value; }
        }
        public string THORACIC_CAGE
        {
            get { return thoracic_cage; }
            set { thoracic_cage = value; }
        }
        public string INVESTIGATE_SUGGESTION
        {
            get { return investigate_suggestion; }
            set { investigate_suggestion = value; }
        }
        public string FLUID_PATH1
        {
            get { return fluid_path1; }
            set { fluid_path1 = value; }
        }
        public string FLUID_PATH2
        {
            get { return fluid_path2; }
            set { fluid_path2 = value; }
        }
        public string FLUID_PATH3
        {
            get { return fluid_path3; }
            set { fluid_path3 = value; }
        }
        public decimal FASTING
        {
            get { return fasting; }
            set { fasting = value; }
        }
        public decimal OPER_HISTORY_INDICATOR
        {
            get { return oper_history_indicator; }
            set { oper_history_indicator = value; }
        }
        public decimal SMOKE_DRINK_INDICATOR
        {
            get { return smoke_drink_indicator; }
            set { smoke_drink_indicator = value; }
        }
        public decimal BLOOD_TRANSFER_HISTORY
        {
            get { return blood_transfer_history; }
            set { blood_transfer_history = value; }
        }
        public decimal SLEEPING_PILL_INDICATOR
        {
            get { return sleeping_pill_indicator; }
            set { sleeping_pill_indicator = value; }
        }
        public decimal INTUB_DIFICULT
        {
            get { return intub_dificult; }
            set { intub_dificult = value; }
        }
        public string MALLAMPATTI
        {
            get { return mallampatti; }
            set { mallampatti = value; }
        }
        public decimal TONSIL_TUMESCENT_INDICATOR
        {
            get { return tonsil_tumescent_indicator; }
            set { tonsil_tumescent_indicator = value; }
        }
        public string TONSIL_TUMESCENT_LEVEL
        {
            get { return tonsil_tumescent_level; }
            set { tonsil_tumescent_level = value; }
        }
        public string ABDOMEN
        {
            get { return abdomen; }
            set { abdomen = value; }
        }
        public string ARTERY_VEIN_PUNCTURE_POS
        {
            get { return artery_vein_puncture_pos; }
            set { artery_vein_puncture_pos = value; }
        }
        public string OPERATION_POSITION
        {
            get { return operation_position; }
            set { operation_position = value; }
        }
        public string IN_ROOM_STATUS
        {
            get { return in_room_status; }
            set { in_room_status = value; }
        }
        public string HEART_FUN
        {
            get { return heart_fun; }
            set { heart_fun = value; }
        }
        public string RBC_PLOT
        {
            get { return rbc_plot; }
            set { rbc_plot = value; }
        }
        public string URINE_CONVENTIONAL
        {
            get { return urine_conventional; }
            set { urine_conventional = value; }
        }
        public string URINE_GIU
        {
            get { return urine_giu; }
            set { urine_giu = value; }
        }
        public string UREA_N
        {
            get { return urea_n; }
            set { urea_n = value; }
        }
        public string ALBUMIN
        {
            get { return albumin; }
            set { albumin = value; }
        }
        public string WBC_BALL
        {
            get { return wbc_ball; }
            set { wbc_ball = value; }
        }
        public string LIVER_FUNCTION
        {
            get { return liver_function; }
            set { liver_function = value; }
        }
        public string ECG
        {
            get { return ecg; }
            set { ecg = value; }
        }
        public string HEART_CATHETERIZATION
        {
            get { return heart_catheterization; }
            set { heart_catheterization = value; }
        }
        public string ECHOCARDIOGRAPHY
        {
            get { return echocardiography; }
            set { echocardiography = value; }
        }
        public string X_RAY_EXAMINATION
        {
            get { return x_ray_examination; }
            set { x_ray_examination = value; }
        }
        public decimal EASEPAIN_TRANSFER
        {
            get { return easepain_transfer; }
            set { easepain_transfer = value; }
        }
        public string PRE_SPEC_ANES_PHAM
        {
            get { return pre_spec_anes_pham; }
            set { pre_spec_anes_pham = value; }
        }
        public string URINE_RBC
        {
            get { return urine_rbc; }
            set { urine_rbc = value; }
        }
        public string URINE_GLOBIN
        {
            get { return urine_globin; }
            set { urine_globin = value; }
        }
        public string KIDNEY_ANTIGEN
        {
            get { return kidney_antigen; }
            set { kidney_antigen = value; }
        }
        public string LAB_KZERO
        {
            get { return lab_kzero; }
            set { lab_kzero = value; }
        }
        public string ERP_SIFT
        {
            get { return erp_sift; }
            set { erp_sift = value; }
        }
        public string LAB_BGKT
        {
            get { return lab_bgkt; }
            set { lab_bgkt = value; }
        }
        public string LAB_BILIRUBIN
        {
            get { return lab_bilirubin; }
            set { lab_bilirubin = value; }
        }
        public string LAB_CHOLESTEROL
        {
            get { return lab_cholesterol; }
            set { lab_cholesterol = value; }
        }
        public string ANES_HISTORY_INDICATOR_TEXT
        {
            get { return anes_history_indicator_text; }
            set { anes_history_indicator_text = value; }
        }
        public string RETAKE_PIPE
        {
            get { return retake_pipe; }
            set { retake_pipe = value; }
        }
        public string BED_LABEL
        {
            get { return bed_label; }
            set { bed_label = value; }
        }
        public string ANES_KEEP
        {
            get { return anes_keep; }
            set { anes_keep = value; }
        }
        public string VISIT_NURSE
        {
            get { return visit_nurse; }
            set { visit_nurse = value; }
        }
        public System.DateTime VISIT_DATE
        {
            get { return visit_date; }
            set { visit_date = value; }
        }
        public string OPERATION_DOC
        {
            get { return operation_doc; }
            set { operation_doc = value; }
        }
        public string BODY_STATUS
        {
            get { return body_status; }
            set { body_status = value; }
        }
        public string SKIN_STATUS
        {
            get { return skin_status; }
            set { skin_status = value; }
        }
        public string ACTIVE_STATUS
        {
            get { return active_status; }
            set { active_status = value; }
        }
        public string PSYCH_STATUS
        {
            get { return psych_status; }
            set { psych_status = value; }
        }
        public string PSYCH_MEMO
        {
            get { return psych_memo; }
            set { psych_memo = value; }
        }
        public string DEGREE_STATUS
        {
            get { return degree_status; }
            set { degree_status = value; }
        }
        public string ECONOMY_STATUS
        {
            get { return economy_status; }
            set { economy_status = value; }
        }
        public string PAY_WAY
        {
            get { return pay_way; }
            set { pay_way = value; }
        }
        public string COMM_MEMO
        {
            get { return comm_memo; }
            set { comm_memo = value; }
        }
        public string BP_STATUS
        {
            get { return bp_status; }
            set { bp_status = value; }
        }
        public string OPERATION_HISTORY
        {
            get { return operation_history; }
            set { operation_history = value; }
        }
        public string I_BP
        {
            get { return i_bp; }
            set { i_bp = value; }
        }
        public string I_P
        {
            get { return i_p; }
            set { i_p = value; }
        }
        public string I_GIU
        {
            get { return i_giu; }
            set { i_giu = value; }
        }
        public string V_BP
        {
            get { return v_bp; }
            set { v_bp = value; }
        }
        public string V_P
        {
            get { return v_p; }
            set { v_p = value; }
        }
        public string V_GIU
        {
            get { return v_giu; }
            set { v_giu = value; }
        }
        public string SYPHILS
        {
            get { return syphils; }
            set { syphils = value; }
        }
        public string HIV_INFO
        {
            get { return hiv_info; }
            set { hiv_info = value; }
        }
        public string ALT
        {
            get { return alt; }
            set { alt = value; }
        }
        public string TP
        {
            get { return tp; }
            set { tp = value; }
        }
        public string ALB
        {
            get { return alb; }
            set { alb = value; }
        }
        public string GLB
        {
            get { return glb; }
            set { glb = value; }
        }
        public string CR
        {
            get { return cr; }
            set { cr = value; }
        }
        public string BUN
        {
            get { return bun; }
            set { bun = value; }
        }
        public string UA
        {
            get { return ua; }
            set { ua = value; }
        }
        public string GLU
        {
            get { return glu; }
            set { glu = value; }
        }
        public string TG
        {
            get { return tg; }
            set { tg = value; }
        }
        public string CHO
        {
            get { return cho; }
            set { cho = value; }
        }
        public string HBSAG
        {
            get { return hbsag; }
            set { hbsag = value; }
        }
        public string PT
        {
            get { return pt; }
            set { pt = value; }
        }
        public string APTT
        {
            get { return aptt; }
            set { aptt = value; }
        }
        public string FBG
        {
            get { return fbg; }
            set { fbg = value; }
        }
        public string TT
        {
            get { return tt; }
            set { tt = value; }
        }
        public string CO2CP
        {
            get { return co2cp; }
            set { co2cp = value; }
        }
        public string AG
        {
            get { return ag; }
            set { ag = value; }
        }
        public string TBIL
        {
            get { return tbil; }
            set { tbil = value; }
        }
        public string DBIL
        {
            get { return dbil; }
            set { dbil = value; }
        }
        public string NFKY
        {
            get { return nfky; }
            set { nfky = value; }
        }
        public string QMS
        {
            get { return qms; }
            set { qms = value; }
        }
        public string BLOOD_TYPE
        {
            get { return blood_type; }
            set { blood_type = value; }
        }
        public string PROPORTION
        {
            get { return proportion; }
            set { proportion = value; }
        }
        public string PH
        {
            get { return ph; }
            set { ph = value; }
        }
        public string ALLEN
        {
            get { return allen; }
            set { allen = value; }
        }
        public string STATE
        {
            get { return state; }
            set { state = value; }
        }
        public System.DateTime PLANDATE
        {
            get { return plandate; }
            set { plandate = value; }
        }
        public string BODY_AREA
        {
            get { return body_area; }
            set { body_area = value; }
        }
        public string SECUNAME
        {
            get { return secuname; }
            set { secuname = value; }
        }
        public string SECUNAME_1
        {
            get { return secuname_1; }
            set { secuname_1 = value; }
        }
        public string STATESPEC
        {
            get { return statespec; }
            set { statespec = value; }
        }
        public string P_HISTORY1
        {
            get { return p_history1; }
            set { p_history1 = value; }
        }
        public string P_HISTORY2
        {
            get { return p_history2; }
            set { p_history2 = value; }
        }
        public string C_HISTORY1
        {
            get { return c_history1; }
            set { c_history1 = value; }
        }
        public string C_HISTORY2
        {
            get { return c_history2; }
            set { c_history2 = value; }
        }
        public string P_WORRY1
        {
            get { return p_worry1; }
            set { p_worry1 = value; }
        }
        public string P_WORRY2
        {
            get { return p_worry2; }
            set { p_worry2 = value; }
        }
        public string P_WORRY3
        {
            get { return p_worry3; }
            set { p_worry3 = value; }
        }
        public string P_WORRY4
        {
            get { return p_worry4; }
            set { p_worry4 = value; }
        }
        public string P_WORRY5
        {
            get { return p_worry5; }
            set { p_worry5 = value; }
        }
        public string P_WORRY6
        {
            get { return p_worry6; }
            set { p_worry6 = value; }
        }
        public string ANES_HISTORY_FAMILY
        {
            get { return anes_history_family; }
            set { anes_history_family = value; }
        }
        public string CARDIAC
        {
            get { return cardiac; }
            set { cardiac = value; }
        }
        public string RESPIRATORY
        {
            get { return respiratory; }
            set { respiratory = value; }
        }
        public string ENDOCRINE
        {
            get { return endocrine; }
            set { endocrine = value; }
        }
        public string GL_GU
        {
            get { return gl_gu; }
            set { gl_gu = value; }
        }
        public string NEUR_HEMA
        {
            get { return neur_hema; }
            set { neur_hema = value; }
        }
        public string MUSCULAR_SKELETAL
        {
            get { return muscular_skeletal; }
            set { muscular_skeletal = value; }
        }
        public string HEART_DESC
        {
            get { return heart_desc; }
            set { heart_desc = value; }
        }
        public string MALLAMPATTI_DESC
        {
            get { return mallampatti_desc; }
            set { mallampatti_desc = value; }
        }
        public string MEDICATIONS
        {
            get { return medications; }
            set { medications = value; }
        }
        public string NPO_SINCE
        {
            get { return npo_since; }
            set { npo_since = value; }
        }
        public string PSCE
        {
            get { return psce; }
            set { psce = value; }
        }
        public string P_M1
        {
            get { return p_m1; }
            set { p_m1 = value; }
        }
        public string P_M2
        {
            get { return p_m2; }
            set { p_m2 = value; }
        }
        public string P_M3
        {
            get { return p_m3; }
            set { p_m3 = value; }
        }
        public string P_T1
        {
            get { return p_t1; }
            set { p_t1 = value; }
        }
        public string P_T2
        {
            get { return p_t2; }
            set { p_t2 = value; }
        }
        public string P_T3
        {
            get { return p_t3; }
            set { p_t3 = value; }
        }
        public string P_T4
        {
            get { return p_t4; }
            set { p_t4 = value; }
        }
        public string P_T5
        {
            get { return p_t5; }
            set { p_t5 = value; }
        }
        public string P_N1
        {
            get { return p_n1; }
            set { p_n1 = value; }
        }
        public string P_N2
        {
            get { return p_n2; }
            set { p_n2 = value; }
        }
        public string P_N3
        {
            get { return p_n3; }
            set { p_n3 = value; }
        }
        public string P_N4
        {
            get { return p_n4; }
            set { p_n4 = value; }
        }
        public string P_H1
        {
            get { return p_h1; }
            set { p_h1 = value; }
        }
        public string P_H2
        {
            get { return p_h2; }
            set { p_h2 = value; }
        }
        public string P_H3
        {
            get { return p_h3; }
            set { p_h3 = value; }
        }
        public string P_H4
        {
            get { return p_h4; }
            set { p_h4 = value; }
        }
        public string P_H5
        {
            get { return p_h5; }
            set { p_h5 = value; }
        }
        public string P_H6
        {
            get { return p_h6; }
            set { p_h6 = value; }
        }
        public string P_HL1
        {
            get { return p_hl1; }
            set { p_hl1 = value; }
        }
        public string P_HL2
        {
            get { return p_hl2; }
            set { p_hl2 = value; }
        }
        public string P_HL3
        {
            get { return p_hl3; }
            set { p_hl3 = value; }
        }
        public string P_HL4
        {
            get { return p_hl4; }
            set { p_hl4 = value; }
        }
        public string P_ANES_M1
        {
            get { return p_anes_m1; }
            set { p_anes_m1 = value; }
        }
        public string P_ANES_M2
        {
            get { return p_anes_m2; }
            set { p_anes_m2 = value; }
        }
        public string P_ACTION
        {
            get { return p_action; }
            set { p_action = value; }
        }

    }
}

   
 
