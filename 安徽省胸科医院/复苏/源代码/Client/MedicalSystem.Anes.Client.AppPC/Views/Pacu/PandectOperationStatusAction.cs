using MedicalSystem.Anes.Client.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.AppPC
{
    public class PandectOperationStatusAction : IPatientStatusAction
    {
        #region IPatientStatusAction 成员

        public object Excute(OperationStatus operationStatus)
        {
            string roomNo = "";
            OperationRoomPandect operationRoomPandect = new OperationRoomPandect("1", true);
            DialogHostFormPC dialogHostForm = new DialogHostFormPC("选择床位 - 双击空床位完成选择", 1000, 600);
            dialogHostForm.Child = operationRoomPandect;
            dialogHostForm.ShowDialog();
            if (operationRoomPandect.SelectedOperationRoomContent != null)
            {
                roomNo = operationRoomPandect.SelectedOperationRoomContent.OperRoomKey;
            }

            return roomNo;
        }

        #endregion
    }
}
