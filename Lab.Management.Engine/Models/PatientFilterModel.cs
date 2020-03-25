using Lab.Management.Engine.Enum;

namespace Lab.Management.Engine.Models
{
    public  class PatientFilterModel
    {
        public string Text { get; set; }
        public QueryFilterAttribute Value { get; set; }
    }
}
