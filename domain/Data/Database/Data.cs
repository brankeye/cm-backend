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
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public string Username { get; set; }

            [Required]
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [Required]
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

            [Required]
            [DataMember]
            public DateTime Date { get; set; }

            [Required]
            [DataMember]
            public int ClassId { get; set; }

            [ForeignKey(nameof(ClassId))]
            [Required]
            [DataMember]
            public Class Class { get; set; }

            [Required]
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [Required]
            [DataMember]
            public Profile Profile { get; set; }
        }

        [DataContract]
        public class CanceledClass : IEntity
        {
            [Key]
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public DateTime Date { get; set; }

            [Required]
            [DataMember]
            public int ClassId { get; set; }

            [Required]
            [ForeignKey(nameof(ClassId))]
            [DataMember]
            public Class Class { get; set; }
        }

        [DataContract]
        public class Class : IEntity
        {
            [Key]
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public string Name { get; set; }

            [Required]
            [DataMember]
            public string Day { get; set; }

            [Required]
            [DataMember]
            public DateTime StartTime { get; set; }

            [Required]
            [DataMember]
            public DateTime EndTime { get; set; }

            [Required]
            [DataMember]
            public int SchoolId { get; set; }

            [ForeignKey(nameof(SchoolId))]
            [Required]
            [DataMember]
            public School School { get; set; }
        }

        [DataContract]
        public class Evaluation : IEntity
        {
            [Key]
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public string Name { get; set; }

            [Required]
            [DataMember]
            public DateTime Date { get; set; }

            [Required]
            [DataMember]
            public DateTime Time { get; set; }

            [Required]
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [Required]
            [DataMember]
            public Profile Profile { get; set; }
        }

        [DataContract]
        public class EvaluationSection : IEntity
        {
            [Key]
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public string Name { get; set; }

            [Required]
            [DataMember]
            public string Body { get; set; }

            [Required]
            [DataMember]
            public float Score { get; set; }

            [Required]
            [DataMember]
            public int EvaluationId { get; set; }

            [ForeignKey(nameof(EvaluationId))]
            [Required]
            [DataMember]
            public Evaluation Evaluation { get; set; }
        }

        [DataContract]
        public class Profile : IEntity
        {
            [Key]
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public string FirstName { get; set; }

            [Required]
            [DataMember]
            public string LastName { get; set; }

            [Required]
            [DataMember]
            public string Email { get; set; }

            [Required]
            [DataMember]
            public string PhoneNumber { get; set; }

            [Required]
            [DataMember]
            public DateTime StartDate { get; set; }

            [Required]
            [DataMember]
            public string Level { get; set; }

            [Required]
            [DataMember]
            public bool IsTeacher { get; set; }
        }

        [DataContract]
        public class Member : IEntity
        {
            [Key]
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public int ProfileId { get; set; }

            [ForeignKey(nameof(ProfileId))]
            [Required]
            [DataMember]
            public Profile Profile { get; set; }

            [Required]
            [DataMember]
            public int SchoolId { get; set; }

            [ForeignKey(nameof(SchoolId))]
            [Required]
            [DataMember]
            public School School { get; set; }
        }

        [DataContract]
        public class School : IEntity
        {
            [Key]
            [Required]
            [DataMember]
            public int Id { get; set; }

            [Required]
            [DataMember]
            public string Name { get; set; }

            [Required]
            [DataMember]
            public string Address { get; set; }

            [Required]
            [DataMember]
            public string Email { get; set; }

            [Required]
            [DataMember]
            public string Website { get; set; }

            [Required]
            [DataMember]
            public string PhoneNumber { get; set; }
        }
    }
}
