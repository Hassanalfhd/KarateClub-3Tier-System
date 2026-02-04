using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using KartateClubDataAccessLayer;

namespace KartateClubBussnessLayer
{


     abstract public  class clsPerson
        {
            protected enum enMode {AddMode =0 , UpdateMode = 2 }
            protected enMode _Mode;
            public int PersonID { set; get; }
            public string Name { set; get; }
            public string Address { set; get; }
            public string Email { set; get; }
            public string Phone { set; get; }
            public string Image { set; get; }
            public char Gender { set; get; }


            public clsPerson(int PersonID, string Name, string Address, string Email, string Phone, string Image, char Gender)
            {
                this.PersonID = PersonID;
                this.Name = Name;
                this.Address = Address;
                this.Email = Email;
                this.Phone = Phone;
                this.Image = Image;
                this.Gender = Gender;
                _Mode = enMode.UpdateMode;
            }

            public clsPerson()
            {
                this.PersonID = -1;
                this.Name = "";
                this.Address = "";
                this.Email = "";
                this.Phone = "";
                this.Image = "";
                this.Gender = ' ';
                _Mode = enMode.AddMode;
            }

        
        }//clsPerson
        
     public class clsMember :clsPerson
        {
            
            public int MemberID { set; get; }
            public string EmergencyContactInfo {set;get;}
            public int LastBeltRank { set; get; }
            public bool IsActive { set; get; }


            private clsMember(int PersonID, string Name, string Addressm, string Email, string Phone, string Image, char Gender, int MemberID, string EmergencyContactInfo, int LastBeltRank, bool IsActive)
                : base(PersonID, Name, Addressm, Email, Phone, Image, Gender)
            {
                this.MemberID = MemberID;
                this.EmergencyContactInfo = EmergencyContactInfo;
                this.LastBeltRank = LastBeltRank;
                this.IsActive = IsActive;
            }

            public clsMember()
            {
                this.MemberID = -1;
                this.EmergencyContactInfo = "";
                this.LastBeltRank = -1;
                this.IsActive = false;
            }

            public static clsMember Find(int MemberID)
            {
                string Name = "", Address = "", Email = "", Image = "", Phone = "", EmergencyContactInfo = "";
                int PersonID = -1 , LastBeltRank = -1 ;
                bool IsActive = false;
                char Gender = ' ';
                if (clsMemberData.GetMemberInfoByID(MemberID, ref PersonID, ref Name, ref Address, ref Email, ref Phone, ref Image, ref Gender, ref EmergencyContactInfo, ref LastBeltRank, ref IsActive))
                {
                    return new clsMember(PersonID, Name, Address, Email, Phone, Image, Gender, MemberID, EmergencyContactInfo, LastBeltRank, IsActive);
                }
                else
                    return null;
            }

            public static clsMember Find(string Name)
            {
                string Address = "", Email = "", Image = "", Phone = "", EmergencyContactInfo = "";
                int PersonID = -1, LastBeltRank = -1, MemberID = -1;
                bool IsActive = false;
                char Gender = ' ';
                if (clsMemberData.GetMemberInfoByName(ref MemberID, ref PersonID, Name, ref Address, ref Email, ref Phone, ref Image, ref Gender, ref EmergencyContactInfo, ref LastBeltRank, ref IsActive))
                {
                    return new clsMember(PersonID, Name, Address, Email, Phone, Image, Gender, MemberID, EmergencyContactInfo, LastBeltRank, IsActive);
                }
                else
                    return null;
            }


            private bool _AddNewMember()
            {
                this.MemberID = clsMemberData.AddNewMember(this.Name, this.Address, this.Email, this.Phone, this.Image,this.Gender, this.EmergencyContactInfo, this.LastBeltRank, this.IsActive);

                return (MemberID != -1);
            }


            private bool _UpdateMember()
            {
                return clsMemberData.UpdateMember(this.MemberID,this.Name, this.Address, this.Email, this.Phone, this.Image, this.Gender,this.EmergencyContactInfo, this.LastBeltRank, this.IsActive);
 
            }

            public bool Save()
            {
                switch (_Mode)
                {
                    case enMode.AddMode:
                        if (_AddNewMember())
                        {
                            return true;
                        }
                        else
                            return false;
                    case enMode.UpdateMode:
                        return _UpdateMember();
                }

                return false;
            }


