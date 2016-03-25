using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_TradingRecord
{
    public class TB_TradingRecord_DAL
	{
        public TB_TradingRecord Add
			(TB_TradingRecord tB_TradingRecord)
		{
				string sql ="INSERT INTO TB_TradingRecord (StartTime, EndTime, ExpendForum, ReceiveForum, ExpendCredits, ReceiveCredits, Sponsor, Recipient)  output inserted.Id VALUES (@StartTime, @EndTime, @ExpendForum, @ReceiveForum, @ExpendCredits, @ReceiveCredits, @Sponsor, @Recipient)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@StartTime", ToDBValue(tB_TradingRecord.StartTime)),
						new SqlParameter("@EndTime", ToDBValue(tB_TradingRecord.EndTime)),
						new SqlParameter("@ExpendForum", ToDBValue(tB_TradingRecord.ExpendForum)),
						new SqlParameter("@ReceiveForum", ToDBValue(tB_TradingRecord.ReceiveForum)),
						new SqlParameter("@ExpendCredits", ToDBValue(tB_TradingRecord.ExpendCredits)),
						new SqlParameter("@ReceiveCredits", ToDBValue(tB_TradingRecord.ReceiveCredits)),
						new SqlParameter("@Sponsor", ToDBValue(tB_TradingRecord.Sponsor)),
						new SqlParameter("@Recipient", ToDBValue(tB_TradingRecord.Recipient)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_TradingRecord WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_TradingRecord tB_TradingRecord)
        {
            string sql =
                "UPDATE TB_TradingRecord " +
                "SET " +
			" StartTime = @StartTime" 
                +", EndTime = @EndTime" 
                +", ExpendForum = @ExpendForum" 
                +", ReceiveForum = @ReceiveForum" 
                +", ExpendCredits = @ExpendCredits" 
                +", ReceiveCredits = @ReceiveCredits" 
                +", Sponsor = @Sponsor" 
                +", Recipient = @Recipient" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_TradingRecord.Id)
					,new SqlParameter("@StartTime", ToDBValue(tB_TradingRecord.StartTime))
					,new SqlParameter("@EndTime", ToDBValue(tB_TradingRecord.EndTime))
					,new SqlParameter("@ExpendForum", ToDBValue(tB_TradingRecord.ExpendForum))
					,new SqlParameter("@ReceiveForum", ToDBValue(tB_TradingRecord.ReceiveForum))
					,new SqlParameter("@ExpendCredits", ToDBValue(tB_TradingRecord.ExpendCredits))
					,new SqlParameter("@ReceiveCredits", ToDBValue(tB_TradingRecord.ReceiveCredits))
					,new SqlParameter("@Sponsor", ToDBValue(tB_TradingRecord.Sponsor))
					,new SqlParameter("@Recipient", ToDBValue(tB_TradingRecord.Recipient))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_TradingRecord GetById(int id)
        {
            string sql = "SELECT * FROM TB_TradingRecord WHERE Id = @Id";
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
		
		public TB_TradingRecord ToModel(SqlDataReader reader)
		{
			TB_TradingRecord tB_TradingRecord = new TB_TradingRecord();

			tB_TradingRecord.Id = (int)ToModelValue(reader,"Id");
			tB_TradingRecord.StartTime = (DateTime)ToModelValue(reader,"StartTime");
			tB_TradingRecord.EndTime = (DateTime?)ToModelValue(reader,"EndTime");
			tB_TradingRecord.ExpendForum = (int)ToModelValue(reader,"ExpendForum");
			tB_TradingRecord.ReceiveForum = (int?)ToModelValue(reader,"ReceiveForum");
			tB_TradingRecord.ExpendCredits = (double)ToModelValue(reader,"ExpendCredits");
			tB_TradingRecord.ReceiveCredits = (double)ToModelValue(reader,"ReceiveCredits");
			tB_TradingRecord.Sponsor = (int)ToModelValue(reader,"Sponsor");
			tB_TradingRecord.Recipient = (int?)ToModelValue(reader,"Recipient");
			return tB_TradingRecord;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_TradingRecord";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_TradingRecord> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_TradingRecord) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_TradingRecord> GetAll()
		{
			string sql = "SELECT * FROM TB_TradingRecord";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_TradingRecord> ToModels(SqlDataReader reader)
		{
			List<TB_TradingRecord> list = new List<TB_TradingRecord>();
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