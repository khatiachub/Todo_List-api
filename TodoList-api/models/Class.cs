using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TodoList_api.models
{
    public class Class
    {
        [Key]
        public int ID { get; set; }
        [Required]


        public string TaskName { get; set; }
        [Required]
        public string TaskStatus { get; set; }

    }

};