            public static bool DeleteMember(int MemberID)
            {
                return clsMemberData.DeleteMember(MemberID);
            }

            public static bool IsMemberExite(int MemberID)
            {
                return clsMemberData.IsMemberExiste(MemberID);
            }

            public static DataTable GetAllMembers()
            {
                return clsMemberData.GetAllMembers();                   
            }


        }//clsMember


     public class clsInstructor : clsPerson
     {

         public int InstrcutorID { set; get; }
         public string Qualification { set; get; }


         private clsInstructor(int PersonID, string Name, string Addressm, string Email, string Phone, string Image,char Gender, int MemberID, string Qualification)
             : base(PersonID, Name, Addressm, Email, Phone, Image,Gender )
         {
             this.InstrcutorID = MemberID;
             this.Qualification = Qualification;
          
         }

         public clsInstructor()
         {
             this.InstrcutorID = -1;
             this.Qualification = "";
             
         }

         public static clsInstructor Find(int InstructorID)
         {
             string Name = "", Address = "", Email = "", Image = "", Phone = "", Qualification = "";
             int PersonID = -1;
             char Gender = ' ';

             if (clsInstructorData.GetInstructorInfoByID(InstructorID, ref PersonID, ref Name, ref Address, ref Email, ref Phone, ref Image, ref Gender, ref Qualification))
             {
                 return new clsInstructor(PersonID, Name, Address, Email, Phone, Image, Gender, InstructorID, Qualification);
             }
             else
                 return null;
         }

         public static clsInstructor Find(string Name)
         {
             string  Address = "", Email = "", Image = "", Phone = "", Qualification = "";
             int PersonID = -1, InstructorID = -1;
             char Gender = ' ';

             if (clsInstructorData.GetInstructorInfoByName(ref InstructorID, ref PersonID, Name, ref Address, ref Email, ref Phone, ref Image, ref Gender, ref Qualification))
             {
                 return new clsInstructor(PersonID, Name, Address, Email, Phone, Image, Gender, InstructorID, Qualification);
             }
             else
                 return null;
         }


         private bool _AddNewMember()
         {
             this.InstrcutorID = clsInstructorData.AddNewInstructor(this.Name, this.Address, this.Email, this.Phone, this.Image,this.Gender, this.Qualification);

             return (InstrcutorID != -1);
         }


         private bool _UpdateMember()
         {
             return clsInstructorData.UpdateInstructor(this.InstrcutorID, this.Name, this.Address, this.Email, this.Phone, this.Image, this.Gender, this.Qualification);

         }

         public bool Save()
         {
             switch (_Mode)
             {
                 case enMode.AddMode:
                     if (_AddNewMember())
                     {
                         return true;
                     }
                     else
                         return false;
                 case enMode.UpdateMode:
                     return _UpdateMember();
             }

             return false;
         }


         public static bool DeleteInstructor(int InstructorID)
         {
             return clsInstructorData.DeleteInstructor(InstructorID);
         }

         public static bool IsInstructorExiste(int InstructorID)
         {
             return clsInstructorData.IsInstructorExiste(InstructorID);
         }

         public static DataTable GetAllInstructors()
         {
             return clsInstructorData.GetAllInstructors();
         }


     }//clsInstrcutor

     public class clsUser : clsPerson
     {
         public int UserID { set; get; }
         public string UserName { set; get; }
         public string Password { set; get; }
         public int Permission { set; get; }
         
         public enum enPermissinos
         {

             pAll = -1, pInstructors = 1, pUsers = 2, pMembers = 4, pPayment = 8, pMemberInstructors = 16,
             pRanks = 32  , pPeriods = 64, pTests = 128,
              pAddUpdateUsers = 256  , pDeleteUsers = 512,
              pAddUpdateMembers =  1024  , pDeleteMembers = 2048,
              pAddUpdateInstructors =  4096 , pDeleteInstructors = 8192,
              pAddUpdateMemberInstructors = 16384  , pDeleteMemberInstructors = 32768 ,
              pAddUpdateRanks =  65536 , pDeleteRanks = 131072,
              pAddUpdateTests =  262144 , pDeleteTests = 524288,
              pAddUpdatePayments =  1048576 , pDeletePayments = 2097152,
              pAddUpdatePeriods =  4194304 , pDeletePeriods = 8388608  
         }


    
         //        enum enPermissinos
         //{
         //    pAll = 1,
         //    pAllUser = 2, pAddUser = 4, pDeleteUser = 8, pShowUser = 16,
         //    pAllInstructor = 32, pAddInstructor = 64, pDeleteInstructor = 128, pShowInstructor = 256,
         //    pAllMember = 512, pAddMember = 1024, pDeleteMember = 2048, pShowMember = 4096,
         //    pAllMemberInstructor = 8192, pAddMemberInstructor = 16382, pDeleteMemberInstructor = 32768, pShowMemberInstructor = 65536,

