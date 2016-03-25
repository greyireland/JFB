using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_PurchaseRecord
{
    public class TB_PurchaseRecord_DAL
	{
        public TB_PurchaseRecord Add
			(TB_PurchaseRecord tB_PurchaseRecord)
		{
				string sql ="INSERT INTO TB_PurchaseRecord (ForumId, PurchaserId, PurchaseTime, Amount, PurchaseCredits, PurchaseStatus)  output inserted.Id VALUES (@ForumId, @PurchaserId, @PurchaseTime, @Amount, @PurchaseCredits, @PurchaseStatus)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ForumId", ToDBValue(tB_PurchaseRecord.ForumId)),
						new SqlParameter("@PurchaserId", ToDBValue(tB_PurchaseRecord.PurchaserId)),
						new SqlParameter("@PurchaseTime", ToDBValue(tB_PurchaseRecord.PurchaseTime)),
						new SqlParameter("@Amount", ToDBValue(tB_PurchaseRecord.Amount)),
						new SqlParameter("@PurchaseCredits", ToDBValue(tB_PurchaseRecord.PurchaseCredits)),
						new SqlParameter("@PurchaseStatus", ToDBValue(tB_PurchaseRecord.PurchaseStatus)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_PurchaseRecord WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_PurchaseRecord tB_PurchaseRecord)
        {
            string sql =
                "UPDATE TB_PurchaseRecord " +
                "SET " +
			" ForumId = @ForumId" 
                +", PurchaserId = @PurchaserId" 
                +", PurchaseTime = @PurchaseTime" 
                +", Amount = @Amount" 
                +", PurchaseCredits = @PurchaseCredits" 
                +", PurchaseStatus = @PurchaseStatus" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_PurchaseRecord.Id)
					,new SqlParameter("@ForumId", ToDBValue(tB_PurchaseRecord.ForumId))
					,new SqlParameter("@PurchaserId", ToDBValue(tB_PurchaseRecord.PurchaserId))
					,new SqlParameter("@PurchaseTime", ToDBValue(tB_PurchaseRecord.PurchaseTime))
					,new SqlParameter("@Amount", ToDBValue(tB_PurchaseRecord.Amount))
					,new SqlParameter("@PurchaseCredits", ToDBValue(tB_PurchaseRecord.PurchaseCredits))
					,new SqlParameter("@PurchaseStatus", ToDBValue(tB_PurchaseRecord.PurchaseStatus))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_PurchaseRecord GetById(int id)
        {
            string sql = "SELECT * FROM TB_PurchaseRecord WHERE Id = @Id";
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
		
		public TB_PurchaseRecord ToModel(SqlDataReader reader)
		{
			TB_PurchaseRecord tB_PurchaseRecord = new TB_PurchaseRecord();

			tB_PurchaseRecord.Id = (int)ToModelValue(reader,"Id");
			tB_PurchaseRecord.ForumId = (int)ToModelValue(reader,"ForumId");
			tB_PurchaseRecord.PurchaserId = (int)ToModelValue(reader,"PurchaserId");
			tB_PurchaseRecord.PurchaseTime = (DateTime)ToModelValue(reader,"PurchaseTime");
			tB_PurchaseRecord.Amount = (double)ToModelValue(reader,"Amount");
			tB_PurchaseRecord.PurchaseCredits = (double)ToModelValue(reader,"PurchaseCredits");
			tB_PurchaseRecord.PurchaseStatus = (int)ToModelValue(reader,"PurchaseStatus");
			return tB_PurchaseRecord;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_PurchaseRecord";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_PurchaseRecord> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_PurchaseRecord) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_PurchaseRecord> GetAll()
		{
			string sql = "SELECT * FROM TB_PurchaseRecord";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_PurchaseRecord> ToModels(SqlDataReader reader)
		{
			List<TB_PurchaseRecord> list = new List<TB_PurchaseRecord>();
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