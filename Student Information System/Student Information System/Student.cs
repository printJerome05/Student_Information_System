using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Student_Information_System
{
    class Student
    {
        Class1 db = new Class1();


        public bool insertStudent(string fname, string lname, string mname, DateTime bdate, string contact, string gender, string adress, string Grade, string Lrn, string GuardianFn, string GuardianLn, string GuardianMn, string GuardianCon, string GuardianEm, string StuEmail, string BirthPlace, string age, string FatherF, string FatherL, string FatherI, string FatherE, string FatherC, string FatherO, string MotherF, string MotherL, string MotherI, string MotherE, string MotherC, string MotherO, MemoryStream picture, string psa, string reportcard, string sf10, string goodmoral)
        {

            //Lrn GuardianFn GuardianLn GuardianMn GuardianCon GuardianEm

            MySqlCommand comm = new MySqlCommand("INSERT INTO `student`(`first_name`, `last_name`, `middle_name`, `bday`, `contact`, `gender`, `address`, `Grade`, `Lrn`, `Guardian_FirstName`, `Guardian_LastName`, `Guardian_MiddleName`, `Guardian_Contact`, `Guardian_Email`, `StuEmail`, `BirthPlace`, `age`, `FatherF`, `FatherL`, `FatherI`, `FatherE`, `FatherC`, `FatherO`, `MotherF`, `MotherL`, `MotherI`, `MotherE`, `MotherC`, `MotherO`, `picture`, `PSA`, `REPORTCARD`, `SF10`, `GOODMORAL`) VALUES (@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuardianCon,@GuardianEm,@StuEmail,@BirthPlace,@age,@FatherF,@FatherL,@FatherI,@FatherE,@FatherC,@FatherO,@MotherF,@MotherL,@MotherI,@MotherE,@MotherC,@MotherO,@pic,@psa,@reportcard,@sf10,@goodmoral)", db.GetConnection);

            //@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuradianCon,@GuardianEm,@pic      
            comm.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            comm.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            comm.Parameters.Add("@mn", MySqlDbType.VarChar).Value = mname;
            comm.Parameters.Add("@bdt", MySqlDbType.Date).Value = bdate;
            comm.Parameters.Add("@cont", MySqlDbType.VarChar).Value = contact;
            comm.Parameters.Add("@gdr", MySqlDbType.VarChar).Value = gender;
            comm.Parameters.Add("@adr", MySqlDbType.Text).Value = adress;
            comm.Parameters.Add("@Grade", MySqlDbType.VarChar).Value = Grade;
            comm.Parameters.Add("@Lrn", MySqlDbType.VarChar).Value = Lrn;
            comm.Parameters.Add("@GuardianFn", MySqlDbType.VarChar).Value = GuardianFn;
            comm.Parameters.Add("@GuardianLn", MySqlDbType.VarChar).Value = GuardianLn;
            comm.Parameters.Add("@GuardianMn", MySqlDbType.VarChar).Value = GuardianMn;
            comm.Parameters.Add("@GuardianCon", MySqlDbType.VarChar).Value = GuardianCon;
            comm.Parameters.Add("@GuardianEm", MySqlDbType.VarChar).Value = GuardianEm;

            comm.Parameters.Add("@StuEmail", MySqlDbType.VarChar).Value = StuEmail;
            comm.Parameters.Add("@BirthPlace", MySqlDbType.VarChar).Value = BirthPlace;
            comm.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;

            comm.Parameters.Add("@FatherF", MySqlDbType.VarChar).Value = FatherF;
            comm.Parameters.Add("@FatherL", MySqlDbType.VarChar).Value = FatherL;
            comm.Parameters.Add("@FatherI", MySqlDbType.VarChar).Value = FatherI;
            comm.Parameters.Add("@FatherE", MySqlDbType.VarChar).Value = FatherE;
            comm.Parameters.Add("@FatherC", MySqlDbType.VarChar).Value = FatherC;
            comm.Parameters.Add("@FatherO", MySqlDbType.VarChar).Value = FatherO;

            comm.Parameters.Add("@MotherF", MySqlDbType.VarChar).Value = MotherF;
            comm.Parameters.Add("@MotherL", MySqlDbType.VarChar).Value = MotherL;
            comm.Parameters.Add("@MotherI", MySqlDbType.VarChar).Value = MotherI;
            comm.Parameters.Add("@MotherE", MySqlDbType.VarChar).Value = MotherE;
            comm.Parameters.Add("@MotherC", MySqlDbType.VarChar).Value = MotherC;
            comm.Parameters.Add("@MotherO", MySqlDbType.VarChar).Value = MotherO;





            // StuEmail, BirthPlace, age, FatherF, FatherL, FatherI, FatherE, FatherC, FatherO, MotherF, MotherL, MotherI, MotherE, MotherC, MotherO 





            comm.Parameters.Add("@pic", MySqlDbType.LongBlob).Value = picture.ToArray();

            //@psa @reportcard@sf10 @goodmoral
            comm.Parameters.Add("@psa", MySqlDbType.VarChar).Value = psa;
            comm.Parameters.Add("@reportcard", MySqlDbType.VarChar).Value = reportcard;
            comm.Parameters.Add("@sf10", MySqlDbType.VarChar).Value = sf10;
            comm.Parameters.Add("@goodmoral", MySqlDbType.VarChar).Value = goodmoral;

            db.openConnection();


            if (comm.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }


        }

        public DataTable getStudents(MySqlCommand comm)
        {

            comm.Connection = db.GetConnection;
            MySqlDataAdapter adpt = new MySqlDataAdapter(comm);
            DataTable tbl = new DataTable();
            adpt.Fill(tbl);

            return tbl;
        }

        public bool updateStudent(int id,string fname,string lname,string mname,DateTime bdate,string contact,string gender,string adress,string Grade,string Lrn,string GuardianFn,string GuardianLn,string GuardianMn,string GuardianCon,string GuardianEm,string StuEmail,string BirthPlace,string age,string FatherF,string FatherL,string FatherI,string FatherE,string FatherC,string FatherO,string MotherF,string MotherL,string MotherI,string MotherE,string MotherC,string MotherO, MemoryStream picture,string psa,string reportcard,string sf10,string goodmoral)
        {
            MySqlCommand comm = new MySqlCommand("UPDATE `student` SET `first_name`=@fn,`last_name`=@ln,`middle_name`=@mn,`bday`=@bdt,`contact`=@cont,`gender`=@gdr,`address`=@adr,`Grade`=@Grade,`Lrn`=@Lrn,`Guardian_FirstName`=@GuardianFn,`Guardian_LastName`=@GuardianLn,`Guardian_MiddleName`=@GuardianMn,`Guardian_Contact`=@GuardianCon,`Guardian_Email`=@GuardianEm,`StuEmail`=@StuEmail,`BirthPlace`=@BirthPlace,`age`=@age,`FatherF`=@FatherF,`FatherL`=@FatherL,`FatherI`=@FatherI,`FatherE`=@FatherE,`FatherC`=@FatherC,`FatherO`=@FatherO,`MotherF`=@MotherF,`MotherL`=@MotherL,`MotherI`=@MotherI,`MotherE`=@MotherE,`MotherC`=@MotherC,`MotherO`=@MotherO,`picture`=@pic,`PSA`=@psa,`REPORTCARD`=@reportcard,`SF10`=@sf10,`GOODMORAL`=@goodmoral WHERE `id`=@ID", db.GetConnection);

                                                                                                                                                                                                     //@fn,@ln,@mn,@bdt,@cont,@gdr,@adr,@Grade,@Lrn,@GuardianFn,@GuardianLn,@GuardianMn,@GuradianCon,@GuardianEm,@pic  
            comm.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            comm.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            comm.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            comm.Parameters.Add("@mn", MySqlDbType.VarChar).Value = mname;
            comm.Parameters.Add("@bdt", MySqlDbType.Date).Value = bdate;
            comm.Parameters.Add("@cont", MySqlDbType.VarChar).Value = contact;
            comm.Parameters.Add("@gdr", MySqlDbType.VarChar).Value = gender;
            comm.Parameters.Add("@adr", MySqlDbType.Text).Value = adress;
            comm.Parameters.Add("@Grade", MySqlDbType.VarChar).Value = Grade;
            comm.Parameters.Add("@Lrn", MySqlDbType.VarChar).Value = Lrn;

            comm.Parameters.Add("@GuardianFn", MySqlDbType.VarChar).Value = GuardianFn;
            comm.Parameters.Add("@GuardianLn", MySqlDbType.VarChar).Value = GuardianLn;
            comm.Parameters.Add("@GuardianMn", MySqlDbType.VarChar).Value = GuardianMn;
            comm.Parameters.Add("@GuardianCon", MySqlDbType.VarChar).Value = GuardianCon;
            comm.Parameters.Add("@GuardianEm", MySqlDbType.VarChar).Value = GuardianEm;

            comm.Parameters.Add("@StuEmail", MySqlDbType.VarChar).Value = StuEmail;
            comm.Parameters.Add("@BirthPlace", MySqlDbType.VarChar).Value = BirthPlace;
            comm.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;

            comm.Parameters.Add("@FatherF", MySqlDbType.VarChar).Value = FatherF;
            comm.Parameters.Add("@FatherL", MySqlDbType.VarChar).Value = FatherL;
            comm.Parameters.Add("@FatherI", MySqlDbType.VarChar).Value = FatherI;
            comm.Parameters.Add("@FatherE", MySqlDbType.VarChar).Value = FatherE;
            comm.Parameters.Add("@FatherC", MySqlDbType.VarChar).Value = FatherC;
            comm.Parameters.Add("@FatherO", MySqlDbType.VarChar).Value = FatherO;

            comm.Parameters.Add("@MotherF", MySqlDbType.VarChar).Value = MotherF;
            comm.Parameters.Add("@MotherL", MySqlDbType.VarChar).Value = MotherL;
            comm.Parameters.Add("@MotherI", MySqlDbType.VarChar).Value = MotherI;
            comm.Parameters.Add("@MotherE", MySqlDbType.VarChar).Value = MotherE;
            comm.Parameters.Add("@MotherC", MySqlDbType.VarChar).Value = MotherC;
            comm.Parameters.Add("@MotherO", MySqlDbType.VarChar).Value = MotherO;

            comm.Parameters.Add("@pic", MySqlDbType.LongBlob).Value = picture.ToArray();

            comm.Parameters.Add("@psa", MySqlDbType.VarChar).Value = psa;
            comm.Parameters.Add("@reportcard", MySqlDbType.VarChar).Value = reportcard;
            comm.Parameters.Add("@sf10", MySqlDbType.VarChar).Value = sf10;
            comm.Parameters.Add("@goodmoral", MySqlDbType.VarChar).Value = goodmoral;

            // `PSA`=@psa, `REPORTCARD`=@reportcard, `SF10`=@sf10, `GOODMORAL`=@goodmoral


            db.openConnection();


            if (comm.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool archiveStudent(int id)
        {
            MySqlCommand comm = new MySqlCommand("INSERT INTO `archive`(id,first_name,last_name,middle_name,bday,contact,gender,address,Grade,Lrn,Guardian_FirstName,Guardian_LastName,Guardian_MiddleName,Guardian_Contact,Guardian_Email,StuEmail,BirthPlace,age,FatherF,FatherL,FatherI,FatherE,FatherC,FatherO,MotherF,MotherL,MotherI,MotherE,MotherC,MotherO,picture,PSA,REPORTCARD,SF10,GOODMORAL) SELECT * from `student` WHERE `id`=@studentID;Delete from `student` Where `id`= @studentID", db.GetConnection);
           
            
            comm.Parameters.Add("@studentID", MySqlDbType.Int32).Value = id;
            


        
            db.openConnection();

            if (comm.ExecuteNonQuery() == 1)
            {
                
                
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool recoverStudent(int id)
        {
            MySqlCommand comm = new MySqlCommand("INSERT INTO `student`(id,first_name,last_name,middle_name,bday,contact,gender,address,Grade,Lrn,Guardian_FirstName,Guardian_LastName,Guardian_MiddleName,Guardian_Contact,Guardian_Email,StuEmail,BirthPlace,age,FatherF,FatherL,FatherI,FatherE,FatherC,FatherO,MotherF,MotherL,MotherI,MotherE,MotherC,MotherO,picture,PSA,REPORTCARD,SF10,GOODMORAL) SELECT * from `archive` WHERE `id`=@studentID;Delete from `archive` Where `id`= @studentID", db.GetConnection);


            comm.Parameters.Add("@studentID", MySqlDbType.Int32).Value = id;




            db.openConnection();

            if (comm.ExecuteNonQuery() == 1)
            {


                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool deleteStudent(int id)
        {
            MySqlCommand comm = new MySqlCommand("DELETE FROM `archive` WHERE `id`= @studentID", db.GetConnection);

            //@ID 
            comm.Parameters.Add("@studentID", MySqlDbType.Int32).Value = id;
            
            db.openConnection();


            if (comm.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public string exeCount(string query)
        {
            MySqlCommand comm = new MySqlCommand(query, db.GetConnection);

            db.openConnection();
            string count = comm.ExecuteScalar().ToString();
            db.closeConnection();

            return count;
        }

        public string totalStudents()
        {
            return exeCount("SELECT COUNT(*) FROM `student`");
        }

        public string totalMaleStudents()
        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `gender` ='Male'");
        }

        public string totalFemaleStudents()
        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `gender` ='Female'");
        }

        public string totalGrade1Students()

        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `Grade` ='Grade 1'");
        }
        public string totalGrade2Students()

        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `Grade` ='Grade 2'");
        }

        public string totalGrade3Students()

        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `Grade` ='Grade 3'");
        }
        public string totalGrade4Students()

        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `Grade` ='Grade 4'");
        }
        public string totalGrade5Students()

        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `Grade` ='Grade 5'");
        }
        public string totalGrade6Students()

        {
            return exeCount("SELECT COUNT(*) FROM `student` WHERE `Grade` ='Grade 6'");
        }






    }
}