         //    pAllRank =131072,pAddRank =  262144 , pUpdateRank = 524288  , pDeleteRank = 1048576   ,pShowRank =   ,
         //    pAllPeriod  , pAddPeriod = , pUpdatePeriod =   , pDeletePeriod = , pShowPeriod =  ,
         //    pAllTest =  , pAddTest = ,  pUpdateTest = , pDeleteTest =  , pShowTest = ,
         //    pAllPayment =  , pAddPayment =  , pUpdatePayment =  , pDeletePayment = ,pShowPayment =
              
         //}


         private clsUser(int PersonID, string Name, string Address, string Email, string Phone, string Image, char Gender, int UserID, string UserName, string Password, int Permission)
            :base(PersonID,Name,Address,Email,Phone,Image,Gender)
         {
             this.UserID = UserID;
             this.UserName = UserName;
             this.Password = Password;
             this.Permission = Permission;

         }

         public clsUser()
         {
             this.UserID = -1;
             this.UserName = "";
             this.Password = "";
             this.Permission = -1;
         }


         public bool ChackAccessPermissinos(enPermissinos Permissinos)
         {
              
             if (this.Permission == (int)enPermissinos.pAll)
                 return true;


             if ((this.Permission & (int)Permissinos) == (int)Permissinos)
                 return true;
             else
                 return false;
         }


          public static clsUser Find(int UserID)
         {
             string Name = "", Address = "", Email = "", Image = "", Phone = "", Password = "", UserName = "";
             int PersonID = -1 , Permission = -1;
             char Gender = ' ';

             if (clsUserData.GetUserInfoByID(UserID, ref PersonID, ref Name, ref Address, ref Email, ref Phone, ref Image, ref Gender, ref UserName,ref Password, ref Permission))
             {
                 return new clsUser(PersonID, Name, Address, Email, Phone, Image, Gender, UserID, UserName, Password, Permission);
             }else
                 return    null;
         }

          public static clsUser Find(string UserName, string Password)
         {
             string Name = "", Address = "", Email = "", Image = "", Phone = "";
             int PersonID = -1 , Permission = -1,  UserID = -1;
             char Gender = ' ';

             if (clsUserData.GetUserInfoByUserNameAndPassword(ref UserID, ref PersonID, ref Name, ref Address, ref Email, ref Phone, ref Image, ref Gender,  UserName, Password, ref Permission))
             {
                 return new clsUser(PersonID, Name, Address, Email, Phone, Image, Gender, UserID, UserName, Password, Permission);
             }else
                 return    null;
         }


          private bool _AddNewUser()
          {
              this.UserID = clsUserData.AddNewUser(this.Name,this.Address,this.Email,this.Phone,this.Image, this.Gender,this.UserName,this.Password, this.Permission);
              return (this.UserID != -1);
          }

          private bool _UpdateUser()
          {
              return clsUserData.UpdateUser(this.UserID, this.Name, this.Address, this.Email, this.Phone, this.Image, this.Gender, this.UserName, this.Password, this.Permission);
          }

          public bool Save()
          {
              switch (_Mode)
              {
                  case enMode.AddMode:
                      if (_AddNewUser())
                      {
                          return true;
                      }
                      else
                          return false;
                  case enMode.UpdateMode:
                      return _UpdateUser();
              }

              return false;
          }


          public static bool DeleteUser(int UserID)
          {
              return clsUserData.DeleteUser(UserID);
          }

          public static bool IsUserExiste(int UserID)
          {
              return clsUserData.IsUserExiste(UserID);
          }

          public static bool IsUserExiste(string UserName, string Password)
          {
              return clsUserData.IsUserExiste(UserName, Password);
          }


