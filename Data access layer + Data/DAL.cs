﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STudentInternshipApplication.Data_access_layer___Data
{
    class DAL
    {


        private SqlConnection _connection;
        private const string ConnectionString = @"Server=(LocalDB)\v11.0;AttachDbFilename=""E:\ConstructionSemester2\STudentInternshipApplication\STudentInternshipApplication\Data access layer + Data\Data.mdf"";Integrated Security=True;";

        public void Connect()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        private void Disconnect()
        {
            _connection.Close();
        }

        public void AddStudent(Student.Student student)
        {
            Connect();
            var command = new SqlCommand()
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO StudentDataTable VALUES (@Cpr, @Name, @Age, @Address, @MobilePhone)"
            };
            command.Parameters.Add(new SqlParameter("Cpr", student.Cpr));
            command.Parameters.Add(new SqlParameter("Name", student.Name));
            command.Parameters.Add(new SqlParameter("Age", student.Age));
            command.Parameters.Add(new SqlParameter("Address", student.Address));    
            command.Parameters.Add(new SqlParameter("MobilePhone", student.MobilePhone));
            command.ExecuteNonQuery();
            MessageBox.Show("Student added.");
            Disconnect();
        }

        public void EditStudent(Student.Student student)
        {
            Connect();
            var command = new SqlCommand()
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "UPDATE StudentTable SET Cpr = @Cpr, Name = @Name, Age = @Age, Address = @Address, MobilePhone = @MobilePhone"
            };
            command.Parameters.Add(new SqlParameter("Cpr", student.Cpr));
            command.Parameters.Add(new SqlParameter("Name", student.Name));
            command.Parameters.Add(new SqlParameter("Age", student.Age));
            command.Parameters.Add(new SqlParameter("Address", student.Address));
            command.Parameters.Add(new SqlParameter("MobilePhone", student.MobilePhone));
            command.ExecuteNonQuery();
            Disconnect();
        }

        public void RemoveStudent(Student.Student student)
        {
            Connect();
            var command = new SqlCommand()
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM StudentTable WHERE Cpr = @Cpr"
            };
            command.Parameters.Add(new SqlParameter("Cpr", student.Cpr));
            command.ExecuteNonQuery();
            Disconnect();
        }
       


        public ObservableCollection<Student.Student> GetStudents()
        {
            Connect();
            var command = new SqlCommand
            {
                Connection = _connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM StudentTable"
            };
            var reader = command.ExecuteReader();
            var collection = new ObservableCollection<Student.Student>();
            while (reader.Read())
            {
                var student = new Student.Student
                {
                    Cpr = (int)reader[0],
                    Name = (string)reader[1],
                    Age = (int)reader[2],
                    Address = (string)reader[3],
                    MobilePhone = (int)reader[4]
                };
                collection.Add(student);
            }
            Disconnect();
            return collection;
        }
    }
}
