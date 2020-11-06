using System;
using MedicalSystem.Anes.Client.FrameWork;


namespace MedicalSystem.Anes.Client.AppPC
{
    /// <summary>
    /// 加载等待框
    /// </summary>
    public partial class WaitingFrm : BaseForm
    {
        public WaitingFrm()
        {
            InitializeComponent();
            this.IsMainForm = true;
        }


        private const int dMilliseconds = 500;
        /// <summary>
        /// 延迟半秒钟关闭，如果这过程中有继续访问的，则不关闭窗口。
        /// </summary>
        private System.Windows.Forms.Timer t = null;
        private DateTime Duration = DateTime.Now;
        /// <summary>
        /// 对于大量连续请求，需要延迟一会。
        /// </summary>
        public void WaitForHide()
        {
            Duration = DateTime.Now;
            isHide = false;
        }
        private bool isHide = false;

        private void LoadingFrm_Load(object sender, EventArgs e)
        {
            t = new System.Windows.Forms.Timer() { Interval = 50 };
            t.Tick += (s, d) =>
            {
                if (!isHide && (DateTime.Now - Duration).Milliseconds > dMilliseconds)
                {
                    isHide = true;
                    this.Hide();
                }
            };
            t.Start();

        }

        private static WaitingFrm _waitingFrm = null;
        private static WaitingFrm waitingFrm
        {
            get
            {
                if (_waitingFrm == null)
                    _waitingFrm = new WaitingFrm();
                return _waitingFrm;
            }
            set { _waitingFrm = value; }
        }

        /// <summary>
        /// 等待请求的数量
        /// </summary>
        private static int watingRequestNums = 0;

        public static void ShowWaiting()
        {
            watingRequestNums++;
            waitingFrm.Show();
            waitingFrm.Activate();
        }

        public static void HideWaiting()
        {
            watingRequestNums--;
            if (watingRequestNums <= 0)
            {
                watingRequestNums = 0;
                waitingFrm.WaitForHide();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (t != null)
            {
                t.Dispose();
                t = null;
            }
            base.OnClosed(e);
        }


    }
}