          public static DataTable GetAllUsers()
          {
              return clsUserData.GetAllUsers();
          }

     }

     public class clsMemberInstructor
     {
         enum enMode {AddMode = 0, UpdateMode = 1 }
         enMode _Mode;

         public int MemberID { set; get; }
         public int InstructorID { set; get; }
         public DateTime AssignDate { set; get; }

         private clsMemberInstructor(int MemberID, int instructorID, DateTime AssignDate)
         {
             this.MemberID = MemberID;
             this.InstructorID = MemberID;
             this.AssignDate = AssignDate;
             _Mode = enMode.UpdateMode;
         }

         public clsMemberInstructor()
         {
             this.MemberID = -1;
             this.InstructorID = -1;
             this.AssignDate = DateTime.Now;
             _Mode = enMode.AddMode;
         }

         public static clsMemberInstructor Find(int instructorID, int MemberID)
         {
             DateTime AssignDate = DateTime.Now;

             if (clsMemberInstructorData.GetMemberInstructorInfoByInstructorIDAndMemberID(instructorID, MemberID, ref  AssignDate))
             {
                 return new clsMemberInstructor(instructorID, MemberID, AssignDate);
             }
             else
                 return null;
         }


         private bool _AddNewMemberInstructor()
         {
             return clsMemberInstructorData.AddNewMemberInstructor(this.InstructorID, this.MemberID, this.AssignDate);
         }

         private bool _UpdateMemberInstructor()
         {
             return clsMemberInstructorData.UpdateMemberInstructor(this.InstructorID, this.MemberID, this.AssignDate);
         }


         public bool Save()
         {
             switch (_Mode)
             {
                 case enMode.AddMode:
                     if (_AddNewMemberInstructor())
                     {
                         return true;
                     }
                     else
                         return false;
                 case enMode.UpdateMode:
                     return _UpdateMemberInstructor();
             }

             return false;
         }


         public static bool DeleteMemberInstructor(int instructorID, int MemberID)
         {
             return clsMemberInstructorData.DeleteMemberInstructor(instructorID, MemberID);
         }

         public static bool IsMemberInstructorExsite(int instructorID, int MemberID)
         {
             return clsMemberInstructorData.IsMemberInstructorExsite(instructorID, MemberID);
         }

         public static DataTable GetAllMemberInstructor()
         {
             return clsMemberInstructorData.GetAllMemberInstructors();
         }


     }//clsMemberInstructor

     public class clsPayment
     {
         private enum enMode {AddMode =0, UpdateMode=1 }
         private enMode _Mode;
         public int PaymentID { set; get; }
         public decimal Amount { set; get; }
         public DateTime Date { set; get; }
         public int MemberID { set; get; }
         public string PaymentType { set; get; }


         private clsPayment(int PaymentID, decimal Amount, DateTime Date, int MemberID, string PaymentType)
         {
             this.PaymentID = PaymentID;
             this.Amount = Amount;
             this.Date = Date;
             this.MemberID = MemberID;
             this.PaymentType = PaymentType;
             _Mode = enMode.UpdateMode;

         }


         public clsPayment()
         {
             this.PaymentID = -1;
             this.Amount = 0;
             this.Date = DateTime.Now;
             this.MemberID = -1;
             this.PaymentType = "";
             _Mode = enMode.AddMode;

         }


         public static clsPayment Find(int PaymentID)
         {
             decimal Amount = 0;
             int MemberID = -1;
             DateTime Date = DateTime.Now;
             string PaymentType = "";

             if (clsPaymentData.GetPaymentInfoByID(PaymentID, ref Amount, ref Date, ref MemberID, ref PaymentType))
                 return new clsPayment(PaymentID, Amount, Date, MemberID, PaymentType);
             else
                 return null;
         }

      

         private bool _AddNewPaymentRecord()
         {
             this.PaymentID = clsPaymentData.AddNewPaymentRecord(this.Amount, this.Date, this.MemberID, this.PaymentType);
             return (this.PaymentID != -1);
         }

         private bool _UpdatePaymentRecord()
         {
             return clsPaymentData.UpdatePaymentRecord(this.PaymentID, this.Amount, this.Date, this.MemberID, this.PaymentType);
         }

