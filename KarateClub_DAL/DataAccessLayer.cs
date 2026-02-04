using System;
using System.Data.SqlClient;
using System.Data;

namespace KartateClubDataAccessLayer
{
   
        public class clsPersonData   
        {


            protected static bool GetPersonInfoByID(int PersonID, ref string Name, ref  string Address, ref string Email, ref string Phone, ref string Image)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = "select * from Person where PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query,connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;
                        Name = (string)reader["Name"];

                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";

                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            protected static bool GetPersonInfoByID(ref int PersonID, string Name, ref  string Address, ref string Email, ref string Phone, ref string Image)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = "select * from Person where Name = @Name";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", Name);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;
                        PersonID = (int)reader["PersonID"];

                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";

                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }


            protected static int AddNewPerson(string Name, string Address, string Email, string Phone, string Image, char Gender)
            {
                int PersonID = -1;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"INSERT INTO [dbo].[Person]
           ([Name]
           ,[Address]
           ,[Email]
           ,[Phone]
           ,[Image]
           ,[Gender])
     VALUES
           (@Name
           ,@Address 
           ,@Email
           ,@Phone 
           ,@Image
           ,@Gender)
		   select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", Name);
               
                if(Address != "")
                    command.Parameters.AddWithValue("@Address", Address);
                else
                    command.Parameters.AddWithValue("@Address", DBNull.Value);

                if (Gender != ' ')
                    command.Parameters.AddWithValue("@Gender", Gender);
                else
                    command.Parameters.AddWithValue("@Gender", DBNull.Value);


                if (Email != "")
                    command.Parameters.AddWithValue("@Email", Email);
                else
                    command.Parameters.AddWithValue("@Email", DBNull.Value);

                if (Phone != "")
                    command.Parameters.AddWithValue("@Phone", Phone);
                else
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);

                if (Image != "")
                    command.Parameters.AddWithValue("@Image", Image);
                else
                    command.Parameters.AddWithValue("@Image", DBNull.Value);

                try
                {
                    connection.Open();

                    int Insert = -1;

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out Insert))
                    {
                        PersonID = Insert;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    PersonID = -1;
                }
                finally
                {
                    connection.Close();
                }

                return PersonID;
            }

            protected static bool UpdatePerson(int PersonID, string Name, string Address, string Email, string Phone, string Image, char Gender)
            {
                int RowAffact = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"UPDATE [dbo].[Person]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Email] = @Email
      ,[Phone] = @Phone
      ,[Image] = @Image
      ,[Gender] = @Gender
 WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@Name", Name);

                if (Address != "")
                    command.Parameters.AddWithValue("@Address", Address);
                else
                    command.Parameters.AddWithValue("@Address", DBNull.Value);

                if (Gender != ' ')
                    command.Parameters.AddWithValue("@Gender", Gender);
                else
                    command.Parameters.AddWithValue("@Gender", DBNull.Value);



                if (Email != "")
                    command.Parameters.AddWithValue("@Email", Email);
                else
                    command.Parameters.AddWithValue("@Email", DBNull.Value);

                if (Phone != "")
                    command.Parameters.AddWithValue("@Phone", Phone);
                else
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);

                if (Image != "")
                    command.Parameters.AddWithValue("@Image", Image);
                else
                    command.Parameters.AddWithValue("@Image", DBNull.Value);

                try
                {
                    connection.Open();

                    RowAffact = command.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    RowAffact = 0;
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffact > 0);
            }

            protected static bool DeletePerson(int PersonID)
            {

                int RowAffact = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Delete Person Where PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    RowAffact = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    RowAffact = 0;
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffact > 0);

            }

            protected static bool IsPersonExiste(int PersonID)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select found = 1 from Person where PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        IsFound = true;

                }
                catch (Exception ex)
                {
                    IsFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

            }

            protected static DataTable GetAllPerson()
            {

                DataTable PersonsTable = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = "select * from Person";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        PersonsTable.Load(reader);

                }
                catch (Exception ex)
                {
                    PersonsTable = null;
                }
                finally
                {
                    connection.Close();
                }

                return PersonsTable;
            }


        }//clsPerson

        public class clsMemberData : clsPersonData 
        {

            public static bool GetMemberInfoByID(int MemberID, ref int PersonID, ref string Name, ref  string Address, ref string Email, ref string Phone, ref string Image,
                ref char Gender, ref string EmergencyContactInfo, ref int LastBeltRank , ref bool IsActive )
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Members.MemberID,Person.Name,Person.Gender, Person.Address, Person.Email, Person.Phone, Members.PersonID, Members.EmergencyContactInfo, Members.LastBeltRank, Members.IsActive,  Person.Image
FROM            Members INNER JOIN
                         BeltRank ON Members.LastBeltRank = BeltRank.RankID INNER JOIN
                         Person ON Members.PersonID = Person.PersonID
    where MemberID = @MemberID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MemberID", MemberID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;

                        EmergencyContactInfo = (string)reader["EmergencyContactInfo"];
                        LastBeltRank = (int)reader["LastBeltRank"];
                        IsActive = (bool)reader["IsActive"];
                        Name = (string)reader["Name"];

                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";

                            Gender = Convert.ToChar (reader["Gender"]);
                       


                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }


            public static bool GetMemberInfoByName(ref int MemberID, ref int PersonID,  string Name, ref  string Address, ref string Email, ref string Phone, ref string Image,
               ref char Gender, ref string EmergencyContactInfo, ref int LastBeltRank, ref bool IsActive)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Members.MemberID,Person.Name,Person.Gender, Person.Address, Person.Email, Person.Phone, Members.PersonID, Members.EmergencyContactInfo, Members.LastBeltRank, Members.IsActive,  Person.Image
