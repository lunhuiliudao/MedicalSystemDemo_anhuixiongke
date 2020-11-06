using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using DevExpress.XtraEditors;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Designer;
using System.IO;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Documents
{
    public class UIElementPrinter
    {
        public event PrintEventHandler EndPrint;  // 打印结束
        protected BaseDoc _baseDoc;
        private int _top = 0;
        protected int _pageIndex = 0;
        protected int _pageHeight = 1150;
        private int _pageIndexBeforePrint = -1;
        private string _pageName;
        private PaperSize _paperSize = null;
        protected float _pagePrintHeight = 1050;
        protected bool _pageFromHeight = false;
        protected int _defaultMargin = 20;
        protected System.Drawing.Imaging.Metafile _printMetafile;
        protected Graphics.EnumerateMetafileProc metafileDelegate = null;

        public BaseDoc BaseDocument
        {
            get
            {
                return _baseDoc;
            }
            set
            {
                _baseDoc = value;
            }
        }

        public UIElementPrinter(BaseDoc baseDoc, PaperSize paperSize) : this(baseDoc, paperSize, false, null) { }
        public UIElementPrinter(BaseDoc baseDoc, PaperSize paperSize, bool pageFromHeight, string pageName)
        {
            _baseDoc = baseDoc;
            _pageName = pageName;
            _paperSize = paperSize;
            _pageFromHeight = pageFromHeight;
        }

        public UIElementPrinter(BaseDoc baseDoc, PaperSize paperSize, bool pageFromHeight, float printHeight, string pageName)
            : this(baseDoc, paperSize, pageFromHeight, pageName)
        {
            _pagePrintHeight = printHeight;
        }

        public bool Print()
        {
            _pageIndexBeforePrint = _pageIndex;
            try
            {
                using (PrintDocument doc = new PrintDocument())
                {
                    if (_baseDoc.GetReportViewerProperties != null)
                    {
                        doc.DefaultPageSettings.Landscape = _baseDoc.GetReportViewerProperties.Landscape;
                        doc.PrinterSettings.DefaultPageSettings.Landscape = _baseDoc.GetReportViewerProperties.Landscape;
                    }
                    List<MPanel> panels = _baseDoc.ReportViewer.GetControls<MPanel>();
                    if (panels != null && panels.Count > 0)
                    {
                        foreach (MPanel panel in panels)
                        {
                            if (panel.Name.Equals("DocTitle"))
                            {
                                panel.Dock = DockStyle.Top;
                                panel.Visible = true;
                            }
                        }
                    }
                    List<MedVitalSignGraph> vitalGraphs = _baseDoc.ReportViewer.GetControls<MedVitalSignGraph>();
                    if (vitalGraphs != null && vitalGraphs.Count > 0)
                    {
                        foreach (MedVitalSignGraph vitalGraph in vitalGraphs)
                        {
                            vitalGraph.BackHeight = vitalGraph.Height;
                            vitalGraph.IsPrinting = true;
                            vitalGraph.Height = (int)(vitalGraph.Height / vitalGraph.ShowZoomRate);
                        }
                    }
                    List<MedGridGraph> gridGraphs = _baseDoc.ReportViewer.GetControls<MedGridGraph>();
                    if (gridGraphs != null && gridGraphs.Count > 0)
                    {
                        foreach (MedGridGraph gridGraph in gridGraphs)
                        {
                            gridGraph.BackHeight = gridGraph.Height;
                            gridGraph.IsPrinting = true;
                            gridGraph.Height = (int)(gridGraph.Height / gridGraph.ShowZoomRate);
                        }
                    }
                    List<MedAnesSheetDetails> anesSheetDetails = _baseDoc.ReportViewer.GetControls<MedAnesSheetDetails>();
                    if (anesSheetDetails != null && anesSheetDetails.Count > 0)
                    {
                        foreach (MedAnesSheetDetails anesSheetDetail in anesSheetDetails)
                        {
                            anesSheetDetail.BackHeight = anesSheetDetail.Height;
                            anesSheetDetail.Height = (int)(anesSheetDetail.Height / anesSheetDetail.ShowZoomRate);
                        }
                    }
                    List<MedDrugGraph> drugGraphs = _baseDoc.ReportViewer.GetControls<MedDrugGraph>();
                    if (drugGraphs != null && drugGraphs.Count > 0)
                    {
                        foreach (MedDrugGraph drugGraph in drugGraphs)
                        {
                            drugGraph.IsPrinting = true;
                            drugGraph.BackHeight = drugGraph.Height;
                            drugGraph.Height = (int)(drugGraph.Height / drugGraph.ShowZoomRate);
                        }
                    }
                    doc.BeginPrint += new PrintEventHandler(doc_BeginPrint);
                    doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                    doc.EndPrint += new PrintEventHandler(doc_EndPrint);

                    //PageSetupDialog pageSetupDialog = new PageSetupDialog();
                    if (!string.IsNullOrEmpty(_pageName))
                    {
                        foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                        {
                            if (ps.PaperName.ToLower().Equals(_pageName.ToLower()))
                            {

                                doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                                doc.DefaultPageSettings.PaperSize = ps;
                                break;
                            }
                        }
                    }
                    else if (_paperSize != null)
                    {
                        doc.PrinterSettings.DefaultPageSettings.PaperSize = _paperSize;
                        doc.DefaultPageSettings.PaperSize = _paperSize;
                    }
                    else
                    {
                        PaperSize ps = new PaperSize();
                        ps.Width = (int)(19.5 / 2.54 * 100);
                        ps.Height = (int)(27.0 / 2.54 * 100);

                        doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                        doc.DefaultPageSettings.PaperSize = ps;
                    }

                    int lefttMarginOffset = 0;
                    int rightMarginOffset = 0;
                    int topMarginOffset = 0;
                    int bottomMarginOffset = 0;
                    ReportViewProperties rp = _baseDoc.GetReportViewerProperties;
                    if (rp != null)
                    {
                        lefttMarginOffset = rp.LeftMarginOffset;
                        rightMarginOffset = rp.RightMarginOffset;
                        topMarginOffset = rp.TopMarginOffset;
                        bottomMarginOffset = rp.BottomMarginOffset;
                    }

                    lefttMarginOffset = (_defaultMargin + lefttMarginOffset) < 0 ? 0 : _defaultMargin + lefttMarginOffset;
                    rightMarginOffset = (_defaultMargin + rightMarginOffset) < 0 ? 0 : _defaultMargin + rightMarginOffset;
                    topMarginOffset = (_defaultMargin + topMarginOffset) < 0 ? 0 : _defaultMargin + topMarginOffset;
                    bottomMarginOffset = (_defaultMargin + bottomMarginOffset) < 0 ? 0 : _defaultMargin + bottomMarginOffset;

                    doc.DefaultPageSettings.Margins = new Margins(lefttMarginOffset, rightMarginOffset, topMarginOffset, bottomMarginOffset);

                    //pageSetupDialog.Document = doc;
                    //pageSetupDialog.AllowMargins = true;

                    //PrintPreviewDialog preview = new PrintPreviewDialog();
                    //preview.WindowState = FormWindowState.Maximized;
                    //preview.Document = doc;
                    //preview.TopLevel = true;
                    //preview.Activate();
                    //preview.Show();

                    // 测试用 打印对话框
                    //PrintDialog printDialog = new PrintDialog();
                    //printDialog.Document = doc;
                    //printDialog.UseEXDialog = true;
                    //printDialog.ShowDialog();
                    // 测试 end
                    doc.Print();

                    if (drugGraphs != null && drugGraphs.Count > 0)
                    {
                        foreach (MedDrugGraph drugGraph in drugGraphs)
                        {
                            drugGraph.IsPrinting = false;
                            drugGraph.Height = drugGraph.BackHeight;
                        }
                    }
                    if (vitalGraphs != null && vitalGraphs.Count > 0)
                    {
                        foreach (MedVitalSignGraph vitalGraph in vitalGraphs)
                        {
                            vitalGraph.Height = vitalGraph.BackHeight;
                            vitalGraph.IsPrinting = false;
                        }
                    }
                    if (gridGraphs != null && gridGraphs.Count > 0)
                    {
                        foreach (MedGridGraph gridGraph in gridGraphs)
                        {
                            gridGraph.Height = gridGraph.BackHeight;
                            gridGraph.IsPrinting = false;
                        }
                    }
                    if (anesSheetDetails != null && anesSheetDetails.Count > 0)
                    {
                        foreach (MedAnesSheetDetails anesSheetDetail in anesSheetDetails)
                        {
                            anesSheetDetail.Height = anesSheetDetail.BackHeight;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        protected bool MetafileCallback(EmfPlusRecordType recordType, int flags, int dataSize, IntPtr data, PlayRecordCallback callbackData)
        {
            byte[] dataArray = null;
            if (data != IntPtr.Zero)
            {
                // Copy the unmanaged record to a managed byte buffer 
                // that can be used by PlayRecord.
                dataArray = new byte[dataSize];
                Marshal.Copy(data, dataArray, 0, dataSize);
            }
            _printMetafile.PlayRecord(recordType, flags, dataSize, dataArray);
            return true;
        }

        /// <summary>
        /// 打印当前页
        /// </summary>
        public void PrintCurrentPage()
        {
            _pageIndexBeforePrint = _baseDoc.PagerSetting.CurrentPageIndex;
            _pageIndex = _baseDoc.PagerSetting.CurrentPageIndex;
            PLPrint();
        }

        public bool PLPrint()
        {
            _pageIndexBeforePrint = _pageIndex;
            try
            {
                using (PrintDocument doc = new PrintDocument())
                {
                    if (_baseDoc.GetReportViewerProperties != null)
                    {
                        doc.DefaultPageSettings.Landscape = _baseDoc.GetReportViewerProperties.Landscape;
                    }

                    List<MPanel> panels = _baseDoc.ReportViewer.GetControls<MPanel>();
                    if (panels != null && panels.Count > 0)
                    {
                        foreach (MPanel panel in panels)
                        {
                            if (panel.Name.Equals("DocTitle"))
                            {
                                panel.Dock = DockStyle.Top;
                                panel.Visible = true;
                            }
                        }
                    }

                    List<MedVitalSignGraph> vitalGraphs = _baseDoc.ReportViewer.GetControls<MedVitalSignGraph>();
                    if (vitalGraphs != null && vitalGraphs.Count > 0)
                    {
                        foreach (MedVitalSignGraph vitalGraph in vitalGraphs)
                        {
                            vitalGraph.BackHeight = vitalGraph.Height;
                            vitalGraph.IsPrinting = true;
                            vitalGraph.Height = (int)(vitalGraph.Height / vitalGraph.ShowZoomRate);
                        }
                    }

                    List<MedGridGraph> gridGraphs = _baseDoc.ReportViewer.GetControls<MedGridGraph>();
                    if (gridGraphs != null && gridGraphs.Count > 0)
                    {
                        foreach (MedGridGraph gridGraph in gridGraphs)
                        {
                            gridGraph.BackHeight = gridGraph.Height;
                            gridGraph.IsPrinting = true;
                            gridGraph.Height = (int)(gridGraph.Height / gridGraph.ShowZoomRate);
                        }
                    }

                    List<MedAnesSheetDetails> anesSheetDetails = _baseDoc.ReportViewer.GetControls<MedAnesSheetDetails>();
                    if (anesSheetDetails != null && anesSheetDetails.Count > 0)
                    {
                        foreach (MedAnesSheetDetails anesSheetDetail in anesSheetDetails)
                        {
                            anesSheetDetail.BackHeight = anesSheetDetail.Height;
                            anesSheetDetail.Height = (int)(anesSheetDetail.Height / anesSheetDetail.ShowZoomRate);
                        }
                    }

                    List<MedDrugGraph> drugGraphs = _baseDoc.ReportViewer.GetControls<MedDrugGraph>();
                    if (drugGraphs != null && drugGraphs.Count > 0)
                    {
                        foreach (MedDrugGraph drugGraph in drugGraphs)
                        {
                            drugGraph.IsPrinting = true;
                            drugGraph.BackHeight = drugGraph.Height;
                            drugGraph.Height = (int)(drugGraph.Height / drugGraph.ShowZoomRate);
                        }
                    }

                    doc.BeginPrint += new PrintEventHandler(doc_BeginPrint);
                    doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                    doc.EndPrint += new PrintEventHandler(doc_EndPrint);

                    if (!string.IsNullOrEmpty(_pageName))
                    {
                        foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                        {
                            if (ps.PaperName.ToLower().Equals(_pageName.ToLower()))
                            {

                                doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                                doc.DefaultPageSettings.PaperSize = ps;
                                break;
                            }
                        }
                    }
                    else if (_paperSize != null)
                    {
                        doc.PrinterSettings.DefaultPageSettings.PaperSize = _paperSize;
                        doc.DefaultPageSettings.PaperSize = _paperSize;
                    }
                    else
                    {
                        PaperSize ps = new PaperSize();
                        ps.Width = (int)(19.5 / 2.54 * 100);
                        ps.Height = (int)(27.0 / 2.54 * 100);

                        doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                        doc.DefaultPageSettings.PaperSize = ps;
                    }

                    int lefttMarginOffset = 0;
                    int rightMarginOffset = 0;
                    int topMarginOffset = 0;
                    int bottomMarginOffset = 0;
                    ReportViewProperties rp = _baseDoc.GetReportViewerProperties;
                    if (rp != null)
                    {
                        lefttMarginOffset = rp.LeftMarginOffset;
                        rightMarginOffset = rp.RightMarginOffset;
                        topMarginOffset = rp.TopMarginOffset;
                        bottomMarginOffset = rp.BottomMarginOffset;
                    }

                    lefttMarginOffset = (_defaultMargin + lefttMarginOffset) < 0 ? 0 : _defaultMargin + lefttMarginOffset;
                    rightMarginOffset = (_defaultMargin + rightMarginOffset) < 0 ? 0 : _defaultMargin + rightMarginOffset;
                    topMarginOffset = (_defaultMargin + topMarginOffset) < 0 ? 0 : _defaultMargin + topMarginOffset;
                    bottomMarginOffset = (_defaultMargin + bottomMarginOffset) < 0 ? 0 : _defaultMargin + bottomMarginOffset;

                    doc.DefaultPageSettings.Margins = new Margins(lefttMarginOffset, rightMarginOffset, topMarginOffset, bottomMarginOffset);
                    doc.Print();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        public bool Print(bool bMultiPrint)
        {
            _pageIndexBeforePrint = _pageIndex;
            try
            {
                using (PrintDocument doc = new PrintDocument())
                {
                    if (_baseDoc.GetReportViewerProperties != null)
                    {
                        doc.DefaultPageSettings.Landscape = _baseDoc.GetReportViewerProperties.Landscape;
                    }
                    List<MPanel> panels = _baseDoc.ReportViewer.GetControls<MPanel>();
                    if (panels != null && panels.Count > 0)
                    {
                        foreach (MPanel panel in panels)
                        {
                            if (panel.Name.Equals("DocTitle"))
                            {
                                panel.Dock = DockStyle.Top;
                                panel.Visible = true;
                            }
                        }
                    }
                    List<MedVitalSignGraph> vitalGraphs = _baseDoc.ReportViewer.GetControls<MedVitalSignGraph>();
                    if (vitalGraphs != null && vitalGraphs.Count > 0)
                    {
                        foreach (MedVitalSignGraph vitalGraph in vitalGraphs)
                        {
                            vitalGraph.BackHeight = vitalGraph.Height;
                            vitalGraph.IsPrinting = true;
                            vitalGraph.Height = (int)(vitalGraph.Height / vitalGraph.ShowZoomRate);
                        }
                    }
                    List<MedGridGraph> gridGraphs = _baseDoc.ReportViewer.GetControls<MedGridGraph>();
                    if (gridGraphs != null && gridGraphs.Count > 0)
                    {
                        foreach (MedGridGraph gridGraph in gridGraphs)
                        {
                            gridGraph.BackHeight = gridGraph.Height;
                            gridGraph.IsPrinting = true;
                            gridGraph.Height = (int)(gridGraph.Height / gridGraph.ShowZoomRate);
                        }
                    }
                    List<MedAnesSheetDetails> anesSheetDetails = _baseDoc.ReportViewer.GetControls<MedAnesSheetDetails>();
                    if (anesSheetDetails != null && anesSheetDetails.Count > 0)
                    {
                        foreach (MedAnesSheetDetails anesSheetDetail in anesSheetDetails)
                        {
                            anesSheetDetail.BackHeight = anesSheetDetail.Height;
                            anesSheetDetail.Height = (int)(anesSheetDetail.Height / anesSheetDetail.ShowZoomRate);
                        }
                    }
                    List<MedDrugGraph> drugGraphs = _baseDoc.ReportViewer.GetControls<MedDrugGraph>();
                    if (drugGraphs != null && drugGraphs.Count > 0)
                    {
                        foreach (MedDrugGraph drugGraph in drugGraphs)
                        {
                            drugGraph.IsPrinting = true;
                            drugGraph.BackHeight = drugGraph.Height;
                            drugGraph.Height = (int)(drugGraph.Height / drugGraph.ShowZoomRate);
                        }
                    }
                    doc.BeginPrint += new PrintEventHandler(doc_BeginPrint);
                    doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                    doc.EndPrint += new PrintEventHandler(doc_EndPrint);

                    //PageSetupDialog pageSetupDialog = new PageSetupDialog();
                    if (!string.IsNullOrEmpty(_pageName))
                    {
                        foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                        {
                            if (ps.PaperName.ToLower().Equals(_pageName.ToLower()))
                            {

                                doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                                doc.DefaultPageSettings.PaperSize = ps;
                                break;
                            }
                        }
                    }
                    else if (_paperSize != null)
                    {
                        doc.PrinterSettings.DefaultPageSettings.PaperSize = _paperSize;
                        doc.DefaultPageSettings.PaperSize = _paperSize;
                    }
                    else
                    {
                        PaperSize ps = new PaperSize();
                        ps.Width = (int)(19.5 / 2.54 * 100);
                        ps.Height = (int)(27.0 / 2.54 * 100);

                        doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                        doc.DefaultPageSettings.PaperSize = ps;
                    }

                    int lefttMarginOffset = 0;
                    int rightMarginOffset = 0;
                    int topMarginOffset = 0;
                    int bottomMarginOffset = 0;
                    ReportViewProperties rp = _baseDoc.GetReportViewerProperties;
                    if (rp != null)
                    {
                        lefttMarginOffset = rp.LeftMarginOffset;
                        rightMarginOffset = rp.RightMarginOffset;
                        topMarginOffset = rp.TopMarginOffset;
                        bottomMarginOffset = rp.BottomMarginOffset;
                    }

                    lefttMarginOffset = (_defaultMargin + lefttMarginOffset) < 0 ? 0 : _defaultMargin + lefttMarginOffset;
                    rightMarginOffset = (_defaultMargin + rightMarginOffset) < 0 ? 0 : _defaultMargin + rightMarginOffset;
                    topMarginOffset = (_defaultMargin + topMarginOffset) < 0 ? 0 : _defaultMargin + topMarginOffset;
                    bottomMarginOffset = (_defaultMargin + bottomMarginOffset) < 0 ? 0 : _defaultMargin + bottomMarginOffset;

                    doc.DefaultPageSettings.Margins = new Margins(lefttMarginOffset, rightMarginOffset, topMarginOffset, bottomMarginOffset);

                    //pageSetupDialog.Document = doc;
                    //pageSetupDialog.AllowMargins = true;
                    //PrintPreviewDialog preview = new PrintPreviewDialog();
                    if (bMultiPrint)
                    {
                        doc.Print();
                    }
                    else
                    {
                        //preview.WindowState = FormWindowState.Maximized;
                        //preview.Document = doc;
                        //preview.ShowDialog();
                    }
                    if (drugGraphs != null && drugGraphs.Count > 0)
                    {
                        foreach (MedDrugGraph drugGraph in drugGraphs)
                        {
                            drugGraph.IsPrinting = false;
                            drugGraph.Height = drugGraph.BackHeight;
                        }
                    }
                    if (vitalGraphs != null && vitalGraphs.Count > 0)
                    {
                        foreach (MedVitalSignGraph vitalGraph in vitalGraphs)
                        {
                            vitalGraph.Height = vitalGraph.BackHeight;
                            vitalGraph.IsPrinting = false;
                        }
                    }
                    if (gridGraphs != null && gridGraphs.Count > 0)
                    {
                        foreach (MedGridGraph gridGraph in gridGraphs)
                        {
                            gridGraph.Height = gridGraph.BackHeight;
                            gridGraph.IsPrinting = false;
                        }
                    }
                    if (anesSheetDetails != null && anesSheetDetails.Count > 0)
                    {
                        foreach (MedAnesSheetDetails anesSheetDetail in anesSheetDetails)
                        {
                            anesSheetDetail.Height = anesSheetDetail.BackHeight;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        protected virtual void doc_EndPrint(object sender, PrintEventArgs e)
        {
            List<Panel> pnls = _baseDoc.ReportViewer.GetControls<Panel>();
            if (pnls.Count > 0)
            {
                pnls[0].Top = _top;
            }
            _pageIndex = _pageIndexBeforePrint;

            if (!e.Cancel && EndPrint != null)
            {
                EndPrint(sender, e);
            }

            _baseDoc.IsPrintEnd = true;
        }


        protected virtual void doc_BeginPrint(object sender, PrintEventArgs e)
        {
            List<Panel> pnls = _baseDoc.ReportViewer.GetControls<Panel>();
            if (pnls.Count > 0)
            {
                _top = pnls[0].Top;
                pnls[0].Top = 0;
            }
            _pageIndex = 0;

        }

        protected PointF GetControlLocation(Control control)
        {
            Control calControl = control;
            if (!calControl.Visible)
            {
                return new PointF(1.2345f, 1.2345f);
            }
            int x = calControl.Location.X;
            int y = calControl.Location.Y;
            while (calControl.Parent != null && !(calControl.Parent is MedReportView))
            {
                calControl = calControl.Parent;
                if (!calControl.Visible)
                {
                    return new PointF(1.2345f, 1.2345f);
                }
                x += calControl.Location.X;
                y += calControl.Location.Y;
            }

            return new PointF(x, y);
        }

        protected virtual bool ShowPage()
        {
            return true;
        }
        //protected float _printScale = 1.0f;

        //图片缩放委托
        //protected Graphics.EnumerateMetafileProc metafileDelegate = null;
        //protected System.Drawing.Imaging.Metafile _printMetafile;
        //private Point destPoint = new Point(0, 0);//wmf 左上角绘制

        /// <summary>
        /// 计算打印区域
        /// </summary>
        /// <returns></returns>
        protected Rectangle GetPrintRect()
        {
            List<Control> controls = _baseDoc.ReportViewer.GetControls<Control>();
            Rectangle rect = new Rectangle(1, 1, 1, 1);
            foreach (Control control in controls)
            {
                Panel panel = null;

                if (control is Panel && control.Parent is MedReportView)
                {

                    panel = (Panel)control;
                    if (rect == new Rectangle(1, 1, 1, 1))
                    {
                        rect = panel.Bounds;
                    }
                    else
                    {
                        if (rect.X > panel.Bounds.X)
                        {
                            rect.X = panel.Bounds.X;
                        }

                        if (rect.Y > panel.Bounds.Y)
                        {
                            rect.Y = panel.Bounds.Y;
                        }

                        if (rect.Width + rect.X < panel.Bounds.X + panel.Bounds.Width)
                        {
                            rect.Width = panel.Bounds.X + panel.Bounds.Width - rect.X;
                        }


                        if (rect.Bottom < panel.Bounds.Bottom)
                        {
                            rect.Height = panel.Bounds.Bottom - rect.Y;
                        }

                    }
                }

            }
            return rect;
        }

        /// <summary>
        /// 打印各组件
        /// </summary>
        /// <param name="g">打印GDI接口</param>
        private void PrintControls(Graphics g)
        {
            float topOffSet = 0;
            if (_pageFromHeight)
            {
                topOffSet = -_pageIndex * _pagePrintHeight;
            }
            float leftOffSet = 0;
            float topOffSet1 = 0;

            float top = 0;
            List<Control> controls = _baseDoc.ReportViewer.GetControls<Control>();
            foreach (Control control in controls)
            {
                if (control is IPrintable)
                {
                    PointF point = GetControlLocation(control);
                    if (point.X != 1.2345f && point.Y != 1.2345f && (!_pageFromHeight || (point.Y > _pageIndex * _pagePrintHeight && point.Y < (_pageIndex + 1) * _pagePrintHeight)))
                    {
                        IPrintable printable = (IPrintable)control;
                        if (!printable.NoPrint)
                        {
                            if (point.Y > top)
                            {
                                printable.Draw(g, leftOffSet + point.X, topOffSet + topOffSet1 + point.Y);
                            }
                            else
                            {
                                printable.Draw(g, leftOffSet + point.X, topOffSet + point.Y);
                            }
                        }
                    }
                }
                else if (control is Panel && (control as Panel).BorderStyle == BorderStyle.FixedSingle)
                {
                    PointF point = GetControlLocation(control);
                    if (point.X != 1.2345f && point.Y != 1.2345f && (!_pageFromHeight || (point.Y > _pageIndex * _pagePrintHeight && point.Y < (_pageIndex + 1) * _pagePrintHeight)))
                    //if (point.X != 1.2345f && point.Y != 1.2345f)
                    {
                        g.DrawRectangle(new Pen(control.ForeColor), new Rectangle((int)(leftOffSet + point.X), (int)(topOffSet + topOffSet1 + point.Y), control.Width - 1, control.Height));

                    }
                }
            }
            foreach (Control control in controls)
            {
                if (control is IPrintable && control.Parent.Name.ToLower() == "panelfuji")
                {
                    PointF point = GetControlLocation(control);
                    if (point.X != 1.2345f && point.Y != 1.2345f)
                    {
                        IPrintable printable = (IPrintable)control;
                        if (!printable.NoPrint)
                        {
                            if (point.Y > top)
                            {
                                printable.Draw(g, leftOffSet + point.X, topOffSet + topOffSet1 + point.Y);
                            }
                            else
                            {
                                printable.Draw(g, leftOffSet + point.X, topOffSet + point.Y);
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// 生产当前页面Metafile
        /// </summary>
        /// <returns></returns>
        public Metafile GetPageMetafile()
        {
            //创建 metafile
            using (MemoryStream ms = new MemoryStream())
            {
                using (Graphics grfx = _baseDoc.CreateGraphics())
                {
                    IntPtr ipHdc = grfx.GetHdc();
                    Metafile metafile = new Metafile(ms, ipHdc);

                    grfx.ReleaseHdc(ipHdc);
                    using (Graphics imageG = Graphics.FromImage(metafile))
                    {

                        //绘图
                        PrintControls(imageG);
                        if (_pageFromHeight)
                        { _pageIndex++; }
                        if (_baseDoc != null)
                        {
                            _baseDoc.CustomDraw(imageG);
                        }

                        //绘图结束
                        imageG.Save();
                    }

                    return metafile;
                }
            }
        }

        protected virtual void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //如果允许分页,则打印每一页,否则则打印当前页
            if (_baseDoc.PagerSetting.AllowPage && _baseDoc.PagerSetting.PagerDesc.Count > 0)
            {
                _baseDoc.PageIndexChanged(_baseDoc.PagerSetting.PagerDesc[_pageIndex].PageIndex,
                                          _baseDoc.PagerSetting.PagerDesc[_pageIndex].IsMain,
                                          _baseDoc.DataSource);
            }

            //创建 metafile
            using (var _printMetafile = GetPageMetafile())
            {
                //_printMetafile.Save(@"E:\printMetafile0.emf");
                //调整边距
                Rectangle rect = new Rectangle(0, 0, _printMetafile.Width, _printMetafile.Height);

                double widthZoom = 1;
                double heightZoom = 1;

                double widthSize = (e.MarginBounds.Width);
                double heightSize = (e.MarginBounds.Height);
                if (widthSize < rect.Width)
                {
                    widthZoom = widthSize / rect.Width;
                }
                //纵轴缩小
                if (heightSize < rect.Height)
                {
                    heightZoom = heightSize / rect.Height;
                }
                double zoom = (widthZoom < heightZoom) ? widthZoom : heightZoom;
                Rectangle zoomRect = new Rectangle(rect.X, rect.Y, (int)(rect.Width * zoom), (int)(rect.Height * zoom));

                using (MemoryStream mStream = new MemoryStream())
                {
                    using (Graphics ggggg = _baseDoc.CreateGraphics())
                    {
                        IntPtr ipHdctemp = ggggg.GetHdc();
                        using (Metafile mf = new Metafile(mStream, ipHdctemp))
                        {
                            using (Graphics gMf = Graphics.FromImage(mf))
                            {
                                gMf.DrawImage(_printMetafile, zoomRect);
                                gMf.Save();
                            }
                            //_printMetafile = mf;
                            //_printMetafile.Save(@"E:\printMetafile1.emf");
                            //metafileDelegate = new Graphics.EnumerateMetafileProc(MetafileCallback);

                            //开始正式打印
                            PrintPage(mf, e, zoomRect.Width, zoomRect.Height);
                            //metafileDelegate = null;
                        }
                        ggggg.ReleaseHdc(ipHdctemp);
                    }
                }
            }

            _pageIndex++;

            if (_pageFromHeight)
            {
                Rectangle r = GetPrintRect();
                if ((_pageIndex) * _pagePrintHeight < r.Height)
                {
                    e.HasMorePages = true;
                }
            }
            else
            {
                if (_baseDoc.PagerSetting.AllowPage && _pageIndex < _baseDoc.PagerSetting.TotalPageCount)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    _pageIndex = 0;
                }
            }
        }

        protected virtual void PrintPage(System.Drawing.Imaging.Metafile file, PrintPageEventArgs e, int width, int height)
        {
            e.Graphics.DrawImage(file, new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, width, height));
        }

        /// <summary>
        /// 此方法用于上传PDF
        /// </summary>
        /// <param name="fileName">PDF文件全路径</param>
        /// <returns></returns>
        public bool ExportPDF3(string fileName)
        {
            _pageIndexBeforePrint = _pageIndex;
            try
            {
                using (PrintDocument doc = new PrintDocument())
                {
                    if (_baseDoc.GetReportViewerProperties != null)
                    {
                        doc.DefaultPageSettings.Landscape = _baseDoc.GetReportViewerProperties.Landscape;
                    }
                    List<MPanel> panels = _baseDoc.ReportViewer.GetControls<MPanel>();
                    if (panels != null && panels.Count > 0)
                    {
                        foreach (MPanel panel in panels)
                        {
                            if (panel.Name.Equals("DocTitle"))
                            {
                                panel.Dock = DockStyle.Top;
                                panel.Visible = true;
                            }
                        }
                    }
                    List<MedVitalSignGraph> vitalGraphs = _baseDoc.ReportViewer.GetControls<MedVitalSignGraph>();
                    if (vitalGraphs != null && vitalGraphs.Count > 0)
                    {
                        foreach (MedVitalSignGraph vitalGraph in vitalGraphs)
                        {
                            vitalGraph.BackHeight = vitalGraph.Height;
                            vitalGraph.IsPrinting = true;
                            vitalGraph.Height = (int)(vitalGraph.Height / vitalGraph.ShowZoomRate);
                        }
                    }
                    List<MedGridGraph> gridGraphs = _baseDoc.ReportViewer.GetControls<MedGridGraph>();
                    if (gridGraphs != null && gridGraphs.Count > 0)
                    {
                        foreach (MedGridGraph gridGraph in gridGraphs)
                        {
                            gridGraph.BackHeight = gridGraph.Height;
                            gridGraph.IsPrinting = true;
                            gridGraph.Height = (int)(gridGraph.Height / gridGraph.ShowZoomRate);
                        }
                    }
                    List<MedAnesSheetDetails> anesSheetDetails = _baseDoc.ReportViewer.GetControls<MedAnesSheetDetails>();
                    if (anesSheetDetails != null && anesSheetDetails.Count > 0)
                    {
                        foreach (MedAnesSheetDetails anesSheetDetail in anesSheetDetails)
                        {
                            anesSheetDetail.BackHeight = anesSheetDetail.Height;
                            anesSheetDetail.Height = (int)(anesSheetDetail.Height / anesSheetDetail.ShowZoomRate);
                        }
                    }
                    List<MedDrugGraph> drugGraphs = _baseDoc.ReportViewer.GetControls<MedDrugGraph>();
                    if (drugGraphs != null && drugGraphs.Count > 0)
                    {
                        foreach (MedDrugGraph drugGraph in drugGraphs)
                        {
                            drugGraph.IsPrinting = true;
                            drugGraph.BackHeight = drugGraph.Height;
                            drugGraph.Height = (int)(drugGraph.Height / drugGraph.ShowZoomRate);
                        }
                    }
                    doc.BeginPrint += new PrintEventHandler(doc_BeginPrint);
                    doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                    doc.EndPrint += new PrintEventHandler(doc_EndPrint);

                    //PageSetupDialog pageSetupDialog = new PageSetupDialog();
                    if (!string.IsNullOrEmpty(_pageName))
                    {
                        foreach (PaperSize ps in doc.PrinterSettings.PaperSizes)
                        {
                            if (ps.PaperName.ToLower().Equals(_pageName.ToLower()))
                            {

                                doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                                doc.DefaultPageSettings.PaperSize = ps;
                                break;
                            }
                        }
                    }
                    else if (_paperSize != null)
                    {
                        doc.PrinterSettings.DefaultPageSettings.PaperSize = _paperSize;
                        doc.DefaultPageSettings.PaperSize = _paperSize;
                    }
                    else
                    {
                        PaperSize ps = new PaperSize();
                        ps.Width = (int)(19.5 / 2.54 * 100);
                        ps.Height = (int)(27.0 / 2.54 * 100);

                        doc.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                        doc.DefaultPageSettings.PaperSize = ps;
                    }

                    int lefttMarginOffset = 0;
                    int rightMarginOffset = 0;
                    int topMarginOffset = 0;
                    int bottomMarginOffset = 0;
                    ReportViewProperties rp = _baseDoc.GetReportViewerProperties;
                    if (rp != null)
                    {
                        lefttMarginOffset = rp.LeftMarginOffset;
                        rightMarginOffset = rp.RightMarginOffset;
                        topMarginOffset = rp.TopMarginOffset;
                        bottomMarginOffset = rp.BottomMarginOffset;
                    }

                    lefttMarginOffset = (_defaultMargin + lefttMarginOffset) < 0 ? 0 : _defaultMargin + lefttMarginOffset;
                    rightMarginOffset = (_defaultMargin + rightMarginOffset) < 0 ? 0 : _defaultMargin + rightMarginOffset;
                    topMarginOffset = (_defaultMargin + topMarginOffset) < 0 ? 0 : _defaultMargin + topMarginOffset;
                    bottomMarginOffset = (_defaultMargin + bottomMarginOffset) < 0 ? 0 : _defaultMargin + bottomMarginOffset;

                    doc.DefaultPageSettings.Margins = new Margins(lefttMarginOffset, rightMarginOffset, topMarginOffset, bottomMarginOffset);

                    // 固定使用"Microsoft Print to PDF"打印机，生成路径：fileName
                    doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    doc.PrinterSettings.PrintToFile = true;
                    doc.PrinterSettings.PrintFileName = fileName;
                    doc.Print();
                }
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Services.Logger.Error("Microsoft Print to PDF出现异常", ex);
                return false;
            }
            return true;
        }

        // Metafile 回调
        //private bool MetafileCallback(EmfPlusRecordType recordType, int flags, int dataSize, IntPtr data, PlayRecordCallback callbackData)
        //{
        //    byte[] dataArray = null;
        //    if (data != IntPtr.Zero)
        //    {
        //        // Copy the unmanaged record to a managed byte buffer 
        //        // that can be used by PlayRecord.
        //        dataArray = new byte[dataSize];
        //        Marshal.Copy(data, dataArray, 0, dataSize);
        //    }
        //    _printMetafile.PlayRecord(recordType, flags, dataSize, dataArray);
        //    return true;
        //}

    }
}
