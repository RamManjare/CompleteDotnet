namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;
public class DBManager
{
public static string conString=@"server=localhost;port=3306;user=root;password=root123;database=compony";

public static List<Employee> GetAllEmp(){
    List<Employee> allemp= new List<Employee>();
    MySqlConnection con=new MySqlConnection(conString);
    try{
        con.Open();
        string query="select * from emp";
        DataSet ds=new DataSet();
        MySqlCommand cmd=new MySqlCommand(query,con);
        MySqlDataAdapter da=new MySqlDataAdapter(cmd);
        da.Fill(ds);

        DataTable dt=ds.Tables[0];
        DataRowCollection rows=dt.Rows;
        foreach(DataRow row in rows){
            Employee emp=new Employee
            {
                eid=int.Parse(row["eid"].ToString()),
                ename=row["ename"].ToString(),
                designation=row["designation"].ToString()
            };
            allemp.Add(emp);
        }
    }
    catch(Exception e){Console.WriteLine(e.Message);}
    finally{con.Close();}
    return allemp;
}
public static void SaveEmp(Employee emp){
    MySqlConnection con=new MySqlConnection(conString);
    try{
        con.Open();
        string query=$"insert into employee(ename,designation) values('{emp.ename}','{emp.designation}')";
        MySqlCommand cmd=new MySqlCommand(query,con);
        cmd.ExecuteNonQuery();
    }
    catch(Exception e){Console.WriteLine(e.Message);}
    finally{con.Close();}

}

}