FROM            Members INNER JOIN
                         BeltRank ON Members.LastBeltRank = BeltRank.RankID INNER JOIN
                         Person ON Members.PersonID = Person.PersonID
    where Name = @Name";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", Name);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;

                        EmergencyContactInfo = (string)reader["EmergencyContactInfo"];
                        LastBeltRank = (int)reader["LastBeltRank"];
                        IsActive = (bool)reader["IsActive"];
                        MemberID = (int)reader["MemberID"];

                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";

                        Gender = Convert.ToChar(reader["Gender"]);



                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }



            public static int AddNewMember(string Name, string Address, string Email, string Phone, string Image, char Gender, string EmergencyContactInfo,  int LastBeltRank,  bool IsActive)
            {
                int MemberID = -1;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
                int PersonID = clsPersonData.AddNewPerson(Name, Address, Email, Phone, Image, Gender);

                string query = @"INSERT INTO [dbo].[Members]
           ([PersonID]
           ,[EmergencyContactInfo]
           ,[LastBeltRank]
           ,[IsActive])
     VALUES
           (@PersonID
           ,@EmergencyContactInfo
           ,@LastBeltRank
           ,@IsActive);
		   select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                   command.Parameters.AddWithValue("@PersonID", PersonID);
        
                   command.Parameters.AddWithValue("@EmergencyContactInfo", EmergencyContactInfo);

                   command.Parameters.AddWithValue("@LastBeltRank", LastBeltRank);

                   command.Parameters.AddWithValue("@IsActive", IsActive);


                try
                {
                    connection.Open();

                    int Insert = -1;

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out Insert))
                    {
                        MemberID = Insert;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    clsPersonData.DeletePerson(PersonID);
                }
                finally
                {
                    connection.Close();
                }

                return MemberID;
            }


            public static bool UpdateMember(int MemberID, string Name, string Address, string Email, string Phone, string Image, char Gender, string EmergencyContactInfo, int LastBeltRank, bool IsActive)
            {

                int RowAffact = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                //if (!clsPersonData.UpdatePerson(PersonID, Name, Address, Email, Phone, Image))
                //{
                //    return false;
                //}


                string query = @"UPDATE [dbo].[Person]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Email] = @Email
      ,[Phone] = @Phone
      ,[Image] = @Image
      ,[Gender] = @Gender
 WHERE PersonID = (Select PersonID From Members where MemberID = @MemberID);

UPDATE [dbo].[Members]
   SET [EmergencyContactInfo] = @EmergencyContactInfo
      ,[LastBeltRank] = @LastBeltRank
      ,[IsActive] = @IsActive
 WHERE MemberID = @MemberID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MemberID", MemberID);

                command.Parameters.AddWithValue("@Name", Name);

                if (Address != "")
                    command.Parameters.AddWithValue("@Address", Address);
                else
                    command.Parameters.AddWithValue("@Address", DBNull.Value);

                if (Gender != ' ')
                    command.Parameters.AddWithValue("@Gender", Address);
                else
                    command.Parameters.AddWithValue("@Gender", DBNull.Value);


                if (Email != "")
                    command.Parameters.AddWithValue("@Email", Email);
                else
                    command.Parameters.AddWithValue("@Email", DBNull.Value);

                if (Phone != "")
                    command.Parameters.AddWithValue("@Phone", Phone);
                else
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);

                if (Image != "")
                    command.Parameters.AddWithValue("@Image", Image);
                else
                    command.Parameters.AddWithValue("@Image", DBNull.Value);



                    command.Parameters.AddWithValue("@EmergencyContactInfo", EmergencyContactInfo);
                    command.Parameters.AddWithValue("@LastBeltRank", LastBeltRank);

                    command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();

                    RowAffact = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    RowAffact = 0;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffact > 0);
            }


            public static bool DeleteMember(int MemberID)
            {

                bool IsDeleted = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select PersonID from Members where MemberID = @MemberID;
                            Delete Members Where MemberID = @MemberID";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MemberID", MemberID);

                try
                {
                    connection.Open();
                    int PersonID = -1;
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out PersonID))
                    {
                        clsPersonData.DeletePerson(PersonID);
                        IsDeleted = true;
                    }



                }
                catch (Exception ex)
                {
                    IsDeleted = false;
                }
                finally
                {
                    connection.Close();
                }

                return IsDeleted;

            }

            public static bool IsMemberExiste(int MemberID)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select Found = 1 from Members Where MemberID = @MemberID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MemberID", MemberID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                        IsFound = true;

                }
                catch (Exception ex)
                {
                    IsFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

            }

            public static DataTable GetAllMembers()
            {

                DataTable MembersTable = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Members.MemberID,Person.Name, Person.Gender, Person.Address, Person.Email, Person.Phone, Members.EmergencyContactInfo, Members.LastBeltRank, Members.IsActive,  Person.Image
FROM            Members INNER JOIN
                         BeltRank ON Members.LastBeltRank = BeltRank.RankID INNER JOIN
                         Person ON Members.PersonID = Person.PersonID;";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        MembersTable.Load(reader);

                }
                catch (Exception ex)
                {
                    MembersTable = null;
                }
                finally
                {
                    connection.Close();
                }

                return MembersTable;

            }


        }//clsMemberData


        public class clsInstructorData : clsPersonData
        {
            public static bool GetInstructorInfoByID(int InstructorID, ref int PersonID, ref string Name, ref  string Address, ref string Email, ref string Phone, ref string Image, ref char Gender, ref string Qualification)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Instructors.InstructorID, Person.Name, Person.Gender, Person.Address, Person.Email, Person.Phone, Instructors.Qualification, Person.Image
FROM            Instructors INNER JOIN
                         Person ON Instructors.PersonID = Person.PersonID
where InstructorID = @InstructorID;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InstructorID", InstructorID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;
                        Name = (string)reader["Name"];

                        if (reader["Qualification"] != DBNull.Value)
                            Qualification = (string)reader["Qualification"];
                        else
                            Qualification = "";


                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";

                            Gender = Convert.ToChar(reader["Gender"]);

                       

                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            public static bool GetInstructorInfoByName(ref int InstructorID, ref int PersonID, string Name, ref  string Address, ref string Email, ref string Phone, ref string Image, ref char Gender, ref string Qualification)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Instructors.InstructorID, Person.Name, Person.Gender, Person.Address, Person.Email, Person.Phone, Instructors.Qualification, Person.Image
FROM            Instructors INNER JOIN
                         Person ON Instructors.PersonID = Person.PersonID
where Name = @Name;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Name", Name);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;
                        InstructorID = (int)reader["InstructorID"];

                        if (reader["Qualification"] != DBNull.Value)
                            Qualification = (string)reader["Qualification"];
                        else
                            Qualification = "";


                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";

                        Gender = Convert.ToChar(reader["Gender"]);



                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }



            public static int AddNewInstructor(string Name, string Address, string Email, string Phone, string Image,char Gender, string Qualification)
            {
                int PersonID = clsPersonData.AddNewPerson(Name, Address, Email, Phone, Image, Gender);
                int InstructorID = -1;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"INSERT INTO [dbo].[Instructors]
           ([PersonID]
           ,[Qualification])
     VALUES
           (@PersonID
           ,@Qualification);
		   select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);

                command.Parameters.AddWithValue("@Qualification", Qualification);


                try
                {
                    connection.Open();

                    int Insert = -1;

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out Insert))
                    {
                        InstructorID = Insert;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    clsPersonData.DeletePerson(PersonID);
                }
                finally
                {
                    connection.Close();
                }

                return InstructorID;
            }

            public static bool UpdateInstructor(int InstructorID, string Name, string Address, string Email, string Phone, string Image, char Gender, string Qualification)
            {

                int RowAffact = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                //if (!clsPersonData.UpdatePerson(PersonID, Name, Address, Email, Phone, Image))
                //{
                //    return false;
                //}


                string query = @"UPDATE [dbo].[Person]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Email] = @Email
      ,[Phone] = @Phone
      ,[Image] = @Image
      ,[Gender] = @Gender
 WHERE PersonID = (Select PersonID From Instructors where InstructorID = @InstructorID);

UPDATE [dbo].[Instructors]
   SET [Qualification] = @Qualification
 WHERE InstructorID = @InstructorID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InstructorID", InstructorID);

                command.Parameters.AddWithValue("@Name", Name);

                if (Address != "")
                    command.Parameters.AddWithValue("@Address", Address);
                else
                    command.Parameters.AddWithValue("@Address", DBNull.Value);

                if (Email != "")
                    command.Parameters.AddWithValue("@Email", Email);
                else
                    command.Parameters.AddWithValue("@Email", DBNull.Value);

                if (Phone != "")
                    command.Parameters.AddWithValue("@Phone", Phone);
                else
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);

                if (Image != "")
                    command.Parameters.AddWithValue("@Image", Image);
                else
                    command.Parameters.AddWithValue("@Image", DBNull.Value);

                if (Gender != ' ')
                    command.Parameters.AddWithValue("@Gender", Address);
                else
                    command.Parameters.AddWithValue("@Gender", DBNull.Value);


                command.Parameters.AddWithValue("@Qualification", Qualification);

                try
                {
                    connection.Open();

                    RowAffact = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    RowAffact = 0;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffact > 0);
            }

            public static bool DeleteInstructor(int InstructorID)
            {

                bool IsDeleted = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select PersonID from Instructors where InstructorID = @InstructorID;
                            Delete Instructors Where InstructorID = @InstructorID";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InstructorID", InstructorID);

                try
                {
                    connection.Open();
                    int PersonID = -1;
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out PersonID))
                    {
                        clsPersonData.DeletePerson(PersonID);
                        IsDeleted = true;
                    }



                }
                catch (Exception ex)
                {
                    IsDeleted = false;
                }
                finally
                {
                    connection.Close();
                }

                return IsDeleted;

            }

            public static bool IsInstructorExiste(int InstructorID)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select Found = 1 from Instructors Where InstructorID = @InstructorID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InstructorID", InstructorID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                        IsFound = true;

                }
                catch (Exception ex)
                {
                    IsFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

            }

            public static DataTable GetAllInstructors()
            {

                DataTable InstructtorsTable = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Instructors.InstructorID, Person.Name, Person.Address, Person.Email, Person.Phone, Instructors.Qualification, Person.Image
FROM            Instructors INNER JOIN
                         Person ON Instructors.PersonID = Person.PersonID";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        InstructtorsTable.Load(reader);

                }
                catch (Exception ex)
                {
                    InstructtorsTable = null;
                }
                finally
                {
                    connection.Close();
                }

                return InstructtorsTable;

            }

        }//clsInstructor

        public class clsUserData : clsPersonData
        {

            public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string Name, ref string Address, ref string Email, ref string Phone, ref string Image,
                ref char Gender,  ref string UserName, ref string Password, ref int Peromission)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Users.UserID, Person.Name, Users.UserName, Users.Password, Person.Gender, Person.Address, Person.Email, Person.Phone, Users.Peromission, Person.Image