         public bool Save()
         {
             switch (_Mode)
             {
                 case enMode.AddMode:
                     if (_AddNewPaymentRecord())
                     {
                         return true;
                     }
                     else
                         return false;
                 case enMode.UpdateMode:
                     return _UpdatePaymentRecord();
             }

             return false;
         }

         public static bool DeletePaymentRecord(int PaymentID)
         {
             return clsPaymentData.DeletePaymentRecord(PaymentID);
         }

         public static bool IsPaymentRecordExiste(int PaymentID)
         {
             return clsPaymentData.IsPaymentRecordExiste(PaymentID);
         }

         public static DataTable GetAllPaymentRecords()
         {
             return clsPaymentData.GetAllPaymentRecords();
         }

     }//clsPayment


     public class clsPeriod
     {
         enum enMode {AddMode=0, UpdateMode =1 }
         enMode _Mode;
       public int PeriodID {set;get;}
        public DateTime StartDate {set;get;}
        public DateTime EndDate{set;get;}
        public decimal Fees { set; get; } 
        public bool Paid{set;get;}
        public int MemberID{set;get;}
        public int PaymentID { set; get; }

        private clsPeriod(int PeriodID, DateTime StartDate, DateTime EndDate, decimal Fees, bool Paid, int MemberID, int PaymentID)
        {
            this.PeriodID = PeriodID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Fees = Fees;
            this.Paid = Paid;
            this.MemberID = MemberID;
            this.PaymentID = PaymentID;
            _Mode = enMode.UpdateMode;

        }

        public clsPeriod()
        {
            this.PeriodID = -1;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.Fees = 0;
            this.Paid = false;
            this.MemberID = -1;
            this.PaymentID = -1;
            _Mode = enMode.AddMode;
        }


        public static clsPeriod Find(int PeriodeID)
        {
            DateTime StartDate =DateTime.Now ,  EndDate = DateTime.Now;
            int MemberID = -1, PaymentID = -1;
            bool Paid = false;
            decimal Fees = 0;

            if (clsPeriodData.GetPeriodsByID(PeriodeID, ref StartDate, ref EndDate, ref Fees, ref Paid, ref MemberID, ref PaymentID))
                return new clsPeriod(PeriodeID, StartDate, EndDate, Fees, Paid, MemberID, PaymentID);
            else
                return null;

        }


        private bool _AddNewPeriod()
        {
            this.PeriodID = clsPeriodData.AddNewPeriod(this.StartDate , this.EndDate, this.Fees, this.Paid, this.MemberID, this.PaymentID);

            return (this.PeriodID != -1);
        }


        private bool UpdatePeriod()
        {
            return clsPeriodData.UpdatePeriod(this.PeriodID, this.StartDate, this.EndDate, this.Fees, this.Paid, this.MemberID, this.PaymentID);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddMode:
                    if (_AddNewPeriod())
                    {
                        return true;
                    }
                    else
                        return false;
                case enMode.UpdateMode:
                    return UpdatePeriod();
            }

            return false;
        }


        public static bool DeletePeriod(int PeriodID)
        {
            return clsPeriodData.DeletePeriod(PeriodID);
        }

        public static bool IsPeriodExiste(int PeriodID)
        {
            return clsPeriodData.IsPeriodExiste(PeriodID);
        }

