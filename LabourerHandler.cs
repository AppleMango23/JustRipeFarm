using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _16102019P1S2
{
    public class LabourerHandler
    {
        public int addNewLabourer(MySqlConnection conn, Labourer labourer)
        {
            string sql = "INSERT INTO labourer (name, age, gender, dateAndTime) "
                + " VALUES ('" + labourer.Name + "', " + labourer.Age
                + " , '" + labourer.Gender + "', '" + labourer.DateAndTime +"')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            return sqlComm.ExecuteNonQuery();
        }

        //Just added this
        public List <Labourer> getAllLabourer(MySqlConnection conn)
        {
            List<Labourer> listLabr = new List<Labourer>();

            string sql = "SELECT * FROM labourer WHERE 1";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            //try
            //{
                MySqlDataReader myReader;
                myReader = sqlComm.ExecuteReader();

                while(myReader.Read())
                {
                    Labourer aLabr = new Labourer();
                    aLabr.Id = (int)myReader.GetValue(0);
                    aLabr.Name = (string)myReader.GetValue(1);
                    aLabr.Age = (int)myReader.GetValue(2);


                    listLabr.Add(aLabr);
                }
            //}
            return listLabr;
        }

}
}