FROM            Users INNER JOIN
                         Person ON Users.PersonID = Person.PersonID
where Users.UserID = @UserID ;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;
                        Name = (string)reader["Name"];

                        UserName = (string)reader["UserName"];
                        Password = (string)reader["Password"];

                        Peromission = (int)reader["Peromission"];


                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";




                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                        Gender = Convert.ToChar(reader["Gender"]);

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            public static bool GetUserInfoByUserNameAndPassword(ref int UserID, ref int PersonID, ref string Name, ref string Address, ref string Email, ref string Phone, ref string Image, ref char Gender, string UserName, string Password, ref int Peromission)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT        Users.UserID, Person.Name, Users.UserName, Users.Password, Person.Gender, Person.Address, Person.Email, Person.Phone, Users.Peromission, Person.Image
FROM            Users INNER JOIN
                         Person ON Users.PersonID = Person.PersonID
where Users.UserName = @UserName and Users.Password = @Password;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;
                        Name = (string)reader["Name"];


                        UserID = (int)reader["UserID"];
                        Peromission = (int)reader["Peromission"];


                        if (reader["Address"] != DBNull.Value)
                            Address = (string)reader["Address"];
                        else
                            Address = "";

                            Gender = Convert.ToChar(reader["Gender"]);



                        if (reader["Email"] != DBNull.Value)
                            Email = (string)reader["Email"];
                        else
                            Email = "";

                        if (reader["Phone"] != DBNull.Value)
                            Phone = (string)reader["Phone"];
                        else
                            Phone = "";

                        if (reader["Image"] != DBNull.Value)
                            Image = (string)reader["Image"];
                        else
                            Image = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            public static int AddNewUser(string Name, string Address, string Email, string Phone, string Image, char Gender, string UserName, string Password, int Peromission)
            {
                int UserID = -1;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                int PersonID = clsPersonData.AddNewPerson(Name, Address, Email, Phone, Image, Gender);
                string query = @"INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[PersonID]
           ,[Peromission])
     VALUES
           (@UserName
           ,@Password
           ,@PersonID
           ,@Peromission);
		   select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@Peromission", Peromission);

                try
                {
                    connection.Open();
                    int Insert = -1;
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out Insert))
                        UserID = Insert;

                }
                catch (Exception ex)
                {
                    UserID = -1;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return UserID;
            }


            public static bool UpdateUser(int UserID, string Name, string Address, string Email, string Phone, string Image, char Gender, string UserName, string Password, int Peromission)
            {

                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"UPDATE [dbo].[Person]
   SET [Name] = @Name
      ,[Address] = @Address
      ,[Email] = @Email
      ,[Phone] = @Phone
      ,[Image] = @Image
      ,[Gender] = @Gender
 WHERE PersonID = (Select PersonID From Users where UserID = @UserID);

    UPDATE [dbo].[Users]
   SET [UserName] = @UserName
      ,[Password] = @Password
      ,[Peromission] = @Peromission
 WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);

                command.Parameters.AddWithValue("@UserName", UserName);

                command.Parameters.AddWithValue("@Password", Password);

                command.Parameters.AddWithValue("@Peromission", Peromission);

                command.Parameters.AddWithValue("@Name", Name);

                command.Parameters.AddWithValue("@Gender", Gender);

                if (Address != "")
                    command.Parameters.AddWithValue("@Address", Address);
                else
                    command.Parameters.AddWithValue("@Address", DBNull.Value);

          

                if (Email != "")
                    command.Parameters.AddWithValue("@Email", Email);
                else
                    command.Parameters.AddWithValue("@Email", DBNull.Value);

                if (Phone != "")
                    command.Parameters.AddWithValue("@Phone", Phone);
                else
                    command.Parameters.AddWithValue("@Phone", DBNull.Value);

                if (Image != "")
                    command.Parameters.AddWithValue("@Image", Image);
                else
                    command.Parameters.AddWithValue("@Image", DBNull.Value);




                try
                {
                    connection.Open();
                    RowAffect = command.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    RowAffect = 0;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);
            }

            public static bool DeleteUser(int UserID)
            {
                bool IsDeleted = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select PersonID From Users Where UserID = @UserID;
                    Delete Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);


                try
                {
                    connection.Open();
                    int PersonID = -1;
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out PersonID))
                    {
                        clsPersonData.DeletePerson(PersonID);
                        IsDeleted = true;
                    }


                }
                catch (Exception ex)
                {
                    IsDeleted = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsDeleted;

            }

            public static bool IsUserExiste(int UserID)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select Found = 1 From Users Where UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserID", UserID);


                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        IsFound = true;
                    }


                    reader.Close();
                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

            }

            public static bool IsUserExiste(string UserName, string Password)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select Found = 1 From Users Where UserName = @UserName And Password = @Password";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@UserName", UserName);
                command.Parameters.AddWithValue("@Password", Password);


                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        IsFound = true;
                    }


                    reader.Close();
                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

            }



            public static DataTable GetAllUsers()
            {
                DataTable UsersTable = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"SELECT Users.UserID, Person.Name, Users.UserName, Users.Password, Person.Gender, Person.Address, Person.Email, Person.Phone, Users.Peromission, Person.Image
FROM            Users INNER JOIN
                         Person ON Users.PersonID = Person.PersonID";

                SqlCommand command = new SqlCommand(query, connection);



                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        UsersTable.Load(reader);
                    }


                    reader.Close();
                }
                catch (Exception ex)
                {
                    UsersTable = null;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return UsersTable;

            }


        }//clsUserData

        public class clsMemberInstructorData
        {

            public static bool GetMemberInstructorInfoByInstructorIDAndMemberID(int InstructorID, int MemberID, ref DateTime AssignDate)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from MemberInstructors where InstructorID = @InstructorID and MemberID = @MemberID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@InstructorID", InstructorID);
                command.Parameters.AddWithValue("@MemberID", MemberID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        IsFound = true;
                        AssignDate = (DateTime)reader["AssignDate"];

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;



            }

            public static bool AddNewMemberInstructor(int InstructorID, int MemberID, DateTime AssignDate)
            {
                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"INSERT INTO [dbo].[MemberInstructors]
           ([MemberID]
           ,[InstructorID]
           ,[AssignDate])
     VALUES
           (@MemberID
           ,@InstructorID
           ,@AssignDate)";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@InstructorID", InstructorID);
                command.Parameters.AddWithValue("@MemberID", MemberID);
                command.Parameters.AddWithValue("@AssignDate", AssignDate);


                try
                {
                    connection.Open();

                    RowAffect = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect >0);
            }

            public static bool UpdateMemberInstructor(int InstructorID, int MemberID, DateTime AssignDate)
            {
                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"UPDATE [dbo].[MemberInstructors]
   SET [MemberID] = @MemberID
      ,[InstructorID] = @InstructorID
      ,[AssignDate] = @AssignDate
 WHERE InstructorID = @InstructorID and MemberID = @MemberID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@InstructorID", InstructorID);
                command.Parameters.AddWithValue("@MemberID", MemberID);
                command.Parameters.AddWithValue("@AssignDate", AssignDate);


                try
                {
                    connection.Open();

                    RowAffect = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);
            }

            public static bool DeleteMemberInstructor(int InstructorID, int MemberID)
            {
                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Delete MemberInstructors  WHERE InstructorID = @InstructorID and MemberID = @MemberID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@InstructorID", InstructorID);
                command.Parameters.AddWithValue("@MemberID", MemberID);


                try
                {
                    connection.Open();

                    RowAffect = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);
            }

            public static bool IsMemberInstructorExsite(int InstructorID, int MemberID)
            {
                bool IsFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select Found = 1 From  MemberInstructors  WHERE InstructorID = @InstructorID and MemberID = @MemberID";


                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@InstructorID", InstructorID);
                command.Parameters.AddWithValue("@MemberID", MemberID);


                try
                {
                    connection.Open();

                   SqlDataReader reader  = command.ExecuteReader();
                   if (reader.Read())
                       IsFound = true;
                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            public static DataTable GetAllMemberInstructors()
            {
                DataTable MemberInstructorsTable = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from MemberInstructors";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MemberInstructorsTable.Load(reader);

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    MemberInstructorsTable= null;

                }
                finally
                {
                    connection.Close();
                }

                return MemberInstructorsTable;



            }


        }//clsMemberInstructorData


        public class clsPaymentData
        {
            public static bool GetPaymentInfoByID(int PaymentID, ref decimal Amount, ref DateTime Date, ref int MemberID, ref string PaymentType)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from Payment where PaymentID = @PaymentID;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PaymentID", PaymentID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;

                        MemberID = (int)reader["MemberID"];
                        Amount = (decimal)reader["Amount"];
                        Date = (DateTime)reader["Date"];

                        if (reader["PaymentType"] != DBNull.Value)
                            PaymentType = (string)reader["PaymentType"];
                        else
                            PaymentType = "";

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

            }


            public static int AddNewPaymentRecord( decimal Amount,  DateTime Date,  int MemberID,  string PaymentType)
            {
                int PaymentID = -1; 
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"INSERT INTO [dbo].[Payment]
           ([Amount]
           ,[Date]
           ,[MemberID]
           ,[PaymentType])
     VALUES
           (@Amount
           ,@Date
           ,@MemberID
           ,@PaymentType);
		   select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@MemberID", MemberID);

                if (PaymentType != "")
                command.Parameters.AddWithValue("@PaymentType", PaymentType);
                else
                    command.Parameters.AddWithValue("@PaymentType", DBNull.Value);


                try
                {
                    connection.Open();
                    int Insert = -1;
                    object result  = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out Insert))
                    {
                        PaymentID = Insert;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    PaymentID = -1;
                }
                finally
                {
                    connection.Close();
                }

                return PaymentID;
            }


            public static bool UpdatePaymentRecord(int PaymentID,decimal Amount, DateTime Date, int MemberID, string PaymentType)
            {
                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"UPDATE [dbo].[Payment]
   SET [Amount] = @Amount
      ,[Date] = @Date
      ,[MemberID] = @MemberID
      ,[PaymentType] = @PaymentType
 WHERE PaymentID = @PaymentID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@PaymentID", PaymentID);
                command.Parameters.AddWithValue("@Amount", Amount);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@MemberID", MemberID);

                if (PaymentType != "")
                    command.Parameters.AddWithValue("@PaymentType", PaymentType);
                else
                    command.Parameters.AddWithValue("@PaymentType", DBNull.Value);


                try
                {
                    connection.Open();

                    RowAffect = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);
            }

            public static bool DeletePaymentRecord(int PaymentID)
            {
                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Delete Payment WHERE PaymentID = @PaymentID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@PaymentID", PaymentID);


                try
                {
                    connection.Open();

                    RowAffect = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);
            }


            public static bool IsPaymentRecordExiste(int PaymentID)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select Found = 1 from Payment where PaymentID = @PaymentID;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PaymentID", PaymentID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        IsFound = true;
                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;



            }

            public static DataTable GetAllPaymentRecords()
            {
                DataTable PaymentsTable = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from Payment";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        PaymentsTable.Load(reader);



                    reader.Close();

                }
                catch (Exception ex)
                {
                    PaymentsTable = null;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return PaymentsTable;

            }


        }//clsPaymentData

        public class clsPeriodData
        {

            public static bool GetPeriodsByID(int PeriodID, ref DateTime StartDate, ref  DateTime EndDate, ref decimal Fees, ref bool Paid, ref int MemberID, ref int PaymentID)
            {
                
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from SubscriptionPeriods where PeriodID = @PeriodID;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PeriodID", PeriodID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        IsFound = true;


                        StartDate = (DateTime)reader["StartDate"];
                        EndDate = (DateTime)reader["EndDate"];
                        Fees = (decimal)reader["Fees"];
                        Paid = (bool)reader["Paid"];
                        MemberID = (int)reader["MemberID"];

                        if (reader["PaymentID"] != DBNull.Value)
                            PaymentID = (int)reader["PaymentID"];
                        else
                            PaymentID = -1;
                                
                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

                
            }


            public static int AddNewPeriod(DateTime StartDate, DateTime EndDate, decimal Fees, bool Paid, int MemberID, int PaymentID)
            {
                int PeriodID = -1;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"INSERT INTO [dbo].[SubscriptionPeriods]
           ([StartDate]
           ,[EndDate]
           ,[Fees]
           ,[Paid]
           ,[MemberID]
           ,[PaymentID])
     VALUES
           (@StartDate
           ,@EndDate
           ,@Fees
           ,@Paid
           ,@MemberID
           ,@PaymentID);
		   select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@StartDate", StartDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);
                command.Parameters.AddWithValue("@MemberID", MemberID);
                command.Parameters.AddWithValue("@Fees", Fees);
                command.Parameters.AddWithValue("@Paid", Paid);

                if (PaymentID != -1)
                    command.Parameters.AddWithValue("@PaymentID", PaymentID);
                else
                    command.Parameters.AddWithValue("@PaymentID", DBNull.Value);


                try
                {
                    connection.Open();
                    int Insert = -1;
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out Insert))
                    {
                        PeriodID = Insert;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    PeriodID = -1;
                }
                finally
                {
                    connection.Close();
                }

                return PeriodID;
                
            }


            public static bool UpdatePeriod(int PeriodID, DateTime StartDate, DateTime EndDate, decimal Fees, bool Paid, int MemberID, int PaymentID)
            {
                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"UPDATE [dbo].[SubscriptionPeriods]
   SET [StartDate] = @StartDate
      ,[EndDate] = @EndDate
      ,[Fees] = @Fees
      ,[Paid] = @Paid
      ,[MemberID] = @MemberID
      ,[PaymentID] = @PaymentID
 WHERE PeriodID = @PeriodID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PeriodID", PeriodID);
                command.Parameters.AddWithValue("@StartDate", StartDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);
                command.Parameters.AddWithValue("@MemberID", MemberID);
                command.Parameters.AddWithValue("@Fees", Fees);
                command.Parameters.AddWithValue("@Paid", Paid);

                if (PaymentID != -1)
                    command.Parameters.AddWithValue("@PaymentID", PaymentID);
                else
                    command.Parameters.AddWithValue("@PaymentID", DBNull.Value);

                try
                {
                    connection.Open();
                    RowAffect = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    RowAffect = -1;
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect >0);
            }


            public static bool DeletePeriod(int PeriodID)
            {
                int RowAffect = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Delete SubscriptionPeriods WHERE PeriodID = @PeriodID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PeriodID", PeriodID);

                try
                {
                    connection.Open();
                    RowAffect = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    RowAffect = -1;
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);
            }



            public static bool IsPeriodExiste(int PeriodID)
            {
                bool IsFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Select found = 1 from SubscriptionPeriods WHERE PeriodID = @PeriodID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PeriodID", PeriodID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        IsFound = true;

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    IsFound = false ;
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            public static DataTable GetAllPeriods()
            {
                DataTable PeriodsTable = new DataTable();

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Select * from SubscriptionPeriods;";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        PeriodsTable.Load(reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    PeriodsTable = null;
                }
                finally
                {
                    connection.Close();
                }

                return PeriodsTable;
            }


        }//clsSubscriptionPeriods

        public class clsBeltRankData
        {

            public static bool GetBeltRankByID(int RankID, ref string RankName, ref decimal TestFees)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from BeltRank where RankID = @RankID;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RankID", RankID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        IsFound = true;
                        RankName = (string)reader["RankName"];
                        TestFees = (decimal)reader["TestFees"];

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            public static bool GetBeltRankByName(ref int RankID,  string RankName, ref decimal TestFees)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from BeltRank where RankName = @RankName;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RankName", RankName);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        IsFound = true;
                        RankID = (int)reader["RankID"];
                        TestFees = (decimal)reader["TestFees"];

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }



            public static int AddNewRank(string RankName,  decimal TestFees)
            {
                int RankID = -1;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"INSERT INTO [dbo].[BeltRank]
           ([RankName]
           ,[TestFees])
     VALUES
           (@RankName
           ,@TestFees);
		   select SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RankID", RankID);
                command.Parameters.AddWithValue("@RankName", RankName);
                command.Parameters.AddWithValue("@TestFees", TestFees);

                try
                {
                    connection.Open();
                    int Insert = -1;

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out Insert))
                        RankID = Insert;

                    

                }
                catch (Exception ex)
                {
                    RankID = -1;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return RankID;
            }

            public static bool UpdateRank(int RankID, string RankName, decimal TestFees)
            {
                int RowAffact = 0;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"UPDATE [dbo].[BeltRank]
   SET [RankName] = @RankName
      ,[TestFees] = @TestFees
 WHERE RankID = @RankID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RankID", RankID);
                command.Parameters.AddWithValue("@RankName", RankName);
                command.Parameters.AddWithValue("@TestFees", TestFees);

                try
                {
                    connection.Open();

                    RowAffact = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    RowAffact = -1;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffact>0);
            }

            public static bool DeleteRank(int RankID)
            {
                int RowAffact = 0;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Delete BeltRank WHERE RankID = @RankID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RankID", RankID);

                try
                {
                    connection.Open();

                    RowAffact = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    RowAffact = -1;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return (RowAffact > 0);
            }

            public static bool IsRankExiste(int RankID)
            {
                bool IsFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Select Found =1 from BeltRank WHERE RankID = @RankID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@RankID", RankID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        IsFound = true;

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }

            public static DataTable GetAllBeltRanks()
            {
                DataTable BeltRanksTable = new DataTable();

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Select * from BeltRank;";

                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        BeltRanksTable.Load(reader);

                    reader.Close();

                }
                catch (Exception ex)
                {
                    BeltRanksTable = null;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return BeltRanksTable;
            }

        }//clsBeltRankData

        public class clsBeltTestData
        {
            public static bool GetBeltTestByID(int TestID, ref int MemberID, ref int RankID, ref bool Result, ref DateTime Date, ref int TestedByInstructorID, ref int PaymentID)
            {

                bool IsFound = false;
                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"select * from BeltTest where TestID = @TestID;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        IsFound = true;
                        MemberID = (int)reader["MemberID"];
                        RankID = (int)reader["RankID"];
                        Result = (bool)reader["Result"];
                        Date = (DateTime)reader["Date"];
                        TestedByInstructorID = (int)reader["TestedByInstructorID"];
                        if(reader["PaymentID"] != DBNull.Value)
                        PaymentID = (int)reader["PaymentID"];
                        else
                            PaymentID = -1;

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    IsFound = false;
                    Console.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return IsFound;
            }


            public static int AddNewBeltTest(int MemberID,  int RankID,  bool Result,  DateTime Date,  int TestedByInstructorID,  int PaymentID)
            {
                int TestID = -1;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"INSERT INTO [dbo].[BeltTest]
           ([MemberID]
           ,[RankID]
           ,[Result]
           ,[Date]
           ,[TestedByInstructorID]
           ,[PaymentID])
     VALUES
           (@MemberID
           ,@RankID
           ,@Result
           ,@Date
           ,@TestedByInstructorID
           ,@PaymentID);
		   select SCOPE_IDENTITY();";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MemberID", MemberID);
                command.Parameters.AddWithValue("@RankID", RankID);
                command.Parameters.AddWithValue("@Result", Result);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@TestedByInstructorID", TestedByInstructorID);

                if (PaymentID != -1)
                   command.Parameters.AddWithValue("@PaymentID", PaymentID);
                else
                    command.Parameters.AddWithValue("@PaymentID", DBNull.Value);

                try
                {
                    connection.Open();
                    int Insert = -1;

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out Insert))
                        TestID = Insert;
                }
                catch (Exception ex)
                {
                    TestID = -1;

                }
                finally
                {
                    connection.Close();
                }

                return TestID;

            }


            public static bool UpdateBeltTest(int TestID, int MemberID, int RankID, bool Result, DateTime Date, int TestedByInstructorID, int PaymentID)
            {
                int RowAffect = 0;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"UPDATE [dbo].[BeltTest]
   SET [MemberID] = @MemberID
      ,[RankID] = @RankID
      ,[Result] = @Result
      ,[Date] = @Date 
      ,[TestedByInstructorID] = @TestedByInstructorID
      ,[PaymentID] = @PaymentID
 WHERE TestID = @TestID";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);
                command.Parameters.AddWithValue("@MemberID", MemberID);
                command.Parameters.AddWithValue("@RankID", RankID);
                command.Parameters.AddWithValue("@Result", Result);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@TestedByInstructorID", TestedByInstructorID);

                if (PaymentID != -1)
                    command.Parameters.AddWithValue("@PaymentID", PaymentID);
                else
                    command.Parameters.AddWithValue("@PaymentID", DBNull.Value);

                try
                {
                    connection.Open();

                    RowAffect = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    RowAffect = -1;

                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);

            }

            public static bool DeleteBeltTest(int TestID)
            {
                int RowAffect = 0;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Delete BeltTest  WHERE TestID = @TestID";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();

                    RowAffect = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    RowAffect = -1;

                }
                finally
                {
                    connection.Close();
                }

                return (RowAffect > 0);

            }

            public static bool IsBeltTestExiste(int TestID)
            {
                bool IsFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Select Found =1 from  BeltTest  WHERE TestID = @TestID";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        IsFound = true;
                }
                catch (Exception ex)
                {
                    IsFound = false;

                }
                finally
                {
                    connection.Close();
                }

                return IsFound;

            }

            public static DataTable GetAllBeltTestes()
            {
                DataTable BeltTestsTable = new DataTable();

                SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                string query = @"Select  * from  BeltTest;";


                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                        BeltTestsTable.Load(reader);
                }
                catch (Exception ex)
                {
                    BeltTestsTable = null;

                }
                finally
                {
                    connection.Close();
                }

                return BeltTestsTable;

            }


        }//clsBeltRankData


}
