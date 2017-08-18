using EmployeesMonitor.Lib.Model;
using Npgsql;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace EmployeesMonitor.Lib.DataBase
{
    public class SqlConnector
    {
        private const string serverName = "horton.elephantsql.com";
        private const string databaseName = "shaybbbb";
        private const string userName = "shaybbbb";
        private const string password = "FmyW_DXjK9B1mskGELS3SWIchp8MGKsC";
       //  static string host = "149.156.136.151";
       //  static string login = "ii245";
       //  static string password = "Zabawa";

        private NpgsqlConnection connection;
        private NpgsqlCommand command;

        public SqlConnector()
        {
            connection = new NpgsqlConnection(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return string.Format("Server={0};User Id={1};Password={2};Database={3};", serverName, userName, password, databaseName);
           // return String.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SID={2})));User Id={3};Password={4};", host, port, sid, login, password);
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
            catch (Exception ex)
            {              
                connection.Close();
                throw new Exception("Cannot connect to sql database.\nCheck your connection and try again.", ex);
            }
        }

        public async Task AddUserAction(UserAction action)
        {
            try 
            {
                using (connection = new NpgsqlConnection(GetConnectionString()))
                {
                    await Connect();

                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO user_actions (id_user, id_project, id_action_type, action_date, info) VALUES (@id_user, @id_project, @id_type, @date, @info)";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id_user", action.UserId);
                        command.Parameters.AddWithValue("@id_project", action.ProjectId);
                        command.Parameters.AddWithValue("@id_type", (int) action.ActionType);
                        command.Parameters.AddWithValue("@info", action.Info ?? (object) DBNull.Value);
                        command.Parameters.AddWithValue("@date", action.Date);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<User> FindUser(string username, string password)
        {
            password = StringManager.GetHashSha256(password);

            try
            {
                using (connection = new NpgsqlConnection(GetConnectionString()))
                {
                    await Connect();

                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT id_user, login, pass, name, surname, id_role FROM users WHERE login = @login AND pass = @pass";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@login", username);
                        command.Parameters.AddWithValue("@pass", password);

                        using (var dataReader = await command.ExecuteReaderAsync())
                        {
                            if (dataReader.Read())
                            {
                                User user = new User();
                                user.UserId = Convert.ToInt32(dataReader["ID_USER"]);
                                user.Login = Convert.ToString(dataReader["LOGIN"]);
                                user.Password = Convert.ToString(dataReader["PASS"]);
                                user.Name = Convert.ToString(dataReader["NAME"]);
                                user.Surname = Convert.ToString(dataReader["SURNAME"]);
                                user.UserRole = (Role) Convert.ToInt32(dataReader["ID_ROLE"]);
                                return user;
                            }

                            return null;
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<IList<Project>> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            try
            {
                using (connection = new NpgsqlConnection(GetConnectionString()))
                {
                    await Connect();

                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT id_project, name, id_supervisor, info FROM projects";

                        using (var dataReader = await command.ExecuteReaderAsync())
                        {
                            while (dataReader.Read())
                            {
                                Project project = new Project();
                                project.ProjectId = Convert.ToInt32(dataReader["ID_PROJECT"]);
                                project.Name = Convert.ToString(dataReader["NAME"]);
                                project.SupervisorId = Convert.ToInt32(dataReader["ID_SUPERVISOR"]);
                                project.Info = Convert.ToString(dataReader["INFO"]);

                                projects.Add(project);
                            }
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return projects;
        }

        public async Task<IList<Project>> FindUserProjects(User user)
        {
            List<Project> projects = new List<Project>();
            try
            {
                using (connection = new NpgsqlConnection(GetConnectionString()))
                {
                    await Connect();

                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT p.id_project, name, id_supervisor, info FROM projects p, projects_users pu WHERE p.id_project = pu.id_project AND pu.id_user = @id_user";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id_user", user.UserId);                       

                        using (var dataReader = await command.ExecuteReaderAsync())
                        {
                            while (dataReader.Read())
                            {
                                Project project = new Project();
                                project.ProjectId = Convert.ToInt32(dataReader["ID_PROJECT"]);
                                project.Name = Convert.ToString(dataReader["NAME"]);
                                project.SupervisorId = Convert.ToInt32(dataReader["ID_SUPERVISOR"]);
                                project.Info = Convert.ToString(dataReader["INFO"]);

                                projects.Add(project);
                            }
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return projects;
        }

        public async Task<IList<Project>> FindSupervisedProjects(User user)
        {
            List<Project> projects = new List<Project>();
            try
            {
                using (connection = new NpgsqlConnection(GetConnectionString()))
                {
                    await Connect();

                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT id_project, name, id_supervisor, info FROM projects WHERE id_supervisor = @id_user";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id_user", user.UserId);

                        using (var dataReader = await command.ExecuteReaderAsync())
                        {
                            while (dataReader.Read())
                            {
                                Project project = new Project();
                                project.ProjectId = Convert.ToInt32(dataReader["ID_PROJECT"]);
                                project.Name = Convert.ToString(dataReader["NAME"]);
                                project.SupervisorId = Convert.ToInt32(dataReader["ID_SUPERVISOR"]);
                                project.Info = Convert.ToString(dataReader["INFO"]);

                                projects.Add(project);
                            }
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return projects;
        }

        public async Task<IList<User>> FindProjectUsers(Project project)
        {
            List<User> users = new List<User>();
            try
            {
                using (connection = new NpgsqlConnection(GetConnectionString()))
                {
                    await Connect();

                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT u.id_user, login, pass, name, surname, id_role FROM users u, projects_users pu WHERE pu.id_user = u.id_user AND id_project = @id_project";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id_project", project.ProjectId);

                        using (var dataReader = await command.ExecuteReaderAsync())
                        {
                            while (dataReader.Read())
                            {
                                User user = new User();
                                user.UserId = Convert.ToInt32(dataReader["ID_USER"]);
                                user.Login = Convert.ToString(dataReader["LOGIN"]);
                                user.Password = Convert.ToString(dataReader["PASS"]);
                                user.Name = Convert.ToString(dataReader["NAME"]);
                                user.Surname = Convert.ToString(dataReader["SURNAME"]);
                                user.UserRole = (Role)Convert.ToInt32(dataReader["ID_ROLE"]);

                                users.Add(user);
                            }
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return users;
        }
    }
}
