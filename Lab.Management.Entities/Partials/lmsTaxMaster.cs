namespace Lab.Management.Entities
{
    public partial class lmsTaxMaster
    {
        public bool isActiveTaxVal { get; set; }
        public bool IsActiveTax
        {
            get
            {
                if (ISACTIVE.HasValue)
                {
                    isActiveTaxVal = ISACTIVE.Value;
                }
                return isActiveTaxVal;
            }
            set
            {
                isActiveTaxVal = value;
            }
        }
    }
}
