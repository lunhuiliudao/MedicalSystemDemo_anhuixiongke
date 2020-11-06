

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:25:33
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedMtrlImportDetail
	/// </summary>
	
	public class DALMedMtrlImportDetail
	{
		private static readonly string MED_MTRL_IMPORT_DETAIL_Insert_SQL = "INSERT INTO MED_MTRL_IMPORT_DETAIL (DOCUMENT_NO,ITEM_NO,MTRL_CODE,MTRL_SPEC,UNITS,BATCH_NO,ANTISEPSIS_DATE,EXPIRE_DATE,SUPPLIER_ID,PURCHASE_PRICE,DISCOUNT,RETAIL_PRICE,PACKAGE_SPEC,QUANTITY,PACKAGE_UNITS,SUB_PACKAGE_1,SUB_PACKAGE_UNITS_1,SUB_PACKAGE_SPEC_1,SUB_PACKAGE_2,SUB_PACKAGE_UNITS_2,SUB_PACKAGE_SPEC_2,INVOICE_NO,INVOICE_DATE) values (@DocumentNo,@ItemNo,@MtrlCode,@MtrlSpec,@Units,@BatchNo,@AntisepsisDate,@ExpireDate,@SupplierId,@PurchasePrice,@Discount,@RetailPrice,@PackageSpec,@Quantity,@PackageUnits,@SubPackage1,@SubPackageUnits1,@SubPackageSpec1,@SubPackage2,@SubPackageUnits2,@SubPackageSpec2,@InvoiceNo,@InvoiceDate)";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Update_SQL = "UPDATE MED_MTRL_IMPORT_DETAIL SET DOCUMENT_NO=@DocumentNo,ITEM_NO=@ItemNo,MTRL_CODE=@MtrlCode,MTRL_SPEC=@MtrlSpec,UNITS=@Units,BATCH_NO=@BatchNo,ANTISEPSIS_DATE=@AntisepsisDate,EXPIRE_DATE=@ExpireDate,SUPPLIER_ID=@SupplierId,PURCHASE_PRICE=@PurchasePrice,DISCOUNT=@Discount,RETAIL_PRICE=@RetailPrice,PACKAGE_SPEC=@PackageSpec,QUANTITY=@Quantity,PACKAGE_UNITS=@PackageUnits,SUB_PACKAGE_1=@SubPackage1,SUB_PACKAGE_UNITS_1=@SubPackageUnits1,SUB_PACKAGE_SPEC_1=@SubPackageSpec1,SUB_PACKAGE_2=@SubPackage2,SUB_PACKAGE_UNITS_2=@SubPackageUnits2,SUB_PACKAGE_SPEC_2=@SubPackageSpec2,INVOICE_NO=@InvoiceNo,INVOICE_DATE=@InvoiceDate WHERE  DOCUMENT_NO=@DocumentNo AND ITEM_NO=@ItemNo";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Delete_SQL = "DELETE MED_MTRL_IMPORT_DETAIL WHERE  DOCUMENT_NO=@DocumentNo AND ITEM_NO=@ItemNo";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Select_SQL = "SELECT DOCUMENT_NO,ITEM_NO,MTRL_CODE,MTRL_SPEC,UNITS,BATCH_NO,ANTISEPSIS_DATE,EXPIRE_DATE,SUPPLIER_ID,PURCHASE_PRICE,DISCOUNT,RETAIL_PRICE,PACKAGE_SPEC,QUANTITY,PACKAGE_UNITS,SUB_PACKAGE_1,SUB_PACKAGE_UNITS_1,SUB_PACKAGE_SPEC_1,SUB_PACKAGE_2,SUB_PACKAGE_UNITS_2,SUB_PACKAGE_SPEC_2,INVOICE_NO,INVOICE_DATE FROM MED_MTRL_IMPORT_DETAIL where  DOCUMENT_NO=@DocumentNo AND ITEM_NO=@ItemNo";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Select_ALL_SQL = "SELECT DOCUMENT_NO,ITEM_NO,MTRL_CODE,MTRL_SPEC,UNITS,BATCH_NO,ANTISEPSIS_DATE,EXPIRE_DATE,SUPPLIER_ID,PURCHASE_PRICE,DISCOUNT,RETAIL_PRICE,PACKAGE_SPEC,QUANTITY,PACKAGE_UNITS,SUB_PACKAGE_1,SUB_PACKAGE_UNITS_1,SUB_PACKAGE_SPEC_1,SUB_PACKAGE_2,SUB_PACKAGE_UNITS_2,SUB_PACKAGE_SPEC_2,INVOICE_NO,INVOICE_DATE FROM MED_MTRL_IMPORT_DETAIL";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Insert = "INSERT INTO MED_MTRL_IMPORT_DETAIL (DOCUMENT_NO,ITEM_NO,MTRL_CODE,MTRL_SPEC,UNITS,BATCH_NO,ANTISEPSIS_DATE,EXPIRE_DATE,SUPPLIER_ID,PURCHASE_PRICE,DISCOUNT,RETAIL_PRICE,PACKAGE_SPEC,QUANTITY,PACKAGE_UNITS,SUB_PACKAGE_1,SUB_PACKAGE_UNITS_1,SUB_PACKAGE_SPEC_1,SUB_PACKAGE_2,SUB_PACKAGE_UNITS_2,SUB_PACKAGE_SPEC_2,INVOICE_NO,INVOICE_DATE) values (:DocumentNo,:ItemNo,:MtrlCode,:MtrlSpec,:Units,:BatchNo,:AntisepsisDate,:ExpireDate,:SupplierId,:PurchasePrice,:Discount,:RetailPrice,:PackageSpec,:Quantity,:PackageUnits,:SubPackage1,:SubPackageUnits1,:SubPackageSpec1,:SubPackage2,:SubPackageUnits2,:SubPackageSpec2,:InvoiceNo,:InvoiceDate)";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Update = "UPDATE MED_MTRL_IMPORT_DETAIL SET DOCUMENT_NO=:DocumentNo,ITEM_NO=:ItemNo,MTRL_CODE=:MtrlCode,MTRL_SPEC=:MtrlSpec,UNITS=:Units,BATCH_NO=:BatchNo,ANTISEPSIS_DATE=:AntisepsisDate,EXPIRE_DATE=:ExpireDate,SUPPLIER_ID=:SupplierId,PURCHASE_PRICE=:PurchasePrice,DISCOUNT=:Discount,RETAIL_PRICE=:RetailPrice,PACKAGE_SPEC=:PackageSpec,QUANTITY=:Quantity,PACKAGE_UNITS=:PackageUnits,SUB_PACKAGE_1=:SubPackage1,SUB_PACKAGE_UNITS_1=:SubPackageUnits1,SUB_PACKAGE_SPEC_1=:SubPackageSpec1,SUB_PACKAGE_2=:SubPackage2,SUB_PACKAGE_UNITS_2=:SubPackageUnits2,SUB_PACKAGE_SPEC_2=:SubPackageSpec2,INVOICE_NO=:InvoiceNo,INVOICE_DATE=:InvoiceDate WHERE  DOCUMENT_NO=:DocumentNo AND ITEM_NO=:ItemNo";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Delete = "DELETE MED_MTRL_IMPORT_DETAIL WHERE  DOCUMENT_NO=:DocumentNo AND ITEM_NO=:ItemNo";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Select = "SELECT DOCUMENT_NO,ITEM_NO,MTRL_CODE,MTRL_SPEC,UNITS,BATCH_NO,ANTISEPSIS_DATE,EXPIRE_DATE,SUPPLIER_ID,PURCHASE_PRICE,DISCOUNT,RETAIL_PRICE,PACKAGE_SPEC,QUANTITY,PACKAGE_UNITS,SUB_PACKAGE_1,SUB_PACKAGE_UNITS_1,SUB_PACKAGE_SPEC_1,SUB_PACKAGE_2,SUB_PACKAGE_UNITS_2,SUB_PACKAGE_SPEC_2,INVOICE_NO,INVOICE_DATE FROM MED_MTRL_IMPORT_DETAIL where  DOCUMENT_NO=:DocumentNo AND ITEM_NO=:ItemNo";
		private static readonly string MED_MTRL_IMPORT_DETAIL_Select_ALL = "SELECT DOCUMENT_NO,ITEM_NO,MTRL_CODE,MTRL_SPEC,UNITS,BATCH_NO,ANTISEPSIS_DATE,EXPIRE_DATE,SUPPLIER_ID,PURCHASE_PRICE,DISCOUNT,RETAIL_PRICE,PACKAGE_SPEC,QUANTITY,PACKAGE_UNITS,SUB_PACKAGE_1,SUB_PACKAGE_UNITS_1,SUB_PACKAGE_SPEC_1,SUB_PACKAGE_2,SUB_PACKAGE_UNITS_2,SUB_PACKAGE_SPEC_2,INVOICE_NO,INVOICE_DATE FROM MED_MTRL_IMPORT_DETAIL";
		
		public DALMedMtrlImportDetail ()
		{
		}
		
		#region [获取参数SQL]
		/// <summary>
		///获取参数MedMtrlImportDetail SQL
		/// </summary>
		public static SqlParameter[] GetParameterSQL(string sqlParms)
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlImportDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
							new SqlParameter("@MtrlCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlSpec",SqlDbType.VarChar),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@BatchNo",SqlDbType.VarChar),
							new SqlParameter("@AntisepsisDate",SqlDbType.DateTime),
							new SqlParameter("@ExpireDate",SqlDbType.DateTime),
							new SqlParameter("@SupplierId",SqlDbType.VarChar),
							new SqlParameter("@PurchasePrice",SqlDbType.Decimal),
							new SqlParameter("@Discount",SqlDbType.Decimal),
							new SqlParameter("@RetailPrice",SqlDbType.Decimal),
							new SqlParameter("@PackageSpec",SqlDbType.VarChar),
							new SqlParameter("@Quantity",SqlDbType.Decimal),
							new SqlParameter("@PackageUnits",SqlDbType.VarChar),
							new SqlParameter("@SubPackage1",SqlDbType.Decimal),
							new SqlParameter("@SubPackageUnits1",SqlDbType.VarChar),
							new SqlParameter("@SubPackageSpec1",SqlDbType.VarChar),
							new SqlParameter("@SubPackage2",SqlDbType.Decimal),
							new SqlParameter("@SubPackageUnits2",SqlDbType.VarChar),
							new SqlParameter("@SubPackageSpec2",SqlDbType.VarChar),
							new SqlParameter("@InvoiceNo",SqlDbType.VarChar),
							new SqlParameter("@InvoiceDate",SqlDbType.DateTime),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlImportDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
							new SqlParameter("@MtrlCode",SqlDbType.VarChar),
							new SqlParameter("@MtrlSpec",SqlDbType.VarChar),
							new SqlParameter("@Units",SqlDbType.VarChar),
							new SqlParameter("@BatchNo",SqlDbType.VarChar),
							new SqlParameter("@AntisepsisDate",SqlDbType.DateTime),
							new SqlParameter("@ExpireDate",SqlDbType.DateTime),
							new SqlParameter("@SupplierId",SqlDbType.VarChar),
							new SqlParameter("@PurchasePrice",SqlDbType.Decimal),
							new SqlParameter("@Discount",SqlDbType.Decimal),
							new SqlParameter("@RetailPrice",SqlDbType.Decimal),
							new SqlParameter("@PackageSpec",SqlDbType.VarChar),
							new SqlParameter("@Quantity",SqlDbType.Decimal),
							new SqlParameter("@PackageUnits",SqlDbType.VarChar),
							new SqlParameter("@SubPackage1",SqlDbType.Decimal),
							new SqlParameter("@SubPackageUnits1",SqlDbType.VarChar),
							new SqlParameter("@SubPackageSpec1",SqlDbType.VarChar),
							new SqlParameter("@SubPackage2",SqlDbType.Decimal),
							new SqlParameter("@SubPackageUnits2",SqlDbType.VarChar),
							new SqlParameter("@SubPackageSpec2",SqlDbType.VarChar),
							new SqlParameter("@InvoiceNo",SqlDbType.VarChar),
							new SqlParameter("@InvoiceDate",SqlDbType.DateTime),
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlImportDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "SelectMedMtrlImportDetail")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@DocumentNo",SqlDbType.VarChar),
							new SqlParameter("@ItemNo",SqlDbType.Decimal),
                    };
                }
            	SqlHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedMtrlImportDetail 
		///Insert Table MED_MTRL_IMPORT_DETAIL
		/// </summary>
		public int InsertMedMtrlImportDetailSQL(MedMtrlImportDetail model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneInert = GetParameterSQL("InsertMedMtrlImportDetail");
					if (model.DocumentNo != null)
						oneInert[0].Value = model.DocumentNo;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.ItemNo.ToString() != null)
						oneInert[1].Value = model.ItemNo;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MtrlCode != null)
						oneInert[2].Value = model.MtrlCode;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneInert[3].Value = model.MtrlSpec;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Units != null)
						oneInert[4].Value = model.Units;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.BatchNo != null)
						oneInert[5].Value = model.BatchNo;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.AntisepsisDate != null)
						oneInert[6].Value = model.AntisepsisDate;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.ExpireDate != null)
						oneInert[7].Value = model.ExpireDate;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.SupplierId != null)
						oneInert[8].Value = model.SupplierId;
					else
						oneInert[8].Value = DBNull.Value;
                    if (model.PurchasePrice.ToString() != null)
						oneInert[9].Value = model.PurchasePrice;
					else
						oneInert[9].Value = DBNull.Value;
                    if (model.Discount.ToString() != null)
						oneInert[10].Value = model.Discount;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.RetailPrice.ToString() != null)
						oneInert[11].Value = model.RetailPrice;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.PackageSpec != null)
						oneInert[12].Value = model.PackageSpec;
					else
						oneInert[12].Value = DBNull.Value;
                    if (model.Quantity.ToString() != null)
						oneInert[13].Value = model.Quantity;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.PackageUnits != null)
						oneInert[14].Value = model.PackageUnits;
					else
						oneInert[14].Value = DBNull.Value;
                    if (model.SubPackage1.ToString() != null)
						oneInert[15].Value = model.SubPackage1;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.SubPackageUnits1 != null)
						oneInert[16].Value = model.SubPackageUnits1;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.SubPackageSpec1 != null)
						oneInert[17].Value = model.SubPackageSpec1;
					else
						oneInert[17].Value = DBNull.Value;
                    if (model.SubPackage2.ToString() != null)
						oneInert[18].Value = model.SubPackage2;
					else
						oneInert[18].Value = DBNull.Value;
					if (model.SubPackageUnits2 != null)
						oneInert[19].Value = model.SubPackageUnits2;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.SubPackageSpec2 != null)
						oneInert[20].Value = model.SubPackageSpec2;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.InvoiceNo != null)
						oneInert[21].Value = model.InvoiceNo;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.InvoiceDate != null)
						oneInert[22].Value = model.InvoiceDate;
					else
						oneInert[22].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_IMPORT_DETAIL_Insert_SQL, oneInert);
			}
		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedMtrlImportDetail 
		///Update Table     MED_MTRL_IMPORT_DETAIL
		/// </summary>
		public int UpdateMedMtrlImportDetailSQL(MedMtrlImportDetail model)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedMtrlImportDetail");
					if (model.DocumentNo != null)
						oneUpdate[0].Value = model.DocumentNo;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.ItemNo.ToString() != null)
						oneUpdate[1].Value = model.ItemNo;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MtrlCode != null)
						oneUpdate[2].Value = model.MtrlCode;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneUpdate[3].Value = model.MtrlSpec;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Units != null)
						oneUpdate[4].Value = model.Units;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.BatchNo != null)
						oneUpdate[5].Value = model.BatchNo;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.AntisepsisDate != null)
						oneUpdate[6].Value = model.AntisepsisDate;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.ExpireDate != null)
						oneUpdate[7].Value = model.ExpireDate;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.SupplierId != null)
						oneUpdate[8].Value = model.SupplierId;
					else
						oneUpdate[8].Value = DBNull.Value;
                    if (model.PurchasePrice.ToString() != null)
						oneUpdate[9].Value = model.PurchasePrice;
					else
						oneUpdate[9].Value = DBNull.Value;
                    if (model.Discount.ToString() != null)
						oneUpdate[10].Value = model.Discount;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.RetailPrice.ToString() != null)
						oneUpdate[11].Value = model.RetailPrice;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.PackageSpec != null)
						oneUpdate[12].Value = model.PackageSpec;
					else
						oneUpdate[12].Value = DBNull.Value;
                    if (model.Quantity.ToString() != null)
						oneUpdate[13].Value = model.Quantity;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.PackageUnits != null)
						oneUpdate[14].Value = model.PackageUnits;
					else
						oneUpdate[14].Value = DBNull.Value;
                    if (model.SubPackage1.ToString() != null)
						oneUpdate[15].Value = model.SubPackage1;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.SubPackageUnits1 != null)
						oneUpdate[16].Value = model.SubPackageUnits1;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.SubPackageSpec1 != null)
						oneUpdate[17].Value = model.SubPackageSpec1;
					else
						oneUpdate[17].Value = DBNull.Value;
                    if (model.SubPackage2.ToString() != null)
						oneUpdate[18].Value = model.SubPackage2;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.SubPackageUnits2 != null)
						oneUpdate[19].Value = model.SubPackageUnits2;
					else
						oneUpdate[19].Value = DBNull.Value;
					if (model.SubPackageSpec2 != null)
						oneUpdate[20].Value = model.SubPackageSpec2;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.InvoiceNo != null)
						oneUpdate[21].Value = model.InvoiceNo;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.InvoiceDate != null)
						oneUpdate[22].Value = model.InvoiceDate;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.DocumentNo != null)
						oneUpdate[23].Value =model.DocumentNo;
					else
						oneUpdate[23].Value = DBNull.Value;
                    if (model.ItemNo.ToString() != null)
						oneUpdate[24].Value =model.ItemNo;
					else
						oneUpdate[24].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_IMPORT_DETAIL_Update_SQL, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedMtrlImportDetail 
		///Delete Table MED_MTRL_IMPORT_DETAIL by (string DOCUMENT_NO,decimal ITEM_NO)
		/// </summary>
		public int DeleteMedMtrlImportDetailSQL(string DOCUMENT_NO,decimal ITEM_NO)
		{
			using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
				SqlParameter[] oneDelete = GetParameterSQL("DeleteMedMtrlImportDetail");
					if (DOCUMENT_NO != null)
						oneDelete[0].Value =DOCUMENT_NO;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (ITEM_NO.ToString() != null)
						oneDelete[1].Value =ITEM_NO;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_MTRL_IMPORT_DETAIL_Delete_SQL, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedMtrlImportDetail 
		///select Table MED_MTRL_IMPORT_DETAIL by (string DOCUMENT_NO,decimal ITEM_NO)
		/// </summary>
		public MedMtrlImportDetail  SelectMedMtrlImportDetailSQL(string DOCUMENT_NO,decimal ITEM_NO)
		{
			MedMtrlImportDetail model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedMtrlImportDetail");
				parameterValues[0].Value=DOCUMENT_NO;
				parameterValues[1].Value=ITEM_NO;
			using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_DETAIL_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlImportDetail();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.BatchNo = oleReader["BATCH_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AntisepsisDate = DateTime.Parse(oleReader["ANTISEPSIS_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ExpireDate = DateTime.Parse(oleReader["EXPIRE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PurchasePrice = decimal.Parse(oleReader["PURCHASE_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Discount = decimal.Parse(oleReader["DISCOUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.RetailPrice = decimal.Parse(oleReader["RETAIL_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.PackageSpec = oleReader["PACKAGE_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.PackageUnits = oleReader["PACKAGE_UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SubPackage1 = decimal.Parse(oleReader["SUB_PACKAGE_1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SubPackageUnits1 = oleReader["SUB_PACKAGE_UNITS_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.SubPackageSpec1 = oleReader["SUB_PACKAGE_SPEC_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.SubPackage2 = decimal.Parse(oleReader["SUB_PACKAGE_2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.SubPackageUnits2 = oleReader["SUB_PACKAGE_UNITS_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.SubPackageSpec2 = oleReader["SUB_PACKAGE_SPEC_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.InvoiceNo = oleReader["INVOICE_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.InvoiceDate = DateTime.Parse(oleReader["INVOICE_DATE"].ToString().Trim()) ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedMtrlImportDetail> SelectMedMtrlImportDetailListSQL()
		{
			List<MedMtrlImportDetail> modelList = new List<MedMtrlImportDetail>();
		    using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_DETAIL_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlImportDetail model = new MedMtrlImportDetail();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.BatchNo = oleReader["BATCH_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AntisepsisDate = DateTime.Parse(oleReader["ANTISEPSIS_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ExpireDate = DateTime.Parse(oleReader["EXPIRE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PurchasePrice = decimal.Parse(oleReader["PURCHASE_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Discount = decimal.Parse(oleReader["DISCOUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.RetailPrice = decimal.Parse(oleReader["RETAIL_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.PackageSpec = oleReader["PACKAGE_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.PackageUnits = oleReader["PACKAGE_UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SubPackage1 = decimal.Parse(oleReader["SUB_PACKAGE_1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SubPackageUnits1 = oleReader["SUB_PACKAGE_UNITS_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.SubPackageSpec1 = oleReader["SUB_PACKAGE_SPEC_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.SubPackage2 = decimal.Parse(oleReader["SUB_PACKAGE_2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.SubPackageUnits2 = oleReader["SUB_PACKAGE_UNITS_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.SubPackageSpec2 = oleReader["SUB_PACKAGE_SPEC_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.InvoiceNo = oleReader["INVOICE_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.InvoiceDate = DateTime.Parse(oleReader["INVOICE_DATE"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
		#region [获取参数]
		/// <summary>
		///获取参数MedMtrlImportDetail
		/// </summary>
		public static OracleParameter[] GetParameter(string sqlParms)
		{
			OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedMtrlImportDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
							new OracleParameter(":MtrlCode",OracleType.VarChar),
							new OracleParameter(":MtrlSpec",OracleType.VarChar),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":BatchNo",OracleType.VarChar),
							new OracleParameter(":AntisepsisDate",OracleType.DateTime),
							new OracleParameter(":ExpireDate",OracleType.DateTime),
							new OracleParameter(":SupplierId",OracleType.VarChar),
							new OracleParameter(":PurchasePrice",OracleType.Number),
							new OracleParameter(":Discount",OracleType.Number),
							new OracleParameter(":RetailPrice",OracleType.Number),
							new OracleParameter(":PackageSpec",OracleType.VarChar),
							new OracleParameter(":Quantity",OracleType.Number),
							new OracleParameter(":PackageUnits",OracleType.VarChar),
							new OracleParameter(":SubPackage1",OracleType.Number),
							new OracleParameter(":SubPackageUnits1",OracleType.VarChar),
							new OracleParameter(":SubPackageSpec1",OracleType.VarChar),
							new OracleParameter(":SubPackage2",OracleType.Number),
							new OracleParameter(":SubPackageUnits2",OracleType.VarChar),
							new OracleParameter(":SubPackageSpec2",OracleType.VarChar),
							new OracleParameter(":InvoiceNo",OracleType.VarChar),
							new OracleParameter(":InvoiceDate",OracleType.DateTime),
                    };
                }
				else if (sqlParms == "UpdateMedMtrlImportDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
							new OracleParameter(":MtrlCode",OracleType.VarChar),
							new OracleParameter(":MtrlSpec",OracleType.VarChar),
							new OracleParameter(":Units",OracleType.VarChar),
							new OracleParameter(":BatchNo",OracleType.VarChar),
							new OracleParameter(":AntisepsisDate",OracleType.DateTime),
							new OracleParameter(":ExpireDate",OracleType.DateTime),
							new OracleParameter(":SupplierId",OracleType.VarChar),
							new OracleParameter(":PurchasePrice",OracleType.Number),
							new OracleParameter(":Discount",OracleType.Number),
							new OracleParameter(":RetailPrice",OracleType.Number),
							new OracleParameter(":PackageSpec",OracleType.VarChar),
							new OracleParameter(":Quantity",OracleType.Number),
							new OracleParameter(":PackageUnits",OracleType.VarChar),
							new OracleParameter(":SubPackage1",OracleType.Number),
							new OracleParameter(":SubPackageUnits1",OracleType.VarChar),
							new OracleParameter(":SubPackageSpec1",OracleType.VarChar),
							new OracleParameter(":SubPackage2",OracleType.Number),
							new OracleParameter(":SubPackageUnits2",OracleType.VarChar),
							new OracleParameter(":SubPackageSpec2",OracleType.VarChar),
							new OracleParameter(":InvoiceNo",OracleType.VarChar),
							new OracleParameter(":InvoiceDate",OracleType.DateTime),
							new OracleParameter(":DocumentNo",SqlDbType.VarChar),
							new OracleParameter(":ItemNo",SqlDbType.Decimal),
                    };
                }
				else if(sqlParms == "DeleteMedMtrlImportDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
                    };
                }
				else if(sqlParms == "SelectMedMtrlImportDetail")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":DocumentNo",OracleType.VarChar),
							new OracleParameter(":ItemNo",OracleType.Number),
                    };
                }
            	OracleHelper.CacheParameters(sqlParms, parms);
			}
			return parms;
		}
		#endregion
		#region [添加一条记录]
		/// <summary>
		///Add    model  MedMtrlImportDetail 
		///Insert Table MED_MTRL_IMPORT_DETAIL
		/// </summary>
		public int InsertMedMtrlImportDetail(MedMtrlImportDetail model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneInert = GetParameter("InsertMedMtrlImportDetail");
					if (model.DocumentNo != null)
						oneInert[0].Value = model.DocumentNo;
					else
						oneInert[0].Value = DBNull.Value;
                    if (model.ItemNo.ToString() != null)
						oneInert[1].Value = model.ItemNo;
					else
						oneInert[1].Value = DBNull.Value;
					if (model.MtrlCode != null)
						oneInert[2].Value = model.MtrlCode;
					else
						oneInert[2].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneInert[3].Value = model.MtrlSpec;
					else
						oneInert[3].Value = DBNull.Value;
					if (model.Units != null)
						oneInert[4].Value = model.Units;
					else
						oneInert[4].Value = DBNull.Value;
					if (model.BatchNo != null)
						oneInert[5].Value = model.BatchNo;
					else
						oneInert[5].Value = DBNull.Value;
					if (model.AntisepsisDate != null)
						oneInert[6].Value = model.AntisepsisDate;
					else
						oneInert[6].Value = DBNull.Value;
					if (model.ExpireDate != null)
						oneInert[7].Value = model.ExpireDate;
					else
						oneInert[7].Value = DBNull.Value;
					if (model.SupplierId != null)
						oneInert[8].Value = model.SupplierId;
					else
						oneInert[8].Value = DBNull.Value;
                    if (model.PurchasePrice.ToString() != null)
						oneInert[9].Value = model.PurchasePrice;
					else
						oneInert[9].Value = DBNull.Value;
                    if (model.Discount.ToString() != null)
						oneInert[10].Value = model.Discount;
					else
						oneInert[10].Value = DBNull.Value;
                    if (model.RetailPrice.ToString() != null)
						oneInert[11].Value = model.RetailPrice;
					else
						oneInert[11].Value = DBNull.Value;
					if (model.PackageSpec != null)
						oneInert[12].Value = model.PackageSpec;
					else
						oneInert[12].Value = DBNull.Value;
                    if (model.Quantity.ToString() != null)
						oneInert[13].Value = model.Quantity;
					else
						oneInert[13].Value = DBNull.Value;
					if (model.PackageUnits != null)
						oneInert[14].Value = model.PackageUnits;
					else
						oneInert[14].Value = DBNull.Value;
                    if (model.SubPackage1.ToString() != null)
						oneInert[15].Value = model.SubPackage1;
					else
						oneInert[15].Value = DBNull.Value;
					if (model.SubPackageUnits1 != null)
						oneInert[16].Value = model.SubPackageUnits1;
					else
						oneInert[16].Value = DBNull.Value;
					if (model.SubPackageSpec1 != null)
						oneInert[17].Value = model.SubPackageSpec1;
					else
						oneInert[17].Value = DBNull.Value;
                    if (model.SubPackage2.ToString() != null)
						oneInert[18].Value = model.SubPackage2;
					else
						oneInert[18].Value = DBNull.Value;
					if (model.SubPackageUnits2 != null)
						oneInert[19].Value = model.SubPackageUnits2;
					else
						oneInert[19].Value = DBNull.Value;
					if (model.SubPackageSpec2 != null)
						oneInert[20].Value = model.SubPackageSpec2;
					else
						oneInert[20].Value = DBNull.Value;
					if (model.InvoiceNo != null)
						oneInert[21].Value = model.InvoiceNo;
					else
						oneInert[21].Value = DBNull.Value;
					if (model.InvoiceDate != null)
						oneInert[22].Value = model.InvoiceDate;
					else
						oneInert[22].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_IMPORT_DETAIL_Insert, oneInert);
			}
		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedMtrlImportDetail 
		///Update Table     MED_MTRL_IMPORT_DETAIL
		/// </summary>
		public int UpdateMedMtrlImportDetail(MedMtrlImportDetail model)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneUpdate = GetParameter("UpdateMedMtrlImportDetail");
					if (model.DocumentNo != null)
						oneUpdate[0].Value = model.DocumentNo;
					else
						oneUpdate[0].Value = DBNull.Value;
                    if (model.ItemNo.ToString() != null)
						oneUpdate[1].Value = model.ItemNo;
					else
						oneUpdate[1].Value = DBNull.Value;
					if (model.MtrlCode != null)
						oneUpdate[2].Value = model.MtrlCode;
					else
						oneUpdate[2].Value = DBNull.Value;
					if (model.MtrlSpec != null)
						oneUpdate[3].Value = model.MtrlSpec;
					else
						oneUpdate[3].Value = DBNull.Value;
					if (model.Units != null)
						oneUpdate[4].Value = model.Units;
					else
						oneUpdate[4].Value = DBNull.Value;
					if (model.BatchNo != null)
						oneUpdate[5].Value = model.BatchNo;
					else
						oneUpdate[5].Value = DBNull.Value;
					if (model.AntisepsisDate != null)
						oneUpdate[6].Value = model.AntisepsisDate;
					else
						oneUpdate[6].Value = DBNull.Value;
					if (model.ExpireDate != null)
						oneUpdate[7].Value = model.ExpireDate;
					else
						oneUpdate[7].Value = DBNull.Value;
					if (model.SupplierId != null)
						oneUpdate[8].Value = model.SupplierId;
					else
						oneUpdate[8].Value = DBNull.Value;
                    if (model.PurchasePrice.ToString() != null)
						oneUpdate[9].Value = model.PurchasePrice;
					else
						oneUpdate[9].Value = DBNull.Value;
                    if (model.Discount.ToString() != null)
						oneUpdate[10].Value = model.Discount;
					else
						oneUpdate[10].Value = DBNull.Value;
                    if (model.RetailPrice.ToString() != null)
						oneUpdate[11].Value = model.RetailPrice;
					else
						oneUpdate[11].Value = DBNull.Value;
					if (model.PackageSpec != null)
						oneUpdate[12].Value = model.PackageSpec;
					else
						oneUpdate[12].Value = DBNull.Value;
                    if (model.Quantity.ToString() != null)
						oneUpdate[13].Value = model.Quantity;
					else
						oneUpdate[13].Value = DBNull.Value;
					if (model.PackageUnits != null)
						oneUpdate[14].Value = model.PackageUnits;
					else
						oneUpdate[14].Value = DBNull.Value;
                    if (model.SubPackage1.ToString() != null)
						oneUpdate[15].Value = model.SubPackage1;
					else
						oneUpdate[15].Value = DBNull.Value;
					if (model.SubPackageUnits1 != null)
						oneUpdate[16].Value = model.SubPackageUnits1;
					else
						oneUpdate[16].Value = DBNull.Value;
					if (model.SubPackageSpec1 != null)
						oneUpdate[17].Value = model.SubPackageSpec1;
					else
						oneUpdate[17].Value = DBNull.Value;
                    if (model.SubPackage2.ToString() != null)
						oneUpdate[18].Value = model.SubPackage2;
					else
						oneUpdate[18].Value = DBNull.Value;
					if (model.SubPackageUnits2 != null)
						oneUpdate[19].Value = model.SubPackageUnits2;
					else
						oneUpdate[19].Value = DBNull.Value;
					if (model.SubPackageSpec2 != null)
						oneUpdate[20].Value = model.SubPackageSpec2;
					else
						oneUpdate[20].Value = DBNull.Value;
					if (model.InvoiceNo != null)
						oneUpdate[21].Value = model.InvoiceNo;
					else
						oneUpdate[21].Value = DBNull.Value;
					if (model.InvoiceDate != null)
						oneUpdate[22].Value = model.InvoiceDate;
					else
						oneUpdate[22].Value = DBNull.Value;
					if (model.DocumentNo != null)
						oneUpdate[23].Value =model.DocumentNo;
					else
						oneUpdate[23].Value = DBNull.Value;
                    if (model.ItemNo.ToString() != null)
						oneUpdate[24].Value =model.ItemNo;
					else
						oneUpdate[24].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_IMPORT_DETAIL_Update, oneUpdate);
			}
		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedMtrlImportDetail 
		///Delete Table MED_MTRL_IMPORT_DETAIL by (string DOCUMENT_NO,decimal ITEM_NO)
		/// </summary>
		public int DeleteMedMtrlImportDetail(string DOCUMENT_NO,decimal ITEM_NO)
		{
			using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
				OracleParameter[] oneDelete = GetParameter("DeleteMedMtrlImportDetail");
					if (DOCUMENT_NO != null)
						oneDelete[0].Value =DOCUMENT_NO;
					else
						oneDelete[0].Value = DBNull.Value;
                    if (ITEM_NO.ToString() != null)
						oneDelete[1].Value =ITEM_NO;
					else
						oneDelete[1].Value = DBNull.Value;
			
				return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_MTRL_IMPORT_DETAIL_Delete, oneDelete);
			}
		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedMtrlImportDetail 
		///select Table MED_MTRL_IMPORT_DETAIL by (string DOCUMENT_NO,decimal ITEM_NO)
		/// </summary>
		public MedMtrlImportDetail  SelectMedMtrlImportDetail(string DOCUMENT_NO,decimal ITEM_NO)
		{
			MedMtrlImportDetail model;
			OracleParameter[] parameterValues = GetParameter("SelectMedMtrlImportDetail");
				parameterValues[0].Value=DOCUMENT_NO;
				parameterValues[1].Value=ITEM_NO;
			using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_DETAIL_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedMtrlImportDetail();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.BatchNo = oleReader["BATCH_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AntisepsisDate = DateTime.Parse(oleReader["ANTISEPSIS_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ExpireDate = DateTime.Parse(oleReader["EXPIRE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PurchasePrice = decimal.Parse(oleReader["PURCHASE_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Discount = decimal.Parse(oleReader["DISCOUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.RetailPrice = decimal.Parse(oleReader["RETAIL_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.PackageSpec = oleReader["PACKAGE_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.PackageUnits = oleReader["PACKAGE_UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SubPackage1 = decimal.Parse(oleReader["SUB_PACKAGE_1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SubPackageUnits1 = oleReader["SUB_PACKAGE_UNITS_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.SubPackageSpec1 = oleReader["SUB_PACKAGE_SPEC_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.SubPackage2 = decimal.Parse(oleReader["SUB_PACKAGE_2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.SubPackageUnits2 = oleReader["SUB_PACKAGE_UNITS_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.SubPackageSpec2 = oleReader["SUB_PACKAGE_SPEC_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.InvoiceNo = oleReader["INVOICE_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.InvoiceDate = DateTime.Parse(oleReader["INVOICE_DATE"].ToString().Trim()) ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
		#region  [获取所有记录]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedMtrlImportDetail> SelectMedMtrlImportDetailList()
		{
			List<MedMtrlImportDetail> modelList = new List<MedMtrlImportDetail>();
		    using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_MTRL_IMPORT_DETAIL_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedMtrlImportDetail model = new MedMtrlImportDetail();
						if (!oleReader.IsDBNull(0))
						{
							model.DocumentNo = oleReader["DOCUMENT_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.ItemNo = decimal.Parse(oleReader["ITEM_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.MtrlCode = oleReader["MTRL_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.MtrlSpec = oleReader["MTRL_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(4))
						{
							model.Units = oleReader["UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(5))
						{
							model.BatchNo = oleReader["BATCH_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(6))
						{
							model.AntisepsisDate = DateTime.Parse(oleReader["ANTISEPSIS_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(7))
						{
							model.ExpireDate = DateTime.Parse(oleReader["EXPIRE_DATE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(8))
						{
							model.SupplierId = oleReader["SUPPLIER_ID"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(9))
						{
							model.PurchasePrice = decimal.Parse(oleReader["PURCHASE_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(10))
						{
							model.Discount = decimal.Parse(oleReader["DISCOUNT"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(11))
						{
							model.RetailPrice = decimal.Parse(oleReader["RETAIL_PRICE"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(12))
						{
							model.PackageSpec = oleReader["PACKAGE_SPEC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(13))
						{
							model.Quantity = decimal.Parse(oleReader["QUANTITY"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(14))
						{
							model.PackageUnits = oleReader["PACKAGE_UNITS"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(15))
						{
							model.SubPackage1 = decimal.Parse(oleReader["SUB_PACKAGE_1"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(16))
						{
							model.SubPackageUnits1 = oleReader["SUB_PACKAGE_UNITS_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(17))
						{
							model.SubPackageSpec1 = oleReader["SUB_PACKAGE_SPEC_1"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(18))
						{
							model.SubPackage2 = decimal.Parse(oleReader["SUB_PACKAGE_2"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(19))
						{
							model.SubPackageUnits2 = oleReader["SUB_PACKAGE_UNITS_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(20))
						{
							model.SubPackageSpec2 = oleReader["SUB_PACKAGE_SPEC_2"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(21))
						{
							model.InvoiceNo = oleReader["INVOICE_NO"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(22))
						{
							model.InvoiceDate = DateTime.Parse(oleReader["INVOICE_DATE"].ToString().Trim()) ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
