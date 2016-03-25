using System;
using System.Collections.Generic;
using System.Text;
namespace JFB.TB_Account
{
    public class TB_Account
    {
        protected int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        protected string account;
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        protected string loginpwd;
        public string LoginPwd
        {
            get { return loginpwd; }
            set { loginpwd = value; }
        }
        protected string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        protected string paypwd;
        public string PayPwd
        {
            get { return paypwd; }
            set { paypwd = value; }
        }
        protected string pwdquestion;
        public string PwdQuestion
        {
            get { return pwdquestion; }
            set { pwdquestion = value; }
        }
        protected string pwdanswer;
        public string PwdAnswer
        {
            get { return pwdanswer; }
            set { pwdanswer = value; }
        }
        protected int exp;
        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        protected int lineofcredit;
        public int LineOfCredit
        {
            get { return lineofcredit; }
            set { lineofcredit = value; }
        }
        protected string status;
        public string STATUS
        {
            get { return status; }
            set { status = value; }
        }
        protected string headimgpath;
        public string HeadImgPath
        {
            get { return headimgpath; }
            set { headimgpath = value; }
        }
        protected string securitylevel;
        public string SecurityLevel
        {
            get { return securitylevel; }
            set { securitylevel = value; }
        }
        protected string token;
        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}