using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JFB.TB_Account
{
    public class TB_Account_DAL
    {
        public TB_Account Add
            (TB_Account tB_Account)
        {
            string sql = "INSERT INTO TB_Accounts (Account, LoginPwd, Email, PayPwd, PwdQuestion, PwdAnswer, Exp, LineOfCredit, STATUS, HeadImgPath, SecurityLevel, Token)  output inserted.Id VALUES (@Account, @LoginPwd, @Email, @PayPwd, @PwdQuestion, @PwdAnswer, @Exp, @LineOfCredit, @STATUS, @HeadImgPath, @SecurityLevel, @Token)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Account", ToDBValue(tB_Account.Account)),
						new SqlParameter("@LoginPwd", ToDBValue(tB_Account.LoginPwd)),
						new SqlParameter("@Email", ToDBValue(tB_Account.Email)),
						new SqlParameter("@PayPwd", ToDBValue(tB_Account.PayPwd)),
						new SqlParameter("@PwdQuestion", ToDBValue(tB_Account.PwdQuestion)),
						new SqlParameter("@PwdAnswer", ToDBValue(tB_Account.PwdAnswer)),
						new SqlParameter("@Exp", ToDBValue(tB_Account.Exp)),
						new SqlParameter("@LineOfCredit", ToDBValue(tB_Account.LineOfCredit)),
						new SqlParameter("@STATUS", ToDBValue(tB_Account.STATUS)),
						new SqlParameter("@HeadImgPath", ToDBValue(tB_Account.HeadImgPath)),
						new SqlParameter("@SecurityLevel", ToDBValue(tB_Account.SecurityLevel)),
						new SqlParameter("@Token", ToDBValue(tB_Account.Token)),
					};

            int newId = (int)SqlHelper.ExecuteScalar(sql, para);
            return GetById(newId);
        }

        public int DeleteById(int id)
        {
            string sql = "DELETE TB_Accounts WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(TB_Account tB_Account)
        {
            string sql =
                "UPDATE TB_Accounts " +
                "SET " +
            " Account = @Account"
                + ", LoginPwd = @LoginPwd"
                + ", Email = @Email"
                + ", PayPwd = @PayPwd"
                + ", PwdQuestion = @PwdQuestion"
                + ", PwdAnswer = @PwdAnswer"
                + ", Exp = @Exp"
                + ", LineOfCredit = @LineOfCredit"
                + ", STATUS = @STATUS"
                + ", HeadImgPath = @HeadImgPath"
                + ", SecurityLevel = @SecurityLevel"
                + ", Token = @Token"

            + " WHERE Id = @Id";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", tB_Account.Id)
					,new SqlParameter("@Account", ToDBValue(tB_Account.Account))
					,new SqlParameter("@LoginPwd", ToDBValue(tB_Account.LoginPwd))
					,new SqlParameter("@Email", ToDBValue(tB_Account.Email))
					,new SqlParameter("@PayPwd", ToDBValue(tB_Account.PayPwd))
					,new SqlParameter("@PwdQuestion", ToDBValue(tB_Account.PwdQuestion))
					,new SqlParameter("@PwdAnswer", ToDBValue(tB_Account.PwdAnswer))
					,new SqlParameter("@Exp", ToDBValue(tB_Account.Exp))
					,new SqlParameter("@LineOfCredit", ToDBValue(tB_Account.LineOfCredit))
					,new SqlParameter("@STATUS", ToDBValue(tB_Account.STATUS))
					,new SqlParameter("@HeadImgPath", ToDBValue(tB_Account.HeadImgPath))
					,new SqlParameter("@SecurityLevel", ToDBValue(tB_Account.SecurityLevel))
					,new SqlParameter("@Token", ToDBValue(tB_Account.Token))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public TB_Account GetById(int id)
        {
            string sql = "SELECT * FROM TB_Accounts WHERE Id = @Id";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
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
        public TB_Account GetByAccount(string acc)
        {
            string sql = "SELECT * FROM TB_Accounts WHERE Account = @Account";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Account", acc)))
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
        public TB_Account ToModel(SqlDataReader reader)
        {
            TB_Account tB_Account = new TB_Account();

            tB_Account.Id = (int)ToModelValue(reader, "Id");
            tB_Account.Account = (string)ToModelValue(reader, "Account");
            tB_Account.LoginPwd = (string)ToModelValue(reader, "LoginPwd");
            tB_Account.Email = (string)ToModelValue(reader, "Email");
            tB_Account.PayPwd = (string)ToModelValue(reader, "PayPwd");
            tB_Account.PwdQuestion = (string)ToModelValue(reader, "PwdQuestion");
            tB_Account.PwdAnswer = (string)ToModelValue(reader, "PwdAnswer");
            tB_Account.Exp = (int)ToModelValue(reader, "Exp");
            tB_Account.LineOfCredit = (int)ToModelValue(reader, "LineOfCredit");
            tB_Account.STATUS = (string)ToModelValue(reader, "STATUS");
            tB_Account.HeadImgPath = (string)ToModelValue(reader, "HeadImgPath");
            tB_Account.SecurityLevel = (string)ToModelValue(reader, "SecurityLevel");
            tB_Account.Token = (string)ToModelValue(reader, "Token");
            return tB_Account;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM TB_Accounts";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IEnumerable<TB_Account> GetPagedData(int minrownum, int maxrownum)
        {
            string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM TB_Accounts) t where rownum>=@minrownum and rownum<=@maxrownum";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
                new SqlParameter("@minrownum", minrownum),
                new SqlParameter("@maxrownum", maxrownum)))
            {
                return ToModels(reader);
            }
        }

        public IEnumerable<TB_Account> GetAll()
        {
            string sql = "SELECT * FROM TB_Accounts";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IEnumerable<TB_Account> ToModels(SqlDataReader reader)
        {
            List<TB_Account> list = new List<TB_Account>();
            while (reader.Read())
            {
                list.Add(ToModel(reader));
            }
            return list;
        }

        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        protected object ToModelValue(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
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