        public static DataTable GetAllPeriods()
        {
            return clsPeriodData.GetAllPeriods(); 
        }


     }//clsPeriod

     public class clsBeltRank
     {
         private enum enMode {AddMode =0, UpdateMode=1 }
         private enMode _Mode;
         public int RankID { set; get; }
         public string RankName { set; get; }
         public decimal TestFees{set;get;}

         private clsBeltRank(int RankID, string RankName, decimal TestFees)
         {
             this.RankID = RankID;
             this.RankName = RankName;
             this.TestFees = TestFees;
             _Mode = enMode.UpdateMode;
         }

         public clsBeltRank()
         {
             this.RankID = -1;
             this.RankName = "";
             this.TestFees = 0;
             _Mode = enMode.AddMode;
         }

         public static clsBeltRank Find(int RankID)
         {
             string RankName = "";
             decimal TestFees = 0;

             if (clsBeltRankData.GetBeltRankByID(RankID, ref RankName, ref TestFees))
                 return new clsBeltRank(RankID, RankName, TestFees);
             else
                 return null;
         }

         public static clsBeltRank Find( string RankName)
         {
             decimal TestFees = 0;
             int RankID = -1;

             if (clsBeltRankData.GetBeltRankByName(ref RankID,  RankName, ref TestFees))
                 return new clsBeltRank(RankID, RankName, TestFees);
             else
                 return null;
         }

         private bool _AddNewRank()
         {
             this.RankID = clsBeltRankData.AddNewRank(this.RankName, this.TestFees);
             return (this.RankID != -1);
         }

         private bool _UpdateRank()
         {
             return clsBeltRankData.UpdateRank(this.RankID, this.RankName, this.TestFees);
         }

         public bool Save()
         {
             switch (_Mode)
             {
                 case enMode.AddMode:
                     if (_AddNewRank())
                     {
                         return true;
                     }
                     else
                         return false;
                 case enMode.UpdateMode:
                     return _UpdateRank();
             }

             return false;
         }


         public static bool DeleteRank(int RankID)
         {
             return clsBeltRankData.DeleteRank(RankID);
         }

         public static bool IsRankExiste(int RankID)
         {
             return clsBeltRankData.IsRankExiste(RankID);
         }

         public static DataTable GetAllBeltRanks()
         {
             return clsBeltRankData.GetAllBeltRanks();
         }

     }//clsBeltRank

     public class clsBeltTest
     {
         private enum enMode { AddMode = 0, UpdateMode = 1 }
         private enMode _Mode;
         public int TestID { set; get; }
         public int MemberID { set; get; }
         public int RankID { set; get; } 
         public bool Result { set; get; }
         public DateTime Date { set; get; }
         public int TestedByInstructorID{set;get;} 
         public int PaymentID{set;get;}

         private clsBeltTest(int TestID, int MemberID, int RankID, bool Result, DateTime Date, int TestedByInstructorID, int PaymentID)
         {
             this.TestID = TestID;
             this.MemberID = MemberID;
             this.RankID = RankID;
             this.Result = Result;
             this.Date = Date;
             this.TestedByInstructorID = TestedByInstructorID;
             this.PaymentID = PaymentID;
             _Mode = enMode.UpdateMode;
         }

         public clsBeltTest()
         {
             this.TestID = -1;
             this.MemberID = -1;
             this.RankID = -1;
             this.Result = false;
             this.Date = DateTime.Now;
             this.TestedByInstructorID = -1;
             this.PaymentID = -1;
             _Mode = enMode.AddMode;
         }


         public static clsBeltTest Find(int TestID)
         {
             int MemberID = -1, RankID = -1, PaymentID = -1, TestedByInstructorID = -1;
             bool Result = false;
             DateTime Date = DateTime.Now;

             if (clsBeltTestData.GetBeltTestByID(TestID, ref MemberID, ref RankID, ref Result, ref Date, ref TestedByInstructorID, ref PaymentID))
                 return new clsBeltTest(TestID, MemberID, RankID, Result, Date, TestedByInstructorID, PaymentID);
             else
                 return null;
         }

         private bool _AddNewBeltTest()
         {
             this.TestID = clsBeltTestData.AddNewBeltTest(this.MemberID, this.RankID, this.Result, this.Date,this.TestedByInstructorID, this.PaymentID);

             return     (this.TestID != -1);
         }

         private bool _UpdateBeltTest()
         {
             return clsBeltTestData.UpdateBeltTest(this.TestID,this.MemberID, this.RankID, this.Result, this.Date, this.TestedByInstructorID, this.PaymentID);

         }

         public bool Save()
         {
             switch (_Mode)
             {
                 case enMode.AddMode:
                     if (_AddNewBeltTest())
                     {
                         return true;
                     }
                     else
                         return false;
                 case enMode.UpdateMode:
                     return _UpdateBeltTest();
             }

             return false;
         }

         public static bool DeleteBeltTest(int TestID)
         {
             return clsBeltTestData.DeleteBeltTest(TestID);
         }

         public static bool IsBeltTestExiste(int TestID)
         {
             return clsBeltTestData.IsBeltTestExiste(TestID);
         }

         public static DataTable GetAllBeltTestes()
         {
             return clsBeltTestData.GetAllBeltTestes();
         }


     }


}
