using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_OverdraftRecord
{
    public class TB_OverdraftRecord_DAL
	{
        public TB_OverdraftRecord Add
			(TB_OverdraftRecord tB_OverdraftRecord)
		{
				string sql ="INSERT INTO TB_OverdraftRecord (OverdrafterId, OverdraftForumId, OverdraftTime, OverdraftCredits)  output inserted.Id VALUES (@OverdrafterId, @OverdraftForumId, @OverdraftTime, @OverdraftCredits)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@OverdrafterId", ToDBValue(tB_OverdraftRecord.OverdrafterId)),
						new SqlParameter("@OverdraftForumId", ToDBValue(tB_OverdraftRecord.OverdraftForumId)),
						new SqlParameter("@OverdraftTime", ToDBValue(tB_OverdraftRecord.OverdraftTime)),
						new SqlParameter("@OverdraftCredits", ToDBValue(tB_OverdraftRecord.OverdraftCredits)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_OverdraftRecord WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_OverdraftRecord tB_OverdraftRecord)
        {
            string sql =
                "UPDATE TB_OverdraftRecord " +
                "SET " +
			" OverdrafterId = @OverdrafterId" 
                +", OverdraftForumId = @OverdraftForumId" 
                +", OverdraftTime = @OverdraftTime" 
                +", OverdraftCredits = @OverdraftCredits" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_OverdraftRecord.Id)
					,new SqlParameter("@OverdrafterId", ToDBValue(tB_OverdraftRecord.OverdrafterId))
					,new SqlParameter("@OverdraftForumId", ToDBValue(tB_OverdraftRecord.OverdraftForumId))
					,new SqlParameter("@OverdraftTime", ToDBValue(tB_OverdraftRecord.OverdraftTime))
					,new SqlParameter("@OverdraftCredits", ToDBValue(tB_OverdraftRecord.OverdraftCredits))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_OverdraftRecord GetById(int id)
        {
            string sql = "SELECT * FROM TB_OverdraftRecord WHERE Id = @Id";
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
		
		public TB_OverdraftRecord ToModel(SqlDataReader reader)
		{
			TB_OverdraftRecord tB_OverdraftRecord = new TB_OverdraftRecord();

			tB_OverdraftRecord.Id = (int)ToModelValue(reader,"Id");
			tB_OverdraftRecord.OverdrafterId = (int)ToModelValue(reader,"OverdrafterId");
			tB_OverdraftRecord.OverdraftForumId = (int)ToModelValue(reader,"OverdraftForumId");
			tB_OverdraftRecord.OverdraftTime = (DateTime)ToModelValue(reader,"OverdraftTime");
			tB_OverdraftRecord.OverdraftCredits = (double)ToModelValue(reader,"OverdraftCredits");
			return tB_OverdraftRecord;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_OverdraftRecord";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_OverdraftRecord> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_OverdraftRecord) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_OverdraftRecord> GetAll()
		{
			string sql = "SELECT * FROM TB_OverdraftRecord";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_OverdraftRecord> ToModels(SqlDataReader reader)
		{
			List<TB_OverdraftRecord> list = new List<TB_OverdraftRecord>();
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