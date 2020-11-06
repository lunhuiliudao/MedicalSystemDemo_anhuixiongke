
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.AnesWorkStation.ViewModel.AnesScoreViewModel
{
    public class BalthazarViewModel : BaseViewModel
    {
        private Score.Balthazar balthazarForm = null;

        public Score.Balthazar BalthazarForm
        {
            get { return this.balthazarForm; }
            set { this.balthazarForm = value; }
        }

        private Score.Child_Pugh child_PughForm = null;
        public Score.Child_Pugh Child_PughForm
        {
            get { return this.child_PughForm; }
            set { this.child_PughForm = value; }
        }

        private Score.Goldman goldmanForm = null;
        public Score.Goldman GoldmanForm
        {
            get { return this.goldmanForm; }
            set { this.goldmanForm = value; }
        }

        private Score.Lutz lutz = null;
        public Score.Lutz Lutz
        {
            get { return this.lutz; }
            set { this.lutz = value; }
        }

        private Score.Pars pars = null;
        public Score.Pars Pars
        {
            get { return this.pars; }
            set { this.pars = value; }
        }

        private Score.ScoreAPACHEIIPanel scoreAPACHEIIPanel = null;
        public Score.ScoreAPACHEIIPanel ScoreAPACHEIIPanel
        {
            get { return this.scoreAPACHEIIPanel; }
            set { this.scoreAPACHEIIPanel = value; }
        }

        private Score.ScoreTISSPanel scoreTISSPanel = null;
        public Score.ScoreTISSPanel ScoreTISSPanel
        {
            get { return this.scoreTISSPanel; }
            set { this.scoreTISSPanel = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public BalthazarViewModel()
        {

            balthazarForm = new Score.Balthazar(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);

            child_PughForm = new Score.Child_Pugh(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);

            goldmanForm = new Score.Goldman(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);

            lutz = new Score.Lutz(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);

            pars = new Score.Pars(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);

            scoreAPACHEIIPanel = new Score.ScoreAPACHEIIPanel(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);

            scoreTISSPanel = new Score.ScoreTISSPanel(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);


        }

        /// <summary>
        /// 注册消息
        /// </summary>
        private void Register()
        {
            
        }
    }
}
