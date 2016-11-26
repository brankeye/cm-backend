using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using cm.backend.domain.Data.Interfaces;
using System.Runtime.Serialization;

namespace cm.backend.domain.Data.Database
{
    public class Data
    {
        [DataContract]
        public class User : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public string Username { get; set; }
            
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [DataMember]
            public Profile Profile { get; set; }
        }

        [DataContract]
        public class AttendanceRecord : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public bool IsAttending { get; set; }
            
            [DataMember]
            public DateTimeOffset Date { get; set; }
            
            [DataMember]
            public int ClassId { get; set; }

            [ForeignKey(nameof(ClassId))]
            [DataMember]
            public Class Class { get; set; }
            
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [DataMember]
            public Profile Profile { get; set; }
        }

        [DataContract]
        public class CanceledClass : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public DateTimeOffset Date { get; set; }
            
            [DataMember]
            public int ClassId { get; set; }
            
            [ForeignKey(nameof(ClassId))]
            [DataMember]
            public Class Class { get; set; }
        }

        [DataContract]
        public class Class : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public string Name { get; set; }
            
            [DataMember]
            public string Day { get; set; }
            
            [DataMember]
            public DateTimeOffset StartTime { get; set; }
            
            [DataMember]
            public DateTimeOffset EndTime { get; set; }
            
            [DataMember]
            public int SchoolId { get; set; }

            [ForeignKey(nameof(SchoolId))]
            [DataMember]
            public School School { get; set; }
        }

        [DataContract]
        public class Evaluation : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public string Name { get; set; }
            
            [DataMember]
            public DateTimeOffset Date { get; set; }
            
            [DataMember]
            public DateTimeOffset Time { get; set; }
            
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [DataMember]
            public Profile Profile { get; set; }
        }

        [DataContract]
        public class EvaluationSection : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public string Name { get; set; }
            
            [DataMember]
            public string Body { get; set; }
            
            [DataMember]
            public float Score { get; set; }
            
            [DataMember]
            public int EvaluationId { get; set; }

            [ForeignKey(nameof(EvaluationId))]
            [DataMember]
            public Evaluation Evaluation { get; set; }
        }

        [DataContract]
        public class Profile : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public string FirstName { get; set; }
            
            [DataMember]
            public string LastName { get; set; }
            
            [DataMember]
            public string Email { get; set; }
            
            [DataMember]
            public string PhoneNumber { get; set; }
            
            [DataMember]
            public DateTimeOffset StartDate { get; set; }
            
            [DataMember]
            public string Level { get; set; }
        }

        [DataContract]
        public class Member : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [DataMember]
            public Profile Profile { get; set; }
            
            [DataMember]
            public int SchoolId { get; set; }

            [ForeignKey(nameof(SchoolId))]
            [DataMember]
            public School School { get; set; }

            [DataMember]
            public bool IsTeacher { get; set; }
        }

        [DataContract]
        public class School : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }
            
            [DataMember]
            public string Name { get; set; }
            
            [DataMember]
            public string Address { get; set; }
            
            [DataMember]
            public string Email { get; set; }
            
            [DataMember]
            public string Website { get; set; }
            
            [DataMember]
            public string PhoneNumber { get; set; }
        }
    }
}
