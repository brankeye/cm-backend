using System.ComponentModel.DataAnnotations;
using cm.backend.domain.Data.Interfaces;
using System.Runtime.Serialization;

namespace cm.backend.domain.Data.Database
{
    public class Data
    {
        [DataContract]
        public class Club : IEntity
        {
            [Key]
            [DataMember]
            public int Id { get; set; }

            [DataMember]
            public string Name { get; set; }
        }
    }
}
