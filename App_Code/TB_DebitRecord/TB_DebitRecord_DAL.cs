using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_DebitRecord
{
    public class TB_DebitRecord_DAL
	{
        public TB_DebitRecord Add
			(TB_DebitRecord tB_DebitRecord)
		{
				string sql ="INSERT INTO TB_DebitRecord (DebitForumId, DebitAccountId, DebitTime, DebitCredits, StipulatePaymentTime, RealityPaymentTime, BorrowingRate)  output inserted.Id VALUES (@DebitForumId, @DebitAccountId, @DebitTime, @DebitCredits, @StipulatePaymentTime, @RealityPaymentTime, @BorrowingRate)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@DebitForumId", ToDBValue(tB_DebitRecord.DebitForumId)),
						new SqlParameter("@DebitAccountId", ToDBValue(tB_DebitRecord.DebitAccountId)),
						new SqlParameter("@DebitTime", ToDBValue(tB_DebitRecord.DebitTime)),
						new SqlParameter("@DebitCredits", ToDBValue(tB_DebitRecord.DebitCredits)),
						new SqlParameter("@StipulatePaymentTime", ToDBValue(tB_DebitRecord.StipulatePaymentTime)),
						new SqlParameter("@RealityPaymentTime", ToDBValue(tB_DebitRecord.RealityPaymentTime)),
						new SqlParameter("@BorrowingRate", ToDBValue(tB_DebitRecord.BorrowingRate)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_DebitRecord WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_DebitRecord tB_DebitRecord)
        {
            string sql =
                "UPDATE TB_DebitRecord " +
                "SET " +
			" DebitForumId = @DebitForumId" 
                +", DebitAccountId = @DebitAccountId" 
                +", DebitTime = @DebitTime" 
                +", DebitCredits = @DebitCredits" 
                +", StipulatePaymentTime = @StipulatePaymentTime" 
                +", RealityPaymentTime = @RealityPaymentTime" 
                +", BorrowingRate = @BorrowingRate" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_DebitRecord.Id)
					,new SqlParameter("@DebitForumId", ToDBValue(tB_DebitRecord.DebitForumId))
					,new SqlParameter("@DebitAccountId", ToDBValue(tB_DebitRecord.DebitAccountId))
					,new SqlParameter("@DebitTime", ToDBValue(tB_DebitRecord.DebitTime))
					,new SqlParameter("@DebitCredits", ToDBValue(tB_DebitRecord.DebitCredits))
					,new SqlParameter("@StipulatePaymentTime", ToDBValue(tB_DebitRecord.StipulatePaymentTime))
					,new SqlParameter("@RealityPaymentTime", ToDBValue(tB_DebitRecord.RealityPaymentTime))
					,new SqlParameter("@BorrowingRate", ToDBValue(tB_DebitRecord.BorrowingRate))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_DebitRecord GetById(int id)
        {
            string sql = "SELECT * FROM TB_DebitRecord WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public TB_DebitRecord ToModel(SqlDataReader reader)
		{
			TB_DebitRecord tB_DebitRecord = new TB_DebitRecord();

			tB_DebitRecord.Id = (int)ToModelValue(reader,"Id");
			tB_DebitRecord.DebitForumId = (int)ToModelValue(reader,"DebitForumId");
			tB_DebitRecord.DebitAccountId = (int)ToModelValue(reader,"DebitAccountId");
			tB_DebitRecord.DebitTime = (DateTime)ToModelValue(reader,"DebitTime");
			tB_DebitRecord.DebitCredits = (double)ToModelValue(reader,"DebitCredits");
			tB_DebitRecord.StipulatePaymentTime = (DateTime)ToModelValue(reader,"StipulatePaymentTime");
			tB_DebitRecord.RealityPaymentTime = (DateTime?)ToModelValue(reader,"RealityPaymentTime");
			tB_DebitRecord.BorrowingRate = (double)ToModelValue(reader,"BorrowingRate");
			return tB_DebitRecord;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_DebitRecord";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_DebitRecord> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_DebitRecord) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_DebitRecord> GetAll()
		{
			string sql = "SELECT * FROM TB_DebitRecord";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_DebitRecord> ToModels(SqlDataReader reader)
		{
			List<TB_DebitRecord> list = new List<TB_DebitRecord>();
			while(reader.Read())
			{
				list.Add(ToModel(reader));
			}	
			return list;
		}		
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		protected object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}
	}
    }