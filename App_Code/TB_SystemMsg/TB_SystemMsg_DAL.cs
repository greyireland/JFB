using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_SystemMsg
{
    public class TB_SystemMsg_DAL
	{
        public TB_SystemMsg Add
			(TB_SystemMsg tB_SystemMsg)
		{
				string sql ="INSERT INTO TB_SystemMsg (MsgTime, MsgTitle, MsgContent, Receiver, IsRead)  output inserted.Id VALUES (@MsgTime, @MsgTitle, @MsgContent, @Receiver, @IsRead)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@MsgTime", ToDBValue(tB_SystemMsg.MsgTime)),
						new SqlParameter("@MsgTitle", ToDBValue(tB_SystemMsg.MsgTitle)),
						new SqlParameter("@MsgContent", ToDBValue(tB_SystemMsg.MsgContent)),
						new SqlParameter("@Receiver", ToDBValue(tB_SystemMsg.Receiver)),
						new SqlParameter("@IsRead", ToDBValue(tB_SystemMsg.IsRead)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE TB_SystemMsg WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(TB_SystemMsg tB_SystemMsg)
        {
            string sql =
                "UPDATE TB_SystemMsg " +
                "SET " +
			" MsgTime = @MsgTime" 
                +", MsgTitle = @MsgTitle" 
                +", MsgContent = @MsgContent" 
                +", Receiver = @Receiver" 
                +", IsRead = @IsRead" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_SystemMsg.Id)
					,new SqlParameter("@MsgTime", ToDBValue(tB_SystemMsg.MsgTime))
					,new SqlParameter("@MsgTitle", ToDBValue(tB_SystemMsg.MsgTitle))
					,new SqlParameter("@MsgContent", ToDBValue(tB_SystemMsg.MsgContent))
					,new SqlParameter("@Receiver", ToDBValue(tB_SystemMsg.Receiver))
					,new SqlParameter("@IsRead", ToDBValue(tB_SystemMsg.IsRead))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public TB_SystemMsg GetById(int id)
        {
            string sql = "SELECT * FROM TB_SystemMsg WHERE Id = @Id";
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
		
		public TB_SystemMsg ToModel(SqlDataReader reader)
		{
			TB_SystemMsg tB_SystemMsg = new TB_SystemMsg();

			tB_SystemMsg.Id = (int)ToModelValue(reader,"Id");
			tB_SystemMsg.MsgTime = (DateTime)ToModelValue(reader,"MsgTime");
			tB_SystemMsg.MsgTitle = (string)ToModelValue(reader,"MsgTitle");
			tB_SystemMsg.MsgContent = (string)ToModelValue(reader,"MsgContent");
			tB_SystemMsg.Receiver = (int)ToModelValue(reader,"Receiver");
			tB_SystemMsg.IsRead = (bool)ToModelValue(reader,"IsRead");
			return tB_SystemMsg;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM TB_SystemMsg";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<TB_SystemMsg> GetPagedData(int minrownum,int maxrownum)
		{
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_SystemMsg) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				return ToModels(reader);					
			}
		}
		
		public IEnumerable<TB_SystemMsg> GetAll()
		{
			string sql = "SELECT * FROM TB_SystemMsg";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<TB_SystemMsg> ToModels(SqlDataReader reader)
		{
			List<TB_SystemMsg> list = new List<TB_SystemMsg>();
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