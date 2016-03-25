using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_LoginLog
{
    public class TB_LoginLog_DAL
	{
        public TB_LoginLog Add
			(TB_LoginLog tB_LoginLog)
		{
				string sql ="INSERT INTO TB_LoginLog (LoginAccount, LoginTime)  output inserted.Id VALUES (@LoginAccount, @LoginTime)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@LoginAccount", ToDBValue(tB_LoginLog.LoginAccount)),
						new SqlParameter("@LoginTime", ToDBValue(tB_LoginLog.LoginTime)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_LoginLog WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_LoginLog tB_LoginLog)
        {
            string sql =
                "UPDATE TB_LoginLog " +
                "SET " +
			" LoginAccount = @LoginAccount" 
                +", LoginTime = @LoginTime" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_LoginLog.Id)
					,new SqlParameter("@LoginAccount", ToDBValue(tB_LoginLog.LoginAccount))
					,new SqlParameter("@LoginTime", ToDBValue(tB_LoginLog.LoginTime))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_LoginLog GetById(int id)
        {
            string sql = "SELECT * FROM TB_LoginLog WHERE Id = @Id";
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
		
		public TB_LoginLog ToModel(SqlDataReader reader)
		{
			TB_LoginLog tB_LoginLog = new TB_LoginLog();

			tB_LoginLog.Id = (int)ToModelValue(reader,"Id");
			tB_LoginLog.LoginAccount = (int)ToModelValue(reader,"LoginAccount");
			tB_LoginLog.LoginTime = (DateTime)ToModelValue(reader,"LoginTime");
			return tB_LoginLog;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_LoginLog";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_LoginLog> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_LoginLog) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_LoginLog> GetAll()
		{
			string sql = "SELECT * FROM TB_LoginLog";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_LoginLog> ToModels(SqlDataReader reader)
		{
			List<TB_LoginLog> list = new List<TB_LoginLog>();
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