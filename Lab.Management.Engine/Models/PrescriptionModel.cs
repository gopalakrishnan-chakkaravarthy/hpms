namespace Lab.Management.Engine.Models
{
    public class PrescriptionModel
    {
        public int PRESCID { get; set; }

        public int BOOKINGID { get; set; }

        public int PATIENTID { get; set; }

        public int DRUGID { get; set; }

        public int MEDICINECOUNT { get; set; }

        public string STRENGTH { get; set; }

        public int DOSAGEID { get; set; }

        public int FREQUENCYID { get; set; }

        public string INSTRUCTIONS { get; set; }
    }
}
