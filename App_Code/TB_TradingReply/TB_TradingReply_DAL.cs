using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_TradingReply
{
    public class TB_TradingReply_DAL
	{
        public TB_TradingReply Add
			(TB_TradingReply tB_TradingReply)
		{
				string sql ="INSERT INTO TB_TradingReply (TradingId, ReplierId, ReplyContent, ReplyTime)  VALUES (@TradingId, @ReplierId, @ReplyContent, @ReplyTime)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@TradingId", ToDBValue(tB_TradingReply.TradingId)),
						new SqlParameter("@ReplierId", ToDBValue(tB_TradingReply.ReplierId)),
						new SqlParameter("@ReplyContent", ToDBValue(tB_TradingReply.ReplyContent)),
						new SqlParameter("@ReplyTime", ToDBValue(tB_TradingReply.ReplyTime)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return tB_TradingReply;				
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_TradingReply WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_TradingReply tB_TradingReply)
        {
            string sql =
                "UPDATE TB_TradingReply " +
                "SET " +
			" TradingId = @TradingId" 
                +", ReplierId = @ReplierId" 
                +", ReplyContent = @ReplyContent" 
                +", ReplyTime = @ReplyTime" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_TradingReply.Id)
					,new SqlParameter("@TradingId", ToDBValue(tB_TradingReply.TradingId))
					,new SqlParameter("@ReplierId", ToDBValue(tB_TradingReply.ReplierId))
					,new SqlParameter("@ReplyContent", ToDBValue(tB_TradingReply.ReplyContent))
					,new SqlParameter("@ReplyTime", ToDBValue(tB_TradingReply.ReplyTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_TradingReply GetById(int id)
        {
            string sql = "SELECT * FROM TB_TradingReply WHERE Id = @Id";
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
		
		public TB_TradingReply ToModel(SqlDataReader reader)
		{
			TB_TradingReply tB_TradingReply = new TB_TradingReply();

			tB_TradingReply.Id = (int)ToModelValue(reader,"Id");
			tB_TradingReply.TradingId = (int)ToModelValue(reader,"TradingId");
			tB_TradingReply.ReplierId = (int)ToModelValue(reader,"ReplierId");
			tB_TradingReply.ReplyContent = (string)ToModelValue(reader,"ReplyContent");
			tB_TradingReply.ReplyTime = (DateTime)ToModelValue(reader,"ReplyTime");
			return tB_TradingReply;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_TradingReply";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_TradingReply> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_TradingReply) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_TradingReply> GetAll()
		{
			string sql = "SELECT * FROM TB_TradingReply";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_TradingReply> ToModels(SqlDataReader reader)
		{
			List<TB_TradingReply> list = new List<TB_TradingReply>();
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