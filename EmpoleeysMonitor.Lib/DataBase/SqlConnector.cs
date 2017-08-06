using EmpoleeysMonitor.Lib.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoleeysMonitor.Lib.DataBase
{
    class SqlConnector
    {
        static string host = "149.156.136.151";
        static string port = "1521";
        static string sid = "orcl";
        static string login = "ii245";
        static string password = "Zabawa";

        OracleConnection connection;
        OracleCommand command;
        User user;

        public SqlConnector()
        {
            Initialize();
        }
        void Initialize()
        {
            user = new User();
        }
        string GetConnectionString()
        {
            return String.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SID={2})));User Id={3};Password={4};", host, port, sid, login, password);
        }

        void SetOracleCommand(string oracleConnection, string name = "")
        {
            command = new OracleCommand(oracleConnection + name, connection);
            command.CommandType = CommandType.StoredProcedure;
        }

        public async Task Connect()
        {
            try
            {
                await Task.Run(async () =>
                {
                    await connection.OpenAsync();
                });
            }
            catch (Exception)
            {
                //ShowMessageBox("Connection failed.", "Cannot connect to sql database.\nCheck your connection and try again.");
                connection.Close();
                throw;
            }
        }

        public async Task AddUserAction(string id_user, string id_action, string info)
        {
            using (connection = new OracleConnection(GetConnectionString()))
            {
                await Connect();

                SetOracleCommand("ADD_USER_ACTION");

                command.Parameters.Add("@id_user", id_user);
                command.Parameters.Add("@id_action", id_action);
                command.Parameters.Add("@info", info);
                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    //ShowMessageBox("Incorect SQL query.", "Insertig user activity into table failed.");
                    connection.Close();
                    return;
                }
                connection.Close();
            }
        }

        public async Task<User> FindUser(string input, string name)
        {
            using (connection = new OracleConnection(GetConnectionString()))
            {
                user = new User();
                await Connect();

                SetOracleCommand("FIND_BY_", name);

                OracleParameter i_parm = new OracleParameter("@" + name, input);
                i_parm.Value = input;
                i_parm.Direction = ParameterDirection.Input;
                command.Parameters.Add(i_parm);

                OracleParameter o_parm = new OracleParameter();
                o_parm.OracleDbType = OracleDbType.RefCursor;
                o_parm.Direction = ParameterDirection.Output;
                command.Parameters.Add(o_parm);

                try
                {
                    using (var dataReader = await command.ExecuteReaderAsync())
                    {
                        while (dataReader.Read())
                        {
                            user.Login = Convert.ToString(dataReader["LOGIN"]);
                            user.Password = Convert.ToString(dataReader["PASSWORD"]);
                            user.Name = Convert.ToString(dataReader["NAME"]);
                            user.Surname = Convert.ToString(dataReader["SURNAME"]);
                      //      user.Role = Convert.ToString(dataReader["ROLE"]);
                        }
                    }
                    //connection.Close();
                }
                catch (Exception)
                {
                    //ShowMessageBox("Incorect SQL query.", "Executing query failed. Table does not exist, or field 'LOGIN' or 'PASSWORD' is missing.");
                    connection.Close();
                    throw;
                }
                return user;
            }
        }

        public async Task<bool> DoUserExist(string input, string name)
        {
            int counter = 0;

            using (connection = new OracleConnection(GetConnectionString()))
            {
                await Connect();

                SetOracleCommand("COUNT_BY_", name);

                OracleParameter i_parm = new OracleParameter("@" + name, input);
                i_parm.Value = input;
                i_parm.Direction = ParameterDirection.Input;
                command.Parameters.Add(i_parm);

                OracleParameter o_parm = new OracleParameter("@counter", counter);
                o_parm.Direction = ParameterDirection.Output;
                command.Parameters.Add(o_parm);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    counter = (int)command.Parameters["@counter"].Value;
                    connection.Close();
                    return !(counter == 0);

                }
                catch (Exception)
                {
                    // ShowMessageBox("Incorect SQL query.", "Table does not exist, or some of the filed are missing.");
                    connection.Close();
                    return false;
                }
            }
        }
    }
}
